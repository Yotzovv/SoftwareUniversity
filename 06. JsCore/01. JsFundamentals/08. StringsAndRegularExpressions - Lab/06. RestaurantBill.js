function solve(arr) {
    let purchases = [], sum = 0;

    for(let i = 0; i < arr.length; i++) {
        if(i % 2 == 0) {
            purchases.push(arr[i]);
        } else {
            sum += Number(arr[i]);
        }
    }
    console.log(`You purchased ${purchases.join(', ')} for a total sum of ${sum}`);
}

solve(['Cola', '1.35', 'Pancakes', '2.88']);