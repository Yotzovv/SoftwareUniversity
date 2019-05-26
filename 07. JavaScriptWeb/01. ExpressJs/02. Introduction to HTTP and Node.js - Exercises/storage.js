const fs=require('fs')
let storage={}

module.exports={
    put:(key,value) => {
        if(typeof key === 'string' && !storage.hasOwnProperty(key)){
            storage[key] = value
        } else {
            throw new Error('Key exists or is not string');
        }
    },
    get:(key) => {
        if(typeof key === 'string' && storage.hasOwnProperty(key)) {
            return storage[key];
        } else {
            throw new Error('The key doesnt exist!')
        }
    },
    getAll:() => {
        if(Object.keys(storage).length == 0) {
            throw new Error('Storage is empty!')
        }

        return storage;
    },
    update: (key, newValue) => {
        if(!typeof key == 'string' || !storage.hasOwnProperty(key)) {
            throw new Error('Key doesnt exist or is not of type string!')
        }

        storage[key] = newValue
    },
    delete: (key) => {
        if(!typeof key === 'string' || !storage.hasOwnProperty(key)) {
            throw new Error('Key doesnt exist or is not of type string!')
        }

        delete storage[key]
    },
    clear: () => {
        storage = {}
    },
    save: () => {
        let json = JSON.stringify(storage)
        fs.writeFileSync('storage.json', json)
    },
    load: () => {
        if(fs.existsSync('storage.json')) {
            let data = fs.readFileSync('storage.json')
            storage=JSON.parse(data);
        }
    }
}