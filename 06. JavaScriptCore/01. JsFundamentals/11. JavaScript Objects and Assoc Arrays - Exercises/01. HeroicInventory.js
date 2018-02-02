function solve(arr) {
    let output = [];

    for(let row of arr) {
        let [name, level, items] = row.split(/\s*\/\s*/);
        level = Number(level);

        if(items != null) {
            items = items.split(', ');
        }

        let hero = {
            name : name,
            level : level,
            items : items,
        }

        output.push(JSON.stringify(hero));
    }

    console.log(`[${output.join('\n')}]`);
}

//solve(['Isacc / 25 / Apple, GravityGun',
//'Derek / 12 / BarrelVest, DestructionSword',
//'Hes / 1 / Desolator, Sentinel, Antara']);

solve(['Jake / 1000 / Gauss, HolidayGrenade'])
