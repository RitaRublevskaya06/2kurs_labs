#include "stdafx.h"
using namespace std;

namespace In
{ 
    // Функция для удаления лишних пробелов из строки
    void removeExtraSpaces(std::string& input, int& spaces) // Удаляем лишние пробелы из текущей строки.
    {
        bool insideQuotes = false; // Переменная для отслеживания, находимся ли мы внутри кавычек
        bool firstLine = true; // Флаг для отслеживания первой строки

        // Проходим по каждому символу в строке
        for (size_t i = 0; i < input.length(); ++i)
        {
            // Проверяем, не встретили ли мы кавычку
            if (input[i] == '\'')
            {
                insideQuotes = !insideQuotes; // Меняем состояние внутри кавычек
            }
            // Если мы не внутри кавычек и встретили пробел
            if (!insideQuotes && input[i] == ' ')
            {
                size_t spacesToRemove = 0; // Счетчик для последовательных пробелов
                // Подсчет количества последовательных пробелов после текущего символа
                while (i + spacesToRemove < input.length() && input[i + spacesToRemove] == ' ')
                {
                    ++spacesToRemove;
                }
                // Если найдено более одного пробела, удаляем их
                if (spacesToRemove > 1)
                {
                    input.erase(i + 0, spacesToRemove - 1);
                    spaces += spacesToRemove - 1; // Увеличиваем счетчик удаленных пробелов
                    //input.erase(i + 1, spacesToRemove - 1);
                    //spaces += spacesToRemove - 1; // Увеличиваем счетчик удаленных пробелов
                }
                // Удаляем пробел, если он на начале или конце строки
                if (i == 0 || i == input.length() - 1)
                {
                    input.erase(i, 1);
                    spaces++; // Увеличиваем счетчик удаленных пробелов
                }
                // Удаляем первый пробел в первой строке
                if (firstLine && i == 0 && spacesToRemove == 1)
                {
                    input.erase(i, 0);
                    //input.erase(i, 1);
                    //spaces++; // Увеличиваем счетчик удаленных пробелов
                }
                // Сбрасываем флаг первой строки
                if (input[i] == '\n') {
                    firstLine = false;
                }
                // Переходим к следующему символу после удаления пробелов
                i += spacesToRemove - 1;
            }
        }
    }

    // Функция для удаления пробелов вокруг операторов в строке
    void removeSpacesAroundOperators(std::string& input, int& spaces) // Удаляем пробелы вокруг операторов из текущей строки.
    {
        const std::string operators = ";,}{()=+-/*"; // Список операторов

        // Проходим по каждому символу в строке
        for (size_t i = 0; i < input.length(); ++i)
        {
            // Проверяем, является ли текущий символ оператором
            if (operators.find(input[i]) != std::string::npos)
            {
                // Удаляем пробелы перед оператором
                while (i > 0 && std::isspace(input[i - 1]))
                {
                    input.erase(i - 1, 1); // Удаляем пробел
                    spaces++; // Увеличиваем счетчик удаленных пробелов
                    --i; // Сдвигаем индекс назад
                }
                // Удаляем пробелы после оператора
                while (i + 1 < input.length() && std::isspace(input[i + 1]))
                {
                    input.erase(i + 1, 1); // Удаляем пробел
                    spaces++; // Увеличиваем счетчик удаленных пробелов
                }
            }
        }
    }



    //// Функция для удаления пробелов вокруг операторов в строке
    //void removeSpacesAroundOperators(std::string& input) // Удаляем пробелы вокруг операторов из текущей строки.
    //{
    //    const std::string operators = ";,}{()=+-/*"; // Список операторов

    //    // Проходим по каждому символу в строке
    //    for (size_t i = 0; i < input.length(); ++i)
    //    {
    //        // Проверяем, является ли текущий символ оператором
    //        if (operators.find(input[i]) != std::string::npos)
    //        {
    //            // Удаляем пробелы перед оператором
    //            while (i > 0 && std::isspace(input[i - 1]))
    //            {
    //                input.erase(i - 1, 1); // Удаляем пробел
    //                --i; // Сдвигаем индекс назад
    //            }
    //            // Удаляем пробелы после оператора
    //            while (i + 1 < input.length() && std::isspace(input[i + 1]))
    //            {
    //                input.erase(i + 1, 1); // Удаляем пробел
    //            }
    //        }
    //    }
    //}


    //// Функция для удаления лишних пробелов из строки
    //void removeExtraSpaces(std::string& input, int& spaces) // Удаляем лишние пробелы из текущей строки.
    //{
    //    bool insideQuotes = false; // Переменная для отслеживания, находимся ли мы внутри кавычек
    //    bool firstLine = true; // Флаг для отслеживания первой строки

