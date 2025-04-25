.586P													;система команд(процессор Pantium)

.MODEL FLAT, STDCALL									
includelib kernel32.lib									

ExitProcess PROTO:DWORD									
MessageBoxA PROTO:DWORD, :DWORD, :DWORD, :DWORD			

.STACK 4096												

.CONST	
MB_OK EQU 0	

.DATA													
STR1 DB "Моя первая программа", 0						
STR2 DB "Привет всем!", 0								
HW   DD ?																							

.CODE													

main PROC												
START:													

	INVOKE MessageBoxA, HW, OFFSET STR2, OFFSET STR1, MB_OK
	INVOKE ExitProcess, -1
	;push - 1											
	;call ExitProcess									
main ENDP												

end main	