function isValid(input,[x1, y1, x2, y2] = input) {
    if (getDistance(x1, y1, 0, 0) % 1 == 0) {
        print('valid', x1, y1, 0, 0);
    } else {
        print('invalid', x1, y1, 0, 0)
    }

    if (getDistance(x2, y2, 0, 0) % 1 == 0) {
        print('valid', x2, y2, 0, 0);
    } else {
        print('invalid', x2, y2, 0, 0);
    }

    if (getDistance(x1, y1, x2, y2) % 1 == 0) {
        print('valid', x1, y1, x2, y2);
    } else {
        print('invalid', x1, y1, x2, y2)
    }
    ;

    function getDistance(x1, y1, x2, y2) {
        return Math.sqrt(Math.pow(x1 - x2, 2) + Math.pow(y1 - y2, 2));
    }

    function print(msg, x1, y1, x2, y2) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${msg}`);
    }
}

isValid([3, 0, 0, 4]);