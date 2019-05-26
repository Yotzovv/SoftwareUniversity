const mongoose = require('mongoose')

const cubeSchema = new mongoose.Schema({
    name: { type: mongoose.Schema.Types.String, required: true },
    description: { type: mongoose.Schema.Types.String, required: true },
    imageUrl: { type: mongoose.Schema.Types.String, required: true },
    difficulty: { type: mongoose.Schema.Types.Number, required: true }
});

cubeSchema.path('name')
          .validate(function () {
              return this.name.length >= 3 && this.name.length <= 15
          }, 'Name must be between 3 and 15 symbols!');

cubeSchema.path('description')
          .validate(function () {
              return this.description.length >= 20 && this.description.length <= 300
          }, 'Description must be between 20 and 300 symbols');

cubeSchema.path('imageUrl')
          .validate(function () {
              return this.imageUrl.startsWith('http') || (this.imageUrl.endsWith('.jpg') || this.imageUrl.endsWith('.png'))
          }, 'Image URL must should start with http and end with .jpg or .png!');

cubeSchema.path('difficulty')
          .validate(function() {
              return this.difficulty >= 1 && this.difficulty <= 6
          }, 'Number must be between 1 and 6');

module.exports = mongoose.model('cube', cubeSchema);