/* Задача 1: Определите тип перменных */

// let a1 = 5; // number
// alert("Тип перемнной a1: " + typeof a1);

// let name1 = "Name"; // string
// alert("Тип перемнной name1: " + typeof name1);

// let i1 = 0; // number
// alert("Тип перемнной i1: " + typeof i1);

// let double1 = 0.23; // number
// alert("Тип перемнной double1: " + typeof double1);

let result1 = 1/0; // number
alert("Тип перемнной result1: " + typeof result1);

// let answer1 = true; // boolean
// alert("Тип перемнной answer1: " + typeof answer1);

// let no1 = null; // object
// alert("Тип перемнной no1: " + typeof no1);


// /* Задача 2: Сколько квадратов В со сторонами 5 мм поместятся в четырехугольник А (45мм х 21мм). */ 

// let S1 = 5 * 5;
// let S2 = 45 * 21;
// let result2 = S2 / S1;
// alert("В четырехугольник А поместиться " + result2 + " квадратов B" );


// /* Задача 3: Сравните a и b. */

// let i = 2;
// let a3 = ++i;
// let b3 = i++;
// if (a3 == b3)
// {
//     alert('a3 и b3 ');
// } 
// else if (a3 < b3)
// {
//     alert('b3 больше a3 ');
// }
// else 
// {
//     alert ('a3 больше b3');
// }


// /* Задача 4: Сравните и объясните «Котик» и «котик», «Котик» и «китик», «Кот» и «Котик»,  «Привет» и «Пока», 73 и «53», false и 0, 54 и true, 123 и false,   true и «3», 3 и «5мм», 8 и «-2», 34 и «34», null и undefined.  Использовать тернарный оператор. */

// ('Котик' < 'котик')? alert('"Котик" < "котик" верно'): alert('"Котик" < "котик" неверно');
// ('Котик' < 'китик')? alert('"Котик" < "китик" верно'): alert('"Котик" < "китик" неверно');
// ('Кот' < 'Котик')? alert('"Кот" < "Котик" верно'): alert('"Кот" < "Котик" неверно');
// ('Привет' < 'Пока')? alert('"Привет" < "Пока" верно'): alert('"Привет" < "Пока" неверно');
// (73 < '53')? alert('73 < "53" верно'): alert('73 < "53" неверно');
// (false == 0) ? alert ('false == 0 верно') : alert('false == 0 неверно');
// (54 > true) ? alert ('54 > true верно') : alert('54 > true неверно');
// (123 > false) ? alert ('123 > false верно') : alert('123 > false неверно');
// (true < '3') ? alert ('true < "3" верно') : alert('true < "3" неверно');
// (3 != '5мм') ? alert ('3 != "5мм" верно') : alert('3 != "5мм" неверно');
// (8 > '-2') ? alert ('8 > "-2" верно') : alert('8 > "-2" неверно');
// (34 == '34') ? alert ('34 == "34" верно') : alert('34 == "34" неверно');
// (null == undefined) ? alert ('null == undefined верно') : alert('null == undefined неверно');


// /* Задача 5: Пользователь вводит имя в диалоговое окно. Если имя совпало с именем преподавателя, то выведите сообщение о том, что введенные пользователем данные верные. Учтите, что пользователь может ввести только имя или имя и отчество, или полностью ФИО. Кроме того, данные могут быть введены в верхнем регистре. */

// userName5 = prompt('Введите ваше имя: ', '');
// let a5 ='Марина'
// let b5 = a5.toLowerCase();
// let c5 = 'Марина Федоровна'
// let d5 = c5.toLowerCase();
// let e5 = 'Федоровна Марина Кудлацкая'
// let f5 = e5.toLowerCase();
// let g5 = 'Марина Кудлацкая'
// let h5 = g5.toLowerCase();
// (userName5 == a5 || userName5 == b5 || userName5 == c5 || userName5 == d5 || userName5 == e5 || userName5 == f5 || userName5 == g5 || userName5 == h5) ? alert('Данные введены верно') : alert('Данные введены неверно');


