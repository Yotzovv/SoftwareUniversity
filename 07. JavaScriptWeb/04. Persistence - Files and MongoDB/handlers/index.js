const homeHandler = require('./home');
const filesHandler = require('./static-files')
const productsHandler = require('./product')
const categoryHandler = require('./category')

module.exports = [ homeHandler, filesHandler, productsHandler, categoryHandler ]