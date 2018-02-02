function solve(arr) {
    let nqkavsimizernamap = new Map();
    for(let row of arr) {
        let [system, component, subcomponent] = row.split(' | ');

        if(!nqkavsimizernamap.has(system)) {
            nqkavsimizernamap.set(system, new Map());
        }

        if(!nqkavsimizernamap.get(system).has(component)) {
            nqkavsimizernamap.get(system).set(component, []);
        }

        nqkavsimizernamap.get(system).get(component).push(subcomponent);
    }
    let sorted = new Map([...nqkavsimizernamap.entries()].sort((a, b) => {
        if ([...a[1]][0][1].length > [...b[1]][0][1].length) {
            return -1;
        }
        return 1;
    }));

    for(let [system, components] of sorted) {
        console.log(system);
        for(let [component, subcomponents] of components) {
            console.log(`|||${component}`);
            for(let subcomponent of subcomponents) {
                console.log(`||||||${subcomponent}`);
            }
        }
    }
}

solve(['SULS | Main Site | Home Page',
'SULS | Main Site | Login Page',
'SULS | Main Site | Register Page',
'SULS | Judge Site | Login Page',
'SULS | Judge Site | Submittion Page',
'Lambda | CoreA | A23',
'SULS | Digital Site | Login Page',
'Lambda | CoreB | B24',
'Lambda | CoreA | A24',
'Lambda | CoreA | A25',
'Lambda | CoreC | C4',
'Indice | Session | Default Storage',
'Indice | Session | Default Security']);