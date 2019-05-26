const fs = require('fs')
const Category = require('../models/Category')

module.exports.addGet = (req, res) => {
    fs.readFile('./views/category/add.html', (err, data) => {
        if(err) {
            console.log(err)
            return
        }
        res.writeHead(200, {
            'Content-Type': 'text/html'
        })
        res.write(data)
        res.end()
    })
}

module.exports.addPost = async (req, res) => {
    let category = req.body
    await Category.create(category).then(() => {
    res.redirect('/')
    })
}

module.exports.productByCategory = (req, res) => {
    let categoryName = req.params.category

    Category.findOne({ name: categoryName })
        .populate('products')
        .then((category) => {
            if (!category) {
                res.sendStatus(404)
                return
            }

            res.render('category/products', { category: category })
        })
}