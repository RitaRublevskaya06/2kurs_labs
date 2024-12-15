#include "stdafx.h"
#include "Log.h"
#include <iostream>
#include <ctime>

namespace Log
{
    // Функция для получения объекта логирования из файла
    LOG getlog(wchar_t logfile[])
    {
        LOG temp; // Временная структура для хранения информации о логе
        // Создаем буфер для имени файла в формате char
        char* outFile = new char[wcslen(logfile) + 1];
        // Преобразуем имя файла из wchar_t в char
        wcstombs_s(NULL, outFile, wcslen(logfile) + 1, logfile, wcslen(logfile) + 1);
        temp.stream = new std::ofstream; // Создаем поток для записи в файл
        temp.stream->open(outFile); // Открываем файл для записи
        // Проверка на ошибки открытия файла
        if (!temp.stream->is_open())
        {
            ERROR_THROW(112); // Ошибка открытия файла
        }
        // Копируем имя файла в структуру логирования
        wcscpy_s(temp.logfile, logfile);
        return temp; // Возвращаем объект логирования
    };

    // Функция для записи строки в лог (с использованием символов типа char)
    void WriteLine(LOG log, char* c, ...)
    {
        char** p = &c; // Указатель на первый элемент аргумента

        // Записываем все переданные строки в лог
        while (*p != "")
        {
            (*log.stream) << *p; // Записываем текущую строку
            p += 1; // Переходим к следующему аргументу
        }
    };

    // Функция для записи строки в лог (с использованием символов типа wchar_t)
    void WriteLine(LOG log, wchar_t* c, ...)
    {
        wchar_t** p = &c; // Указатель на первый элемент аргумента
        char buffer[50]; // Буфер для преобразования символов

        // Записываем все переданные строки в лог
        while (*p != L"")
        {
            wcstombs(buffer, *p, sizeof(buffer)); // Преобразуем строку в char
            (*log.stream) << buffer; // Записываем в лог
            p += 1; // Переходим к следующему аргументу
        }
    };

    // Функция для записи временной метки в лог
    void WriteLog(LOG log)
    {
        char buffer[PARM_MAX_SIZE]; // Буфер для хранения временной метки

        time_t rawtime; // Переменная для хранения времени
        struct tm* timeinfo; // Структура для хранения информации о времени

        time(&rawtime); // Получаем текущее время
        timeinfo = localtime(&rawtime); // Преобразуем в локальное время

        // Форматируем временную метку
        strftime(buffer, PARM_MAX_SIZE, "%d.%m.%Y %H:%M:%S", timeinfo);
        // Записываем заголовок лога с временной меткой
        (*log.stream) << "\n--— Протокол —— \n" << buffer << " —— \n";
    };

    // Функция для записи параметров в лог
    void WriteParm(LOG log, Parm::PARM parm)
    {
        char inInfo[PARM_MAX_SIZE]; // Буфер для входных параметров
        char outInfo[PARM_MAX_SIZE]; // Буфер для выходных параметров
        char logInfo[PARM_MAX_SIZE]; // Буфер для информации о логе

        // Преобразуем входные параметры из wchar_t в char
        wcstombs(inInfo, parm.in, sizeof(inInfo));
        wcstombs(outInfo, parm.out, sizeof(outInfo));
        wcstombs(logInfo, parm.log, sizeof(logInfo));

        // Записываем параметры в лог
        (*log.stream) << "--— Аргументы —— \n"
            << " -in: " << inInfo << "\n"
            << " -out: " << outInfo << "\n"
            << " -log: " << logInfo << "\n";
    };

    // Функция для записи информации о вводе в лог
    void WriteIn(LOG log, In::IN in)
    {
        // Записываем количество символов, строк и пропущенных символов в лог
        (*log.stream) << "--— Параметры —— \n"
            << "Количество символов: " << in.size << "\n"
            << "Строк: " << in.lines << "\n"
            << "Пропущено: " << in.ignor << "\n";
        // Добавляем информацию об удалённых пробелах
        (*log.stream) << "Удалено пробелов: " << in.spaces << "\n";

    };

    // Функция для записи информации об ошибке в лог
    void WriteError(LOG log, Error::ERROR error)
    {
        // Если имеется информация о строке, где произошла ошибка
        if (error.inext.line != -1)
        {
            *log.stream << "Ошибка в строке:\t" << error.inext.buff << std::endl; // Записываем содержимое строки
            *log.stream << "Строка: " << error.inext.line << " Позиция: " << error.inext.col << std::endl; // Записываем номер строки и позицию
        }
        *log.stream << "Ошибка: " << error.id << ":" << error.message << std::endl; // Записываем код и сообщение об ошибке
    }

    // Функция для закрытия потока логирования
    void Close(LOG log)
    {
        log.stream->close(); // Закрываем поток
    }
};



