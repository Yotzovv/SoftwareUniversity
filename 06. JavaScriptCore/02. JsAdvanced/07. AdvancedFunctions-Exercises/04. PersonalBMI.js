function solve(name, age, weight, height) {
    let obj = {
        name: name,
        personalInfo: {
            age,
            weight,
            height
        },
        BMI: Math.round(weight / (Math.pow((height / 100), 2))),
        status: undefined,
    };

    obj.status = getStatus(obj);
    return obj;

    function getStatus(obj) {
        if (obj.BMI < 18.5) {
            return 'underweight';
        } else if (obj.BMI < 25) {
            return 'normal';
        } else if (obj.BMI < 30) {
            return 'overweight';
        } else if (obj.BMI >= 30) {
            obj.recommendation = 'admission required';
            return 'obese';
        }
    }
}

console.log(solve('Peter', 29, 75, 182))
console.log(solve('Honey Boo Boo', 9, 57, 137));