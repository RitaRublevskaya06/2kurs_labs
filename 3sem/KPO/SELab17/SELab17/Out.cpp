#include "stdafx.h"
using namespace std;

namespace Out
{
    // Функция для получения объекта записи в файл
    OUT getout(wchar_t outfile[])
    {
        OUT temp; // Временная структура для хранения информации о выходном файле
        // Создаем буфер для имени файла в формате char
        char* outFile = new char[wcslen(outfile) + 1];
        // Преобразуем имя файла из wchar_t в char
        wcstombs_s(NULL, outFile, wcslen(outfile) + 1, outfile, wcslen(outfile) + 1);

        temp.stream = new std::ofstream; // Создаем поток для записи в файл
        temp.stream->open(outFile); // Открываем файл для записи

        // Проверка на ошибки открытия файла
        if (!temp.stream->is_open())
        {
            ERROR_THROW(113); // Ошибка открытия выходного файла
        }

        // Копируем имя файла в структуру выходного файла
        wcscpy_s(temp.outfile, outfile);
        return temp; // Возвращаем объект выходного файла
    };

    // Функция для записи данных из структуры In в файл
    void WriteOut(In::IN in, wchar_t out[])
    {
        std::ofstream fout(out); // Создаем поток для записи в указанный файл

        // Проходим по всем строкам в структуре In
        for (int i = 0; i < in.text.size(); i++)
        {
            fout << in.text[i]; // Записываем каждую строку в файл
        }
    };

    // Функция для записи информации об ошибке в выходной файл
    void WriteError(OUT out, Error::ERROR error)
    {
        // Записываем все элементы из MyVector (содержимое ошибки)
        for (int i = 0; i < error.inext.MyVector.size(); i++)
        {
            *out.stream << error.inext.MyVector[i]; // Записываем каждый элемент
        }

        *out.stream << endl; // Переход на новую строку
        // Записываем код и сообщение об ошибке
        *out.stream << "Ошибка " << error.id << ": " << error.message << endl << endl;
        // Записываем строку и позицию, где произошла ошибка
        *out.stream << "строка: " << error.inext.line << " позиция: " << error.inext.col << endl << endl;

        // Если информация о строке и позиции ошибки валидна
        if (error.inext.line != -1 && error.inext.col != -1)
        {
            // Записываем ошибку с контекстом
            *out.stream << "Ошибка в строке: " << error.inext.buff << endl << endl;
        }
    }

    // Функция для закрытия потока записи в файл
    void Close(OUT out)
    {
        out.stream->close(); // Закрываем поток
    }
}