// /* Задача 6: У студента 3 экзамена: русский, математика, английский. Если он сдаст все экзамены, то его переведут на следующий курс. Если он не сдаст ни одного экзамена, то его отчислят. Если он не сдаст хотя бы один экзамен, то его ожидает пересдача. Для решения задачи использовать логические операторы.*/

// let russian = confirm('Сдан русский?');
// let math = confirm('Сдана математика?');
// let english = confirm('Сдан английский?');
// (russian == true && math == true && english == true) ? alert ('Вы переходите на следующий курс!') :
// (russian == false && math == false && english == false)? alert('Вас ожидает отчисление!') : alert('Вас ожидает пересдача!')


// /* Задача 7: Вычислите и поясните */

// true + true    // 1 + 1 = 2
// 0 + "5"        // 05
// 5 + "мм"       // 5мм
// 8 / Infinity   // 0
// 9 * "\n9"      // 81
// null - 1       // -1
// "5" - 2        // 3
// "5px" - 3      // NaN
// true - 3       // -2
// 7 || 0         // 7 


// /* Задача 8: К каждому четному числу в диапазоне [1, 10] прибавьте 2, а каждое нечетное число преобразуйте к строке вида «Xмм», где X – нечетное число. Выведите результат. */

// for(i = 1; i <= 10; i++)
// {
//     if(i % 2 == 0)
//     {
//         let numb = Number(i) + 2;
//         alert(numb);
//     }
//     else 
//     {
//         let str = i + "мм";
//         alert(str);
//     }
// }
    

// /* Задача 9: По номеру дня недели определить какой это день: 1 – пн, 2 – вт, … , 7 – вс. Номер дня вводит пользователь. Реализовать через объект и через массив. */

// let days1 = ["Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье"];
// let numb1 = Number(prompt("Введите номер дня недели (1-7): "));
// alert(days1[numb1 - 1]); // Нумерация дней в массиве начинается с 0

// // Через объект
// let days2 = { 1: "Понедельник", 2: "Вторник", 3: "Среда", 4: "Четверг", 5: "Пятница", 6: "Суббота", 7: "Воскресенье"};
// let numb2 = Number(prompt("Введите номер дня недели (1-7): "));
// alert(days2[numb2]);


/* Задача 10: Реализуйте функцию с тремя параметрами. Первый параметр по умолчанию. Третий параметр вводит пользователь. Функция возвращает строку из трех параметров. */


// function myFunction(firstParam = "Привет", secondParam, thirdParam) {
//     if (thirdParam === undefined) {
//         thirdParam = prompt("Введите третий параметр:", '');
//     }

//     return `${firstParam} ${secondParam} ${thirdParam}`;
// }

// const result = myFunction(undefined, "Мир");
// console.log(result);


/* Задача 11: Известны стороны четырехугольника a и b. Если это квадрат, то функция params() возвращает его периметр, если прямоугольник –  то площадь. Создайте params() как Function Declaration и Function Expression, функцию стрелку. */

// // Function Declaration
// function params(a, b) {
//     if (a === b) {
//         return 4 * a; // Периметр квадрата
//     } else {
//         return a * b; // Площадь прямоугольника
//     }
// }

// // Function Expression
// const paramsFuncExp = function(a, b) {
//     if (a === b) {
//         return 4 * a; // Периметр квадрата
//     } else {
//         return a * b; // Площадь прямоугольника
//     }
// };

// // Arrow Function
// const paramsArrow = (a, b) => {
//     if (a === b) {
//         return 4 * a; // Периметр квадрата
//     } else {
//         return a * b; // Площадь прямоугольника
//     }
// };

// // const paramsArrow = (a, b) => a === b ? 4 * a : a * b;
     


// console.log(params(4, 4)); // 16 
// console.log(params(4, 5)); // 20 

// console.log(paramsFuncExp(4, 4)); // 16 
// console.log(paramsFuncExp(4, 5)); // 20

// // console.log(paramsFuncExp(3, 3)); // 12
// // console.log(paramsFuncExp(4, 7)); // 21

// console.log(paramsArrow(4, 4)); // 16 
// console.log(paramsArrow(4, 5)); // 20

// // console.log(paramsArrow(5, 5)); // 25 
// // console.log(paramsArrow(6, 8)); // 48


