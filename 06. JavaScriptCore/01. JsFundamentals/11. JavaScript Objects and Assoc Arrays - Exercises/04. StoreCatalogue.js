function solve(arr) {
    arr = arr.sort(function (a, b) {
        return a.localeCompare(b);
    });

    let currentLetter = '';

    for(let str of arr) {
        if(str[0] !== currentLetter) {
            currentLetter = str[0];
            console.log(currentLetter);
        }
        let output = str.split(/\s*:\s*/);

        console.log(`  ${output[0]}: ${output[1]}`);
    }
}

// solve(['Appricot : 20.4',
// 'Fridge : 1500',
// 'TV : 1499',
// 'Deodorant : 10',
// 'Boiler : 300',
// 'Apple : 1.25',
// 'Anti-Bug Spray : 15',
// 'T-Shirt : 10']);

solve(['Banana : 2',
'Rubic\'s Cube : 5',
'Raspberry P : 4999',
'Rolex : 100000',
'Rollon : 10',
'Rali Car : 2000000',
'Pesho : 0.000001',
'Barrel : 10'])