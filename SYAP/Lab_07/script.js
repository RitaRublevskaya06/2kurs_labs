/* 1. Создайте объект person с методами greet (сообщение с приветствием пользователя) и ageAfterYears (принимает years и возвращает 
“текущий возраст” + years), которые используют this для доступа к свойствам объекта. */

const person = {
    name: 'Маргарита',
    age: 18,
    greet: function() {
        return `Добро пожаловать, ${this.name}!`;
    },
    ageAfterYears: function(years) {
        return this.age + years;
    }
};

console.log(person.greet()); // Добро пожаловать, Маргарита!
console.log(person.ageAfterYears(3)); // 21


/* 2. Создайте объект car, который имеет свойства model и year, а также метод getInfo, который выводит информацию о машине. */

const car = {
    model: 'Audi A7',
    year: 2023,
    getInfo: function() {
        return `Модель: ${this.model}, Год выпуска: ${this.year}`;
    }
};

console.log(car.getInfo()); // Модель: Audi A7, Год выпуска: 2023


/* 3. Создайте функцию-конструктор Book, которая создает объекты с методами getTitle и getAuthor. */

function Book(title, author) {
    this.title = title;
    this.author = author;

    this.getTitle = function() {
        return this.title;
    };

    this.getAuthor = function() {
        return this.author;
    };
}

const book1 = new Book('Гарри Поттер', 'Джоан Кэтлин Роулинг');
console.log(book1.getTitle()); // Гарри Поттер
console.log(book1.getAuthor()); // Джоан Кэтлин Роулинг

/* Примечание: Имя функции-конструктора должно начинаться с большой буквы. Функция-конструктор должна выполняться только с 
помощью оператора "new". */


/* 4. Создайте объект team, который содержит массив игроков и метод для вывода информации о каждом игроке. Используйте this в вложенной 
функции. */

const team = {
    players: ['Артём', 'Иван', 'Ирина', 'Владислава', 'Пётр'],
    showPlayers: function() {
        this.players.forEach((player) => {
            console.log(`Игрок: ${player}`);
        });
    }
};

team.showPlayers();
// Игрок: Артём
// Игрок: Иван
// Игрок: Ирина
// Игрок: Владислава
// Игрок: Пётр


/* 5. Создайте модуль counter, который инкапсулирует переменную count и предоставляет методы для инкрементации, декрементации и 
получения текущего значения. Используйте this для доступа к свойствам. */

const counter = (function() {
    // Объект counterObj теперь содержит count
    const counterObj = {
        count: 0, // Инициализируем count как свойство объекта

        increment: function() {
            this.count++; // Используем this для доступа к count
            return this.count;
        },
        decrement: function() {
            this.count--; 
            return this.count;
        },
        getCount: function() {
            return this.count; 
        }
    };

    return counterObj;
})();

console.log(counter.increment()); // 1
console.log(counter.increment()); // 2
console.log(counter.decrement()); // 1
console.log(counter.getCount()); // 1




/* 6. Создайте объект item со свойством price. Сначала определите его с параметрами, разрешающими изменение и удаление. Затем 
переопределите дескрипторы так, чтобы свойство стало неизменяемым. */

const item = {
    price: 100
};

// Устанавливаем дескрипторы, позволяющие изменение и удаление
Object.defineProperty(item, 'price', {
    configurable: true,
    writable: true,
    value: 100
});

// Изменяем значение
item.price = 200; 
console.log(item.price); // 200

// Переопределяем дескрипторы, чтобы сделать свойство неизменяемым
Object.defineProperty(item, 'price', {
    configurable: false,
    writable: false,
    value: 200
});

// Пытаемся изменить значение 
item.price = 300; 
console.log(item.price); // 200


/* 7. Создайте объект circle, который имеет свойство radius. Добавьте геттер для вычисления площади круга на основе радиуса, геттер и 
сеттер для изменения радиуса. */

const circle = {
    _radius: 0, // Приватное свойство для радиуса
   
    get radius() {
        return this._radius;
    },

    set radius(value) {
        this._radius = value;
    },

    get area() {
        return Math.PI * Math.pow(this._radius, 2);
    }
};

