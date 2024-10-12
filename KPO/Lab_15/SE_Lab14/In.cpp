#include "stdafx.h"
#include "In.h"
#include "Error.h"

using namespace std;

namespace In
{
	IN getin(wchar_t infile[])
	{

		IN in;
		in.size = 0; in.lines = 1; in.ignor = 0;
		int col = 1;

		unsigned char* text = new unsigned char[IN_MAX_LEN_TEXT];

		ifstream fin(infile);
		if (!fin.is_open())
			throw ERROR_THROW(110);

		while (in.size < IN_MAX_LEN_TEXT)
		{
			char c;
			fin.get(c); //считывает символ из файла и сохраняет в переменную
			unsigned char x = c;

			if (fin.eof()) //если файл закончен, ставится конец строки
			{
				text[in.size] = '\0';
				break;
			}
			switch (in.code[x])
			{
			case in.T: // если символ допустим, то он доббавляется в массив и количество символов увеличивается 
				text[in.size] = x;
				in.size++;
				col++;
				break;
			case in.I:
				in.ignor++;
				col++;
				break;
			case in.F:
				throw ERROR_THROW_IN(111, in.lines, col);
				break;
			default:
				text[in.size] = in.code[x];//присвает к элементу массива новый элемент из таблицы
				in.size++;
				col++;
				break;
			}
			if (x == IN_CODE_ENDL) //если элемент равен концу строки,то....
			{
				in.lines++;
				col = 1;
			}
		}
		in.text = text;
		return in;
	}
}