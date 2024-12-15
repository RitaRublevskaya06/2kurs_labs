#include "stdafx.h"
#include "Log.h" 
#include <iostream> 
#include <ctime> 

namespace Log 
{
	// Функция для получения структуры LOG и открытия файла для записи
	LOG getlog(wchar_t logfile[])
	{
		LOG temp; // Создаем временную структуру LOG
		char* outFile = new char[wcslen(logfile) + 1]; // Выделяем память для имени файла
		wcstombs_s(NULL, outFile, wcslen(logfile) + 1, logfile, wcslen(logfile) + 1); // Преобразуем имя файла из wchar_t в char
		temp.stream = new std::ofstream; // Создаем новый поток для записи в файл
		temp.stream->open(outFile); // Открываем файл для записи
		if (!temp.stream->is_open()) // Если файл не открыт
		{
			ERROR_THROW(112); // Генерируем ошибку с кодом 112
		}
		wcscpy_s(temp.logfile, logfile); // Копируем имя файла в структуру LOG
		return temp; // Возвращаем структуру LOG
	};

	// Функция для записи строки в лог, принимающая строку в формате char
	void WriteLine(LOG log, char* c, ...)
	{
		char** p = &c; // Указатель на строку

		while (*p != "") // Пока строка не пустая
		{

			(*log.stream) << *p; // Записываем строку в лог
			p += 1; // Переходим к следующей строке
		}
	};

	// Функция для записи строки в лог, принимающая строку в формате wchar_t
	void WriteLine(LOG log, wchar_t* c, ...)
	{
		wchar_t** p = &c; // Указатель на строку
		char buffer[50]; // Буфер для преобразования строки

		while (*p != L"") // Пока строка не пустая
		{
			wcstombs(buffer, *p, sizeof(buffer)); // Преобразуем строку из wchar_t в char
			(*log.stream) << buffer; // Записываем строку в лог
			p += 1; // Переходим к следующей строке
		}
	};

	// Функция для записи времени и заголовка лога
	void WriteLog(LOG log)
	{
		char buffer[PARM_MAX_SIZE]; // Буфер для хранения времени

		time_t rawtime; // Переменная для хранения текущего времени
		struct tm* timeinfo; // Структура для хранения времени в формате человеко-читаемого вида

		time(&rawtime); // Получаем текущее время
		timeinfo = localtime(&rawtime); // Преобразуем время в локальное время

		strftime(buffer, PARM_MAX_SIZE, "%d.%m.%Y %H:%M:%S", timeinfo); // Преобразуем время в строковый формат
		(*log.stream) << "\n--— Протокол —— \n" << buffer << " —— \n"; // Записываем время и заголовок в лог
	};

	// Функция для записи параметров, переданных через структуру Parm::PARM
	void WriteParm(LOG log, Parm::PARM parm)
	{
		char inInfo[PARM_MAX_SIZE]; // Буфер для входного файла
		char outInfo[PARM_MAX_SIZE]; // Буфер для выходного файла
		char logInfo[PARM_MAX_SIZE]; // Буфер для лог-файла

		wcstombs(inInfo, parm.in, sizeof(inInfo)); // Преобразуем входной файл из wchar_t в char
		wcstombs(outInfo, parm.out, sizeof(outInfo)); // Преобразуем выходной файл из wchar_t в char
		wcstombs(logInfo, parm.log, sizeof(logInfo)); // Преобразуем лог-файл из wchar_t в char

		(*log.stream) << "--— Аргументы —— \n" // Записываем аргументы в лог
			<< " -in: " << inInfo << "\n" // Записываем входной файл
			<< " -out: " << outInfo << "\n" // Записываем выходной файл
			<< " -log: " << logInfo << "\n"; // Записываем лог-файл
	};

	// Функция для записи информации о входных данных, переданных через структуру In::IN
	void WriteIn(LOG log, In::IN in)
	{
		(*log.stream) << "--— Параметры —— \n" // Заголовок раздела с параметрами
			<< "Количество символов: " << in.size << "\n" // Записываем количество символов
			<< "Строк: " << in.lines << "\n" // Записываем количество строк
			<< "Пропущено: " << in.ignor << "\n"; // Записываем количество пропущенных символов
		// Добавляем информацию об удалённых пробелах
		(*log.stream) << "Удалено пробелов: " << in.spaces << "\n";
	};

	// Функция для записи ошибки, переданной через структуру Error::ERROR
	void WriteError(LOG log, Error::ERROR error)
	{
		if (error.inext.line != -1) // Если строка ошибки известна
		{
			*log.stream << "Ошибка в строке:\t" << error.inext.buff << std::endl; // Записываем строку с ошибкой
			*log.stream << "Строка: " << error.inext.line << " Позиция: " << error.inext.col << std::endl; // Записываем строку и позицию ошибки
		}
		*log.stream << "Ошибка: " << error.id << ":" << error.message << std::endl; // Записываем код и сообщение об ошибке
	}

	// Функция для закрытия лог-файла
	void Close(LOG log)
	{
		log.stream->close(); // Закрываем файл
	}

	// Функция для записи таблицы лексем, переданной через структуру LT::LexTable
	void WriteLexTable(LOG log, LT::LexTable& lextable)
	{
		int currentLine = 0;  // Инициализируем переменную для хранения текущей строки
		bool currentLineChange = true;
		*log.stream << "\n\nТаблица Лексем:\n"; // Заголовок таблицы лексем
		for (int i = 0; i < lextable.size; i++) // Цикл по лексемам
		{
			if (lextable.table[i].sn != currentLine) // Если строка лексемы изменилась
			{
				*log.stream << '\n';  // Делаем перенос строки
				currentLine = lextable.table[i].sn; // Обновляем текущую строку
				currentLineChange = true;
			}
			if (currentLine+1 < 10 && currentLineChange == true) {
				*log.stream << "0" << currentLine + 1 << ' ';
				currentLineChange = false;
			}
			else if (currentLineChange == true){
				*log.stream << currentLine + 1 << ' ';
				currentLineChange = false;
			}
			*log.stream << lextable.table[i].lexema; // Записываем лексему в лог
		}
	}

};
