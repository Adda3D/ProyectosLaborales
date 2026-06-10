const mongoose = require('mongoose');

const EstateSchema = new mongoose.Schema({

  address:{type: String},//
  block: { type: String},
  cadastralReference: {type: String, unique: true},
  latitude: { type: String},
  longitude: { type: String},
  currentLegislation: { type: String},
  estateType: { type: String},
  typology: { type: String},
  ownerFirstName: { type: String},
  ownerSurname: { type: String},
  email:{type: String},
  phoneNumber: { type: String, minlength: 10},
  estateUse: { type: String},
  intervention: { type: [Date]},
  processes: { type: [String]},
  sanctions: { type: [String]},

})

module.exports = mongoose.model('Estate', EstateSchema)