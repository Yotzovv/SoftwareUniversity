const storage=require('./storage')

storage.put('First', 'FirsPlayer')
storage.put('Second', 'SecondPlayer')
console.log(storage.get('First'))

console.log(storage.getAll())

storage.update('First', 'ChangedFirstPlayer')
console.log(storage.get('First'))

storage.save()
storage.load()
storage.put('Third', 'ThirdPlayer')
storage.save()
storage.load()
console.log(storage.getAll())