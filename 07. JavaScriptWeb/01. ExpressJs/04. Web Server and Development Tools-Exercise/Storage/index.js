let storage = require("./storage").storage;

storage.load(() => {
    storage.clear()
    storage.put('first', 'firstValue')
    storage.put('second', 'secondValue')
    storage.put('third', 'thirdValue')

    console.log(storage.get('first'))

    console.log(storage.getAll())
    storage.delete('second')
    storage.update('first', 'updatedFirst')
    storage.save(() => {
        storage.clear()
        console.log(storage.getAll())
        storage.load(() => console.log(storage.getAll()))
    })
})