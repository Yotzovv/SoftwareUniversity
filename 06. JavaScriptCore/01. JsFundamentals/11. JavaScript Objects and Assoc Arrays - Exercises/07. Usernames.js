function solve(arr) {
    arr.sort((a, b) => {
        if(a.length < b.length) {
            return -1;
        }

        if(a.length > b.length) {
            return 1;
        }

    });


    console.log(arr.join('\n'));
}

//solve(['Ashton',
//'Kutcher',
//'Ariel',
//'Lilly',
//'Keyden',
//'Aizen',
//'Billy',
//'Braston']);

solve(['Denise',
'Ignatius',
'Iris',
'Isacc',
'Indie',
'Dean',
'Donatello',
'Enfuego',
'Benjamin',
'Biser',
'Bounty',
'Renard',
'Rot'])