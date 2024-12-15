/* 1. Создайте класс Task, который описывает задачу из списка дел (Todolist). У каждой задачи есть id, название и состояние 
«выполнена» или «не выполнена». Реализуйте соответствующие методы, для изменения названия задачи и ее состояния.  */

class Task {
    constructor(id, title) {
        this.id = id;
        this.title = title;
        this.completed = false; // состояние задачи: выполнена или не выполнена
    }

    // Метод для изменения названия задачи
    changeTitle(newTitle) {
        this.title = newTitle;
    }

    // Метод для изменения состояния задачи
    toggleCompletion() {
        this.completed = !this.completed;
    }
}



/* 2. Создайте класс Todolist, который представляет список дел. Список дел имеет id, название и метод, который его изменяет. Класс 
имеет метод, который добавляет новую задачу Task в список дел. Класс должен содержать метод, который фильтрует задачи по состоянию. */

class Todolist {
    constructor(id, title) {
        this.id = id;
        this.title = title;
        this.tasks = []; // массив задач
    }

    // Метод для изменения названия списка дел
    changeTitle(newTitle) {
        this.title = newTitle;
    }

    // Метод для добавления новой задачи
    addTask(task) {
        this.tasks.push(task);
    }

    // Метод для фильтрации задач по состоянию
    filterTasks(completed) {
        return this.tasks.filter(task => task.completed === completed);
    }
}


/* 3. Создайте несколько списков Todolist. Продемонстрируйте работу с классами Todolist и Task. */

// Создание нескольких списков Todolist
const workList = new Todolist(1, "Рабочий список");
const personalList = new Todolist(2, "Личный список");

// Создание задач
const task1 = new Task(1, "Завершить проект");
const task2 = new Task(2, "Купить продукты");
const task3 = new Task(3, "Сделать домашнюю работу");
const task4 = new Task(4, "Сделать работу");

// Добавление задач в списки
workList.addTask(task1);
personalList.addTask(task2);
personalList.addTask(task3);
workList.addTask(task4);

task4.changeTitle("Уволиться!");

// Изменение состояния задачи
task1.toggleCompletion(); 
task2.toggleCompletion();

// Фильтрация задач
const completedTasks_1 = personalList.filterTasks(true);
const incompleteTasks_1 = personalList.filterTasks(false);
const completedTasks_2 = workList.filterTasks(true);
const incompleteTasks_2 = workList.filterTasks(false);

// Вывод результатов
console.log("Завершенные задачи из Личного списка:", completedTasks_1);
console.log("Незавершенные задачи из Личного списка:", incompleteTasks_1);

console.log("Завершенные задачи из Рабочего списка:", completedTasks_2);
console.log("Незавершенные задачи из Рабочего списка:", incompleteTasks_2);

