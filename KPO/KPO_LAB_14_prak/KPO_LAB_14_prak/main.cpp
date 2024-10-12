#include "stdafx.h"
#include <iostream>
#include "Error.h"
#include "Parm.h"
#include "In.h"
#include "Log.h"
#include <cwchar>
#include <time.h>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
    setlocale(LC_ALL, "russian");


    cout << "---- тест Parm::getparm ----" << endl;
    try
    {
        Parm::PARM parm = Parm::getparm(argc, argv);
        wcout << "-in: " << parm.in << ", -out: " << parm.out << ", -log: " << parm.log << endl;
    }
    catch (Error::ERROR e)
    {
        cout << "Ошибка " << e.id << ": " << e.message << endl;
    }


    cout << "---- тест In::getin ----" << endl;
    try
    {
        Parm::PARM parm = Parm::getparm(argc, argv);
        In::IN in = In::getin(parm.in);
        cout << in.text << endl;
        cout << "Всего символов: " << in.size << endl;
        cout << "Всего строк: " << in.lines << endl;
        cout << "Пропущено: " << in.ignor << endl;
    }
    catch (Error::ERROR e) {
        cout << "Ошибка " << e.id << ": " << e.message << endl;
        cout << "Строка " << e.inext.line << " позиция " << e.inext.col << endl;
    }



    cout << "---- тест Log::getlog ----" << endl;
     Log::LOG log = Log::INITLOG;
    try
    {
        Parm::PARM parm = Parm::getparm(argc, argv);
        log = Log::getlog(parm.log);
        Log::WriteLine(log, (char*)"Тест", (char*)" без ошибок \n", "");
        Log::WriteLine(log, (wchar_t*)L"Тест", (wchar_t*)L" без ошибок \n", "");
        Log::WriteLog(log);
        Log::WriteParm(log, parm);
        In::IN in = In::getin(parm.in);
        Log::WriteIn(log, in);
        Log::Close(log);
    }
    catch (Error::ERROR e)
    {
        Log::WriteError(log, e);
    }



    system("pause");
    return 0;
}
