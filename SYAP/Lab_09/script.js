// 1
class Figure{
    constructor(color, side){
        this.color = color;
        this.side = side;
    }
}
class Square extends Figure{
    constructor(color, side, isSmall = false){
        super(color, side);
        this.isSmall = isSmall;
    }
}
class Circle extends Figure{
    constructor(color, side){
        super(color, side);
        this.type = "circle";
    }
}
class Triangle extends Figure{
    constructor(color, side, lineCount = 3){
        super(color, side);
        this.lineCount = lineCount;
    }
}
let square = new Square("Желтый", 3, true);
let circle = new Circle("Зеленый", 3);
let triangle = new Triangle("Белый", 5, 3);
console.log(`Есть ли у квадрата собственное свойство: ${square.isSmall}`);
console.log("Свойства зеленого круга:");
console.log(`Цвет: ${circle.color}, Тип: ${circle.type}`);
console.log("Свойства треугольника с тремя линиями:");
console.log(`Цвет: ${triangle.color}, Количество линий: ${triangle.lineCount}`);

// 2 
class Human {
    constructor(name, surname, address, yearOfBirthday, currentYear) {
        this.name = name;
        this.surname = surname;
        this.address = address;
        this.yearOfBirthday = yearOfBirthday;
        this.currentYear = currentYear;
    }
    changeAddress(newAddress) {
        this.address = newAddress;
    }
    get age() {
        return this.currentYear - this.yearOfBirthday;
    }
    set age(newAge) {
        this.yearOfBirthday = this.currentYear - newAge;
    }
}
class Student extends Human {
    constructor(name, surname, address, yearOfBirthday, currentYear, faculty, course, group, numberOfBook) {
        super(name, surname, address, yearOfBirthday, currentYear);
        this.faculty = faculty;
        this.course = course;
        this.group = group;
        this.numberOfBook = numberOfBook;
    }
    changeCourse(newValueOfCourse) {
        this.course = newValueOfCourse;
    }
    changeGroup(newNumberOfGroup) {
        this.group = newNumberOfGroup;
    }
    getFullName() {
        return `Имя и фамилия студента: ${this.name} ${this.surname}`;
    }
}
class Faculty extends Student {
    constructor(name, surname, address, yearOfBirthday, currentYear, faculty, course, group, numberOfBook, numberOfGroup, numberOfStudents) {
        super(name, surname, address, yearOfBirthday, currentYear, faculty, course, group, numberOfBook);
        this.numberOfGroup = numberOfGroup;
        this.numberOfStudents = numberOfStudents;
    }
    changeNumberOfGroup(newValueOfGroup) {
        this.numberOfGroup = newValueOfGroup;
    }
    changeNumberOfStudents(newValueOfStudents) {
        this.numberOfStudents = newValueOfStudents;
    }
    getDev() {
        let countStudents = 0;
        let bookStr = this.numberOfBook.toString();
        if (bookStr[0] === '7' && bookStr[1] === '3'){
            countStudents++;
        }
        return `Количество студентов ДЭВИ: ${countStudents}`;
    }
    getGroup(value) {
        let students = 0;
        if (this.group === value) {
            students++;
        }
        return `Количество студентов в группе ${value}: ${students}`;
    }
}
let students = [
    {name: "Петр", surname: "Петров", address: "ул. Ленина", yearOfBirthday: 2006, currentYear: 2024, faculty: "ФИТ", course: 2, group: 8, numberOfBook: 73231001},
    {name: "Иван", surname: "Иванов", address: "ул. Ленина", yearOfBirthday: 2005, currentYear: 2024, faculty: "ФИТ", course: 3, group: 5, numberOfBook: 61231001},
    {name: "Иван", surname: "Петров", address: "ул. Ленина", yearOfBirthday: 2006, currentYear: 2024, faculty: "ФИТ", course: 2, group: 8, numberOfBook: 73232001},
    {name: "Пётр", surname: "Иванов", address: "ул. Ленина", yearOfBirthday: 2005, currentYear: 2024, faculty: "ФИТ", course: 3, group: 5, numberOfBook: 73232002},
];
let facultyStudents = students.map(student => new Faculty(
    student.name, 
    student.surname, 
    student.address, 
    student.yearOfBirthday, 
    student.currentYear, 
    student.faculty, 
    student.course, 
    student.group, 
    student.numberOfBook
));
facultyStudents.forEach(student => {
    console.log(student.getFullName());
    console.log(student.getDev());
    console.log(student.getGroup(8));
    console.log(`Возраст студента: ${student.age}`);
});