//#include "stdafx.h"
//#include "Log.h"
//#include <iostream>
//#include <ctime>
//
//namespace Log
//{
//    // Функция для получения объекта логирования из файла
//    LOG getlog(wchar_t logfile[])
//    {
//        LOG temp; // Временная структура для хранения информации о логе
//        // Создаем буфер для имени файла в формате char
//        char* outFile = new char[wcslen(logfile) + 1];
//        // Преобразуем имя файла из wchar_t в char
//        wcstombs_s(NULL, outFile, wcslen(logfile) + 1, logfile, wcslen(logfile) + 1);
//        temp.stream = new std::ofstream; // Создаем поток для записи в файл
//        temp.stream->open(outFile); // Открываем файл для записи
//        // Проверка на ошибки открытия файла
//        if (!temp.stream->is_open())
//        {
//            ERROR_THROW(112); // Ошибка открытия файла
//        }
//        // Копируем имя файла в структуру логирования
//        wcscpy_s(temp.logfile, logfile);
//        return temp; // Возвращаем объект логирования
//    };
//
//    // Функция для записи строки в лог (с использованием символов типа char)
//    void WriteLine(LOG log, char* c, ...)
//    {
//        char** p = &c; // Указатель на первый элемент аргумента
//
//        // Записываем все переданные строки в лог
//        while (*p != "")
//        {
//            (*log.stream) << *p; // Записываем текущую строку
//            p += 1; // Переходим к следующему аргументу
//        }
//    };
//
//    // Функция для записи строки в лог (с использованием символов типа wchar_t)
//    void WriteLine(LOG log, wchar_t* c, ...)
//    {
//        wchar_t** p = &c; // Указатель на первый элемент аргумента
//        char buffer[50]; // Буфер для преобразования символов
//
//        // Записываем все переданные строки в лог
//        while (*p != L"")
//        {
//            wcstombs(buffer, *p, sizeof(buffer)); // Преобразуем строку в char
//            (*log.stream) << buffer; // Записываем в лог
//            p += 1; // Переходим к следующему аргументу
//        }
//    };
//
//    // Функция для записи временной метки в лог
//    void WriteLog(LOG log)
//    {
//        char buffer[PARM_MAX_SIZE]; // Буфер для хранения временной метки
//
//        time_t rawtime; // Переменная для хранения времени
//        struct tm* timeinfo; // Структура для хранения информации о времени
//
//        time(&rawtime); // Получаем текущее время
//        timeinfo = localtime(&rawtime); // Преобразуем в локальное время
//
//        // Форматируем временную метку
//        strftime(buffer, PARM_MAX_SIZE, "%d.%m.%Y %H:%M:%S", timeinfo);
//        // Записываем заголовок лога с временной меткой
//        (*log.stream) << "\n--— Протокол —— \n" << buffer << " —— \n";
//    };
//
//    // Функция для записи параметров в лог
//    void WriteParm(LOG log, Parm::PARM parm)
//    {
//        char inInfo[PARM_MAX_SIZE]; // Буфер для входных параметров
//        char outInfo[PARM_MAX_SIZE]; // Буфер для выходных параметров
//        char logInfo[PARM_MAX_SIZE]; // Буфер для информации о логе
//
//        // Преобразуем входные параметры из wchar_t в char
//        wcstombs(inInfo, parm.in, sizeof(inInfo));
//        wcstombs(outInfo, parm.out, sizeof(outInfo));
//        wcstombs(logInfo, parm.log, sizeof(logInfo));
//
//        // Записываем параметры в лог
//        (*log.stream) << "--— Аргументы —— \n"
//            << " -in: " << inInfo << "\n"
//            << " -out: " << outInfo << "\n"
//            << " -log: " << logInfo << "\n";
//    };
//
//    // Функция для записи информации о вводе в лог
//    void WriteIn(LOG log, In::IN in)
//    {
//        // Записываем количество символов, строк и пропущенных символов в лог
//        (*log.stream) << "--— Параметры —— \n"
//            << "Количество символов: " << in.size << "\n"
//            << "Строк: " << in.lines << "\n"
//            << "Пропущено: " << in.ignor << "\n";
//    };
//
//    // Функция для записи информации об ошибке в лог
//    void WriteError(LOG log, Error::ERROR error)
//    {
//        // Если имеется информация о строке, где произошла ошибка
//        if (error.inext.line != -1)
//        {
//            *log.stream << "Ошибка в строке:\t" << error.inext.buff << std::endl; // Записываем содержимое строки
//            *log.stream << "Строка: " << error.inext.line << " Позиция: " << error.inext.col << std::endl; // Записываем номер строки и позицию
//        }
//        *log.stream << "Ошибка: " << error.id << ":" << error.message << std::endl; // Записываем код и сообщение об ошибке
//    }
//
//    // Функция для закрытия потока логирования
//    void Close(LOG log)
//    {
//        log.stream->close(); // Закрываем поток
//    }
//};
