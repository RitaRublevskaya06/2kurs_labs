/* 1. Имеется массив numbers. Сохранить первый элемент массива в переменную y используя деструктуризацию.*/

// let numbers = [7, 1, 2, 8, 9];
// let [firstNum, ...rest] = numbers;
// alert(firstNum);
// alert(rest);


/* 2. Объект user имеет свойства name, age. Создайте объект admin, у которого есть свойства admin и все свойства объекта user. Используйте 
spread оператор.*/

// let user = { name: "Rita", age: 18 };
// let admin = { admin: true, ...user }; // Используем spread оператор, чтобы добавить свойства user в admin
// console.log(admin);


/* 3. Выполнить деструктуризацию объекта store до 3 уровня вложенности. После этого вывести значения likesCount из массива posts. Выполнить 
фильтрацию массива dialogs – выбрать пользователей с четными id. В массиве messages заменить все сообщения на “Hello user” (использовать 
метод map).*/

// let store = {
//     state: { // 1 уровень
//         profilePage: { // 2 уровень
//             posts: [ // 3 уровень
//                 { id: 1, message: 'Hi', likeCount: 12 },
//                 { id: 2, message: 'By', likeCount: 1 },
//             ],
//             newPostText: 'About me',
//         },
//         dialogsPage: {
//             dialogs: [
//                 { id: 1, name: 'Valera' },
//                 { id: 2, name: 'Andrey' },
//                 { id: 3, name: 'Sasha' },
//                 { id: 4, name: 'Victor' },
//             ],
//             messages: [ 
//                 { id: 1, message: 'hi' },
//                 { id: 2, message: 'hi hi' },
//                 { id: 3, message: 'hi hi hi' },
//             ],
//         },
//         sidebar: [],
//     },
// };

// // Деструктуризация
// let {
//     state: {
//         profilePage: { posts },
//         dialogsPage: { dialogs, messages }, 
//         sidebar,
//     },
// } = store;

// // Вывод значений likesCount
// for (const post of posts) {
//     console.log(post.likeCount);
// }
   
// // Фильтрация массива dialogs
// let filteredDialogs = dialogs.filter((dialog) => dialog.id % 2 === 0);
// console.log(filteredDialogs);
   
// // Замена сообщений в messages на "Hello user"
// let newMessages = messages.map((message) => ({ ...message, message: 'Hello user' })); // Добавлено изменение сообщения
// console.log(newMessages); 


/* 4. В массиве tasks хранится список задач. Создать новую задачу task и добавить ее в массив, используя spread оператор.*/

// let tasks = [
//     {id: 1, title: 'HTML&CSS', isDone: true},
//     {id: 2, title: 'S', isDone: true},
//     {id: 3, title: 'ReactJS', isDone: false},
//     {id: 4, title: 'Rest API', isDone: false},
//     {id: 5, title: 'GraphQL', isDone: false},
// ];

// let task = {id: 6, title: "JS2.0", isDone: false};
// tasks = [...tasks, task];
// console.log(tasks);


/* 5. Массив [1, 2, 3] передайте в качестве параметра функции sumValues. Используйте spread оператор.*/

// let array = [1, 2, 3];

// function sumValues(x, y, z){
//     return x + y + z;
// }

// console.log(sumValues(...array));