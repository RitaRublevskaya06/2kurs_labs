#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <iostream>
#include <winsock2.h>
#include <iphlpapi.h>
#include <icmpapi.h>
#include <windows.h>
#include <locale.h>
#include <ws2tcpip.h>  // Для использования getaddrinfo
#pragma comment(lib, "ws2_32.lib")
#pragma comment(lib, "iphlpapi.lib")

using namespace std;

void Ping(const char* cHost, unsigned int Timeout, unsigned int RequestCount, unsigned char Ttl, unsigned char Tos) {
    HANDLE hIP = IcmpCreateFile();
    if (hIP == INVALID_HANDLE_VALUE) {
        cout << "Ошибка создания ICMP соединения." << endl;
        WSACleanup();
        return;
    }

    char SendData[32] = "Data for ping";
    int LostPacketsCount = 0;
    unsigned int MaxMS = 0;
    int MinMS = -1;

    PICMP_ECHO_REPLY pIpe = (PICMP_ECHO_REPLY)GlobalAlloc(GHND, sizeof(ICMP_ECHO_REPLY) + sizeof(SendData));
    if (pIpe == nullptr) {
        cout << "Ошибка выделения памяти." << endl;
        IcmpCloseHandle(hIP);
        WSACleanup();
        return;
    }

    pIpe->Data = SendData;
    pIpe->DataSize = sizeof(SendData);

    // Используем getaddrinfo для разрешения имени
    struct addrinfo hints = {};
    hints.ai_family = AF_INET;  // IPv4
    hints.ai_socktype = SOCK_STREAM;

    struct addrinfo* result = nullptr;
    int status = getaddrinfo(cHost, nullptr, &hints, &result);
    if (status != 0) {
        cout << "Ошибка разрешения доменного имени: " << gai_strerror(status) << endl;
        IcmpCloseHandle(hIP);
        WSACleanup();
        return;
    }

    // Получаем IP-адрес из результата
    struct sockaddr_in* sockaddr_ipv4 = (struct sockaddr_in*)result->ai_addr;
    unsigned long ipaddr = sockaddr_ipv4->sin_addr.S_un.S_addr;

    freeaddrinfo(result);  // Освобождаем память, выделенную для getaddrinfo

    // Установка параметров TTL и TOS
    IP_OPTION_INFORMATION option = { Ttl, Tos, 0, 0, 0 };

    for (unsigned int c = 0; c < RequestCount; c++) {
        int dwStatus = IcmpSendEcho(hIP, ipaddr, SendData, sizeof(SendData), &option, pIpe, sizeof(ICMP_ECHO_REPLY) + sizeof(SendData), Timeout);

        if (dwStatus > 0) {
            for (int i = 0; i < dwStatus; i++) {
                unsigned char* pIpPtr = (unsigned char*)&pIpe->Address;
                cout << "Ответ от " << (int)*(pIpPtr) << "." << (int)*(pIpPtr + 1) << "." << (int)*(pIpPtr + 2) << "." << (int)*(pIpPtr + 3)
                    << ": число байт = " << pIpe->DataSize << " время = " << pIpe->RoundTripTime << "мс TTL = " << (int)pIpe->Options.Ttl << endl;

                MaxMS = (MaxMS > pIpe->RoundTripTime) ? MaxMS : pIpe->RoundTripTime;
                MinMS = (MinMS < (int)pIpe->RoundTripTime && MinMS >= 0) ? MinMS : pIpe->RoundTripTime;
            }
        }
        else {
            LostPacketsCount++;
            cout << "Ошибка отправки пакета: " << pIpe->Status << endl;
        }
        cout << endl;
    }

    if (MinMS < 0) MinMS = 0;
    unsigned char* pByte = (unsigned char*)&pIpe->Address;
    cout << "Статистика Ping: " << (int)*(pByte) << "." << (int)*(pByte + 1) << "." << (int)*(pByte + 2) << "." << (int)*(pByte + 3) << endl;
    cout << "\tПакетов: отправлено = " << RequestCount << ", получено = " << RequestCount - LostPacketsCount
        << ", потеряно = " << LostPacketsCount << " <" << (int)(100.0 / RequestCount * LostPacketsCount) << "% потерь>" << endl;
    cout << "Приблизительное время приема-передачи:" << endl
        << "\tМинимальное = " << MinMS << "мс, Максимальное = " << MaxMS << "мс, Среднее = " << (MaxMS + MinMS) / 2 << "мс" << endl;

    IcmpCloseHandle(hIP);
    WSACleanup();
}

int main(int argc, char** argv) {
    setlocale(LC_ALL, "RUS");

    if (argc < 6) {
        cout << "Использование: " << argv[0] << " <адрес> <таймаут> <количество запросов> <TTL> <TOS>" << endl;
        return 1;
    }

    const char* cHost = argv[1];
    unsigned int Timeout = atoi(argv[2]);
    unsigned int RequestCount = atoi(argv[3]);
    unsigned char Ttl = (unsigned char)atoi(argv[4]);
    unsigned char Tos = (unsigned char)atoi(argv[5]);

    Ping(cHost, Timeout, RequestCount, Ttl, Tos);

    return 0;
}