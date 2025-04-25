.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib
includelib user32.lib

ExitProcess PROTO :DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

.STACK 4096

.CONST

.DATA

 myBytes BYTE 10h, 20h, 30h, 40h                ; Определение массива байтов
 myWords WORD 8Ah, 3Bh, 44h, 5Fh, 99h          ; Определение массива слов
 myDoubles DWORD 1, 2, 3, 4, 5, 6               ; Определение массива двойных слов
 myPointer DWORD myDoubles                       ; Указатель на массив myDoubles

 massive DWORD 1, 2, 3, 0, 5, 6, 7              ; Определение массива целых чисел
 sumOfElements DWORD 0                           ; Переменная для хранения суммы элементов массива

 STR1 DB "Рублевская М. В., 2 курс, 10 группа", 0 ; Строка для заголовка сообщения
 STR2 DB "Есть нулевой элемент", 0               ; Строка для сообщения о наличии нуля
 STR3 DB "Нулевого элемента не найдено", 0       ; Строка для сообщения об отсутствии нуля

.CODE
main PROC
START: 
 mov ESI, 0                                      ; Инициализация индекса для доступа к myDoubles
 mov EAX, myDoubles[ESI + 4]                     ; myDoubles[1] = 2, EAX = 2 (второй элемент)
 mov EDX, [myDoubles + ESI]                      ; myDoubles[0] = 1, EDX = 1 (первый элемент)
 
 ; Суммирование элементов массива massive
 mov ESI, OFFSET massive                          ; Указатель на массив massive
 mov ECX, lengthof massive                        ; Длина массива
 mov EBX, 0                                       ; По умолчанию 0 (нулевого элемента не найдено)

CYCLE:
 mov EAX, [ESI]                                  ; Сохраняем текущий элемент в EAX
 add sumOfElements, EAX                          ; Суммируем текущий элемент с общей суммой
 cmp EAX, 0                                      ; Проверяем текущий элемент на ноль
 jz ZERO                                         ; Если ноль, переход к метке ZERO
 add ESI, 4                                      ; Переход к следующему элементу (4 байта для DWORD)
 loop CYCLE                                      ; Уменьшаем ECX и повторяем цикл

 jmp ALLOK                                        ; Переход к метке ALLOK после завершения цикла

ZERO:
 mov EBX, 1                                      ; Найден нулевой элемент
 add ESI, 4                                      ; Переход к следующему элементу (продолжаем проверку)
 loop CYCLE                                      ; Продолжаем цикл для оставшихся элементов

ALLOK:
 mov EAX, sumOfElements                                 ; Загружаем сумму в EAX
 cmp EBX, 0                                             ; Проверяем, найден ли нулевой элемент
 jz NO_ZERO                                             ; Если нулевого элемента не найдено, переход к NO_ZERO
 INVOKE MessageBoxA, 0, OFFSET STR2, OFFSET STR1, 1     ; Есть нулевой элемент
 jmp END_PROGRAM                                        ; Переход к завершению программы

NO_ZERO:
 INVOKE MessageBoxA, 0, OFFSET STR3, OFFSET STR1, 1     ; Нет нулевого элемента

END_PROGRAM:
 push -1                                         ; Завершение программы
 call ExitProcess                                 ; Вызов функции завершения процесса
main ENDP
end main
