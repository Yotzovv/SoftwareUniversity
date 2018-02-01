function solve(arr) {
    let result = new Map();

    for (let row of arr) {
        let [town, productName, quantity, price] = row.split(/\s*->\s*|:/);
        quantity = Number(quantity);
        price = Number(price);

        if (!result.has(town)) {
            result.set(town, new Map());
        }

        let income = (quantity * price);
        let oldIncome = result.get(town).get(productName);

        if (!isNaN(oldIncome)) {
            income += result.get(town).get(productName);
        }

        result.get(town).set(productName, income);
    }

    let output = Array.from(result.keys());

    for(let town of output) {
        console.log(`Town - ${town}`);

        for(let [product, income] of result.get(town)) {
            console.log(`$$$${product} : ${income}`);
        }
    }
}



solve(['Sofia -> Laptops HP -> 200 : 2000', 'Sofia -> Raspberry -> 200000 : 1500',
'Sofia -> Audi Q7 -> 200 : 100000', 'Montana -> Portokals -> 200000 : 1',
'Montana -> Qgodas -> 20000 : 0.2', 'Montana -> Chereshas -> 1000 : 0.3']);