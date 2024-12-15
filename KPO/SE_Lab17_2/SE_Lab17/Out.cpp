#include "stdafx.h" 
using namespace std; 

namespace Out 
{
	
	OUT getout(wchar_t outfile[])
	{
		OUT temp; // Создаем временную структуру OUT
		char* outFile = new char[wcslen(outfile) + 1]; // Выделяем память для имени файла в формате char
		wcstombs_s(NULL, outFile, wcslen(outfile) + 1, outfile, wcslen(outfile) + 1); // Преобразуем имя файла из wchar_t в char
		temp.stream = new std::ofstream; // Создаем новый поток для записи в файл
		temp.stream->open(outFile); // Открываем файл для записи
		if (!temp.stream->is_open()) // Если файл не открыт
		{
			ERROR_THROW(113); // Генерируем ошибку с кодом 113
		}
		wcscpy_s(temp.outfile, outfile); // Копируем имя файла в структуру OUT
		return temp; // Возвращаем структуру OUT
	};

	// Функция для записи содержимого в выходной файл
	void WriteOut(In::IN in, wchar_t out[])
	{
		std::ofstream fout(out); // Открываем выходной файл для записи
		for (int i = 0; i < in.text.size(); i++) // Цикл по всему тексту
		{
			fout << in.text[i]; // Записываем каждый символ в файл
		}
	};

	// Функция для записи информации об ошибке в выходной файл
	void WriteError(OUT out, Error::ERROR error)
	{
		for (int i = 0; i < error.inext.MyVector.size(); i++) // Цикл по элементам вектора с информацией об ошибке
		{
			*out.stream << error.inext.MyVector[i]; // Записываем каждый элемент в файл
		}
		*out.stream << endl; // Переход на новую строку
		*out.stream << "Ошибка" << error.id << ": " << error.message << endl << endl; // Записываем код и сообщение об ошибке
		*out.stream << "строка:" << error.inext.line << " позиция:" << error.inext.col << endl << endl; // Записываем строку и позицию ошибки
		if (error.inext.line != -1 && error.inext.col != -1) // Если строка и позиция ошибки известны
		{
			*out.stream << "Ошибка в строке " << ": " << error.inext.buff << endl << endl; // Записываем строку с ошибкой
		}
	}

	// Функция для закрытия выходного файла
	void Close(OUT out)
	{
		out.stream->close(); // Закрываем файл
	}
}
