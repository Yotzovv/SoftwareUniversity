function arrToObject(input) {
    let obj =  {
        [input[0]] : input[1],
        [input[2]] : input[3],
        [input[4]] : input[5],
    }
    console.log(obj);
}

arrToObject(['name', 'Pesho', 'age', '23', 'gender', 'male']);