#include "stdafx.h"
#include <iostream>
#include "Error.h"
#include "Parm.h"
#include "Log.h"
#include "In.h"
#include <cwchar>
#include <time.h>
#include "Out.h"

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
    setlocale(LC_ALL, "russian");

    cout << "---- тест getparm ----" << endl;
    try
    {
        Parm::PARM parm = Parm::getparm(argc, argv);
        wcout << "-in:" << parm.in << ", -out:" << parm.out << ", -log:" << parm.log << endl << endl;
    }
    catch (Error::ERROR e)
    {
        cout << "ID: " << e.id << " Сообщение: " << e.message << " Строка: " << e.inext.line << " Позиция:" << e.inext.col << endl;
    }

    cout << "---- тест getin----" << endl;
    try
    {
        Parm::PARM parm = Parm::getparm(argc, argv);
        In::IN in = In::getin(parm.in);
        cout << in.text << endl;
        cout << "Всего символов: " << in.size << endl;
        cout << "Всего строк: " << in.lines << endl;
        cout << "Пропущено: " << in.ignor << endl;
    }
    catch (Error::ERROR e)
    {
        cout << "ID: " << e.id << " Сообщение: " << e.message << " Строка: " << e.inext.line << " Позиция:" << e.inext.col << endl;
    }
    /*cout << "-------------------------------------------------------------------------" << endl;*/
   
    cout << "---- тест getlog----" << endl;
    Log::LOG log = Log::INITLOG;
    Parm::PARM parm = Parm::getparm(argc, argv);
    try
    {
        log = Log::getlog(parm.log);
        Log::WriteLine(log, (char*)"Тест", (char*)" без ошибок \n", "");
        Log::WriteLine(log, (wchar_t*)L"Тест", (wchar_t*)L" без ошибок \n", L"");
        Log::WriteLog(log);
        Log::WriteParm(log, parm);
        In::IN in = In::getin(parm.in);
        Log::WriteIn(log, in);

 
        Out::OUT out = Out::getout(parm.out);
        Out::WriteOut(out, in);
        Out::Close(out);

        Log::Close(log);
    }
    catch (Error::ERROR e)
    {
        Log::WriteError(log, e);
        Out::OUT out = Out::getout(parm.out);
        Out::WriteError(out, e);
        Out::Close(out);
    }

    system("pause");

    return 0;
}
