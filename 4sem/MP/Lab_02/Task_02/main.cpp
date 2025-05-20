#include <iostream>
#include "Combi.h"

int main()
{
    setlocale(LC_ALL, "rus");

    char  AA[][2] = { "A", "B", "C", "D", "E" };

    std::cout  << " --- Генератор сочетаний ---" << std::endl;
    std::cout << std::endl << "Исходное множество: ";

    std::cout << "{ ";
    for (int i = 0; i < sizeof(AA) / 2; i++)

        std::cout << AA[i] << ((i < sizeof(AA) / 2 - 1) ? ", " : " ");
    std::cout << "}";

    std::cout << std::endl << "Генерация сочетаний ";

    combi::xcombination xc(sizeof(AA) / 2, 3);
    std::cout << "из " << xc.n << " по " << xc.m;
    int  n = xc.getfirst();

    while (n >= 0)
    {

        std::cout << std::endl << xc.nc << ": { ";

        for (int i = 0; i < n; i++)


            std::cout << AA[xc.ntx(i)] << ((i < n - 1) ? ", " : " ");

        std::cout << "}";

        n = xc.getnext();
    };

    std::cout << std::endl << "Всего: " << xc.count() << std::endl;

    system("pause");

    return 0;
}
