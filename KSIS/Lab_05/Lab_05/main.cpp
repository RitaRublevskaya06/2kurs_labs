#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <iostream>
#include <winsock2.h>
#include <iphlpapi.h>
#include <icmpapi.h>
#include <windows.h>
#include <locale.h>
#include <ws2tcpip.h>  // ��� ������������� getaddrinfo
#pragma comment(lib, "ws2_32.lib")
#pragma comment(lib, "iphlpapi.lib")

using namespace std;

void Ping(const char* cHost, unsigned int Timeout, unsigned int RequestCount, unsigned char Ttl, unsigned char Tos) {
    HANDLE hIP = IcmpCreateFile();
    if (hIP == INVALID_HANDLE_VALUE) {
        cout << "������ �������� ICMP ����������." << endl;
        WSACleanup();
        return;
    }

    char SendData[32] = "Data for ping";
    int LostPacketsCount = 0;
    unsigned int MaxMS = 0;
    int MinMS = -1;

    PICMP_ECHO_REPLY pIpe = (PICMP_ECHO_REPLY)GlobalAlloc(GHND, sizeof(ICMP_ECHO_REPLY) + sizeof(SendData));
    if (pIpe == nullptr) {
        cout << "������ ��������� ������." << endl;
        IcmpCloseHandle(hIP);
        WSACleanup();
        return;
    }

    pIpe->Data = SendData;
    pIpe->DataSize = sizeof(SendData);

    // ���������� getaddrinfo ��� ���������� �����
    struct addrinfo hints = {};
    hints.ai_family = AF_INET;  // IPv4
    hints.ai_socktype = SOCK_STREAM;

    struct addrinfo* result = nullptr;
    int status = getaddrinfo(cHost, nullptr, &hints, &result);
    if (status != 0) {
        cout << "������ ���������� ��������� �����: " << gai_strerror(status) << endl;
        IcmpCloseHandle(hIP);
        WSACleanup();
        return;
    }

    // �������� IP-����� �� ����������
    struct sockaddr_in* sockaddr_ipv4 = (struct sockaddr_in*)result->ai_addr;
    unsigned long ipaddr = sockaddr_ipv4->sin_addr.S_un.S_addr;

    freeaddrinfo(result);  // ����������� ������, ���������� ��� getaddrinfo

    // ��������� ���������� TTL � TOS
    IP_OPTION_INFORMATION option = { Ttl, Tos, 0, 0, 0 };

    for (unsigned int c = 0; c < RequestCount; c++) {
        int dwStatus = IcmpSendEcho(hIP, ipaddr, SendData, sizeof(SendData), &option, pIpe, sizeof(ICMP_ECHO_REPLY) + sizeof(SendData), Timeout);

        if (dwStatus > 0) {
            for (int i = 0; i < dwStatus; i++) {
                unsigned char* pIpPtr = (unsigned char*)&pIpe->Address;
                cout << "����� �� " << (int)*(pIpPtr) << "." << (int)*(pIpPtr + 1) << "." << (int)*(pIpPtr + 2) << "." << (int)*(pIpPtr + 3)
                    << ": ����� ���� = " << pIpe->DataSize << " ����� = " << pIpe->RoundTripTime << "�� TTL = " << (int)pIpe->Options.Ttl << endl;

                MaxMS = (MaxMS > pIpe->RoundTripTime) ? MaxMS : pIpe->RoundTripTime;
                MinMS = (MinMS < (int)pIpe->RoundTripTime && MinMS >= 0) ? MinMS : pIpe->RoundTripTime;
            }
        }
        else {
            LostPacketsCount++;
            cout << "������ �������� ������: " << pIpe->Status << endl;
        }
        cout << endl;
    }

    if (MinMS < 0) MinMS = 0;
    unsigned char* pByte = (unsigned char*)&pIpe->Address;
    cout << "���������� Ping: " << (int)*(pByte) << "." << (int)*(pByte + 1) << "." << (int)*(pByte + 2) << "." << (int)*(pByte + 3) << endl;
    cout << "\t�������: ���������� = " << RequestCount << ", �������� = " << RequestCount - LostPacketsCount
        << ", �������� = " << LostPacketsCount << " <" << (int)(100.0 / RequestCount * LostPacketsCount) << "% ������>" << endl;
    cout << "��������������� ����� ������-��������:" << endl
        << "\t����������� = " << MinMS << "��, ������������ = " << MaxMS << "��, ������� = " << (MaxMS + MinMS) / 2 << "��" << endl;

    IcmpCloseHandle(hIP);
    WSACleanup();
}

int main(int argc, char** argv) {
    setlocale(LC_ALL, "RUS");

    if (argc < 6) {
        cout << "�������������: " << argv[0] << " <�����> <�������> <���������� ��������> <TTL> <TOS>" << endl;
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