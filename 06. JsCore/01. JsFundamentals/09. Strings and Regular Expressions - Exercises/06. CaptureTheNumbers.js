function solve(arr) {
    let str = arr.join(' ');
    let numbers = str.match(/\d+/g);
    console.log(numbers.join(' '));
}

solve(['123a456', '789b987', '654c321', '0']);
solve(['Let’s ', 'go11!!!11!', 'Okey!1!']);