#include "stdafx.h"
namespace  Lexer
{

	FST::FST typeInteger("", 8,
		FST::NODE(1, FST::RELATION('i', 1)),
		FST::NODE(1, FST::RELATION('n', 2)),
		FST::NODE(1, FST::RELATION('t', 3)),
		FST::NODE(1, FST::RELATION('e', 4)),
		FST::NODE(1, FST::RELATION('g', 5)),
		FST::NODE(1, FST::RELATION('e', 6)),
		FST::NODE(1, FST::RELATION('r', 7)),
		FST::NODE()
	);

	FST::FST typeString("", 7,
		FST::NODE(1, FST::RELATION('s', 1)),
		FST::NODE(1, FST::RELATION('t', 2)),
		FST::NODE(1, FST::RELATION('r', 3)),
		FST::NODE(1, FST::RELATION('i', 4)),
		FST::NODE(1, FST::RELATION('n', 5)),
		FST::NODE(1, FST::RELATION('g', 6)),
		FST::NODE()
	);

	FST::FST typeFunction("", 9,
		FST::NODE(1, FST::RELATION('f', 1)),
		FST::NODE(1, FST::RELATION('u', 2)),
		FST::NODE(1, FST::RELATION('n', 3)),
		FST::NODE(1, FST::RELATION('c', 4)),
		FST::NODE(1, FST::RELATION('t', 5)),
		FST::NODE(1, FST::RELATION('i', 6)),
		FST::NODE(1, FST::RELATION('o', 7)),
		FST::NODE(1, FST::RELATION('n', 8)),
		FST::NODE()
	);

	FST::FST typeDeclare("", 8,
		FST::NODE(1, FST::RELATION('d', 1)),
		FST::NODE(1, FST::RELATION('e', 2)),
		FST::NODE(1, FST::RELATION('c', 3)),
		FST::NODE(1, FST::RELATION('l', 4)),
		FST::NODE(1, FST::RELATION('a', 5)),
		FST::NODE(1, FST::RELATION('r', 6)),
		FST::NODE(1, FST::RELATION('e', 7)),
		FST::NODE()
	);

	FST::FST typeReturn("", 7,
		FST::NODE(1, FST::RELATION('r', 1)),
		FST::NODE(1, FST::RELATION('e', 2)),
		FST::NODE(1, FST::RELATION('t', 3)),
		FST::NODE(1, FST::RELATION('u', 4)),
		FST::NODE(1, FST::RELATION('r', 5)),
		FST::NODE(1, FST::RELATION('n', 6)),
		FST::NODE()
	);

	FST::FST typeMain("", 5,
		FST::NODE(1, FST::RELATION('m', 1)),
		FST::NODE(1, FST::RELATION('a', 2)),
		FST::NODE(1, FST::RELATION('i', 3)),
		FST::NODE(1, FST::RELATION('n', 4)),
		FST::NODE()
	);

	FST::FST typePrint("", 6,
		FST::NODE(1, FST::RELATION('p', 1)),
		FST::NODE(1, FST::RELATION('r', 2)),
		FST::NODE(1, FST::RELATION('i', 3)),
		FST::NODE(1, FST::RELATION('n', 4)),
		FST::NODE(1, FST::RELATION('t', 5)),
		FST::NODE()
	);

