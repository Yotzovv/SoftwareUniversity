function solve(arr) {
    let total = new Map();
    for(let dataRow of arr) {
        let [town, population] = dataRow.split(/\s*<->\s*/);
        population = Number(population);

        if(total.has(town)) {
            total.set(town, total.get(town) + population);
        } else {
            total.set(town, population);
        }
    }

    for(let [town, sum] of total) {
        console.log(town + " : " + sum);
    }
}

solve(['Sofia <-> 1200000', 'Montana <-> 20000', 'New York <-> 10000000',
'Washington <-> 2345000', 'Las Vegas <-> 1000000']);