function drawSquare(n) {
    n = n % 2 == 0 ? n - 1 : n;

    let output = '+' + '-'.repeat(n-2) + '+' + '-'.repeat(n-2) + '+\n';

    output += ('|' + ' '.repeat(n-2) + '|' + ' '.repeat(n-2) + '|\n').repeat(((n % 2 == 0 ? n - 1 : n) - 3)/2);

    output += '+' + '-'.repeat(n-2) + '+' + '-'.repeat(n-2) + '+\n';
    output += ('|' + ' '.repeat(n-2) + '|' + ' '.repeat(n-2) + '|\n').repeat(((n % 2 == 0 ? n - 1 : n) - 3)/2);

    output += '+' + '-'.repeat(n-2) + '+' + '-'.repeat(n-2) + '+\n';

    console.log(output);
}

drawSquare(-1);
drawSquare(5);
drawSquare(6);
drawSquare(7);