	FST::FST typeSpace("", 2,
		FST::NODE(1, FST::RELATION(' ', 1)),
		FST::NODE()
	);
	FST::FST typeLeftBrace("", 2,
		FST::NODE(1, FST::RELATION('{', 1)),
		FST::NODE()
	);
	FST::FST typeRightBrace("", 2,
		FST::NODE(1, FST::RELATION('}', 1)),
		FST::NODE()
	);
	FST::FST typeLeftThesis("", 2,
		FST::NODE(1, FST::RELATION('(', 1)),
		FST::NODE()
	);
	FST::FST typeRightThesis("", 2,
		FST::NODE(1, FST::RELATION(')', 1)),
		FST::NODE()
	);
	FST::FST typeSemicolon("", 2,
		FST::NODE(1, FST::RELATION(';', 1)),
		FST::NODE()
	);
	FST::FST typeComma("", 2,
		FST::NODE(1, FST::RELATION(',', 1)),
		FST::NODE()
	);
	FST::FST typePlus("", 2,
		FST::NODE(1, FST::RELATION('+', 1)),
		FST::NODE());
	FST::FST typeMinus("", 2,
		FST::NODE(1, FST::RELATION('-', 1)),
		FST::NODE());
	FST::FST typeDel("", 2,
		FST::NODE(1, FST::RELATION('/', 1)),
		FST::NODE());
	FST::FST typeMulti("", 2,
		FST::NODE(1, FST::RELATION('*', 1)),
		FST::NODE());
	FST::FST typeEquals("", 2,
		FST::NODE(1, FST::RELATION('=', 1)),
		FST::NODE());
	//обработка индентификторов алфавита
	FST::FST typeIdentificator("", 2,
		FST::NODE(52,
			FST::RELATION('a', 0), FST::RELATION('b', 0),
			FST::RELATION('c', 0), FST::RELATION('d', 0),
			FST::RELATION('e', 0), FST::RELATION('f', 0),
			FST::RELATION('g', 0), FST::RELATION('h', 0),
			FST::RELATION('i', 0), FST::RELATION('j', 0),
			FST::RELATION('k', 0), FST::RELATION('l', 0),
			FST::RELATION('m', 0), FST::RELATION('n', 0),
			FST::RELATION('o', 0), FST::RELATION('p', 0),
			FST::RELATION('q', 0), FST::RELATION('r', 0),
			FST::RELATION('s', 0), FST::RELATION('t', 0),
			FST::RELATION('u', 0), FST::RELATION('v', 0),
			FST::RELATION('w', 0), FST::RELATION('x', 0),
			FST::RELATION('y', 0), FST::RELATION('z', 0),
			FST::RELATION('a', 1), FST::RELATION('b', 1),
			FST::RELATION('c', 1), FST::RELATION('d', 1),
			FST::RELATION('e', 1), FST::RELATION('f', 1),
			FST::RELATION('g', 1), FST::RELATION('h', 1),
			FST::RELATION('i', 1), FST::RELATION('j', 1),
			FST::RELATION('k', 1), FST::RELATION('l', 1),
			FST::RELATION('m', 1), FST::RELATION('n', 1),
			FST::RELATION('o', 1), FST::RELATION('p', 1),
			FST::RELATION('q', 1), FST::RELATION('r', 1),
			FST::RELATION('s', 1), FST::RELATION('t', 1),
			FST::RELATION('u', 1), FST::RELATION('v', 1),
			FST::RELATION('w', 1), FST::RELATION('x', 1),
			FST::RELATION('y', 1), FST::RELATION('z', 1)
		),

		FST::NODE()
	);

	
	FST::FST typeStringLiteral("", 4,
		//обработка комментариев
		FST::NODE(1,
			FST::RELATION('\'', 1)),
		FST::NODE(384,
			FST::RELATION('!', 2), FST::RELATION('@', 2), FST::RELATION('#', 2), FST::RELATION('$', 2), FST::RELATION('%', 2), FST::RELATION('^', 2),
			FST::RELATION('&', 2), FST::RELATION('*', 2), FST::RELATION('(', 2), FST::RELATION(')', 2), FST::RELATION('-', 2), FST::RELATION('_', 2),
			FST::RELATION('+', 2), FST::RELATION('=', 2), FST::RELATION('~', 2), FST::RELATION('`', 2), FST::RELATION('1', 2), FST::RELATION('2', 2),
			FST::RELATION('3', 2), FST::RELATION('4', 2), FST::RELATION('5', 2), FST::RELATION('6', 2), FST::RELATION('7', 2), FST::RELATION('8', 2),
			FST::RELATION('9', 2), FST::RELATION('0', 2), FST::RELATION('	', 2), FST::RELATION(' ', 2), FST::RELATION('q', 2), FST::RELATION('w', 2),
			FST::RELATION('e', 2), FST::RELATION('r', 2), FST::RELATION('t', 2), FST::RELATION('y', 2), FST::RELATION('u', 2), FST::RELATION('i', 2),
			FST::RELATION('o', 2), FST::RELATION('p', 2), FST::RELATION('{', 2), FST::RELATION('[', 2), FST::RELATION('}', 2), FST::RELATION(']', 2),
			FST::RELATION('\\', 2), FST::RELATION('|', 2), FST::RELATION('Q', 2), FST::RELATION('W', 2), FST::RELATION('R', 2), FST::RELATION('T', 2), FST::RELATION('Y', 2),
			FST::RELATION('U', 2), FST::RELATION('I', 2), FST::RELATION('O', 2), FST::RELATION('P', 2), FST::RELATION('a', 2), FST::RELATION('s', 2),
			FST::RELATION('d', 2), FST::RELATION('f', 2), FST::RELATION('g', 2), FST::RELATION('h', 2), FST::RELATION('j', 2), FST::RELATION('k', 2),
			FST::RELATION('l', 2), FST::RELATION(':', 2), FST::RELATION(';', 2), FST::RELATION('\'', 2), FST::RELATION('"', 2), FST::RELATION('A', 2),
			FST::RELATION('S', 2), FST::RELATION('D', 2), FST::RELATION('F', 2), FST::RELATION('G', 2), FST::RELATION('H', 2), FST::RELATION('J', 2),
			FST::RELATION('K', 2), FST::RELATION('L', 2), FST::RELATION('z', 2), FST::RELATION('x', 2), FST::RELATION('c', 2), FST::RELATION('v', 2),
			FST::RELATION('b', 2), FST::RELATION('n', 2), FST::RELATION('m', 2), FST::RELATION(',', 2), FST::RELATION('.', 2), FST::RELATION('/', 2),
			FST::RELATION('Z', 2), FST::RELATION('X', 2), FST::RELATION('C', 2), FST::RELATION('V', 2), FST::RELATION('B', 2), FST::RELATION('N', 2),
			FST::RELATION('M', 2), FST::RELATION('<', 2), FST::RELATION('>', 2), FST::RELATION('?', 2), FST::RELATION('ё', 2), FST::RELATION('Ё', 2),
			FST::RELATION('й', 2), FST::RELATION('ц', 2), FST::RELATION('у', 2), FST::RELATION('к', 2), FST::RELATION('е', 2), FST::RELATION('н', 2),
			FST::RELATION('г', 2), FST::RELATION('ш', 2), FST::RELATION('щ', 2), FST::RELATION('з', 2), FST::RELATION('х', 2), FST::RELATION('ъ', 2),
			FST::RELATION('Й', 2), FST::RELATION('Ц', 2), FST::RELATION('У', 2), FST::RELATION('К', 2), FST::RELATION('Е', 2), FST::RELATION('Н', 2),
			FST::RELATION('Г', 2), FST::RELATION('Ш', 2), FST::RELATION('Щ', 2), FST::RELATION('З', 2), FST::RELATION('Х', 2), FST::RELATION('Ъ', 2),
			FST::RELATION('ф', 2), FST::RELATION('ы', 2), FST::RELATION('в', 2), FST::RELATION('а', 2), FST::RELATION('п', 2), FST::RELATION('р', 2),
			FST::RELATION('о', 2), FST::RELATION('л', 2), FST::RELATION('д', 2), FST::RELATION('ж', 2), FST::RELATION('э', 2), FST::RELATION('Ф', 2),
			FST::RELATION('Ы', 2), FST::RELATION('В', 2), FST::RELATION('А', 2), FST::RELATION('П', 2), FST::RELATION('Р', 2), FST::RELATION('О', 2),
			FST::RELATION('Л', 2), FST::RELATION('Д', 2), FST::RELATION('Ж', 2), FST::RELATION('Э', 2), FST::RELATION('я', 2), FST::RELATION('ч', 2),
			FST::RELATION('с', 2), FST::RELATION('м', 2), FST::RELATION('и', 2), FST::RELATION('т', 2), FST::RELATION('ь', 2), FST::RELATION('б', 2),
			FST::RELATION('ю', 2), FST::RELATION('Я', 2), FST::RELATION('Ч', 2), FST::RELATION('С', 2), FST::RELATION('М', 2), FST::RELATION('И', 2),
			FST::RELATION('Т', 2), FST::RELATION('Ь', 2), FST::RELATION('Б', 2), FST::RELATION('Ю', 2),
			FST::RELATION('!', 1), FST::RELATION('@', 1), FST::RELATION('#', 1), FST::RELATION('$', 1), FST::RELATION('%', 1), FST::RELATION('^', 1),
			FST::RELATION('&', 1), FST::RELATION('*', 1), FST::RELATION('(', 1), FST::RELATION(')', 1), FST::RELATION('-', 1), FST::RELATION('_', 1),
			FST::RELATION('+', 1), FST::RELATION('=', 1), FST::RELATION('~', 1), FST::RELATION('`', 1), FST::RELATION('1', 1), FST::RELATION('2', 1),
			FST::RELATION('3', 1), FST::RELATION('4', 1), FST::RELATION('5', 1), FST::RELATION('6', 1), FST::RELATION('7', 1), FST::RELATION('8', 1),
			FST::RELATION('9', 1), FST::RELATION('0', 1), FST::RELATION('	', 1), FST::RELATION(' ', 1), FST::RELATION('q', 1), FST::RELATION('w', 1),
			FST::RELATION('e', 1), FST::RELATION('r', 1), FST::RELATION('t', 1), FST::RELATION('y', 1), FST::RELATION('u', 1), FST::RELATION('i', 1),
			FST::RELATION('o', 1), FST::RELATION('p', 1), FST::RELATION('{', 1), FST::RELATION('[', 1), FST::RELATION('}', 1), FST::RELATION(']', 1),
			FST::RELATION('\\', 1), FST::RELATION('|', 1), FST::RELATION('Q', 1), FST::RELATION('W', 1), FST::RELATION('R', 1), FST::RELATION('T', 1), FST::RELATION('Y', 1),
			FST::RELATION('U', 1), FST::RELATION('I', 1), FST::RELATION('O', 1), FST::RELATION('P', 1), FST::RELATION('a', 1), FST::RELATION('s', 1),
			FST::RELATION('d', 1), FST::RELATION('f', 1), FST::RELATION('g', 1), FST::RELATION('h', 1), FST::RELATION('j', 1), FST::RELATION('k', 1),
			FST::RELATION('l', 1), FST::RELATION(':', 1), FST::RELATION(';', 1), FST::RELATION('\'', 1), FST::RELATION('"', 1), FST::RELATION('A', 1),
			FST::RELATION('S', 1), FST::RELATION('D', 1), FST::RELATION('F', 1), FST::RELATION('G', 1), FST::RELATION('H', 1), FST::RELATION('J', 1),
			FST::RELATION('K', 1), FST::RELATION('L', 1), FST::RELATION('z', 1), FST::RELATION('x', 1), FST::RELATION('c', 1), FST::RELATION('v', 1),
			FST::RELATION('b', 1), FST::RELATION('n', 1), FST::RELATION('m', 1), FST::RELATION(',', 1), FST::RELATION('.', 1), FST::RELATION('/', 1),
			FST::RELATION('Z', 1), FST::RELATION('X', 1), FST::RELATION('C', 1), FST::RELATION('V', 1), FST::RELATION('B', 1), FST::RELATION('N', 1),
			FST::RELATION('M', 1), FST::RELATION('<', 1), FST::RELATION('>', 1), FST::RELATION('?', 1), FST::RELATION('ё', 1), FST::RELATION('Ё', 1),
			FST::RELATION('й', 1), FST::RELATION('ц', 1), FST::RELATION('у', 1), FST::RELATION('к', 1), FST::RELATION('е', 1), FST::RELATION('н', 1),
			FST::RELATION('г', 1), FST::RELATION('ш', 1), FST::RELATION('щ', 1), FST::RELATION('з', 1), FST::RELATION('х', 1), FST::RELATION('ъ', 1),
			FST::RELATION('Й', 1), FST::RELATION('Ц', 1), FST::RELATION('У', 1), FST::RELATION('К', 1), FST::RELATION('Е', 1), FST::RELATION('Н', 1),
			FST::RELATION('Г', 1), FST::RELATION('Ш', 1), FST::RELATION('Щ', 1), FST::RELATION('З', 1), FST::RELATION('Х', 1), FST::RELATION('Ъ', 1),
			FST::RELATION('ф', 1), FST::RELATION('ы', 1), FST::RELATION('в', 1), FST::RELATION('а', 1), FST::RELATION('п', 1), FST::RELATION('р', 1),
			FST::RELATION('о', 1), FST::RELATION('л', 1), FST::RELATION('д', 1), FST::RELATION('ж', 1), FST::RELATION('э', 1), FST::RELATION('Ф', 1),
			FST::RELATION('Ы', 1), FST::RELATION('В', 1), FST::RELATION('А', 1), FST::RELATION('П', 1), FST::RELATION('Р', 1), FST::RELATION('О', 1),
			FST::RELATION('Л', 1), FST::RELATION('Д', 1), FST::RELATION('Ж', 1), FST::RELATION('Э', 1), FST::RELATION('я', 1), FST::RELATION('ч', 1),
			FST::RELATION('с', 1), FST::RELATION('м', 1), FST::RELATION('и', 1), FST::RELATION('т', 1), FST::RELATION('ь', 1), FST::RELATION('б', 1),
			FST::RELATION('ю', 1), FST::RELATION('Я', 1), FST::RELATION('Ч', 1), FST::RELATION('С', 1), FST::RELATION('М', 1), FST::RELATION('И', 1),
			FST::RELATION('Т', 1), FST::RELATION('Ь', 1), FST::RELATION('Б', 1), FST::RELATION('Ю', 1)
		),
		FST::NODE(1,
			FST::RELATION('\'', 3)),
		FST::NODE()
	);

