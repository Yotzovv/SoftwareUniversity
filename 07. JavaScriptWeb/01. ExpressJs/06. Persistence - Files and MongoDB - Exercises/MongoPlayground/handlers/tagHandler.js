const util = require('util');
const formidable = require('formidable');
const Tag = require('mongoose').model('Tag');


module.exports = (req, res) => {
  if (req.pathname === '/generateTag' && req.method === 'POST') {
      const form = formidable.IncomingForm();

      form.parse(req, (err, fields, files) => {
        res.writeHead(200, {
          'content-type': 'text/plain'
        });
        const name = fields.tagName;
        Tag.create({
          name,
          images: []
        }).then(tag => {
          res.writeHead(302, {
            location: '/'
          });
          res.end()
        }).catch(err => {
          res.writeHead(500, {
            'content-type': 'text/plain'
          });
          res.write('500 Server Error')
          res.end()
        })
        
        // res.write('recieved upload:\n\n');
        // res.end(util.inspect({
        //   fields: fields,
        //   files: files
        // }));
      });
  } else {
    return true
  }
}
