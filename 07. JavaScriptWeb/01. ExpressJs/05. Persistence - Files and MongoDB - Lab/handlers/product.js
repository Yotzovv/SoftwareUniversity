const url = require('url')
// const database = require('../config/database.js')
const fs = require('fs')
const path = require('path')
const dbPath = path.join(__dirname, '/database.json')
const qs = require('querystring')
const multiparty = require('multiparty')
const shortid = require('shortid')
const Product = require('../models/Product')

function getProducts() {
    if(!fs.exists(dbPath)) {
        fs.writeFileSync(dbPath, '[]')
        return []
    }

    let json = fs.readFileSync(dbPath).toString() || '[]'
    let products = JSON.parse(json)
    return products
}

function saveProducts(products) {
    let json = JSON.stringify(products)
    fs.writeFileSync(dbPath, json)
}

module.exports = (req, res) => {
    req.pathname = req.pathname || url.parse(req.url).pathname
    
    if(req.pathname === '/product/add' && req.method === 'GET') {
        let filePath = path.normalize(
            path.join(__dirname, '../views/products/add.html'))
        
        fs.readFile(filePath, (err, data) => {
            if(err) {
                console.log(err)
            }

            res.writeHead(200, {
                'Content-Type': 'text/html'
            })

            res.write(data)
            res.end()
        })
    } else if (req.pathname === '/product/add' && req.method === 'POST') {
        let form = new multiparty.Form()
        let dataString = ''
        let product = {};
        
        form.on('part', (part) => {

            if (part.filename) {

                part.setEncoding('binary')

                part.on('data', (data) => {
                    dataString += data
                })

                part.on('end', () => {
                    let fileName = shortid.generate()
                    let filePath = path.normalize(`./content/images/${fileName}.png`)
                    product.image = filePath;
                    fs.writeFile(
                        filePath, dataString, {encoding: 'ascii'}, (err) => {
                            if(err) {
                                console.log(err)
                                return
                            }
                        })
                    })
                } else {
                    part.setEncoding('utf-8')
                    let field = ''
                    part.on('data', (data) => {
                        field += data
                    })

                    part.on('end', () => {
                        product[part.name] = field
                    })
                }
            })

            form.on('close', () => {
                Product.create(product).then(() => {
                    res.writeHead(302, {
                        Location: '/'
                    })

                    res.end()
                })
            })

            form.parse(req)
        }
    }
                