	FST::FST typeNumbLiteral("", 3,
		FST::NODE(20,
			FST::RELATION('0', 2), FST::RELATION('1', 2), FST::RELATION('2', 2), FST::RELATION('3', 2), FST::RELATION('4', 2),
			FST::RELATION('5', 2), FST::RELATION('6', 2), FST::RELATION('7', 2), FST::RELATION('8', 2), FST::RELATION('9', 2),
			FST::RELATION('1', 1), FST::RELATION('2', 1), FST::RELATION('3', 1), FST::RELATION('4', 1),
			FST::RELATION('5', 1), FST::RELATION('6', 1), FST::RELATION('7', 1), FST::RELATION('8', 1), FST::RELATION('9', 1)),

		FST::NODE(20,
			FST::RELATION('0', 2), FST::RELATION('1', 2), FST::RELATION('2', 2), FST::RELATION('3', 2), FST::RELATION('4', 2),
			FST::RELATION('5', 2), FST::RELATION('6', 2), FST::RELATION('7', 2), FST::RELATION('8', 2), FST::RELATION('9', 2),
			FST::RELATION('0', 1), FST::RELATION('1', 1), FST::RELATION('2', 1), FST::RELATION('3', 1), FST::RELATION('4', 1),
			FST::RELATION('5', 1), FST::RELATION('6', 1), FST::RELATION('7', 1), FST::RELATION('8', 1), FST::RELATION('9', 1)),

		FST::NODE()

	);

	// Функция для проверки строки s с использованием заданного конечного автомата fst
	bool check(std::string s, FST::FST fst)
	{
		// Устанавливаем строку внутри конечного автомата fst
		fst.string = s;

		// Запускаем выполнение конечного автомата и возвращаем результат
		return FST::execute(fst);
	}


