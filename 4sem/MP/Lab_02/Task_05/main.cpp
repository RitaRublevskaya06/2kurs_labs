#include <iostream>
#include "Combi.h"
#include "Knapsack.h"
#include <ctime>
#define NN 18  // количество типов предметов

int main()
{
    setlocale(LC_ALL, "rus");

    int V = 300,                // вместимость рюкзака              
        v[] = { 25, 30, 60, 20, 21, 14, 36, 85, 45, 35, 74, 58, 67, 25, 19, 46, 36, 89, 51, 101 },     // размер предмета каждого типа  
        c[] = { 25, 10, 20, 30, 5, 15, 55, 36, 47, 50, 32, 52, 12, 11, 30, 40, 7, 21, 24, 50 };     // стоимость предмета каждого типа 
    short m[NN];                // количество предметов каждого типа  {0,1}   

    clock_t  t1 = 0, t2 = 0;
    t1 = clock();
    int maxcc = knapsack_s( V, NN, v, c, m);
    t2 = clock();

    std::cout << "-------- Задача о рюкзаке --------- " << std::endl;
    std::cout << std::endl << "- количество предметов : " << NN;
    std::cout << std::endl << "- вместимость рюкзака  : " << V;
    std::cout << std::endl << "- размеры предметов    : ";
    for (int i = 0; i < NN; i++) std::cout << v[i] << " ";
    std::cout << std::endl << "- стоимости предметов  : ";
    for (int i = 0; i < NN; i++) std::cout << v[i] * c[i] << " ";
    std::cout << std::endl << "- оптимальная стоимость рюкзака: " << maxcc;
    std::cout << std::endl << "- вес рюкзака: ";
    int s = 0; for (int i = 0; i < NN; i++) s += m[i] * v[i];
    std::cout << s;
    std::cout << std::endl << "- выбраны предметы: ";
    for (int i = 0; i < NN; i++) std::cout << " " << m[i];
    std::cout << std::endl << std::endl;
    std::cout << std::endl << "продолжительность (у.е):   " << (t2 - t1);
    std::cout << std::endl << "                  (сек):   "
        << ((double)(t2 - t1)) / ((double)CLOCKS_PER_SEC);
    std::cout << std::endl;

    system("pause");
    return 0;
}