.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib
includelib user32.lib

ExitProcess PROTO :DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

.STACK 4096

.CONST

.DATA

 myBytes BYTE 10h, 20h, 30h, 40h                ; ����������� ������� ������
 myWords WORD 8Ah, 3Bh, 44h, 5Fh, 99h          ; ����������� ������� ����
 myDoubles DWORD 1, 2, 3, 4, 5, 6               ; ����������� ������� ������� ����
 myPointer DWORD myDoubles                       ; ��������� �� ������ myDoubles

 massive DWORD 1, 2, 3, 0, 5, 6, 7              ; ����������� ������� ����� �����
 sumOfElements DWORD 0                           ; ���������� ��� �������� ����� ��������� �������

 STR1 DB "���������� �. �., 2 ����, 10 ������", 0 ; ������ ��� ��������� ���������
 STR2 DB "���� ������� �������", 0               ; ������ ��� ��������� � ������� ����
 STR3 DB "�������� �������� �� �������", 0       ; ������ ��� ��������� �� ���������� ����

.CODE
main PROC
START: 
 mov ESI, 0                                      ; ������������� ������� ��� ������� � myDoubles
 mov EAX, myDoubles[ESI + 4]                     ; myDoubles[1] = 2, EAX = 2 (������ �������)
 mov EDX, [myDoubles + ESI]                      ; myDoubles[0] = 1, EDX = 1 (������ �������)
 
 ; ������������ ��������� ������� massive
 mov ESI, OFFSET massive                          ; ��������� �� ������ massive
 mov ECX, lengthof massive                        ; ����� �������
 mov EBX, 0                                       ; �� ��������� 0 (�������� �������� �� �������)

CYCLE:
 mov EAX, [ESI]                                  ; ��������� ������� ������� � EAX
 add sumOfElements, EAX                          ; ��������� ������� ������� � ����� ������
 cmp EAX, 0                                      ; ��������� ������� ������� �� ����
 jz ZERO                                         ; ���� ����, ������� � ����� ZERO
 add ESI, 4                                      ; ������� � ���������� �������� (4 ����� ��� DWORD)
 loop CYCLE                                      ; ��������� ECX � ��������� ����

 jmp ALLOK                                        ; ������� � ����� ALLOK ����� ���������� �����

ZERO:
 mov EBX, 1                                      ; ������ ������� �������
 add ESI, 4                                      ; ������� � ���������� �������� (���������� ��������)
 loop CYCLE                                      ; ���������� ���� ��� ���������� ���������

ALLOK:
 mov EAX, sumOfElements                                 ; ��������� ����� � EAX
 cmp EBX, 0                                             ; ���������, ������ �� ������� �������
 jz NO_ZERO                                             ; ���� �������� �������� �� �������, ������� � NO_ZERO
 INVOKE MessageBoxA, 0, OFFSET STR2, OFFSET STR1, 1     ; ���� ������� �������
 jmp END_PROGRAM                                        ; ������� � ���������� ���������

NO_ZERO:
 INVOKE MessageBoxA, 0, OFFSET STR3, OFFSET STR1, 1     ; ��� �������� ��������

END_PROGRAM:
 push -1                                         ; ���������� ���������
 call ExitProcess                                 ; ����� ������� ���������� ��������
main ENDP
end main
