const mongoose = require('mongoose');

const DocumentSchema = new mongoose.Schema({
  file_url: {type: String, unique: true},
  title: {type: String},
  description: {type: String},
}, {timestamps: mongoose.timestamps})

module.exports = mongoose.model('Document', DocumentSchema)