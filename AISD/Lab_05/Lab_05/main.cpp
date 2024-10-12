#include <iostream>
#include <algorithm>
#define I INT_MAX

using namespace std;

struct Edge
{
    int start;
    int end;
    int weight;
};

void Prims(int graphMatrix[8][8], int start)
{
    int x = start - 1;
    int y = 0;
    int visited[8];
    int currentEdge = 0;

    for (int i = 0; i < 8; i++)
    {
        visited[i] = false;
    }

    visited[x] = true;

    cout << "\nАлгоритм Прима:\n";
    int primEdges[7][2];

    while (currentEdge < 7)
    {
        x = 0;
        y = 0;
        int min = I;

        for (int i = 0; i < 8; i++)
        {
            if (visited[i])
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!visited[j])
                    {
                        if (min > graphMatrix[i][j])
                        {
                            min = graphMatrix[i][j];
                            x = i;
                            y = j;
                        }
                    }
                }
            }
        }

        visited[y] = true;

        primEdges[currentEdge][0] = x + 1;
        primEdges[currentEdge][1] = y + 1;
        currentEdge++;
    }

    for (int i = 0; i < 7; i++)
    {
        cout << "Вершина " << primEdges[i][0] << " -> " << "вершина " << primEdges[i][1] << "; вес - " << graphMatrix[primEdges[i][0] - 1][primEdges[i][1] - 1] << endl;
    }
}

bool isConnected(int connectedVert[8])
{
    int root = connectedVert[0];
    for (int i = 1; i < 8; i++)
    {
        if (connectedVert[i] != root)
        {
            return false;
        }
    }
    return true;
}


void Kruslals(Edge edgeList[], int n)
{
    int connectedVert[8];

    for (int i = 0; i < 8; i++)
    {
        connectedVert[i] = i;
    }

    sort(edgeList, edgeList + n, [](Edge& a, Edge& b) { return a.weight < b.weight; });

    cout << "\nАлгоритм Краскала(Крускала):\n";
    int kruskalEdges[7][2];
    int edgeCount = 0;
    for (int i = 0; i < n; i++)
    {
        Edge e = edgeList[i];

        if (connectedVert[e.start] != connectedVert[e.end])
        {
            kruskalEdges[edgeCount][0] = e.start + 1;
            kruskalEdges[edgeCount][1] = e.end + 1;
            edgeCount++;
            int oldVert = connectedVert[e.start];
            int newVert = connectedVert[e.end];

            for (int j = 0; j < 8; j++)
            {
                if (connectedVert[j] == oldVert)
                {
                    connectedVert[j] = newVert;
                }
            }
        }
    }


    for (int i = 0; i < edgeCount; i++)
    {
        int start = kruskalEdges[i][0];
        int end = kruskalEdges[i][1];
        int weight = 0;

        for (int j = 0; j < n; j++)
        {
            if ((edgeList[j].start == start - 1 && edgeList[j].end == end - 1) || (edgeList[j].start == end - 1 && edgeList[j].end == start - 1))
            {
                weight = edgeList[j].weight;
                break;
            }
        }
        cout << "Вершина " << start << " -> " << "вершина " << end << "; вес - " << weight << endl;
    }
}

int main()
{
    setlocale(LC_ALL, "Rus");

    int graphMatrix[8][8] =
    {
       // 1   2   3   4   5   6   7   8
         {I,  2,  I,  8,  2,  I,  I,  I}, // 1
         {2,  I,  3, 10,  5,  I,  I,  I}, // 2
         {I,  3,  I,  I, 12,  I,  I,  7}, // 3
         {8, 10,  I,  I, 14,  3,  1,  I}, // 4
         {2,  5, 12, 14,  I, 11,  4,  8}, // 5
         {I,  I,  I,  3, 11,  I,  6,  I}, // 6
         {I,  I,  I,  1,  4,  6,  I,  9}, // 7
         {I,  I,  7,  I,  8,  I,  9,  I}  // 8
    };

    Edge edgeList[] =
    {
        {0, 1, 2}, {0, 3, 8}, {6, 4, 4}, {0, 4, 2},
        {1, 2, 3}, {1, 4, 5}, {1, 3, 10}, {2, 4, 12},
        {2, 7, 7}, {3, 4, 14}, {3, 5, 3}, {3, 6, 1},
        {4, 7, 8}, {5, 6, 6}, {6, 7, 9}, {4, 5, 11}
    };

    int start;
    cout << "Введите начальную вершину для алгоритма Прима (1-8): ";
    cin >> start;

    Prims(graphMatrix, start);
    Kruslals(edgeList, sizeof(edgeList) / sizeof(edgeList[0]));

    return 0;
}