	// Объявление функции getIdentifierContext, которая принимает лексическую таблицу и текущий индекс
	std::string getIdentifierContext(const LT::LexTable& lextable, int currentIndex)
	{
		// Объявление переменных для хранения контекста
		std::string context;
		std::string buffer;
		std::string buff;
		std::string type;

		// Проверка, пуст ли контекст
		if (context.empty())
		{
			// Первый цикл: обратный проход по лексической таблице от текущего индекса назад
			for (int i = currentIndex - 1; i >= 0; i--)
			{
				// Проверка, что текущая лексема - это переменная (t) и имеет тот же комментарий, что и предыдущая
				if (lextable.table[i].lexema == 't' && lextable.table[i + 1].comm == lextable.table[currentIndex - 1].comm)
				{
					// Добавление соответствующего типа в контекст (integer или string)
					if (lextable.table[i].comm == "integer")
					{
						type += "_integer_";
					}
					if (lextable.table[i].comm == "string")
					{
						type += "_string_";
					}

					// Завершение цикла
					break;
				}
			}

			// Второй цикл: обратный проход по лексической таблице от текущего индекса назад
			for (int i = currentIndex - 1; i >= 0; i--)
			{
				const LT::Entry& entry = lextable.table[i];
				// Проверка, что текущая лексема - это объявление функции (LEX_FUNCTION)
				if (entry.lexema == LEX_FUNCTION)
				{
					// Добавление "function" в контекст
					buffer += "function";

					// Проверка типа (integer или string) и добавление соответствующего типа в контекст
					if (lextable.table[i - 1].comm == "integer")
					{
						type += "_integer_";
					}
					if (lextable.table[i - 1].comm == "string") {
						type += "_string_";
					}

					// Получение имени функции и добавление его в контекст
					buff = lextable.table[i + 1].comm;
					buffer += type;
					buffer += buff;

					// Очистка временных переменных
					type.clear();
					buff.clear();

					// Завершение цикла
					break;
				}
				// Проверка, что текущая лексема - это открывающая скобка
				else if (entry.lexema == LEX_LEFTBRACE)
				{
					// Внутренний цикл: обратный проход от текущего индекса назад
					for (int j = i; j >= 0; j--)
					{
						if (lextable.table[j].lexema == LEX_FUNCTION)
						{
							// Проверка, что функция является встроенной (LIB_FUNCTION1 или LIB_FUNCTION2)
							if (lextable.table[j].comm == LIB_FUNCTION1 ||
								lextable.table[j].comm == LIB_FUNCTION2)
							{
								continue;
							}

							// Получение имени функции и добавление "var_function" в контекст
							buff = lextable.table[j + 1].comm;
							buffer += "var_function";

							// Завершение цикла
							break;
						}

						// Проверка, что текущая лексема - это главная функция (LEX_MAINFUNC)
						if (lextable.table[j].lexema == LEX_MAINFUNC)
						{
							// Добавление "var_main" в контекст
							buffer += "var_main";

							// Завершение цикла
							break;
						}
					}

					// Добавление типа и имени в контекст
					buffer += type;
					buffer += buff;

					// Очистка временных переменных
					type.clear();
					buff.clear();

					// Завершение цикла
					break;
				}
				// Проверка, что текущая лексема - это открывающая скобка (LEX_LEFTHESIS)
				else if (entry.lexema == LEX_LEFTHESIS)
				{
					// Проверка наличия условий для игнорирования
					if (lextable.table[i - 1].lexema == LEX_RAV || lextable.table[i - 1].lexema == 'v' || lextable.table[i + 1].lexema == 'v')
					{
						// Пропуск
						;
					}

					// Внутренний цикл: обратный проход от текущего индекса назад, пока не встретится закрывающая скобка
					for (int j = i; j >= 0 && j != LEX_RIGHTBRACE; j--)
					{
						// Проверка, что буфер пуст и текущая лексема - это идентификатор (LEX_ID)
						if (buffer.empty())
						{
							if (lextable.table[j].lexema == LEX_ID && lextable.table[j - 1].lexema == LEX_FUNCTION)
							{
								// Получение имени параметра и добавление "parameter_function" в контекст
								buff = lextable.table[j + 1].comm;
								buffer += "parameter_function";

								// Завершение цикла
								break;
							}
						}

						// Проверка, что буфер пуст и текущая лексема - это открывающая скобка
						if (buffer.empty())
						{
							if (lextable.table[j].lexema == LEX_LEFTBRACE)
							{
								// Внутренний цикл: обратный проход от текущего индекса назад
								for (int k = j; k >= 0; k--)
								{
									if (lextable.table[k].lexema == LEX_FUNCTION)
									{
										// Проверка, что функция является встроенной (LIB_FUNCTION1 или LIB_FUNCTION2)
										if (lextable.table[k].comm == LIB_FUNCTION1 ||
											lextable.table[k].comm == LIB_FUNCTION2)
										{
											continue;
										}

										// Получение имени функции и добавление "var_function" в контекст
										buff = lextable.table[k + 1].comm;
										buffer += "var_function";

										// Завершение цикла
										break;
									}

									// Проверка, что текущая лексема - это главная функция (LEX_MAINFUNC)
									if (lextable.table[k].lexema == LEX_MAINFUNC)
									{
										// Добавление "var_main" в контекст
										buffer += "var_main";

										// Завершение цикла
										break;
									}
								}
							}
						}
					}

					// Добавление типа и имени в контекст
					buffer += type;
					buffer += buff;

					// Очистка временных переменных
					type.clear();
					buff.clear();

					// Завершение цикла
					break;
				}
			}
		}

		// Присвоение полученного контекста переменной context
		context = buffer;

		// Возврат контекста
		return context;
	}


	// Функция fillFields принимает запись idEntry и контекст и заполняет поля записи на основе контекста
	void fillFields(IT::Entry& idEntry, std::string context)
	{
		// Проверка, начинается ли контекст с "function_string_"
		if (context.find("function_string_") == 0)
		{
			// Заполнение полей записи для функции с возвращаемым значением типа string
			idEntry.functionname = idEntry.id;
			idEntry.idtype = IT::IDTYPE::F;
			idEntry.iddatatype = IT::IDDATATYPE::STR;
		}
		// Проверка, начинается ли контекст с "function_integer_"
		else if (context.find("function_integer_") == 0)
		{
			// Заполнение полей записи для функции с возвращаемым значением типа integer
			idEntry.functionname = idEntry.id;
			idEntry.idtype = IT::IDTYPE::F;
			idEntry.iddatatype = IT::IDDATATYPE::INT;
		}
		// Проверка, начинается ли контекст с "parameter_function"
		else if (context.find("parameter_function") == 0)
		{
			// Заполнение полей записи для параметра функции
			idEntry.idtype = IT::IDTYPE::P;
			// Проверка, содержит ли контекст "string"
			if (context.find("string") != std::string::npos)
			{
				idEntry.iddatatype = IT::IDDATATYPE::STR;
				idEntry.value.setString("");
			}
			// Проверка, содержит ли контекст "integer"
			else if (context.find("integer") != std::string::npos)
			{
				idEntry.iddatatype = IT::IDDATATYPE::INT;
				idEntry.value.setInteger(0);
			}
			// Извлечение имени функции из контекста
			std::string buff;
			size_t lastUnderscorePos = context.rfind("_");
			if (lastUnderscorePos != std::string::npos)
			{
				buff = context.substr(lastUnderscorePos + 1);
			}
			idEntry.fun = buff;
		}
		// Проверка, начинается ли контекст с "var_main"
		else if (context.find("var_main") == 0)
		{
			// Заполнение полей записи для переменной в главной функции
			idEntry.idtype = IT::IDTYPE::V;
			// Проверка, содержит ли контекст "string"
			if (context.find("string") != std::string::npos)
			{
				idEntry.iddatatype = IT::IDDATATYPE::STR;
				idEntry.value.setString("");
			}
			// Проверка, содержит ли контекст "integer"
			if (context.find("integer") != std::string::npos)
			{
				idEntry.iddatatype = IT::IDDATATYPE::INT;
				idEntry.value.setInteger(0);
			}
			// Установление имени функции как "main"
			idEntry.fun = "main";
		}
		// Проверка, начинается ли контекст с "var_function"
		else if (context.find("var_function") == 0)
		{
			// Заполнение полей записи для переменной в пользовательской функции
			idEntry.idtype = IT::IDTYPE::V;
			// Проверка, содержит ли контекст "string"
			if (context.find("string") != std::string::npos)
			{
				idEntry.iddatatype = IT::IDDATATYPE::STR;
				idEntry.value.setString("");
			}
			// Проверка, содержит ли контекст "integer"
			if (context.find("integer") != std::string::npos)
			{
				idEntry.iddatatype = IT::IDDATATYPE::INT;
				idEntry.value.setInteger(0);
			}
			// Извлечение имени функции из контекста
			std::string buff;
			size_t lastUnderscorePos = context.rfind("_");
			if (lastUnderscorePos != std::string::npos)
			{
				buff = context.substr(lastUnderscorePos + 1);
			}
			idEntry.fun = buff;
		}
	}


