function fruitOrVegetable(input) {
    let fruits = ["banana", "apple", "kiwi", "cherry", "lemon", "grapes", "peach"];
    let veggies = ["tomato", "cucumber", "pepper", "onion", "garlic", "parsley"];

    if (fruits.includes(input)) {
        console.log("fruit")
    }
    else if (veggies.includes(input)) {
        console.log("vegetable")
    }
    else {
        console.log("unknown")
    }
}