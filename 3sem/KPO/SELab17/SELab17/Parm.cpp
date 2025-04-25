#include "stdafx.h"
#include "Parm.h"
#include "Error.h"

namespace Parm
{
    // Функция для получения параметров командной строки
    PARM getparm(int argc, wchar_t* argv[])
    {
        PARM result; // Структура для хранения параметров
        bool isOut = false, isLog = false; // Флаги для проверки наличия параметров вывода и лога

        // Проверка на количество аргументов
        if (argc < 2) { throw ERROR_THROW(100); } // Если аргументов меньше двух, выбрасываем ошибку

        // Проходим по всем аргументам командной строки
        for (int i = 0; i < argc; i++)
        {
            /* Функция wcsstr используется для поиска первого вхождения одной широкой подстроки
               в другой широкой строке. Возвращает указатель на начало найденной подстроки
               или nullptr, если подстрока не найдена. */

               // Проверка на превышение максимальной длины строки
            if (wcslen(argv[i]) > PARM_MAX_SIZE + 3)
            {
                throw ERROR_THROW(104); // Выбрасываем ошибку, если длина превышает допустимую
            }

            // Проверка на наличие входного параметра
            if (wcsstr(argv[i], PARM_IN) != nullptr)
            {
                /* Функция wcscpy_s используется для безопасного копирования содержимого одной широкой строки
                   в другую. Прототип: errno_t wcscpy_s(wchar_t* dest, size_t destSize, const wchar_t* src);
                   Параметры:
                   dest: Указатель на целевую строку.
                   destSize: Максимальный размер dest в символах.
                   src: Указатель на строку-источник. */
                wcscpy_s(result.in, argv[i] + wcslen(PARM_IN)); // Копируем значение параметра -in
            }

            // Проверка на наличие выходного параметра
            if (wcsstr(argv[i], PARM_OUT) != nullptr)
            {
                isOut = true; // Устанавливаем флаг, что параметр -out найден
                wcscpy_s(result.out, argv[i] + wcslen(PARM_OUT)); // Копируем значение параметра -out
            }

            // Проверка на наличие параметра лога
            if (wcsstr(argv[i], PARM_LOG) != nullptr)
            {
                isLog = true; // Устанавливаем флаг, что параметр -log найден
                wcscpy_s(result.log, argv[i] + wcslen(PARM_LOG)); // Копируем значение параметра -log
            }
        }

        // Если параметр -out не был указан, создаем имя выходного файла по умолчанию
        if (!isOut)
        {
            wcscpy_s(result.out, result.in); // Копируем имя входного файла в выходное
            wcscat_s(result.out, PARM_OUT_DEFAULT_EXT); // Добавляем стандартное расширение
        }

        // Если параметр -log не был указан, создаем имя файла лога по умолчанию
        if (!isLog)
        {
            wcscpy_s(result.log, result.in); // Копируем имя входного файла в лог-файл
            wcscat_s(result.log, PARM_LOG_DEFAULT_EXT); // Добавляем стандартное расширение для лога
        }

        return result; // Возвращаем структуру с параметрами
    }
}