// Использование 
circle.radius = 5;
console.log(circle.area); // 78.53981633974483
console.log(circle.radius); // 5


/* 8. Создайте объект car с тремя свойствами: make, model, и year. Сначала определите их с параметрами, разрешающими изменение и удаление. 
Затем переопределите дескрипторы, чтобы все свойства стали неизменяемыми. */

let car2 = {
    make: 'Japan',
    model: 'Toyota Camry',
    year: 2021 
}

Object.defineProperty(car2, 'make', {
    configurable: true,
    writable: true,
    value: 'Japan'
});
Object.defineProperty(car2, 'model', {
    configurable: true,
    writable: true,
    value: 'Toyota Camry'
});
Object.defineProperty(car2, 'year', {
    configurable: true,
    writable: true,
    value: 2021
});

console.log(car2); // {make: 'Japan', model: 'Toyota Camry', year: 2021}

// Изменяем свойства
car2.make = 'Germany';
car2.model = 'BMW XM';
car2.year = 2022;
console.log(car2); // {make: 'Germany', model: 'BMW XM', year: 2022}

// Переопределяем дескрипторы, чтобы сделать свойства неизменяемыми
Object.defineProperty(car2, 'make', {
    configurable: false,
    writable: false,
    value: 'Germany'
});
Object.defineProperty(car2, 'model', {
    configurable: false,
    writable: false,
    value: 'BMW XM'
});
Object.defineProperty(car2, 'year', {
    configurable: false,
    writable: false,
    value: 2022
});

// Пытаемся изменить значение 
car2.make = 'USA';
car2.model = 'Ford Focus';
car2.year = 2023;
console.log(car2); // {make: 'Germany', model: 'BMW XM', year: 2022}


/* 9. Создайте массив, в котором будет три числа. Используя Object.defineProperty, добавьте свойство sum (геттер), которое будет 
возвращать сумму всех элементов массива. Сделайте это свойство доступным только для чтения. */

let numbers = [1, 5, 7];

Object.defineProperty(numbers, 'sum', {
    get: function() {
        return this.reduce((acc, num) => acc + num, 0);
    },
    enumerable: false,
    configurable: false
});

// Использование 
console.log(numbers.sum); // 13


/* 10. Создайте объект rectangle, который имеет свойства width и height. Добавьте геттер для вычисления площади прямоугольника, 
геттеры и сеттеры для ширины и высоты.  */

const rectangle = {
    width: 15,
    height: 10,

    get area() {
        return this.width * this.height;
    },

    get width() {
        return this._width;
    },

    set width(value) {
        if (value > 0) {
            this._width = value;
        } else {
            console.error('Число должно быть положительным');
        }
    },

    get height() {
        return this._height;
    },

    set height(value) {
        if (value > 0) {
            this._height = value;
        } else {
            console.error('Число должно быть положительным');
        }
    }
}

// Использование 
rectangle.width = 15;
rectangle.height = 10;
console.log(rectangle.area); // 150 
rectangle.width = 20;
console.log(rectangle.area); // 200

/* 11. Создайте объект user, который имеет свойства firstName и lastName. Добавьте геттер для получения полного имени и сеттер для 
изменения полного имени. */

const user = {
    firstName: 'Том',
    lastName: 'Холланд',

    get fullName() {
        return `${this.firstName} ${this.lastName}`;
    },

    set fullName(name) {
        const parts = name.split(' ');
        if (parts.length === 2) {
            this.firstName = parts[0];
            this.lastName = parts[1];
        } else {
            console.error('Имя должно включать имя и фамилию.')
        }
    }
};

// Использование 
console.log(user.fullName);
user.fullName = 'Тимоте Шаламе';
console.log(user.firstName); // Тимоте 
console.log(user.lastName); // Шаламе
console.log(user.fullName); // Тимоте Шаламе
















/* Примечание для меня: var -переменные могут быть как обновлены, так и переопределены внутри области видимости; let -переменные можно 
обновлять, но не переопределять; const -переменные нельзя ни обновлять, ни переопределять.  */