    //    // Проходим по каждому символу в строке
    //    for (size_t i = 0; i < input.length(); ++i)
    //    {
    //        // Проверяем, не встретили ли мы кавычку
    //        if (input[i] == '\'')
    //        {
    //            insideQuotes = !insideQuotes; // Меняем состояние внутри кавычек
    //        }
    //        // Если мы не внутри кавычек и встретили пробел
    //        if (!insideQuotes && input[i] == ' ')
    //        {
    //            size_t spacesToRemove = 0; // Счетчик для последовательных пробелов
    //            // Подсчет количества последовательных пробелов после текущего символа
    //            while (i + spacesToRemove < input.length() && input[i + spacesToRemove] == ' ')
    //            {
    //                ++spacesToRemove;
    //            }
    //            // Если найдено более одного пробела, удаляем их
    //            if (spacesToRemove > 1)
    //            {
    //                input.erase(i + 1, spacesToRemove - 1);
    //                spaces += spacesToRemove - 1; // Увеличиваем счетчик удаленных пробелов
    //            }
    //            // Удаляем пробел, если он на начале или конце строки
    //            if (i == 0 || i == input.length() - 1)
    //            {
    //                input.erase(i, 1);
    //                spaces++; // Увеличиваем счетчик удаленных пробелов
    //            }
    //            // Удаляем первый пробел в первой строке
    //            if (firstLine && i == 0 && spacesToRemove == 1)
    //            {
    //                input.erase(i, 1);
    //                spaces++; // Увеличиваем счетчик удаленных пробелов
    //            }
    //            // Сбрасываем флаг первой строки
    //            if (input[i] == '\n') {
    //                firstLine = false;
    //            }
    //        }
    //    }
    //}
   

    // Функция для чтения данных из файла
    IN getin(wchar_t infile[])
    {
        ifstream fin; // Поток для чтения из файла
        // Создаем буфер для имени файла в формате char
        char* outFile = new char[wcslen(infile) + 1];
        // Преобразуем имя файла из wchar_t в char
        wcstombs_s(NULL, outFile, wcslen(infile) + 1, infile, wcslen(infile) + 1);
        fin.open(infile); // Открываем файл
        // Проверка на ошибки открытия файла
        if (fin.bad())
        {
            throw ERROR_THROW(116); // Ошибка чтения
        }
        if (!fin.is_open())
        {
            throw ERROR_THROW(110); // Ошибка открытия файла
        }

        IN resultIn; // Структура для хранения результатов
        resultIn.size = 0; // Инициализация размера
        resultIn.lines = 0; // Инициализация количества строк
        int position = 0; // Позиция в текущей строке
        int ch; // Переменная для хранения символа
        std::string currentLine; // Строка для накопления символов
        std::string buffer; // Буфер для считывания строк из файла

        // Читаем файл построчно
        while (std::getline(fin, buffer))
        {
            resultIn.lines++; // Увеличиваем счетчик строк
            for (int i = 0; i < buffer.length(); i++) // Проходим по символам в считанной строке
            {
                ch = buffer[i]; // Получаем текущий символ

                // Проверяем, не достигли ли конца файла
                if (ch == fin.eof())
                {
                    break; // Выходим из цикла, если достигли конца файла
                }

                // Анализируем символ с помощью таблицы resultIn.code
                switch (resultIn.code[(unsigned char)ch])
                {
                case IN::F: // Если символ является буквой, цифрой или знаком подчеркивания, то это идентификатор
                {
                    resultIn.text.push_back(currentLine); // Добавляем текущую строку к результату
                    throw ERROR_THROW_IN(111, resultIn.lines, ++position, buffer, resultIn.text);
                    break;
                }
                case IN::I: // Если символ игнорируется
                {
                    resultIn.ignor++; // Увеличиваем счетчик игнорируемых символов
                    position++; // Увеличиваем позицию
                    break;
                }
                case IN::T: // Если символ является текстовым символом
                {
                    currentLine += ch; // Добавляем его к текущей строке
                    position++;
                    resultIn.size++; // Увеличиваем общий размер
                    break;
                }
                default: // Если символ не попадает ни в одну из вышеперечисленных категорий
                {
                    currentLine += resultIn.code[(unsigned char)ch]; // Добавляем символ к текущей строке
                    resultIn.size++; // Увеличиваем общий размер
                    position++;
                    break;
                }
                }
            }

            // Если текущая строка не пустая, обрабатываем её
            if (!currentLine.empty())
            {
                resultIn.size++; // Увеличиваем размер
                position++;
                position = 0; // Сбрасываем позицию
                currentLine += resultIn.code[IN_CODE_ENDL]; // Добавляем символ конца строки

                removeExtraSpaces(currentLine, resultIn.spaces); // Удаляем лишние пробелы
                //removeSpacesAroundOperators(currentLine); // Удаляем пробелы вокруг операторов
                removeSpacesAroundOperators(currentLine, resultIn.spaces); // Удаляем пробелы вокруг операторов

                resultIn.text.push_back(currentLine); // Добавляем текущую строку к результату
                currentLine.clear(); // Очищаем текущую строку для следующей итерации
            }
        }

        fin.close(); // Закрываем файл
        return resultIn; // Возвращаем результат
    }
}
