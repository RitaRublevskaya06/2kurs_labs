// Задача 1: Система управления пользователями
abstract class BaseUser {
    constructor(protected id: number, protected name: string) {}
    abstract getRole(): string;
    abstract getPermissions(): string[];
}

class Guest extends BaseUser {
    getRole(): string {
        return "Guest";
    }
    getPermissions(): string[] {
        return ["Просмотр контента"];
    }
}

class User extends BaseUser {
    getRole(): string {
        return "User";
    }
    getPermissions(): string[] {
        return ["Просмотр контента", "Оставлять комментарии"];
    }
}

class Admin extends BaseUser {
    getRole(): string {
        return "Admin";
    }
    getPermissions(): string[] {
        return ["Просмотр контента", "Оставлять комментарии", "Удалять контент", "Управлять пользователями"];
    }
}

const guest = new Guest(1, "Аноним");
console.log(guest.getRole(), guest.getPermissions());
const user = new User(2, "Иван");
console.log(user.getRole(), user.getPermissions());
const admin = new Admin(3, "Мария");
console.log(admin.getRole(), admin.getPermissions());

// Задача 2: Полиморфизм и интерфейсы
interface IReport {
    generate(): string;
}

class BaseReport {
    constructor(protected title: string, protected content: string) {}
}

class HTMLReport extends BaseReport implements IReport {
    generate(): string {
        return `<h1>${this.title}</h1><p>${this.content}</p>`;
    }
}

class JSONReport extends BaseReport implements IReport {
    generate(): string {
        return JSON.stringify({ title: this.title, content: this.content });
    }
}

const report1 = new HTMLReport("Отчет 1", "Содержание отчета");
console.log(report1.generate());
const report2 = new JSONReport("Отчет 2", "Содержание отчета");
console.log(report2.generate());

// Задача 3: Обобщенный кеш данных
class MyCache<T> {
    private cache: { [key: string]: { value: T; expiry: number } } = {};

    add(key: string, value: T, ttl: number): void {
        const expiry = Date.now() + ttl;
        this.cache[key] = { value: value, expiry: expiry };
    }

    get(key: string): T | null {
        this.clearExpired(); 
        if (this.cache[key]) {
            return this.cache[key].value;
        }
        return null;
    }

    clearExpired(): void {
        const now = Date.now();
        for (const key in this.cache) {
            if (this.cache.hasOwnProperty(key) && this.cache[key].expiry <= now) {
                delete this.cache[key];
            }
        }
    }
}

const cache = new MyCache<number>(); 
cache.add("price", 150, 5000);
console.log(cache.get("price"));
setTimeout(() => console.log(cache.get("price")), 6000);  // null


// Задача 4: Дженерик-фабрика
function createInstance<T>(cls: new (...args: any[]) => T, ...args: any[]): T {
    return new cls(...args);
}

class Product {
    constructor(public name: string, public price: number) {}
}

const product = createInstance(Product, "Телефон", 50000);
console.log("Созданный продукт:", product);  // Созданный продукт: Product { name: 'Телефон', price: 50000 }

// Задача 5: Логирование событий с кортежами
enum LogLevel {
    INFO = "INFO",            // информационные сообщения
    WARNING = "WARNING",      // предупреждения
    ERROR = "ERROR"           // ошибки
}

type LogEntry = [Date, LogLevel, string];

function logEvent(event: LogEntry): void {           // [2025-03-07T12:34:56.789Z] INFO: Система запущена
    console.log(`[${event[0].toISOString()}] ${event[1]}: ${event[2]}`);
}

logEvent([new Date(), LogLevel.INFO, "Система запущена"]);

// Задача 6: Типы безопасных API-ответов
enum HttpStatus {
    OK = 200,      // запрос успешный
    BAD_REQUEST = 400,  // неверный запрос
    UNAUTHORIZED = 401,  // неавторизован
    NOT_FOUND = 404,    // не найдено
    INTERNAL_SERVER_ERROR = 500  // ошибка сервера
}

type ApiResponse<T> = [HttpStatus, T | null, string?];

function Success<T>(data: T): ApiResponse<T> {
    return [HttpStatus.OK, data];
}

function error(message: string, status: HttpStatus): ApiResponse<null> {
    return [status, null, message];
}

const res1 = Success({ user: "Андрей" });
console.log("Успешный ответ:", res1);
const res2 = error("Не найдено", HttpStatus.NOT_FOUND);
console.log("Ошибка:", res2);