function upCase(input) {
    let res = input.split(/\W+/).filter(w=>w!='').join(', ').toUpperCase();
    console.log(res.substring(0, res.length));
}

upCase('Hi, how are you?');