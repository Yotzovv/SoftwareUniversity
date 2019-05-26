const fs = require('fs')
const path = require('path')

const Product = require('../models/Product')
const Category = require('../models/Category')

module.exports.addGet = (req, res) => {
    let category = req.body
    Category.create(category).then(() => {
        res.redirect('/')
    })
}

module.exports.editGet = (req, res) => {
    let id = req.params.id
    Product.findById(id).then(product => {
        if(!product) {
            res.sendStatus(404)
            return
        }

        Category.find().then((categories) => {
            res.render('product/edit', {
                product: product,
                categories: categories
            })
        })
    })
}

module.exports.addPost = async (req, res) => {
    let productObj = req.body
    productObj.image = req.file.destination + '\\' + req.file.originalname

    let product = await Product.create(productObj)
    let category = await Category.findById(product.category)


    category.products.push(product._id)
    category.save()
    res.redirect('/')
}

module.exports.editPost = async (req, res) => {
    let id = req.params.id
    let editedProduct = req.body

    let product = await Product.findById(id)
    if(!product) {
        res.redirect(`/?error=${encodeURIComponent('Product was not found!')}`)
        return
    }
    product.name = editedProduct.name
    product.description = editedProduct.description
    product.price = editedProduct.price

    if(req.file) {
        product.image = req.file.destination + '\\' + req.file.originalname
    }

    product.save().then(() => {
        res.redirect(`/?success=${encodeURIComponent('Product was edited successfully!')}`)
    })

    if(product.category.toString() !== editedProduct.category) {
        Category.findById(product.category).then((currentCategory) => {
            Category.findById(editedProduct.category).then((nextCategory) => {
                let index = currentCategory.products.indexOf(product._id)
                if(index >= 0) {
                    currentCategory.products.splice(index,1)
                }
                currentCategory.save()

                nextCategory.products.push(product._id)
                nextCategory.save()

                product.category = editedProduct.category

                product.save().then(() => {
                    res.redirect(
                        '/?success=' + 
                        encodeURIComponent('Product was edited successfully!'))
                })
            })
        })
    } else {
        product.save().then(() => {
            res.redirect(
                '/?success=' +
                encodeURIComponent('Product was edited successfuly!'))
        })
    }
}