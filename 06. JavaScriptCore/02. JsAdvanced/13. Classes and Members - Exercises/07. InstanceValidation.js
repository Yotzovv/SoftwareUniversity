let CheckingAccount = (
    function () {
      function validate(prop, value, position) {
  
        let template = {
          "clientID": /^[0-9]{6}$/g,
          "email": /^[A-Za-z0-9]+@[A-Za-z.]+$/g,
          "name": /^[A-Za-z]+$/g,
          "nameLenght": /^.{3,20}$/g,
        }
  
        switch (prop) {
          case "clientID":
            if (!template[prop].test(value)) {
              throw new TypeError('Client ID must be a 6-digit number');
            }
            break;
  
          case "email":
            if (!template[prop].test(value)) {
              throw new TypeError('Invalid e-mail');
            }
            break;
  
          case "nameLenght":
            if (!template[prop].test(value)) {
              throw new TypeError(`${position} must be between 3 and 20 characters long`);
            }
            break;
  
          case "name":
            if (!template[prop].test(value)) {
              throw new TypeError(`${position} must contain only Latin characters`);
            }
            break;
        }
  
      }
      class CheckingAccount {
  
        constructor(clientId, email, firstName, lastName) {
          this.clientId = clientId;
          this.email = email;
          this.firstName = firstName;
          this.lastName = lastName;
          this.products = [];
        }
  
        set clientId(value) {
          validate("clientID", value);
          this._clientId = value;
        }
        get clientId() {
          return this._clientId;
        }
  
        set email(value) {
          validate("email", value);
          this._email = value;
        }
        get email() {
          return this._email;
        }
  
        set firstName(value) {
          validate("nameLenght", value, "First name");
          validate("name", value, "First name");
          this._firstName = value;
        }
  
        get firstName() {
          return this._firstName;
        }
  
        set lastName(value) {
          validate("nameLenght", value,"Last name");
          validate("name", value,"Last name");
          this._lastName = value;
        }
  
        get lastName() {
          return this._lastName;
        }
  
      }
      return CheckingAccount;
    }
  
  )();
  
  let acc = new CheckingAccount('131455', 'ivan@', 'Ivan', 'Petrov')
