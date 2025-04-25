#include "stdafx.h"
#include "Error.h"

namespace Error {
    // Массив ошибок с максимальным количеством записей
    // серии ошибок:
    // 0 - 99 - системные ошибки
    // 100 - 109 - ошибки параметров 
    // 110 - 119 - ошибки открытия и чтения
    ERROR errors[ERROR_MAX_ENTRY] = {
        ERROR_ENTRY(0, "Недопустимый код ошибки"), // Код 0 - сообщение об ошибке по умолчанию
        ERROR_ENTRY(1, "Системный сбой"), // Код 1 - системная ошибка
        ERROR_ENTRY_NODEF(2), ERROR_ENTRY_NODEF(3), ERROR_ENTRY_NODEF(4), ERROR_ENTRY_NODEF(5),
        ERROR_ENTRY_NODEF(6), ERROR_ENTRY_NODEF(7), ERROR_ENTRY_NODEF(8), ERROR_ENTRY_NODEF(9),
        ERROR_ENTRY_NODEF10(10), ERROR_ENTRY_NODEF10(20), ERROR_ENTRY_NODEF10(30), ERROR_ENTRY_NODEF10(40), ERROR_ENTRY_NODEF10(50),
        ERROR_ENTRY_NODEF10(60), ERROR_ENTRY_NODEF10(70), ERROR_ENTRY_NODEF10(80), ERROR_ENTRY_NODEF10(90),
        ERROR_ENTRY(100, "Параметр -in должен быть задан"), // Код 100 - ошибка в параметрах
        ERROR_ENTRY_NODEF(101), ERROR_ENTRY_NODEF(102), ERROR_ENTRY_NODEF(103),
        ERROR_ENTRY(104, "Превышена длина входного параметра"), // Код 104 - ошибка превышения длины
        ERROR_ENTRY_NODEF(105), ERROR_ENTRY_NODEF(106), ERROR_ENTRY_NODEF(107),
        ERROR_ENTRY_NODEF(108), ERROR_ENTRY_NODEF(109),
        ERROR_ENTRY(110, "Ошибка при открытии файла с исходным кодом (-in)"), // Код 110 - ошибка открытия файла
        ERROR_ENTRY(111, "Недопустимый символ в исходном файле (-in)"), // Код 111 - ошибка символа
        ERROR_ENTRY(112, "Ошибка при создании файла протокола (-log)"), // Код 112 - ошибка создания файла протокола
        ERROR_ENTRY(113, "Ошибка при создании выходного файла (-out)"), // Код 113 - ошибка создания выходного файла
        ERROR_ENTRY(114, "Ошибка разбора цепочки"), // Код 114 - ошибка разбора строки
        ERROR_ENTRY(115, "Индекс строки больше размера контейнера"), // Код 115 - ошибка индексации
        ERROR_ENTRY(116, "Файл не существует"), // Код 116 - ошибка отсутствия файла
        ERROR_ENTRY(117, "Ошибка разбора входной строки"), // Код 117 - ошибка разбора входа
        ERROR_ENTRY_NODEF(118), ERROR_ENTRY_NODEF(119),
        ERROR_ENTRY_NODEF10(120), ERROR_ENTRY_NODEF10(130), ERROR_ENTRY_NODEF10(140), ERROR_ENTRY_NODEF10(150),
        ERROR_ENTRY_NODEF10(160), ERROR_ENTRY_NODEF10(170), ERROR_ENTRY_NODEF10(180), ERROR_ENTRY_NODEF10(190),
        ERROR_ENTRY_NODEF100(200), ERROR_ENTRY_NODEF100(300), ERROR_ENTRY_NODEF100(400), ERROR_ENTRY_NODEF100(500),
        ERROR_ENTRY_NODEF100(600), ERROR_ENTRY_NODEF100(700), ERROR_ENTRY_NODEF100(800), ERROR_ENTRY_NODEF100(900)
    };

    // Функция для получения сообщения об ошибке по идентификатору
    ERROR geterror(int id) {
        // Проверяем, что идентификатор в допустимом диапазоне
        if (id > 0 && id < ERROR_MAX_ENTRY) {
            return errors[id]; // Возвращаем ошибку по идентификатору
        }
        else {
            return errors[0]; // Возвращаем ошибку по умолчанию, если идентификатор недопустим
        }
    }

    // Функция для получения ошибки с дополнительной информацией
    ERROR geterrorin(int id, int line, int col, std::string buff, std::vector<std::string> MyVector) {
        // Проверяем, что идентификатор в допустимом диапазоне
        if (id > 0 && id < ERROR_MAX_ENTRY) {
            // Заполняем дополнительную информацию о ошибке
            errors[id].inext.col = col;
            errors[id].inext.line = line;
            errors[id].inext.buff = buff;
            errors[id].inext.MyVector = MyVector;
            return errors[id]; // Возвращаем ошибку с дополнительной информацией
        }
        else {
            return errors[0]; // Возвращаем ошибку по умолчанию
        }
    }

    // Функция для получения ошибки с номером строки и буфером
    ERROR geterrorfst(int id, int line, std::string buff) {
        // Проверяем, что идентификатор в допустимом диапазоне
        if (id > 0 && id < ERROR_MAX_ENTRY) {
            // Заполняем номер строки и буфер
            errors[id].inext.fstline = line;
            errors[id].inext.buff = buff;
            return errors[id]; // Возвращаем ошибку с номером строки
        }
        else {
            return errors[0]; // Возвращаем ошибку по умолчанию
        }
    }
}
