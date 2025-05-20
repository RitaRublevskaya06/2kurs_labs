// 1. Определение типа для массива студентов
interface Student {
    id: number;
    name: string;
    group: number;
}

const array: Student[] = [
    { id: 1, name: 'Vasya', group: 10 },
    { id: 2, name: 'Ivan', group: 11 },
    { id: 3, name: 'Masha', group: 12 },
    { id: 4, name: 'Petya', group: 10 },
    { id: 5, name: 'Kira', group: 11 },
];

array.forEach(student => {
    console.log(`ID: ${student.id}, Имя: ${student.name}, Группа: ${student.group}`);
});



// 2. Определение типов для автомобилей

interface CarsType {
    manufacturer: string;
    model: string;
}

let car: CarsType = { // объект создан! 
    manufacturer: "China",
    model: "FAW"
};

console.log(car);

// 3. Определение типов для автомобилей

interface CarsType_1 {
    manufacturer: string;
    model: string;
}

const car1: CarsType_1 = { // объект создан! 
    manufacturer: "Japan",
    model: "Acura"
};

const car2: CarsType_1 = { // объект создан! 
    manufacturer: "Germany",
    model: "BMW"
};

interface ArrayCarsType {
    cars: CarsType[];
}

const arrayCars: Array<ArrayCarsType> = [{
    cars: [car1, car2]
}];

console.log(arrayCars);

// 4. Определение типов для оценок, студентов и групп

type MarkFilterType = 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10;
type GroupFilterType = 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12;
type DoneType = boolean;

type MarkType = {
    subject: string;
    mark: MarkFilterType;  // может принимать значения от 1 до 10
    done: DoneType;
};

type StudentType = {
    id: number;
    name: string;
    group: GroupFilterType;  // может принимать значения от 1 до 12
    marks: MarkType[];
};

type GroupType = {
    students: StudentType[];   // массив студентов типа StudentType
    studentsFilter: (group: GroupFilterType) => StudentType[];  // фильтр по группе
    marksFilter: (mark: MarkFilterType) => StudentType[];  // фильтр по  оценке
    deleteStudent: (id: number) => void;   // удалить студента по id из  исходного массива
    mark: MarkFilterType;
    group: GroupFilterType;
};

class Group implements GroupType {
    students: StudentType[];
    mark: MarkFilterType;
    group: GroupFilterType;

    constructor(students: StudentType[], group: GroupFilterType, mark: MarkFilterType) {
        this.students = students;
        this.group = group;
        this.mark = mark;
    }

    studentsFilter = (group: GroupFilterType): StudentType[] => {
        return this.students.filter(student => student.group === group);
    };

    marksFilter = (mark: MarkFilterType): StudentType[] => {
        return this.students.filter(student => 
            student.marks.some(m => m.mark === mark)
        );
    };

    deleteStudent = (id: number): void => {
        this.students = this.students.filter(student => student.id !== id);
    };
}

const students: StudentType[] = [
    { id: 1, name: "Alex", group: 10, marks: [{ subject: "Math", mark: 8, done: true }] },
    { id: 2, name: "John", group: 9, marks: [{ subject: "Math", mark: 6, done: true }] },
    { id: 3, name: "Masha", group: 10, marks: [{ subject: "Math", mark: 8, done: true }] },
    { id: 4, name: "Nik", group: 8, marks: [{ subject: "Math", mark: 10, done: true }] },
    { id: 5, name: "Ann", group: 10, marks: [{ subject: "Math", mark: 9, done: true }] },
];

const group = new Group(students, 10, 5);
console.log(group.studentsFilter(10));  // Выведет студентов из 10-й группы
console.log(group.marksFilter(8));
group.deleteStudent(1);  
console.log(group.students);  // Выведет массив без студента с id = 1


















// // вывод 1 задания:
// const student = array.find(student => student.id === 3);

// if (student) {
//     console.log(`ID: ${student.id}, Имя: ${student.name}, Группа: ${student.group}`);
// } else {
//     console.log("Студент с таким ID не найден");
// }


// // ИЛИ 


