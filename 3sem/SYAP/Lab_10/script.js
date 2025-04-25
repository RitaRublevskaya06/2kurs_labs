// 1
console.log("Пример № 1");
const set = new Set([1, 1, 2, 3, 4]);
console.log(set); // Вывод: Set(4) {1, 2, 3, 4}


// 2
console.log("Пример № 2");
const name_2 = "Lydia";
age = 21;
console.log(delete name_2); // Вывод: false
console.log(delete age); // Вывод: true


// 3
console.log("Пример № 3");
const numbers = [1, 2, 3, 4, 5];
const [y] = numbers;
console.log(y); // Вывод: 1


// 4
console.log("Пример № 4");
const user = {
    name_4: "Lydia",
    age: 21
};
const admin = {admin: true, ...user};
console.log(admin); // Вывод: {admin: true, name_4: 'Lydia', age: 21}


// 5
console.log("Пример № 5");
const person = {name_5: "Lydia"};
Object.defineProperty(person, "age", {value: 21});
console.log(person); // Вывод: {name_5: 'Lydia', age: 21}
console.log(Object.keys(person)); // Вывод: ['name_5']


// 6
console.log("Пример № 6");
const a = {};
const b = {key: "b"};
const c = {key: "c"};
a[b] = 123;
a[c] = 456;
console.log(a[b]); // Вывод: 456


// 7
console.log("Пример № 7");
let num = 10;
const increaseNumber = () => num++;
const increasePassedNumber = number => number++;
const num1 = increaseNumber ();
const num2 = increasePassedNumber(num1);
console.log(num1); // Вывод: 10
console.log(num2); // Вывод: 10


// 8
console.log("Пример № 8");
const value = {number: 10};
const multiphy = (x = {...value}) => {
    console.log((x.number *= 2)); // Вывод: 20 20 20 40
};
multiphy();
multiphy();
multiphy(value);
multiphy(value);


// 9
console.log("Пример № 9");
[1, 2, 3, 4].reduce((x, y) => {console.log(x, y); return x; }); 
/* Вывод: 
1 2 
undefined 3 
undefined 4 */