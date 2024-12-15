#include "stdafx.h" // Заголовочный файл для предкомпилированных заголовков
#include <iostream> // Подключаем библиотеку для ввода-вывода
#include "Error.h"  // Заголовок для обработки ошибок
#include "Parm.h"   // Заголовок для работы с параметрами
#include <cwchar>   // Библиотека для работы с широкими символами
#include <time.h>   // Библиотека для работы с временем
using namespace std; // Используем стандартное пространство имен


int _tmain(int argc, _TCHAR* argv[])
{
    setlocale(LC_ALL, ".1251"); // Устанавливаем локаль для корректного отображения символов
    Out::OUT out = Out::INITOUT; // Инициализация объекта для записи в выходной файл
    Log::LOG log = Log::INITLOG; // Инициализация объекта для логирования
    In::IN in; // Объявляем переменную для хранения входных данных

    try
    {
        // Получаем параметры из командной строки
        Parm::PARM parm = Parm::getparm(argc, argv);

        // Открываем лог-файл
        log = Log::getlog(parm.log);

        // Записываем текст в лог (как в char, так и в wchar_t)
        Log::WriteLine(log, (char*)"Текст: ", (char*)"без ошибки \n", "");
        Log::WriteLine(log, (wchar_t*)L"Текст", (wchar_t*)L" без ошибок \n", L"");

        // Открываем выходной файл
        out = Out::getout(parm.out);

        // Записываем параметры в лог
        Log::WriteParm(log, parm);

        // Записываем текущую дату и время в лог
        Log::WriteLog(log);

        // Получаем входные данные из файла
        in = In::getin(parm.in);

        // Записываем информацию о входных данных в лог
        Log::WriteIn(log, in);

        // Записываем данные из структуры in в выходной файл
        Out::WriteOut(in, parm.out);

        // Выводим весь текст на консоль
        for (size_t i = 0; i < in.text.size(); i++)
        {
            cout << in.text[i] << endl; // Печатаем каждую строку
        }

        // Выводим статистику по входным данным
        cout << "Всего символов: " << in.size << endl;
        cout << "Всего строк: " << in.lines << endl;


    }
    // Обработка ошибок
    catch (Error::ERROR e)
    {
        // Выводим информацию об ошибке
        cout << "Ошибка " << e.id << ": " << e.message << endl << endl;
        cout << "строка: " << e.inext.line << " позиция: " << e.inext.col << endl << endl;

        // Записываем информацию об ошибке в лог и выходной файл
        Log::WriteError(log, e);
        Out::WriteError(out, e);

        // Если указана строка и позиция ошибки, выводим её контекст
        if (e.inext.line != -1 && e.inext.col != -1)
        {
            cout << "Ошибка в строке: " << e.inext.buff << endl << endl;
        }
    }

    return 0; // Завершаем выполнение программы
}
