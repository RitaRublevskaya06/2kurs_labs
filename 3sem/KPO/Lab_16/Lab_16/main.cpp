#include "FST.h"
#include <tchar.h>
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "rus");
	FST::FST fst0(			// ������������������ �������� ������� (a+b)*aba
		(char*)"aabbabaaba",					// ������� ��� �������������
		4,										// ���������� ��������
		FST::NODE(3, FST::RELATION('a', 0), FST::RELATION('b', 0), FST::RELATION('a', 1)),	// ��������� 0 (���������)
		FST::NODE(1, FST::RELATION('b', 2)),												// ��������� 1
		FST::NODE(1, FST::RELATION('a', 3)),												// ��������� 2
		FST::NODE()																			// ��������� 3 (��������)
	);
	if (FST::execute(fst0))
		cout << "������� " << fst0.string << " ����������" << endl;
	else
		cout << "������� " << fst0.string << " �� ����������" << endl;


	FST::FST fst1(
		(char*)"abbf",
		12,
		FST::NODE(1, FST::RELATION('a', 1)), // 0
		FST::NODE(1, FST::RELATION('b', 2)),  // 1
		FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('b', 2), FST::RELATION('b', 10)), // 2
		FST::NODE(1, FST::RELATION('g', 4)), // 3 
		FST::NODE(3, FST::RELATION('b', 5), FST::RELATION('b', 7), FST::RELATION('d', 6)), // 4
		FST::NODE(3, FST::RELATION('b', 5), FST::RELATION('b', 7), FST::RELATION('d', 6)), // 5
		FST::NODE(1, FST::RELATION('g', 9)), // 6 
		FST::NODE(2, FST::RELATION('b', 7), FST::RELATION('e', 8)), // 7
		FST::NODE(2, FST::RELATION('e', 8), FST::RELATION('g', 9)), // 8
		FST::NODE(1, FST::RELATION('b', 10)), //9 
		FST::NODE(2, FST::RELATION('b', 10), FST::RELATION('f', 11)), // 10
		FST::NODE() // 11
	);
	if (FST::execute(fst1))
		cout << "������� " << fst1.string << " ����������" << endl;
	else
		cout << "������� " << fst1.string << " �� ����������" << endl;

	FST::FST fst2(
		(char*)"abbbf",
		12,
		FST::NODE(1, FST::RELATION('a', 1)), // 0
		FST::NODE(1, FST::RELATION('b', 2)),  // 1
		FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('b', 2), FST::RELATION('b', 10)), // 2
		FST::NODE(1, FST::RELATION('g', 4)), // 3 
		FST::NODE(3, FST::RELATION('b', 5), FST::RELATION('b', 7), FST::RELATION('d', 6)), // 4
		FST::NODE(3, FST::RELATION('b', 5), FST::RELATION('b', 7), FST::RELATION('d', 6)), // 5
		FST::NODE(1, FST::RELATION('g', 9)), // 6 
		FST::NODE(2, FST::RELATION('b', 7), FST::RELATION('e', 8)), // 7
		FST::NODE(2, FST::RELATION('e', 8), FST::RELATION('g', 9)), // 8
		FST::NODE(1, FST::RELATION('b', 10)), //9 
		FST::NODE(2, FST::RELATION('b', 10), FST::RELATION('f', 11)), // 10
		FST::NODE() // 11
	);
	if (FST::execute(fst2))
		cout << "������� " << fst2.string << " ����������" << endl;
	else
		cout << "������� " << fst2.string << " �� ����������" << endl;

	FST::FST fst3(
		(char*)"abbbbf",
		12,
		FST::NODE(1, FST::RELATION('a', 1)), // 0
		FST::NODE(1, FST::RELATION('b', 2)),  // 1
		FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('b', 2), FST::RELATION('b', 10)), // 2
		FST::NODE(1, FST::RELATION('g', 4)), // 3 
		FST::NODE(3, FST::RELATION('b', 5), FST::RELATION('b', 7), FST::RELATION('d', 6)), // 4
		FST::NODE(3, FST::RELATION('b', 5), FST::RELATION('b', 7), FST::RELATION('d', 6)), // 5
		FST::NODE(1, FST::RELATION('g', 9)), // 6 
		FST::NODE(2, FST::RELATION('b', 7), FST::RELATION('e', 8)), // 7
		FST::NODE(2, FST::RELATION('e', 8), FST::RELATION('g', 9)), // 8
		FST::NODE(1, FST::RELATION('b', 10)), //9 
		FST::NODE(2, FST::RELATION('b', 10), FST::RELATION('f', 11)), // 10
		FST::NODE() // 11
	);
	if (FST::execute(fst3))
		cout << "������� " << fst3.string << " ����������" << endl;
	else
		cout << "������� " << fst3.string << " �� ����������" << endl;

	FST::FST fst4(
		/*(char*)"abcgbegbf",*/
		(char*)"abbbcgbbdgcgbbbeeegbbbf",
		12,
		FST::NODE(1, FST::RELATION('a', 1)), // 0
		FST::NODE(1, FST::RELATION('b', 2)),  // 1
		FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('b', 2), FST::RELATION('b', 10)), // 2
		FST::NODE(1, FST::RELATION('g', 4)), // 3 
		FST::NODE(3, FST::RELATION('b', 5), FST::RELATION('b', 7), FST::RELATION('d', 6)), // 4
		FST::NODE(3, FST::RELATION('b', 5), FST::RELATION('b', 7), FST::RELATION('d', 6)), // 5
		FST::NODE(1, FST::RELATION('g', 9)), // 6 
		FST::NODE(2, FST::RELATION('b', 7), FST::RELATION('e', 8)), // 7
		FST::NODE(2, FST::RELATION('e', 8), FST::RELATION('g', 9)), // 8
		FST::NODE(2, FST::RELATION('b', 10), FST::RELATION('c', 3)), //9 
		FST::NODE(2, FST::RELATION('b', 10), FST::RELATION('f', 11)), // 10
		FST::NODE() // 11
	);
	if (FST::execute(fst4))
		cout << "������� " << fst4.string << " ����������" << endl;
	else
		cout << "������� " << fst4.string << " �� ����������" << endl;

	FST::FST fst5(
		(char*)"abcgdgcgdgbf",
		12,
		FST::NODE(1, FST::RELATION('a', 1)), // 0
		FST::NODE(1, FST::RELATION('b', 2)),  // 1
		FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('b', 2), FST::RELATION('b', 10)), // 2
		FST::NODE(1, FST::RELATION('g', 4)), // 3 
		FST::NODE(3, FST::RELATION('b', 5), FST::RELATION('b', 7), FST::RELATION('d', 6)), // 4
		FST::NODE(3, FST::RELATION('b', 5), FST::RELATION('b', 7), FST::RELATION('d', 6)), // 5
		FST::NODE(1, FST::RELATION('g', 9)), // 6 
		FST::NODE(2, FST::RELATION('b', 7), FST::RELATION('e', 8)), // 7
		FST::NODE(2, FST::RELATION('e', 8), FST::RELATION('g', 9)), // 8
		FST::NODE(2, FST::RELATION('b', 10), FST::RELATION('c', 3)), //9 
		FST::NODE(2, FST::RELATION('b', 10), FST::RELATION('f', 11)), // 10
		FST::NODE() // 11
	);
	if (FST::execute(fst5))
		cout << "������� " << fst5.string << " ����������" << endl;
	else
		cout << "������� " << fst5.string << " �� ����������" << endl;

	FST::FST fst6(
		(char*)"abcgbbbbegbf",
		12,
		FST::NODE(1, FST::RELATION('a', 1)), // 0
		FST::NODE(1, FST::RELATION('b', 2)),  // 1
		FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('b', 2), FST::RELATION('b', 10)), // 2
		FST::NODE(1, FST::RELATION('g', 4)), // 3 
		FST::NODE(3, FST::RELATION('b', 5), FST::RELATION('b', 7), FST::RELATION('d', 6)), // 4
		FST::NODE(3, FST::RELATION('b', 5), FST::RELATION('b', 7), FST::RELATION('d', 6)), // 5
		FST::NODE(1, FST::RELATION('g', 9)), // 6 
		FST::NODE(2, FST::RELATION('b', 7), FST::RELATION('e', 8)), // 7
		FST::NODE(2, FST::RELATION('e', 8), FST::RELATION('g', 9)), // 8
		FST::NODE(2, FST::RELATION('b', 10), FST::RELATION('c', 3)), //9  
		FST::NODE(2, FST::RELATION('b', 10), FST::RELATION('f', 11)), // 10
		FST::NODE() // 11
	);
	if (FST::execute(fst6))
		cout << "������� " << fst6.string << " ����������" << endl;
	else
		cout << "������� " << fst6.string << " �� ����������" << endl;

	FST::FST fst7(
		(char*)"abbcgbdgbf",
		12,
		FST::NODE(1, FST::RELATION('a', 1)), // 0
		FST::NODE(1, FST::RELATION('b', 2)),  // 1
		FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('b', 2), FST::RELATION('b', 10)), // 2
		FST::NODE(1, FST::RELATION('g', 4)), // 3 
		FST::NODE(3, FST::RELATION('b', 5), FST::RELATION('b', 7), FST::RELATION('d', 6)), // 4
		FST::NODE(3, FST::RELATION('b', 5), FST::RELATION('b', 7), FST::RELATION('d', 6)), // 5
		FST::NODE(1, FST::RELATION('g', 9)), // 6 
		FST::NODE(2, FST::RELATION('b', 7), FST::RELATION('e', 8)), // 7
		FST::NODE(2, FST::RELATION('e', 8), FST::RELATION('g', 9)), // 8
		FST::NODE(2, FST::RELATION('b', 10), FST::RELATION('c', 3)), //9 
		FST::NODE(2, FST::RELATION('b', 10), FST::RELATION('f', 11)), // 10
		FST::NODE() // 11
	);
	if (FST::execute(fst7))
		cout << "������� " << fst7.string << " ����������" << endl;
	else
		cout << "������� " << fst7.string << " �� ����������" << endl;

	FST::FST fst8(
		(char*)"bcdfdf",
		12,
		FST::NODE(1, FST::RELATION('a', 1)), // 0
		FST::NODE(1, FST::RELATION('b', 2)),  // 1
		FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('b', 2), FST::RELATION('b', 10)), // 2
		FST::NODE(1, FST::RELATION('g', 4)), // 3 
		FST::NODE(3, FST::RELATION('b', 5), FST::RELATION('b', 7), FST::RELATION('d', 6)), // 4
		FST::NODE(3, FST::RELATION('b', 5), FST::RELATION('b', 7), FST::RELATION('d', 6)), // 5
		FST::NODE(1, FST::RELATION('g', 9)), // 6 
		FST::NODE(2, FST::RELATION('b', 7), FST::RELATION('e', 8)), // 7
		FST::NODE(2, FST::RELATION('e', 8), FST::RELATION('g', 9)), // 8
		FST::NODE(2, FST::RELATION('b', 10), FST::RELATION('c', 3)), //9 
		FST::NODE(2, FST::RELATION('b', 10), FST::RELATION('f', 11)), // 10
		FST::NODE() // 11
	);
	if (FST::execute(fst8))
		cout << "������� " << fst8.string << " ����������" << endl;
	else
		cout << "������� " << fst8.string << " �� ����������" << endl;

	FST::FST fst9(
		(char*)"bbcgbdg",
		12,
		FST::NODE(1, FST::RELATION('a', 1)), // 0
		FST::NODE(1, FST::RELATION('b', 2)),  // 1
		FST::NODE(3, FST::RELATION('c', 3), FST::RELATION('b', 2), FST::RELATION('b', 10)), // 2
		FST::NODE(1, FST::RELATION('g', 4)), // 3 
		FST::NODE(3, FST::RELATION('b', 5), FST::RELATION('b', 7), FST::RELATION('d', 6)), // 4
		FST::NODE(3, FST::RELATION('b', 5), FST::RELATION('b', 7), FST::RELATION('d', 6)), // 5
		FST::NODE(1, FST::RELATION('g', 9)), // 6 
		FST::NODE(2, FST::RELATION('b', 7), FST::RELATION('e', 8)), // 7
		FST::NODE(2, FST::RELATION('e', 8), FST::RELATION('g', 9)), // 8
		FST::NODE(2, FST::RELATION('b', 10), FST::RELATION('c', 3)), //9 
		FST::NODE(2, FST::RELATION('b', 10), FST::RELATION('f', 11)), // 10
		FST::NODE() // 11
	);
	if (FST::execute(fst9))
		cout << "������� " << fst9.string << " ����������" << endl;
	else
		cout << "������� " << fst9.string << " �� ����������" << endl;
	
}