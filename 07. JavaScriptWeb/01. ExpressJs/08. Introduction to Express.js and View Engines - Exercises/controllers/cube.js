const Cube = require('../models/Cube')

function handleErrors(err, res, cubeBody) {
    let errors = [];

    for (const prop in err.errors) {
        errors.push(err.errors[prop].message)
    }

    res.locals.globalErrors = errors;
    res.render('create', cubeBody);
}

module.exports = {
    createGet: (req, res) => {
        res.render('create');
    },
    createPost: (req, res) => {
        const cubeBody = req.body;
        console.log(cubeBody);
        cubeBody.difficulty = Number(cubeBody.difficulty);
        
        Cube.create(cubeBody)
            .then((c) => {
                res.redirect('/')
            })
            .catch((e) => handleErrors(e, res, cubeBody));

    },
    details: (req, res) => {
        const cubeId = req.params.cubeId;

        Cube.findById(cubeId)
            .then((cube) => {
                res.render('cube/details', cube);
            })
            .catch((e) => handleErrors(e, res, cubeBody))
    }
}