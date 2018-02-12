function solve(portions, commands) {
    let mealsEaten = 0;

    for(let cmd of commands) {
        let params = cmd.split(' ').slice(1);
        cmd = cmd.split(' ')[0];

        switch (cmd) {
            case 'Serve':
                if(portions.length < 1) {
                    break;
                }
                console.log(`${portions.pop()} served!`);
                break;
            case 'Eat':
                if(portions.length < 1) {
                    break;
                }
                console.log(`${portions.shift()} eaten`);
                mealsEaten++;
                break;
            case 'Add':
                portions.unshift(params[0]);
                break;
            case 'Consume':
                if (params[0] < portions.length) {
                    if (portions.length > Number(params[1]) + Number(params[0])) {
                        portions.splice(params[0], Number(params[1]) - Number(params[0])+1);
                        mealsEaten += params[1] - params[0] + 1;
                        console.log('Burp!');
                    }
                }
                break;
            case 'Shift':
                if(portions[Number(params[0])] != undefined && portions[Number(portions[1])] != undefined) {
                    var b = portions[params[0]];
                    portions[params[0]] = portions[params[1]];
                    portions[params[1]] = b;
                }
                break;
            case "End":
                break;
        }
    }

    if(portions.length > 0) {
        console.log(`Meals left: ${portions.join(', ')}`);
    } else {
        console.log(`The food is gone`);
    }

    console.log(`Meals eaten: ${mealsEaten}`);
}


//solve(['chicken', 'st//eggs'],
//    ['Serve', 'Eat', //'Consume 0 1']);
//console.log();
//solve(['fries', 'fish//r', 'chicken', 'beer', 'eggs'],
//    ['Add spaghetti',
//        'Shift 0 1',
//        'Consume 1 4',
//        'End']);
//console.log();
//solve(['carrots', 'apple'],
//    ['Consume 0 2',
//        'End',]);