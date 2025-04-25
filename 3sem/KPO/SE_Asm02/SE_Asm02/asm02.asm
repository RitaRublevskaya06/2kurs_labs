.586P                  
.MODEL FLAT, STDCALL           
includelib kernel32.lib  
includelib user32.lib

ExitProcess PROTO : DWORD               
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, :DWORD

.STACK 4096
      
.DATA
    op1 DWORD 5
    op2 DWORD 2
    result DWORD ?
    
    header DB "Plus", 0
    text DB "Результат сложения = ", 0 

    MB_OK EQU 0
    HW DD ?  

.CODE
main PROC
    START:
   
    mov eax, op1     
    add eax, op2      
    add eax, '0'
    add [text+21], al 

    INVOKE MessageBoxA, HW, OFFSET text, OFFSET header, MB_OK

    INVOKE ExitProcess, 0
main ENDP

END main             