	// Функция addIdentificator добавляет идентификатор в таблицу лексем (lextable) и таблицу идентификаторов (idtable)
	void addIdentificator(LT::LexTable& lextable, IT::IdTable& idtable, std::string word, LT::Entry& lexEntry, int line)
	{
		// Устанавливаем лексему как LEX_ID и устанавливаем номер строки
		lexEntry.lexema = LEX_ID;
		lexEntry.sn = line;

		// Если идентификатор слишком длинный, укорачиваем его до максимальной длины ID_MAXSIZE
		if (word.length() > ID_MAXSIZE && (word != LIB_FUNCTION1 && word != LIB_FUNCTION2))
		{
			word = word.substr(0, ID_MAXSIZE);
		}

		// Устанавливаем значение комментария в лексеме
		lexEntry.comm = word;

		// Добавляем лексему в таблицу лексем
		LT::Add(lextable, lexEntry);

		// Получаем размер таблицы лексем после добавления
		int size = lextable.size - 1;

		// Создаем запись для идентификатора
		IT::Entry idEntry;

		// Получаем контекст для идентификатора
		std::string context = getIdentifierContext(lextable, lextable.size);

		// Ищем идентификатор в таблице идентификаторов
		int idIndex = IsId(idtable, word, idEntry.functionname, idEntry.fun);

		// Если идентификатор уже существует
		if (idIndex != TI_NULLIDX)
		{
			idEntry.id = word;

			// Заполняем поля записи идентификатора на основе контекста
			fillFields(idEntry, context);

			// Проверяем тип идентификатора в таблице идентификаторов
			if (idtable.table[idIndex].idtype == 4)
			{
				// Проверяем условия для присваивания значения в зависимости от контекста
				bool condition1 = ((lextable.table[size - 1].lexema == LEX_LEFTHESIS && lextable.table[size - 2].lexema == LEX_ID)
					|| (lextable.table[size - 1].lexema == LEX_COMMA && lextable.table[size - 2].lexema == LEX_ID) || lextable.table[size - 1].lexema == LEX_SEMICOLON
					|| lextable.table[size - 1].lexema == LEX_PRINT || lextable.table[size - 1].lexema == LEX_RETURN);
				bool condition2 = (idtable.table[idIndex].iddatatype == idEntry.iddatatype &&
					idtable.table[idIndex].idtype == idEntry.idtype && idtable.table[idIndex].fun == idEntry.fun);

				// Если не выполняются оба условия, добавляем новую запись в таблицу идентификаторов
				if (!condition1)
				{
					if (!condition2)
					{
						idEntry.idxfirstLE = size;
						lextable.table[size].idxTI = idtable.size;

						// Добавляем запись в таблицу идентификаторов
						IT::Add(idtable, idEntry);
					}
				}
				// Иначе устанавливаем индекс из существующей записи в таблице идентификаторов
				else
				{
					int bufIndex = idtable.table[idIndex].idxfirstLE;
					lextable.table[size].idxTI = lextable.table[bufIndex].idxTI;
				}
			}
			else if (idtable.table[idIndex].idtype == 3)
			{
				if (idtable.table[idIndex].fun != idEntry.fun)
				{
					idEntry.idxfirstLE = size;
					lextable.table[size].idxTI = idtable.size;

					// Добавляем запись в таблицу идентификаторов
					IT::Add(idtable, idEntry);
				}
				else
				{
					int bufIndex = idtable.table[idIndex].idxfirstLE;
					lextable.table[size].idxTI = lextable.table[bufIndex].idxTI;
				}
			}
			else
			{
				int bufIndex = idtable.table[idIndex].idxfirstLE;
				lextable.table[size].idxTI = lextable.table[bufIndex].idxTI;
			}
		}
		// Если идентификатор не существует в таблице идентификаторов
		else
		{
			idEntry.id = word;
			fillFields(idEntry, context);

			// Проверяем тип идентификатора и добавляем запись в таблицу идентификаторов
			if (idEntry.iddatatype == IT::IDDATATYPE::STR || idEntry.iddatatype == IT::IDDATATYPE::INT)
			{
				idEntry.idxfirstLE = size;
				lextable.table[size].idxTI = idtable.size;

				// Добавляем запись в таблицу идентификаторов
				IT::Add(idtable, idEntry);
			}
		}
	}



