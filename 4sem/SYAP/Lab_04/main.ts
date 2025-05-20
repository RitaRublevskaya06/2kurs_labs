console.log('Начало работы');

// 1. Создать промис, который через 3 секунды генерирует случайное число
const myPromise: Promise<number> = new Promise((resolve) => {
    setTimeout(() => {
        const randomNumber: number = Math.floor(Math.random() * 10);
        resolve(randomNumber);
    }, 3000);
});

myPromise.then(number => console.log('Случайное число:', number));
// Вывод:
// Случайное число: X


// 2. Функция, принимающая параметр delay и возвращающая промис
const generateNumber = (delay: number): Promise<number> => {
    return new Promise(resolve => {
        setTimeout(() => {
            const randomNumber: number = Math.floor(Math.random() * 10);
            resolve(randomNumber);
        }, delay);
    });
};

Promise.all([generateNumber(3000), generateNumber(4000), generateNumber(5000)])
    .then(numbers => console.log('Сгенерированные числа:', numbers));
// Вывод:
// Случайное число: X Сгенерированные числа: [X, Y, Z]



// 3. Анализ поведения цепочки then/catch
let pr = new Promise((res, rej) => {
    rej('ku');
});

pr
    .then(() => console.log(1))  
    .catch(() => console.log(2))
    .catch(() => console.log(3))
    .then(() => console.log(4))
    .then(() => console.log(5));
// Вывод:
// 2
// 4
// 5



// 4. Создать промис с числом 21 и вызвать цепочку then
const promise21: Promise<number> = new Promise(resolve => resolve(21));

promise21
    .then(num => {
        console.log(num);
        return num;
    })
    .then(num => {
        console.log(num * 2);
    });
// Вывод:
// 21
// 42

// 5. Реализация через async/await
async function asyncExample(): Promise<void> {
    const num: number = await promise21;
    console.log(num);
    console.log(num * 2);
}
asyncExample();
// Вывод:
// 21
// 42

// 7. Вывод в консоль
let promise_7 = new Promise((res, rej) => {
    res('Resolved promise - 1');
});

promise_7
    .then((res) => {
        console.log("Resolved promise - 2");
        return "OK";
    })
    .then((res) => {
        console.log(res);
    });
// Вывод:
// Resolved promise - 2
// OK


// 8. Вывод в консоль
let promise_8 = new Promise((res, rej) => {
    res('Resolved promise - 1');
});

promise_8
    .then((res) => {
        console.log(res);
        return 'OK';
    })
    .then((res1) => {
        console.log(res1);
    });
// Вывод:
// Resolved promise - 1
// OK


// 9. Вывод в консоль
let promise_9 = new Promise((res, rej) => {
    res('Resolved promise - 1');
});

promise_9
    .then((res) => {
        console.log(res);
        return res;
    })
    .then((res1) => {
    console.log('Resolved promise - 2');
});
// Вывод:
// Resolved promise - 1
// Resolved promise - 2


// 10. Вывод в консоль
let promise_10 = new Promise((res, rej) => {
    res('Resolved promise - 1');
});

promise_10
    .then((res) => {
        console.log(res);
        return res;
    })
    .then((res1) => {
        console.log(res1);
    });
// Вывод:
// Resolved promise - 1
// Resolved promise - 1


// 11. Вывод в консоль 
let promise_11 = new Promise((res, rej) => {
    res('Resolved promise - 1');
});

promise_11
    .then((res) => {
        console.log(res);
    })
    .then((res1) => {
        console.log(res1);
    });
// Вывод:
// Resolved promise - 1
// undefined


// 12. Вывод в консоль
let pr_12 = new Promise((res, rej) => {
    rej('ku');
});

pr_12
    .then(() => console.log(1))
    .catch(() => console.log(2))
    .catch(() => console.log(3)) 
    .then(() => console.log(4))
    .then(() => console.log(5))
// Вывод:
// 2
// 4
// 5













// const myPromise: Promise<number> = new Promise((resolve, reject) => {
//     setTimeout(() => {
//         const randomNumber: number = Math.floor(Math.random() * 10);
//         if (randomNumber < 5) {
//             reject(new Error("Число меньше 5, операция не выполнена"));
//         } else {
//             resolve(randomNumber);
//         }
//     }, 3000);
// });

// myPromise
//     .then((result) => {
//         console.log("Успех:", result);
//     })
//     .catch((error) => {
//         console.error("Ошибка:", error.message);
//     });
