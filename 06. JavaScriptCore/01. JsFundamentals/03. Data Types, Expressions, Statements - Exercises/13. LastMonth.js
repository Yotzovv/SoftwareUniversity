function lastMonth(input) {
    let date = new Date(input[2], input[1]-1, 0);
    console.log(date.getDate());
}

lastMonth([17, 3, 2002]);