	void parse(In::IN in, LT::LexTable& lextable, IT::IdTable& idtable)
	{
		//// Создаем переменные для лексемы и идентификатора
		LT::Entry lex;
		IT::Entry idn;
		// Строка, содержащая разделители
		std::string separators = "();{}=*/+-|, ";
		// Буфер для хранения текущей строки из входных данных
		std::string buff = "";
		// Флаг, указывающий, находится ли парсер внутри строки (внутри одинарных кавычек)
		bool insideString = false;
		// Счетчик открывающихся кавычек
		int numbMarks = 0;
		// Переменные для отслеживания текущей строки и позиции в ней
		int line = 0;
		int pos = 0;
		// Счетчик для литералов
		int count = 0;
		// Проходим по строкам во входных данных
		for (line = 0; line < in.text.size(); line++)
		{
			// Получаем текущую строку
			buff = in.text[line];
			// Переменная для хранения текущего слова (лексемы)
			std::string word = "";
			// Проходим по символам в текущей строке
			for (pos = 0; pos < buff.size(); pos++)
			{
				// Если находимся внутри строки
				if (insideString)
				{
					if (buff[pos] == '\'')
					{
						insideString = false;
						// Убираем кавычки из строки
						word += (unsigned char)buff[pos];
						word.erase(0, 1);
						word.erase(word.length() - 1, 1);
						// Проверяем, существует ли такая строка в таблице идентификаторов
						int i = IT::findLexStr(idtable, word);
						// Заполняем лексему и добавляем ее в таблицу лексем
						lex.lexema = LEX_LITERAL;
						lex.sn = line;
						lex.comm = word;
						if (i != LT_TI_NULLIDX)
						{
							lex.idxTI = i;
						}
						else
						{
							idn.id = "L" + std::to_string(count);
							idn.iddatatype = IT::STR;
							idn.idtype = IT::L;
							idn.idxfirstLE = lextable.size;
							lex.idxTI = idtable.size;
							idn.value.setString(word);
							count++;
							IT::Add(idtable, idn);
						}

						LT::Add(lextable, lex);
					}
					else
					{
						word += (unsigned char)buff[pos];
					}
				}
				// Если текущий символ - одинарная кавычка, входим внутрь строки
				else if (buff[pos] == '\'')
				{
					insideString = true;
					word += (unsigned char)buff[pos];
				}
				// Если текущий символ - разделитель и мы не внутри строки
				else if (separators.find(buff[pos]) != std::string::npos && !insideString)
				{
					std::string buffer = "";
					buffer += buff[pos];
					// Обрабатываем разные типы разделителей
					switch (buff[pos]) // Переключение по текущему символу в буфере на позиции pos
					{
					case ' ':
					{
						break; // Если символ пробел, ничего не делаем и переходим к следующему символу
					}
					case '|':
					{
						break; // Если символ вертикальная черта '|', ничего не делаем и переходим к следующему символу
					}
					case '-':
					{
						if (check(buffer, typeMinus)) // Проверка, соответствует ли буфер типу "минус"
						{
							lex.lexema = LEX_MINUS; // Установка типа лексемы как LEX_MINUS
							lex.sn = line; // Установка номера строки, где находится лексема
							lex.idxTI = -1; // Инициализация индекса таблицы идентификаторов как -1 (не определен)
							LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу
						}
						else
						{
							// Если буфер не соответствует типу "минус", генерируем ошибку с кодом 105
							throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text);
						}
						break; // Выход из текущего случая
					}
					case '+':
					{
						if (check(buffer, typePlus)) // Проверка, соответствует ли буфер типу "плюс"
						{
							lex.lexema = LEX_PLUS; // Установка типа лексемы как LEX_PLUS
							lex.sn = line; // Установка номера строки, где находится лексема
							// lex.sn++; // Закомментированная строка, возможно, использовалась для инкрементации номера строки
							lex.idxTI = -1; // Инициализация индекса таблицы идентификаторов как -1 (не определен)
							LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу
						}
						else
						{
							// Если буфер не соответствует типу "плюс", генерируем ошибку с кодом 105
							throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text);
						}
						break; // Выход из текущего случая
					}

					case '*':
					{
						if (check(buffer, typeMulti)) // Проверка, соответствует ли буфер типу "умножение"
						{
							lex.lexema = LEX_STAR; // Установка типа лексемы как LEX_STAR
							lex.sn = line; // Установка номера строки, где находится лексема
							// lex.sn++; // Закомментированная строка, возможно, использовалась для инкрементации номера строки
							lex.idxTI = -1; // Инициализация индекса таблицы идентификаторов как -1 (не определен)
							LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу
						}
						else
						{
							// Если буфер не соответствует типу "умножение", генерируем ошибку с кодом 105
							throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text);
						}
						break; // Выход из текущего случая
					}

					case '/':
					{
						if (check(buffer, typeDel)) // Проверка, соответствует ли буфер типу "деление"
						{
							lex.lexema = LEX_DIRSLASH; // Установка типа лексемы как LEX_DIRSLASH (двойной слэш или другой тип деления)
							lex.sn = line; // Установка номера строки, где находится лексема
							lex.idxTI = -1; // Инициализация индекса таблицы идентификаторов как -1 (не определен)
							// lex.sn++; // Закомментированная строка, возможно, использовалась для инкрементации номера строки
							LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу
						}
						else
						{
							// Если буфер не соответствует типу "деление", генерируем ошибку с кодом 105
							throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text);
						}
						break; // Выход из текущего случая
					}

					case '(':
					{
						if (check(buffer, typeLeftThesis)) // Проверка, соответствует ли буфер типу "левая скобка"
						{
							lex.lexema = LEX_LEFTHESIS; // Установка типа лексемы как LEX_LEFTHESIS
							lex.sn = line; // Установка номера строки, где находится лексема
							// lex.sn++; // Закомментированная строка, возможно, использовалась для инкрементации номера строки
							lex.idxTI = -1; // Инициализация индекса таблицы идентификаторов как -1 (не определен)
							LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу
						}
						else
						{
							// Если буфер не соответствует типу "левая скобка", генерируем ошибку с кодом 105
							throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text);
						}
						break; // Выход из текущего случая
					}

