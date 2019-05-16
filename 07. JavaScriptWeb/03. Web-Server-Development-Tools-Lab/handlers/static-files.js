const fs = require('fs')
const path = require('path')
const url = require('url')

function getContentType(url) {
    let contentTypes = {
        ".css": "application/x-pointplus",
        ".css": "text/css",
        ".ico": "image/x-icon",
        ".htm": "text/html",
        ".html": "text/html",
        ".htmls": "text/html",
        ".jpeg": "image/jpeg",
        ".jpeg": "image/pjpeg",
        ".jpg": "image/jpeg",
        ".jpg": "image/pjpeg",
        ".js": "application/x-javascript",
        ".js": "application/javascript",
        ".js": "application/ecmascript",
        ".js": "text/javascript",
        ".js": "text/ecmascript",
        ".png": "image/png"
    }

    let fileExtension = "." + url.split('.').pop();
    
    return contentTypes[fileExtension];
}

module.exports = (req, res) => {
    req.pathname = req.pathname || url.parse(req.url).pathname

    if(req.pathname.startsWith('/content/') && req.method === 'GET') {
        let filePath = path.normalize(
            path.join(__dirname, `..${req.pathname}`))

        fs.readFile(filePath, (err, data) => {
            if(err) {
                res.WriteHead(404, {
                    'Content-Type': 'text/plain'
                })

                res.write('Resources not found!')
                res.end()
                return
            }

            res.writeHead(200, {
                'Content-Type': getContentType(req.pathname)
            })

            res.write(data)
            res.end()
        })
    } else {
        return true
    }
}