#pragma once // Защита от многократного включения данного заголовка

// Макрос для получения ошибки по её коду и бросания исключения
#define ERROR_THROW(id) Error::geterror(id); // throw ERROR_THROW(id)

// Макрос для получения ошибки с дополнительной информацией о позиции в строке
#define ERROR_THROW_IN(id, l, c, buff, arr) Error::geterrorin(id, l, c, buff, arr); // throw ERROR_THROW_IN

// Макрос для получения ошибки с указанием первой строки
#define ERROR_THROW_FST(id, index, buffer) Error::geterrorfst(id, index, buffer); // throw ERROR_THROW_FST

// Макрос для создания элемента таблицы ошибок
#define ERROR_ENTRY(id, m) {id, m, {-1, -1}} // элемент таблицы ошибок с указанием кода и сообщения

// Максимальная длина сообщения об ошибке
#define ERROR_MAXSIZE_MESSAGE 200 

// Макрос для создания неопределенной ошибки с заданным кодом
#define ERROR_ENTRY_NODEF(id) ERROR_ENTRY(-id, "Неопределенная ошибка") // 1 неопределенный элемент таблицы ошибок

// Макрос для создания 10 неопределенных ошибок
#define ERROR_ENTRY_NODEF10(id) ERROR_ENTRY_NODEF(id+0),ERROR_ENTRY_NODEF(id+1),ERROR_ENTRY_NODEF(id+2), ERROR_ENTRY_NODEF(id+3), \
                                ERROR_ENTRY_NODEF(id+4), ERROR_ENTRY_NODEF(id+5), ERROR_ENTRY_NODEF(id+6), ERROR_ENTRY_NODEF(id+7), \
                                ERROR_ENTRY_NODEF(id+8), ERROR_ENTRY_NODEF(id+9)

// Макрос для создания 100 неопределенных ошибок
#define ERROR_ENTRY_NODEF100(id) ERROR_ENTRY_NODEF(id+0),ERROR_ENTRY_NODEF(id+10),ERROR_ENTRY_NODEF(id+20), ERROR_ENTRY_NODEF(id+30), \
                                ERROR_ENTRY_NODEF(id+40), ERROR_ENTRY_NODEF(id+50), ERROR_ENTRY_NODEF(id+60), ERROR_ENTRY_NODEF(id+70), \
                                ERROR_ENTRY_NODEF(id+80), ERROR_ENTRY_NODEF(id+90)

// Максимальное количество элементов в таблице ошибок
#define ERROR_MAX_ENTRY 1000 // количество элементов в таблице ошибок

namespace Error
{
    // Структура для описания ошибки
    struct ERROR // тип исключения для throw ERROR_THROW | ERROR_THROW_IN
    {
        int id; // код ошибки
        char message[ERROR_MAXSIZE_MESSAGE]; // сообщение об ошибке
        struct IN // расширение для ошибок при обработке входных данных
        {
            short line; // номер строки (0, 1, 2, ...)
            short col; // номер столбца (0, 1, 2, ...)
            std::string buff; // буфер для хранения строки с ошибкой
            short fstline; // номер первой строки, связанной с ошибкой

            std::vector<std::string> MyVector; // вектор для хранения дополнительной информации, связанной с ошибкой
        } inext; // экземпляр структуры IN, вложенной в структуру ERROR
    };

    // Функция для формирования ERROR по коду ошибки
    ERROR geterror(int id); // сформировать ERROR для ERROR_THROW

    // Функция для формирования ERROR с информацией о позиции в строке
    ERROR geterrorin(int id, int line, int col, std::string buff, std::vector<std::string> MyVector); // сформировать ERROR для ERROR_THROW_IN

    // Функция для формирования ERROR с указанием первой строки
    ERROR geterrorfst(int id, int fstline, std::string buff); // сформировать ERROR для ERROR_THROW_FST
};
