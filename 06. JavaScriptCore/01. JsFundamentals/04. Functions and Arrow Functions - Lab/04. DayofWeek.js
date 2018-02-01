function dayOfWeek(day) {
    let myDays= ["Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"];

    if(myDays.includes(day)) { return myDays.indexOf(day) + 1 }
    else { return "error"; }
}

console.log(dayOfWeek("Sunday"));