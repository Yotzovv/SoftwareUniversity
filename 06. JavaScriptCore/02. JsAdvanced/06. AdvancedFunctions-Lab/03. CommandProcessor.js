function solve(arr) {
    let str = '';

    for (let e of arr) {
        let cmd = e.split(' ')[0];
        let param = e.split(' ')[1];

        switch (cmd) {
            case 'append':
                str = str + param;
                break;
            case 'removeStart':
                str = str.substring(param);
                break;
            case 'removeEnd':
                str = str.substring(0, str.length - param);
                break;
            case 'print':
                console.log(str);
                break;

        }
    }
}

solve(['append hello',
    'append again',
    'removeStart 3',
    'removeEnd 4',
    'print']);