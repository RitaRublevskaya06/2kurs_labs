// 1
let  user = { // Объект user
    name: 'Masha', // Свойство name
    age: 21 // Свойство age
};

// 2
let numbers = [1, 2, 3]; // Массив чисел 

// 3
let user1 = { // Объект user1 
    name: 'Masha', 
    age: 23, 
    location: { // Вложенный объект location
        city: 'Minsk',
        country: 'Belarus'
    }
};

// 4
let user2 = { // Объект user2
    name: 'Masha',
    age: 28,
    skills: ["HTML", "CSS", "JavaScript", "React"] // Массив строк skills
};

// 5
const array = [ // Массив объектов array
    {id: 1, name: 'Vasya', group: 10}, 
    {id: 2, name: 'Ivan', group: 11},
    {id: 3, name: 'Masha', group: 12},
    {id: 4, name: 'Petya', group: 10},
    {id: 5, name: 'Kira', group: 11},
]

// 6
let user4 = { // Объект user4
    name: 'Masha',
    age: 19,
    studies: { // Вложенный объект studies
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        exams: { // Вложенный объект exams
            maths: true,
            programming: false
        }
    }
};


/* 1. Выполнить глубокое копирование всех объектов и массивов. Использовать spread оператор. */
/*1*/ 
console.log("Задание № 1, пример № 1");
let copyUser = {...user};
console.log(copyUser); 
let copyUser0_1 = structuredClone(user)
console.log(copyUser0_1); 

/*2*/ 
console.log("Задание № 1, пример № 2");
let copyNumbers = [...numbers];
console.log(copyNumbers); 

/*3*/ let copyUser1 = { // Создаем новый объект copyUser1
    ...user1, // Копируем все свойства верхнего уровня из user1 в copyUser1
    location: {...user1.location} // Вложенного объекта location
};
console.log("Задание № 1, пример № 3")
// copyUser1.location.city = 'Lida'; // Изменяем значение свойства city объекта location в copyUser1
console.log(copyUser1); 


/*4*/ let copyUser2 = {
    ...user2,
    skills: [...user2.skills]
};
console.log("Задание № 1, пример № 4");
// copyUser2.skills.push("SQL"); // Добавляем новый элемент массива SQL
console.log(copyUser2);

/*5*/ console.log("Задание № 1, пример № 5")
let copyArray = array.map(el => ({...el})); // Для каждого элемента el в исходном массиве array, создается новый объект с помощью оператора расширения (...)
console.log(copyArray);

/*6*/ let copyUser4 = {
    ...user4,
    studies: {...user4.studies,
    exams: {...user4.exams}
}
};
console.log("Задание № 1, пример № 6")
// copyUser4.studies.speciality = "PI"; // Изменяем свойство speciality в скопированном объекте copyUser4
console.log(copyUser4);


/* 2. Обратитесь к копии объекта user5 и измените значение свойства group на 12, а оценку по программированию измените на 10.*/
let user5 = { // Объект user5
    name: 'Masha',
    age: 22,
    studies: { // Вложенный объект studies
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        department: { // Вложенный объект department
            faculty: 'FIT',
            group: 10,
        },
        exams: [ // Вложенный массив объектов exams
            { maths: true, mark: 8},
            { programming: true, mark: 4},
        ]
    }
};

let copyUser5 = structuredClone(user5);
console.log("Задание № 2, пример № 7")
copyUser5.studies.department.group = 12; // Изменяем свойство group в объекте department
copyUser5.studies.exams[1].mark = 10; // Изменяем mark второго экзамена в массиве exams.
console.log(copyUser5);


/* 3. Обратитесь к копии объекта user6 и измените имя преподавателя.*/
let user6 = { // Объект user6
    name: 'Masha',
    age: 21,
    studies: { // Вложенный объект studies
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        department: { // Вложенный объект department
            faculty: 'FIT',
            group: 10,
        },
        exams: [ // Вложенный массив объектов exams
            { 
		maths: true,
		mark: 8,
		professor: { // Вложенный объект professor
		    name: 'Ivan Ivanov ',
		    degree: 'PhD'
		}
	     },
            { 
		programming: true,
		mark: 10,
		professor: { // Вложенный объект professor
		    name: 'Petr Petrov',
		    degree: 'PhD'
		}
	     },
        ]
    }
};

let copyUser6 = structuredClone(user6);
console.log("Задание № 3, пример № 8"); // Создается новая копия объекта professor, что позволяет изменять данные о профессоре без влияния на оригинал
copyUser6.studies.exams[0].professor.name = "Vasily Vasiliev"; 
console.log(copyUser6);


/* 4. Обратитесь к копии объекта user7 и измените количество страниц на 3 для статьи “About CSS” преподавателя Petr Ivanov. */
let user7 = { // Объект user7
    name: 'Masha',
    age: 20,
    studies: { // Вложенный объект studies
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        department: { // Вложенный объект department
            faculty: 'FIT',
            group: 10,
        },
        exams: [ // Вложенный массив объектов exams
            { 
		maths: true,
		mark: 8,
		professor: { // Вложенный объект professor
		    name: 'Ivan Petrov',
		    degree: 'PhD',
		    articles: [
                        {title: "About HTML", pagesNumber: 3},
                        {title: "About CSS", pagesNumber: 5},
                        {title: "About JavaScript", pagesNumber: 1},
                    ]
		}
	     },
            { 
		programming: true,
		mark: 10,
		professor: { // Вложенный объект professor
		    name: 'Petr Ivanov',
		    degree: 'PhD',
		    articles: [
                        {title: "About HTML", pagesNumber: 3},
                        {title: "About CSS", pagesNumber: 5},
                        {title: "About JavaScript", pagesNumber: 1},
                    ]
		}
	     },
        ]
    }
};


let copyUser7 = {
    ...user7,
    studies: {
        ...user7.studies,
        department: {
            ...user7.studies.exams.map(exam => ({
                ...exam,
                professor: {
                    ...exam.professor,
                    articles: exam.professor.articles.map(article => ({...article}))
                }
            }))
        }

    }
};

console.log("Задание № 4, пример № 9");
copyUser7.studies.exams[1].professor.articles[1].pagesNumber = 10; // Изменяем количество страниц второй статьи профессора второго экзамена
console.log(copyUser7);
// let copyUser7_1 = structuredClone(user7);
// console.log(copyUser7_1);


/* 5. Замените все сообщения в объекте store на “Hello”. */
let store = {
    state: { // 1 уровень
        profilePage: { // 2 уровень 
            posts: [ // 3 уровень
                { id: 1, message: 'Hi', likeCount: 12 },
                { id: 2, message: 'By', likeCount: 1 },
            ],
            newPostText: 'About me',
        },
        dialogsPage: { // Вложенный объект dialogsPage
            dialogs: [ // Вложенный массив объектов dialogs
                { id: 1, name: 'Valera' },
                { id: 2, name: 'Andrey' },
                { id: 3, name: 'Sasha' },
                { id: 4, name: 'Victor' },
            ],
            messages: [ // Вложенный массив объектов messages
                { id: 1, message: 'hi' },
                { id: 2, message: 'hi hi' },
                { id: 3, message: 'hi hi hi' },
            ],
        },
        sidebar: [], // Пустой массив sidebar
    },
};

let copeStore = structuredClone(store);
console.log("Задание № 5, пример № 10");
console.log(store);
copeStore.state.dialogsPage.messages = copeStore.state.dialogsPage.messages.map(function(m){
    return m = {id: m.id, message: "Hello"}; // Изменяем сообщения в массиве messages, устанавливая новое значение для каждого сообщения с использованием метода map()
});
console.log(copeStore);

