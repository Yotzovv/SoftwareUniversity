function solve(arr) {
    let data = new Map();

    for (let row of arr) {
        let [town, product, price] = row.split(/\s*\|\s*/);
        price = Number(price);

        if (!data.has(product)) {
            product = product.trim();
            data.set(product, new Map());
        }

        data.get(product).set(town, price);
    }

    //console.log(data);//

    for(let product of data) {
        let towns = [...product[1]];
        towns.sort((a,b) => {
            return a[1] > b[1]
        });
        console.log(`${product[0]} -> ${towns[0][1]} (${towns[0][0]})`);
    }
}


solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']);

//solve(['Sofia City | Audi | 100000',
//    'Sofia City | BMW | 100000',
//    'Sofia City | Mitsubishi | 10000',
//    'Sofia City | Mercedes | 10000',
//    'Sofia City | NoOffenseToCarLovers | 0',
//    'Mexico City | Audi | 1000',
//    'Mexico City | BMW | 99999',
//    'New York City | Mitsubishi | 10000',
//    'New York City | Mitsubishi | 1000',
//    'Mexico City | Audi | 100000',
//    'Washington City | Mercedes | 1000])'])