					case ')':
					{
						if (check(buffer, typeRightThesis)) // Проверка, соответствует ли буфер типу "правая скобка"
						{
							lex.lexema = LEX_RIGHTHESIS; // Установка типа лексемы как LEX_RIGHTHESIS
							lex.sn = line; // Установка номера строки, где находится лексема
							// lex.sn++; // Закомментированная строка, возможно, использовалась для инкрементации номера строки
							lex.idxTI = -1; // Инициализация индекса таблицы идентификаторов как -1 (не определен)
							LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу
						}
						else
						{
							// Если буфер не соответствует типу "правая скобка", генерируем ошибку с кодом 105
							throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text);
						}
						break; // Выход из текущего случая
					}

					case '{':
					{
						if (check(buffer, typeLeftBrace)) // Проверка, соответствует ли буфер типу "левая фигурная скобка"
						{
							lex.lexema = LEX_LEFTBRACE; // Установка типа лексемы как LEX_LEFTBRACE
							lex.sn = line; // Установка номера строки, где находится лексема
							lex.idxTI = -1; // Инициализация индекса таблицы идентификаторов как -1 (не определен)
							LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу
						}
						else
						{
							// Если буфер не соответствует типу "левая фигурная скобка", генерируем ошибку с кодом 105
							throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text);
						}
						break; // Выход из текущего случая
					}

					case '}':
					{
						if (check(buffer, typeRightBrace)) // Проверка, соответствует ли буфер типу "правая фигурная скобка"
						{
							lex.lexema = LEX_RIGHTBRACE; // Установка типа лексемы как LEX_RIGHTBRACE
							lex.sn = line; // Установка номера строки, где находится лексема
							lex.idxTI = -1; // Инициализация индекса таблицы идентификаторов как -1 (не определен)
							LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу
						}
						else
						{
							// Если буфер не соответствует типу "правая фигурная скобка", генерируем ошибку с кодом 105
							throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text);
						}
						break; // Выход из текущего случая
					}

					case ',':
					{
						if (check(buffer, typeComma)) // Проверка, соответствует ли буфер типу "запятая"
						{
							lex.lexema = LEX_COMMA; // Установка типа лексемы как LEX_COMMA
							lex.sn = line; // Установка номера строки, где находится лексема
							lex.idxTI = -1; // Инициализация индекса таблицы идентификаторов как -1 (не определен)
							LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу
						}
						else
						{
							// Если буфер не соответствует типу "запятая", генерируем ошибку с кодом 117
							throw ERROR_THROW_IN(117, ++line, ++pos, buff, in.text);
						}
						break; // Выход из текущего случая
					}

					case ';':
					{
						if (check(buffer, typeSemicolon)) // Проверка, соответствует ли буфер типу "точка с запятой"
						{
							lex.lexema = LEX_SEMICOLON; // Установка типа лексемы как LEX_SEMICOLON
							lex.sn = line; // Установка номера строки, где находится лексема
							lex.idxTI = -1; // Инициализация индекса таблицы идентификаторов как -1 (не определен)
							LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу
						}
						else
						{
							// Если буфер не соответствует типу "точка с запятой", генерируем ошибку с кодом 105
							throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text);
						}
						break; // Выход из текущего случая
					}

					case '=':
					{
						if (check(buffer, typeEquals)) // Проверка, соответствует ли буфер типу "равно"
						{
							lex.lexema = LEX_RAV; // Установка типа лексемы как LEX_RAV (равно)
							lex.sn = line; // Установка номера строки, где находится лексема
							lex.idxTI = -1; // Инициализация индекса таблицы идентификаторов как -1 (не определен)
							LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу
						}
						else
						{
							// Если буфер не соответствует типу "равно", генерируем ошибку с кодом 105
							throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text);
						}
						break; // Выход из текущего случая
					}

					default:
					{
						// Если символ не соответствует ни одному из известных типов, генерируем ошибку с кодом 105
						throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text);
						break; // Выход из текущего случая (необязательно, так как throw уже прерывает выполнение)
					}
					} // Конец оператора switch
					buffer.clear(); // Очистка буфера после обработки текущего символа
				}
				else
				{
					// Если текущий символ не разделитель, добавляем его к текущей лексеме (слову)
					word += (unsigned char)buff[pos];
					char k = buff[pos + 1];
					// Если следующий символ - разделитель, проверяем, какой это тип лексемы
					if (separators.find(buff[pos + 1]) != std::string::npos)
					{
						switch ((unsigned char)word[0]) // Переключение по первому символу слова
						{
						case 'i':
						{
							// Если это начало слова, начинающегося на 'i'
							if (check(word, typeInteger)) // Проверка, соответствует ли слово типу "integer"
							{
								// Если слово соответствует типу "integer", добавляем соответствующую лексему
								lex.lexema = LEX_INTEGER; // Установка типа лексемы как LEX_INTEGER
								lex.sn = line; // Установка номера строки
								lex.idxTI = -1; // Инициализация индекса таблицы идентификаторов как -1 (не определен)
								lex.comm = word; // Установка комментария или значения лексемы
								LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу

								word.clear(); // Очистка текущего слова для обработки следующего
							}
							else if (check(word, typeIdentificator)) // Проверка, является ли слово идентификатором
							{
								// Если это идентификатор, обрабатываем его
								addIdentificator(lextable, idtable, word, lex, line); // Добавление идентификатора в таблицы

								word.clear(); // Очистка текущего слова для обработки следующего
							}
							else
							{
								// Если слово не соответствует ни одному из ожидаемых типов, выбрасываем ошибку
								throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text); // Генерация ошибки с кодом 105 и дополнительной информацией
							}

							break; // Выход из текущего случая
						}
						case 'd':
						{
							if (check(word, typeDeclare)) // Проверка, соответствует ли слово типу "declare"
							{
								lex.lexema = LEX_DECLARE; // Установка типа лексемы как LEX_DECLARE
								lex.sn = line; // Установка номера строки
								lex.idxTI = -1; // Инициализация индекса таблицы идентификаторов как -1 (не определен)
								// lex.sn++; // Закомментированная строка, возможно, использовалась ранее для инкрементации номера строки
								LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу

								word.clear(); // Очистка текущего слова для обработки следующего
							}
							else if (check(word, typeIdentificator)) // Проверка, является ли слово идентификатором
							{
								addIdentificator(lextable, idtable, word, lex, line); // Добавление идентификатора в таблицы

								word.clear(); // Очистка текущего слова для обработки следующего
							}
							else
							{
								throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text); // Генерация ошибки с кодом 105 и дополнительной информацией
							}
							break; // Выход из текущего случая
						}

						case 's':
						{
							if (check(word, typeString)) // Проверка, соответствует ли слово типу "string"
							{
								lex.lexema = LEX_STRING; // Установка типа лексемы как LEX_STRING
								lex.sn = line; // Установка номера строки
								lex.idxTI = -1; // Инициализация индекса таблицы идентификаторов как -1 (не определен)
								lex.comm = word; // Установка комментария или значения лексемы
								LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу

								word.clear(); // Очистка текущего слова для обработки следующего
							}
							else if (check(word, typeIdentificator)) // Проверка, является ли слово идентификатором
							{
								addIdentificator(lextable, idtable, word, lex, line); // Добавление идентификатора в таблицы

								word.clear(); // Очистка текущего слова для обработки следующего
							}
							else
							{
								throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text); // Генерация ошибки с кодом 105 и дополнительной информацией
							}
							break; // Выход из текущего случая
						}
						case 'f':
						{
							if (check(word, typeFunction)) // Проверка, соответствует ли слово типу "function"
							{
								lex.lexema = LEX_FUNCTION; // Установка типа лексемы как LEX_FUNCTION
								lex.sn = line; // Установка номера строки
								lex.idxTI = -1; // Инициализация индекса таблицы идентификаторов как -1 (не определен)
								lex.comm = word; // Установка комментария или значения лексемы
								LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу

								word.clear(); // Очистка текущего слова для обработки следующего
							}
							else if (check(word, typeIdentificator)) // Проверка, является ли слово идентификатором
							{
								addIdentificator(lextable, idtable, word, lex, line); // Добавление идентификатора в таблицы

								word.clear(); // Очистка текущего слова для обработки следующего
							}
							else
							{
								throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text); // Генерация ошибки с кодом 105 и дополнительной информацией
							}
							break; // Выход из текущего случая
						}

						case 'm':
						{
							if (check(word, typeMain)) // Проверка, соответствует ли слово типу "main"
							{
								lex.lexema = LEX_MAINFUNC; // Установка типа лексемы как LEX_MAINFUNC
								lex.sn = line; // Установка номера строки
								lex.idxTI = -1; // Инициализация индекса таблицы идентификаторов как -1 (не определен)
								lex.comm = word; // Установка комментария или значения лексемы
								LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу

								word.clear(); // Очистка текущего слова для обработки следующего
							}
							else if (check(word, typeIdentificator)) // Проверка, является ли слово идентификатором
							{
								addIdentificator(lextable, idtable, word, lex, line); // Добавление идентификатора в таблицы

								word.clear(); // Очистка текущего слова для обработки следующего
							}
							else
							{
								throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text); // Генерация ошибки с кодом 105 и дополнительной информацией
							}
							break; // Выход из текущего случая
						}
						case 'r':
						{
							if (check(word, typeReturn)) // Проверка, соответствует ли слово типу "return"
							{
								lex.lexema = LEX_RETURN; // Установка типа лексемы как LEX_RETURN
								lex.sn = line; // Установка номера строки
								lex.idxTI = -1; // Инициализация индекса таблицы идентификаторов как -1 (не определен)
								lex.comm = word; // Установка комментария или значения лексемы
								LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу

								word.clear(); // Очистка текущего слова для обработки следующего
							}
							else if (check(word, typeIdentificator)) // Проверка, является ли слово идентификатором
							{
								addIdentificator(lextable, idtable, word, lex, line); // Добавление идентификатора в таблицы

								word.clear(); // Очистка текущего слова для обработки следующего
							}
							else
							{
								throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text); // Генерация ошибки с кодом 105 и дополнительной информацией
							}
							break; // Выход из текущего случая
						}

						case 'p':
						{
							if (check(word, typePrint)) // Проверка, соответствует ли слово типу "print"
							{
								lex.lexema = LEX_PRINT; // Установка типа лексемы как LEX_PRINT
								lex.sn = line; // Установка номера строки
								lex.idxTI = -1; // Инициализация индекса таблицы идентификаторов как -1 (не определен)
								lex.comm = word; // Установка комментария или значения лексемы
								LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу

								word.clear(); // Очистка текущего слова для обработки следующего
							}
							else if (check(word, typeIdentificator)) // Проверка, является ли слово идентификатором
							{
								addIdentificator(lextable, idtable, word, lex, line); // Добавление идентификатора в таблицы

								word.clear(); // Очистка текущего слова для обработки следующего
							}
							else
							{
								throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text); // Генерация ошибки с кодом 105 и дополнительной информацией
							}
							break; // Выход из текущего случая
						}

						default:
						{
							if (check(word, typeNumbLiteral)) // Проверка, является ли слово числовым литералом
							{
								int i = IT::findLexInteger(idtable, stoi(word)); // Поиск целочисленного значения в таблице идентификаторов
								lex.lexema = LEX_LITERAL; // Установка типа лексемы как LEX_LITERAL
								lex.sn = line; // Установка номера строки
								lex.comm = word; // Установка комментария или значения лексемы
								if (i != LT_TI_NULLIDX) // Если значение найдено в таблице идентификаторов
								{
									lex.idxTI = i; // Установка индекса таблицы идентификаторов
								}
								else
								{
									// Если значение не найдено, добавляем новый идентификатор
									idn.id = "L" + std::to_string(count); // Формирование нового имени идентификатора
									idn.iddatatype = IT::INT; // Установка типа данных как INT
									idn.idtype = IT::L; // Установка типа идентификатора как локальная переменная

									idn.idxfirstLE = lextable.size; // Установка индекса первого элемента лексической таблицы

									lex.idxTI = idtable.size; // Установка индекса таблицы идентификаторов

									idn.value.setInteger(stoi(word)); // Установка значения идентификатора
									count++; // Инкремент счетчика идентификаторов
									IT::Add(idtable, idn); // Добавление нового идентификатора в таблицу идентификаторов
								}
								LT::Add(lextable, lex); // Добавление лексемы в лексическую таблицу

								word.clear(); // Очистка текущего слова для обработки следующего
							}
							else if (check(word, typeIdentificator)) // Проверка, является ли слово идентификатором
							{
								addIdentificator(lextable, idtable, word, lex, line); // Добавление идентификатора в таблицы
								word.clear(); // Очистка текущего слова для обработки следующего
							}
							else
							{
								// Если слово не соответствует ни одному из ожидаемых типов, выбрасываем ошибку
								throw ERROR_THROW_IN(105, ++line, ++pos, buff, in.text); // Генерация ошибки с кодом 105 и дополнительной информацией
							}

							break; // Выход из текущего случая
						}
						}

					}

				}
			}

		}


		std::cout << "\n";

		std::cout << "\n\nТаблица идентификаторов:\n";
		std::cout << std::setfill(' ');

		for (int i = 0; i < lextable.size; i++) // Цикл по всем элементам лексической таблицы
		{
			(std::cout) << i << '\t' << "SN: " << lextable.table[i].sn << ", " // Вывод индекса и серийного номера
				<< "IdxTI: " << lextable.table[i].idxTI << ", " // Вывод индекса таблицы идентификаторов
				<< "Lexema: " << lextable.table[i].lexema << std::endl; // Вывод лексемы и переход на новую строку
		}

		std::cout << "\n"; // Вывод пустой строки для разделения

		std::cout << "\n\nТаблица идентификаторов:\n"; // Вывод заголовка таблицы идентификаторов

		// Вывод заголовков столбцов таблицы идентификаторов с выравниванием по левому краю и заданной шириной
		//std::cout << std::left << std::setw(20) << "Index"
		//	<< std::setw(20) << "Index FirstLE"
		//	<< std::setw(20) << "Identifier"
		//	<< std::setw(20) << "Function"
		//	<< std::setw(10) << "Type"
		//	<< std::setw(30) << "Value"
		//	<< std::setw(25) << "Function Name" << "\n";

		std::cout << std::setfill(' '); // Установка заполнителя пробелами для форматирования

		for (int i = 0; i < idtable.size; i++) { // Цикл по всем элементам таблицы идентификаторов
			std::string type; // Объявление строки для хранения типа данных
			switch (idtable.table[i].iddatatype) { // Определение типа данных идентификатора
			case IT::INT:
				type = "INT"; // Если тип INT
				break;
			case IT::STR:
				type = "STR"; // Если тип STR
				break;
			default:
				type = "Unknown"; // Если тип неизвестен
			}

			std::string idtype; // Объявление строки для хранения типа идентификатора
			switch (idtable.table[i].idtype) { // Определение типа идентификатора
			case IT::V:
				idtype = "Variable"; // Если тип переменная
				break;
			case IT::F:
				idtype = "Function"; // Если тип функция
				break;
			case IT::P:
				idtype = "Parameter"; // Если тип параметр
				break;
			case IT::L:
				idtype = "Local Variable"; // Если тип локальная переменная
				break;
			default:
				idtype = "Unknown"; // Если тип неизвестен
			}

			// Вывод заголовков столбцов для текущей строки (повторно, возможно, избыточно)
			std::cout << std::left << std::setw(20) << "Index"
				<< std::setw(20) << "IdxfirstLE"
				<< std::setw(15) << "ID"
				<< std::setw(15) << "Fun"
				<< std::setw(10) << "Type";

			// Если идентификатор не является функцией, вывод дополнительных полей
			if (idtable.table[i].idtype != IT::F) {
				if (idtable.table[i].iddatatype == IT::INT) {
					std::cout << std::setw(15) << "IntValue"; // Вывод заголовка для целочисленного значения
				}
				else if (idtable.table[i].iddatatype == IT::STR) {
					std::cout << std::setw(15) << "StrValue"; // Вывод заголовка для строкового значения
				}
			}
			else {
				std::cout << std::setw(15) << "-"; // Если функция, вывод дефиса вместо значения
			}

			std::cout << std::setw(30) << "Function Name" << "\n"; // Вывод заголовка для имени функции

			// Вывод данных текущей строки таблицы идентификаторов с выравниванием и заданной шириной
			std::cout << std::left << std::setw(20) << i // Вывод индекса
				<< std::setw(20) << idtable.table[i].idxfirstLE // Вывод индекса первого элемента лексической таблицы
				<< std::setw(15) << idtable.table[i].id // Вывод идентификатора
				<< std::setw(15) << idtable.table[i].fun // Вывод функции
				<< std::setw(10) << type; // Вывод типа данных

			if (idtable.table[i].idtype != IT::F) { // Если идентификатор не является функцией
				if (idtable.table[i].iddatatype == IT::INT) {
					std::cout << std::setw(15) << idtable.table[i].value.vint; // Вывод целочисленного значения
				}
				else if (idtable.table[i].iddatatype == IT::STR) {
					std::cout << std::setw(15) << idtable.table[i].value.vstr; // Вывод строкового значения
				}
			}
			else {
				std::cout << std::setw(15) << "-"; // Если функция, вывод дефиса вместо значения
			}

			std::cout << std::setw(30) << idtable.table[i].functionname << "\n"; // Вывод имени функции
		}

		std::cout << '\n'; // Вывод пустой строки для завершения вывода

	} // Закрытие функции или области видимости
} // Закрытие пространства имен или класса

