var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __spreadArray = (this && this.__spreadArray) || function (to, from, pack) {
    if (pack || arguments.length === 2) for (var i = 0, l = from.length, ar; i < l; i++) {
        if (ar || !(i in from)) {
            if (!ar) ar = Array.prototype.slice.call(from, 0, i);
            ar[i] = from[i];
        }
    }
    return to.concat(ar || Array.prototype.slice.call(from));
};
// Задача 1: Система управления пользователями
var BaseUser = /** @class */ (function () {
    function BaseUser(id, name) {
        this.id = id;
        this.name = name;
    }
    return BaseUser;
}());
var Guest = /** @class */ (function (_super) {
    __extends(Guest, _super);
    function Guest() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Guest.prototype.getRole = function () {
        return "Guest";
    };
    Guest.prototype.getPermissions = function () {
        return ["Просмотр контента"];
    };
    return Guest;
}(BaseUser));
var User = /** @class */ (function (_super) {
    __extends(User, _super);
    function User() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    User.prototype.getRole = function () {
        return "User";
    };
    User.prototype.getPermissions = function () {
        return ["Просмотр контента", "Оставлять комментарии"];
    };
    return User;
}(BaseUser));
var Admin = /** @class */ (function (_super) {
    __extends(Admin, _super);
    function Admin() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Admin.prototype.getRole = function () {
        return "Admin";
    };
    Admin.prototype.getPermissions = function () {
        return ["Просмотр контента", "Оставлять комментарии", "Удалять контент", "Управлять пользователями"];
    };
    return Admin;
}(BaseUser));
var guest = new Guest(1, "Аноним");
console.log(guest.getRole(), guest.getPermissions());
var user = new User(2, "Иван");
console.log(user.getRole(), user.getPermissions());
var admin = new Admin(3, "Мария");
console.log(admin.getRole(), admin.getPermissions());
var BaseReport = /** @class */ (function () {
    function BaseReport(title, content) {
        this.title = title;
        this.content = content;
    }
    return BaseReport;
}());
var HTMLReport = /** @class */ (function (_super) {
    __extends(HTMLReport, _super);
    function HTMLReport() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    HTMLReport.prototype.generate = function () {
        return "<h1>".concat(this.title, "</h1><p>").concat(this.content, "</p>");
    };
    return HTMLReport;
}(BaseReport));
var JSONReport = /** @class */ (function (_super) {
    __extends(JSONReport, _super);
    function JSONReport() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    JSONReport.prototype.generate = function () {
        return JSON.stringify({ title: this.title, content: this.content });
    };
    return JSONReport;
}(BaseReport));
var report1 = new HTMLReport("Отчет 1", "Содержание отчета");
console.log(report1.generate());
var report2 = new JSONReport("Отчет 2", "Содержание отчета");
console.log(report2.generate());
// Задача 3: Обобщенный кеш данных
var MyCache = /** @class */ (function () {
    function MyCache() {
        this.cache = {};
    }
    MyCache.prototype.add = function (key, value, ttl) {
        var expiry = Date.now() + ttl;
        this.cache[key] = { value: value, expiry: expiry };
    };
    MyCache.prototype.get = function (key) {
        this.clearExpired();
        if (this.cache[key]) {
            return this.cache[key].value;
        }
        return null;
    };
    MyCache.prototype.clearExpired = function () {
        var now = Date.now();
        for (var key in this.cache) {
            if (this.cache.hasOwnProperty(key) && this.cache[key].expiry <= now) {
                delete this.cache[key];
            }
        }
    };
    return MyCache;
}());
var cache = new MyCache();
cache.add("price", 150, 5000);
console.log(cache.get("price"));
setTimeout(function () { return console.log(cache.get("price")); }, 6000); // null
// Задача 4: Дженерик-фабрика
function createInstance(cls) {
    var args = [];
    for (var _i = 1; _i < arguments.length; _i++) {
        args[_i - 1] = arguments[_i];
    }
    return new (cls.bind.apply(cls, __spreadArray([void 0], args, false)))();
}
var Product = /** @class */ (function () {
    function Product(name, price) {
        this.name = name;
        this.price = price;
    }
    return Product;
}());
var product = createInstance(Product, "Телефон", 50000);
console.log("Созданный продукт:", product); // Созданный продукт: Product { name: 'Телефон', price: 50000 }
// Задача 5: Логирование событий с кортежами
var LogLevel;
(function (LogLevel) {
    LogLevel["INFO"] = "INFO";
    LogLevel["WARNING"] = "WARNING";
    LogLevel["ERROR"] = "ERROR"; // ошибки
})(LogLevel || (LogLevel = {}));
function logEvent(event) {
    console.log("[".concat(event[0].toISOString(), "] ").concat(event[1], ": ").concat(event[2]));
}
logEvent([new Date(), LogLevel.INFO, "Система запущена"]);
// Задача 6: Типы безопасных API-ответов
var HttpStatus;
(function (HttpStatus) {
    HttpStatus[HttpStatus["OK"] = 200] = "OK";
    HttpStatus[HttpStatus["BAD_REQUEST"] = 400] = "BAD_REQUEST";
    HttpStatus[HttpStatus["UNAUTHORIZED"] = 401] = "UNAUTHORIZED";
    HttpStatus[HttpStatus["NOT_FOUND"] = 404] = "NOT_FOUND";
    HttpStatus[HttpStatus["INTERNAL_SERVER_ERROR"] = 500] = "INTERNAL_SERVER_ERROR"; // ошибка сервера
})(HttpStatus || (HttpStatus = {}));
function Success(data) {
    return [HttpStatus.OK, data];
}
function error(message, status) {
    return [status, null, message];
}
var res1 = Success({ user: "Андрей" });
console.log("Успешный ответ:", res1);
var res2 = error("Не найдено", HttpStatus.NOT_FOUND);
console.log("Ошибка:", res2);
