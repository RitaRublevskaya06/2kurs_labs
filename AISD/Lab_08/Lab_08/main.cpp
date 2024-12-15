#include <iostream>
#include <vector>
#include <algorithm>
#include <Windows.h>

using namespace std;

struct Item {
    string name;
    int weight;
    int price;
};

vector<Item> backpack(int capacity, vector<Item>& items) {
    int n = items.size();
    vector<vector<int>> dp(n + 1, vector<int>(capacity + 1, 0));
   
    for (int i = 1; i <= n; ++i) {
        for (int w = 1; w <= capacity; ++w) {
            if (items[i - 1].weight <= w) {
                dp[i][w] = max(dp[i - 1][w], dp[i - 1][w - items[i - 1].weight] + items[i - 1].price);
            }
            else {
                dp[i][w] = dp[i - 1][w];
            }
        }
    }

    vector<Item> selectedItems;
    int w = capacity;
    int i = n;
    while (i > 0 && w > 0) {
        if (dp[i][w] != dp[i - 1][w]) {
            selectedItems.push_back(items[i - 1]);
            w -= items[i - 1].weight;
        }
        i--;
    }

    return selectedItems;
}

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    int capacity;
    cout << "Введите вместимость рюкзака (N): ";
    cin >> capacity;

    vector<Item> items;
    int numItems;
    cout << "Введите количество товаров: ";
    cin >> numItems;

    for (int i = 0; i < numItems; ++i) {
        Item item;
        cout << "Название товара " << i + 1 << ": ";
        cin >> item.name;
        cout << "Вес " << i + 1 << ": ";
        cin >> item.weight;
        cout << "Стоимость " << i + 1 << ": ";
        cin >> item.price;
        items.push_back(item);
    }

    vector<Item> selectedItems = backpack(capacity, items);

    cout << "Предметы, положенные в рюкзак:\n";
    int totalValue = 0;
    for (const Item& item : selectedItems) {
        cout << " - " << item.name << " (вес: " << item.weight << ", стоимость: " << item.price << ")\n";
        totalValue += item.price;
    }

    cout << "Максимальная стоимость: " << totalValue << endl;

    return 0;
}
