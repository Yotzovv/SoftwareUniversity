function solve(email) {
    let pattern = /^[a-zA-Z0-9]+@[a-z]+(\.[a-z]+)+$/g;
    let result = pattern.test(email);

    if(result) { console.log('Valid') }
    else { console.log('Invalid') }
}

solve('valid@email.bg');
solve('invalid@emai1.bg');