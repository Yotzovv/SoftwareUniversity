const homeHandler = require('./home');
const filesHandler = require('./static-files')
const productsHandler = require('./product')

module.exports = [ homeHandler, filesHandler, productsHandler ]