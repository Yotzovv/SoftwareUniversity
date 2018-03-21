class PaymentProcessor {
    constructor() {
        this.types = arguments.length > 0 ? arguments[0].types : ["service", "product", "other"];

        if(arguments.length > 0 && arguments[0].precision !== undefined) {
            this.precision = arguments[0].precision;
        } else {
            this.precision = 2;
        }

        this.payments = [];
    }

    registerPayment(id, name, type, value) {
        var element = this.payments.find(x => x.id === id);

        if (element === undefined) {
            var payment = {
                id: id,
                name: name,
                type: type,
                value: Number(value)
            };

            this.payments.push(payment);
        }

    }

    deletePayment(id) {
        var element = this.payments.find(x => x.id === id);

        if (element === undefined) {
            throw new Error('ID not found');
        }

        this.payments.splice(this.payments.indexOf(element), 1);


    }

    get(id) {
        var element = this.payments.find(x => x.id === id);

        if (element === undefined) {
            throw new Error('ID not found');
        }

        var result = 'Details about payment ID: EO28\n';

        result += `- Name: ${element.name}\n`;
        result += `- Type: ${element.type}\n`;
        result += `- Value: ${element.value.toFixed(this.precision)}\n`;

        return result;

    }

    setOptions(options) {
        if(options.types !== undefined) {
            this.types = options.types;
        }

        if(options.precision !== undefined) {
            this.precision = options.precision;
        }
    }

    toString() {
        let result = 'Summary:\n';
        result += `- Payments: ${this.payments.length}\n`;
        let balance = 0;

        for (let price of this.payments) {
            balance += price.value;
        }

        result += `- Balance: ${balance.toFixed(this.precision)}`;

        return result;
    }
}


// Initialize processor with default options
const generalPayments = new PaymentProcessor();
generalPayments.registerPayment('0001', 'Microchips', 'product', 15000);
generalPayments.registerPayment('01A3', 'Biopolymer', 'product', 23000);
console.log(generalPayments.toString());

// Should throw an error (invalid type)
generalPayments.registerPayment('E028', 'Rare-earth elements', 'materials', 8000);

generalPayments.setOptions({types: ['product', 'material']});
generalPayments.registerPayment('E028', 'Rare-earth elements', 'material', 8000);
console.log(generalPayments.get('E028'));
generalPayments.registerPayment('CF15', 'Enzymes', 'material', 55000);

generalPayments.deletePayment('E028');
console.log(generalPayments.toString());

// Initialize processor with custom types
const servicePyaments = new PaymentProcessor({types: ['service']});
servicePyaments.registerPayment('01', 'HR Consultation', 'service', 3000);
servicePyaments.registerPayment('02', 'Discount', 'service', -1500);
console.log(servicePyaments.toString());

// Initialize processor with custom precision
const transactionLog = new PaymentProcessor({precision: 5});
transactionLog.registerPayment('b5af2d02-327e-4cbf', 'Interest', 'other', 0.00153);
console.log(transactionLog.toString());
