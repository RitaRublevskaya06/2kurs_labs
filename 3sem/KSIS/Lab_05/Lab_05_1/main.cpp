#include <iostream>
#include <winsock2.h>
#include <iphlpapi.h>
#include <icmpapi.h>
#include <sstream>
#pragma comment(lib, "iphlpapi.lib")
#pragma comment(lib, "ws2_32.lib")

#pragma warning(disable:4996) // ���������� �������
#define IP_STATUS_BASE 11000 
#define IP_SUCCESS 0
#define IP_DEST_NET_UNREACHABLE 11002
#define IP_DEST_HOST_UNREACHABLE 11003 
#define IP_DEST_PROT_UNREACHABLE 11004
#define IP_DEST_PORT_UNREACHABLE 11005
#define IP_REQ_TIMED_OUT 11010 
#define IP_BAD_REQ 11011
#define IP_BAD_ROUTE 11012
#define IP_TTL_EXPIRED_TRANSIT 11013
IP_OPTION_INFORMATION option = { 255, 255, 240, 0, 0 };//����� ��� ��������� � ��������� IP ������ 

using namespace std;


// ������ �������� � ����� �����, ������� ����� �����������, 
// ������ � ����� �������� ������ (� ��) ����� �������, 
// ������ � ���������� ���������� ��������
void Ping(const char* cHost, unsigned int Timeout, unsigned int RequestCount)
{
    // ������� ���� �������
    HANDLE hIP = IcmpCreateFile();

    if (hIP == INVALID_HANDLE_VALUE)
    {
        WSACleanup();
        return;
    }

    char SendData[32] = "Data for ping";//����� ��� ��������
    int LostPacketsCount = 0; // ���-�� ���������� �������
    unsigned int MaxMS = 0;// ������������ ����� ������ (��)
    int MinMS = -1; // ����������� ����� ������ (��)

    // �������� ������ ��� ����� � ����� ������

    PICMP_ECHO_REPLY pIpe =
        (PICMP_ECHO_REPLY)GlobalAlloc(GHND,
            sizeof(ICMP_ECHO_REPLY) + sizeof(SendData));

    if (pIpe == 0) {
        IcmpCloseHandle(hIP);
        WSACleanup();
        return;
    }

    pIpe->Data = SendData;
    pIpe->DataSize = sizeof(SendData);
    unsigned long ipaddr = inet_addr(cHost);


    for (unsigned int c = 0; c < RequestCount; c++)
    {
        int dwStatus = IcmpSendEcho(hIP,
            ipaddr,
            SendData,
            sizeof(SendData),
            &option,
            pIpe,
            sizeof(ICMP_ECHO_REPLY) +
            sizeof(SendData),
            Timeout);

        if (dwStatus > 0)
        {
            for (int i = 0; i < dwStatus; i++)
            {
                unsigned char* pIpPtr =
                    (unsigned char*)&pIpe->Address;
                cout << "����� �� " << (int)*(pIpPtr)
                    << "." << (int)*(pIpPtr + 1)
                    << "." << (int)*(pIpPtr + 2)
                    << "." << (int)*(pIpPtr + 3)
                    << ": ����� ���� = " << pIpe->DataSize
                    << " ����� = " << pIpe->RoundTripTime
                    << "�� TTL = " << (int)pIpe->Options.Ttl;
                MaxMS = (MaxMS > pIpe->RoundTripTime) ?
                    MaxMS : pIpe->RoundTripTime;
                MinMS = (MinMS < (int)pIpe->RoundTripTime
                    && MinMS >= 0) ?
                    MinMS : pIpe->RoundTripTime;
                cout << endl;
            }
        }
        else
        {
            if (pIpe->Status)
            {
                LostPacketsCount++;
                switch (pIpe->Status)
                {
                case IP_DEST_NET_UNREACHABLE:
                case IP_DEST_HOST_UNREACHABLE:
                case IP_DEST_PROT_UNREACHABLE:
                case IP_DEST_PORT_UNREACHABLE:
                    cout << "Remote host may be down." << endl;
                    break;
                case IP_REQ_TIMED_OUT:
                    cout << "Request timed out." << endl;
                    break;
                case IP_TTL_EXPIRED_TRANSIT:
                    cout << "TTL expired in transit." << endl;
                    break;
                default:
                    cout << "Error code: %ld"
                        << pIpe->Status << endl;
                    break;
                }
            }
        }
    }

    IcmpCloseHandle(hIP);
    WSACleanup();



    if (MinMS < 0) MinMS = 0;
    unsigned char* pByte = (unsigned char*)&pIpe->Address;
    cout << "���������� Ping "
        << (int)*(pByte)
        << "." << (int)*(pByte + 1)
        << "." << (int)*(pByte + 2)
        << "." << (int)*(pByte + 3) << endl;
    cout << "\t�������: ���������� = " << RequestCount
        << ", ������� = "
        << RequestCount - LostPacketsCount
        << ", �������� = " << LostPacketsCount
        << "<" << (int)(100 / (float)RequestCount) *
        LostPacketsCount
        << " % ������>, " << endl;
    cout << "��������������� ����� ������-��������:"
        << endl << "\t����������� = " << MinMS
        << "��, ������������ = " << MaxMS
        << "��, ������� = " << (MaxMS + MinMS) / 2
        << "��" << endl;
}

int main(int argc, char** argv)
{
    setlocale(LC_ALL, "RUS");
    char hostIp[80];
    unsigned int ms;
    unsigned int reqNumber;
    cout << "������� ����� �����" << endl;
    cin >> hostIp;
    cout << "������� ����� �������� ������ � ��" << endl;
    cin >> ms;
    cout << "������� ���������� ��������" << endl;
    cin >> reqNumber;
    Ping(hostIp, ms, reqNumber);
    return 0;
}

