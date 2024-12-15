#pragma once // Защита от многократного включения данного заголовка

#include "stdafx.h" // Включение предварительно скомпилированного заголовка

namespace Out
{
    // Структура для работы с выходными данными
    struct OUT
    {
        wchar_t outfile[PARM_MAX_SIZE]; // Имя выходного файла в широких символах
        std::ofstream* stream; // Указатель на поток вывода для записи в файл
    };

    // Инициализация структуры OUT с пустым именем файла и нулевым указателем на поток
    static const OUT INITOUT{ L"", NULL };

    // Функция для открытия выходного файла
    OUT getout(wchar_t outfile[]);

    // Функция для записи содержимого структуры In в выходной файл
    void WriteOut(In::IN in, wchar_t out[]);

    // Функция для записи информации об ошибке в выходной файл
    void WriteError(OUT out, Error::ERROR error);

    // Функция для закрытия выходного файла
    void Close(OUT out);
};
