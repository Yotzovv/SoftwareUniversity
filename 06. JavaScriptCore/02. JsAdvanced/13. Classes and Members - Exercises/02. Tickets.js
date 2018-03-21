function solve(arr, sort) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = [];

    for (let element of arr) {
        var [destination, price, status] = element.split('|');
        price = Number(price);

        tickets.push(new Ticket(destination, price, status));
    }

    switch (sort) {
        case 'destination':
            tickets.sort((a, b) => a.destination > b.destination);
            break;
        case 'price':
            tickets.sort((a, b) => a.price > b.price);
            break;
        case 'status':
            tickets.sort((a, b) => a.status > b.status);
            break;
    }

    return tickets;
}

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'));

