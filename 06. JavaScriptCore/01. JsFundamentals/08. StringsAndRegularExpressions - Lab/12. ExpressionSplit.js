function solve(input) {
    let elements = input.split(/[\s.();,]+/);
    console.log(elements.join('\n'));
}

solve('let sum = 1 + 2;if(sum > 2){\tconsole.log(sum);}');