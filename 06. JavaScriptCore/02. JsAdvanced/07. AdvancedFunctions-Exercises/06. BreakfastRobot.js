let meal = {
    protein: 0,
    carbohydrate: 0,
    fat: 0,
    flavour: 0
};

let apple = { carbohydrate: 1, flavour: 2 };
let coke = { carbohydrate: 10, flavour: 20 };
let burger = { carbohydrate: 5, fat: 7, flavour: 3 };
let omelet = { protein: 5, fat: 1, flavour: 1 };
let cheverme = { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 };


function solve(parameters) {
    let [cmd, subject, quantity] = parameters.split(' ');
    quantity = Number(quantity);

    switch (cmd) {
        case 'restock':
            console.log(restock(subject, quantity));
            break;
        case 'prepare':
            console.log(prepare(subject, quantity));
            break;
        case 'report':
            console.log(`protein=${meal.protein} carbohydrate=${meal.carbohydrate} fat=${meal.fat} flavour=${meal.fat}`);
            break;
    }

    // console.log(meal);
}

function restock(subject, quantity) {
    switch (subject) {
        case 'protein': meal.protein += quantity;
            return 'Success';
        case 'carbohydrate': meal.carbohydrate += quantity;
            return 'Success';
        case 'fat': meal.fat += quantity;
            return 'Success';
        case 'flavour': meal.flavour += quantity;
            return 'Success';
    }
}

function prepare(recipe, quantity) {
    if (stockIsEnough(recipe)) {
        switch (recipe) {
            case 'apple':
                meal.carbohydrate -= apple.carbohydrate;
                meal.flavour -= apple.flavour;
                break;
            case 'coke':
                meal.carbohydrate -= coke.carbohydrate;
                meal.flavour -= coke.flavour;
                break;
            case 'burger':
                meal.carbohydrate -= burger.carbohydrate;
                meal.fat -= burger.fat;
                meal.flavour -= burger.flavour;
                break;
            case 'omelet':
                meal.protein -= omelet.protein;
                meal.fat -= omelet.fat;
                meal.flavour -= omelet.flavour;
                break;
            case 'cheverme':
                meal.protein -= cheverme.protein;
                meal.carbohydrate -= cheverme.carbohydrate;
                meal.fat -= cheverme.fat;
                meal.flavour -= cheverme.flavour;
                break;
        }
        return 'Success'
    } else {
        return missingIngredientError(recipe);
    }
}

function missingIngredientError(recipe) {
    let rObj = getRecipe(recipe);
    let missingIngr = '';

    if (recipe === 'apple') {
        if (meal.carbohydrate < rObj.carbohydrate) {
            missingIngr = 'carbohydrate';
        }

        if (meal.flavour < rObj.flavour) {
            missingIngr = 'flavour';
        }
    } else if (recipe === 'coke') {
        if (meal.carbohydrate < rObj.carbohydrate) {
            missingIngr = 'carbohydrate';
        }

        if (meal.flavour < rObj.flavour) {
            missingIngr = 'flavour';
        }
    } else if (recipe === 'burger') {
        if (meal.fat < rObj.fat) {
            missingIngr = 'fat';
        }

        if (meal.carbohydrate < rObj.carbohydrate) {
            missingIngr = 'carbohydrate';
        }

        if (meal.flavour < rObj.flavour) {
            missingIngr = 'flavour';
        }
    } else if (recipe === 'omelet') {
        if (meal.protein < rObj.protein) {
            missingIngr = 'protein';
        }

        if (meal.fat < rObj.fat) {
            missingIngr = 'fat';
        }

        if (meal.flavour < rObj.flavour) {
            missingIngr = 'flavour';
        }
    } else if (recipe === 'cheverme') {
        if (meal.protein < rObj.protein) {
            missingIngr = 'protein';
        }

        if (meal.carbohydrate < rObj.carbohydrate) {
            missingIngr = 'carbohydrate';
        }

        if (meal.fat < rObj.fat) {
            missingIngr = 'fat';
        }

        if (meal.flavour < rObj.flavour) {
            missingIngr = 'flavour';
        }
    }

    return `Error: not enough ${missingIngr} in stock`;
}

function stockIsEnough(recipe) {
    let recipeObj = getRecipe(recipe);

    if (meal.fat < recipeObj.fat
        || meal.carbohydrate < recipe.carbohydrate
        || meal.protein < recipe.protein
        || meal.flavour < recipe.flavour) {
        return false;
    }

    return true;
}

function getRecipe(recipeStr) {
    switch (recipeStr) {
        case 'apple': return apple;
        case 'coke': return coke;
        case 'burger': return burger;
        case 'omelet': return omelet;
        case 'cheverme': return cheverme;
    }
}

// solve('restock carbohydrate 10');
// solve('restock flavour 10');
// solve('prepare apple 1');
// solve('restock fat 10');
// solve('prepare burger 1');
// solve('report');

solve('prepare cheverme 1');
solve('restock protein 10');
solve('prepare cheverme 1');
solve('restock carbohydrate 10');
solve('prepare cheverme 1');
solve('restock fat 10');
solve('prepare cheverme 1');
solve('restock flavour 10');
solve('restock flavour 10');
solve('report');