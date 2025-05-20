var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g = Object.create((typeof Iterator === "function" ? Iterator : Object).prototype);
    return g.next = verb(0), g["throw"] = verb(1), g["return"] = verb(2), typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (g && (g = 0, op[0] && (_ = 0)), _) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
console.log('Начало работы');
// 1. Создать промис, который через 3 секунды генерирует случайное число
var myPromise = new Promise(function (resolve) {
    setTimeout(function () {
        var randomNumber = Math.floor(Math.random() * 10);
        resolve(randomNumber);
    }, 3000);
});
myPromise.then(function (number) { return console.log('Случайное число:', number); });
// Вывод:
// Случайное число: X
// 2. Функция, принимающая параметр delay и возвращающая промис
var generateNumber = function (delay) {
    return new Promise(function (resolve) {
        setTimeout(function () {
            var randomNumber = Math.floor(Math.random() * 10);
            resolve(randomNumber);
        }, delay);
    });
};
Promise.all([generateNumber(3000), generateNumber(4000), generateNumber(5000)])
    .then(function (numbers) { return console.log('Сгенерированные числа:', numbers); });
// Вывод:
// Случайное число: X Сгенерированные числа: [X, Y, Z]
// 3. Анализ поведения цепочки then/catch
var pr = new Promise(function (res, rej) {
    rej('ku');
});
pr
    .then(function () { return console.log(1); })
    .catch(function () { return console.log(2); }) // Будет выполнено, так как промис был отклонен
    .catch(function () { return console.log(3); }) // Не выполнится, так как ошибка уже обработана
    .then(function () { return console.log(4); }) // Выполнится
    .then(function () { return console.log(5); }); // Выполнится
// Вывод:
// 2
// 4
// 5
// 4. Создать промис с числом 21 и вызвать цепочку then
var promise21 = new Promise(function (resolve) { return resolve(21); });
promise21
    .then(function (num) {
    console.log(num);
    return num;
})
    .then(function (num) {
    console.log(num * 2);
});
// Вывод:
// 21
// 42
// 5. Реализация через async/await
function asyncExample() {
    return __awaiter(this, void 0, void 0, function () {
        var num;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0: return [4 /*yield*/, promise21];
                case 1:
                    num = _a.sent();
                    console.log(num);
                    console.log(num * 2);
                    return [2 /*return*/];
            }
        });
    });
}
asyncExample();
// Вывод:
// 21
// 42
// 7. Вывод в консоль
var promise_7 = new Promise(function (res, rej) {
    res('Resolved promise - 1');
});
promise_7
    .then(function (res) {
    console.log("Resolved promise - 2");
    return "OK";
})
    .then(function (res) {
    console.log(res);
});
// Вывод:
// Resolved promise - 2
// OK
// 8. Вывод в консоль
var promise_8 = new Promise(function (res, rej) {
    res('Resolved promise - 1');
});
promise_8
    .then(function (res) {
    console.log(res);
    return 'OK';
})
    .then(function (res1) {
    console.log(res1);
});
// Вывод:
// Resolved promise - 1
// OK
// 9. Вывод в консоль
var promise_9 = new Promise(function (res, rej) {
    res('Resolved promise - 1');
});
promise_9
    .then(function (res) {
    console.log(res);
    return res;
})
    .then(function (res1) {
    console.log('Resolved promise - 2');
});
// Вывод:
// Resolved promise - 1
// Resolved promise - 2
// 10. Вывод в консоль
var promise_10 = new Promise(function (res, rej) {
    res('Resolved promise - 1');
});
promise_10
    .then(function (res) {
    console.log(res);
    return res;
})
    .then(function (res1) {
    console.log(res1);
});
// Вывод:
// Resolved promise - 1
// Resolved promise - 1
// 11. Вывод в консоль 
var promise_11 = new Promise(function (res, rej) {
    res('Resolved promise - 1');
});
promise_11
    .then(function (res) {
    console.log(res);
})
    .then(function (res1) {
    console.log(res1);
});
// Вывод:
// Resolved promise - 1
// undefined
// 12. Вывод в консоль
var pr_12 = new Promise(function (res, rej) {
    rej('ku');
});
pr_12
    .then(function () { return console.log(1); })
    .catch(function () { return console.log(2); })
    .catch(function () { return console.log(3); })
    .then(function () { return console.log(4); })
    .then(function () { return console.log(5); });
// Вывод:
// 2
// 4
// 5
