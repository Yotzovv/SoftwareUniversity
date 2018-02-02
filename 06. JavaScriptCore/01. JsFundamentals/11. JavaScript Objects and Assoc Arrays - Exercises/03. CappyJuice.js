function solve(arr) {
    let juiceBottles = new Map();
    let juicesQuantities = new Map();

    for (let juice of arr) {
        let [juiceName, quantity] = juice.split(/\s*=>\s*/);
        quantity = Number(quantity);

        if (!juicesQuantities.has(juiceName)) {
            juicesQuantities.set(juiceName, quantity);
        } else {
            juicesQuantities.set(juiceName, juicesQuantities.get(juiceName) + quantity);
        }

        if (juicesQuantities.get(juiceName) >= 1000) {
            if (!juiceBottles.has(juiceName)) {
                juiceBottles.set(juiceName, parseInt((juicesQuantities.get(juiceName) / 1000).toString()));
            } else {
                juiceBottles.set(juiceName, parseInt((juicesQuantities.get(juiceName) / 1000).toString()));
            }
        }
    }

    console.log();
    for (let bottle of juiceBottles) {
        console.log(`${bottle[0]} => ${bottle[1]}`);
    }
}

//solve(['Orange => 2000',
//'Peach => 1432',//
//'Banana => 450',
//'Peach => 600',
//'Strawberry => 549']);

solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']);