function solve(str) {
    str = str.split(' ');
    pattern = /^[\_][a-zA-Z0-9]+$/g;
    result = [];

    for(x of str) {
        if(x.match(pattern)) {
            result.push(x.slice(1));
        }
    }
    console.log(result.join(','));
}

solve('The _id and _age variables are both integers.');