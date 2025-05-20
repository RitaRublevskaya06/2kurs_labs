"use strict";
const array = [
    { id: 1, name: 'Vasya', group: 10 },
    { id: 2, name: 'Ivan', group: 11 },
    { id: 3, name: 'Masha', group: 12 },
    { id: 4, name: 'Petya', group: 10 },
    { id: 5, name: 'Kira', group: 11 },
];
array.forEach(student => {
    console.log(`ID: ${student.id}, Имя: ${student.name}, Группа: ${student.group}`);
});
let car = {
    manufacturer: "China",
    model: "FAW"
};
console.log(car);
const car1 = {
    manufacturer: "Japan",
    model: "Acura"
};
const car2 = {
    manufacturer: "Germany",
    model: "BMW"
};
const arrayCars = [{
        cars: [car1, car2]
    }];
console.log(arrayCars);
class Group {
    constructor(students, group, mark) {
        this.studentsFilter = (group) => {
            return this.students.filter(student => student.group === group);
        };
        this.marksFilter = (mark) => {
            return this.students.filter(student => student.marks.some(m => m.mark === mark));
        };
        this.deleteStudent = (id) => {
            this.students = this.students.filter(student => student.id !== id);
        };
        this.students = students;
        this.group = group;
        this.mark = mark;
    }
}
const students = [
    { id: 1, name: "Alex", group: 10, marks: [{ subject: "Math", mark: 8, done: true }] },
    { id: 2, name: "John", group: 9, marks: [{ subject: "Math", mark: 6, done: true }] },
    { id: 3, name: "Masha", group: 10, marks: [{ subject: "Math", mark: 8, done: true }] },
    { id: 4, name: "Nik", group: 8, marks: [{ subject: "Math", mark: 10, done: true }] },
    { id: 5, name: "Ann", group: 10, marks: [{ subject: "Math", mark: 9, done: true }] },
];
const group = new Group(students, 10, 5);
console.log(group.studentsFilter(10)); // Выведет студентов из 10-й группы
console.log(group.marksFilter(8));
group.deleteStudent(1);
console.log(group.students); // Выведет массив без студента с id = 1
// // вывод 1 задания:
// const student = array.find(student => student.id === 3);
// if (student) {
//     console.log(`ID: ${student.id}, Имя: ${student.name}, Группа: ${student.group}`);
// } else {
//     console.log("Студент с таким ID не найден");
// }
// // ИЛИ 
