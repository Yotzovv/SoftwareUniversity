function solve(car) {

    let engine;
    let carriage;
    let wheels = []
  
    if (car.power <= 90) {
      engine = {
        power: 90,
        volume: 1800
      }
    } else if (car.power <= 120) {
      engine = {
        power: 120,
        volume: 2400
      }
    } else {
      engine = {
        power: 200,
        volume: 3500
      }
    }

      
    carriage = {
      type: car.carriage,
      color: car.color
    }
    if (car.wheelsize % 2 == 0) {
      car.wheelsize--;
    }
  
    for (let i = 0; i < 4; i++) {
      wheels.push(car.wheelsize)
    }
  
    return {
      model: car.model,
      engine: engine,
      carriage: carriage,
      wheels: wheels
    }
  }