const mongoose = require('mongoose');

const UserSchema = new mongoose.Schema({

  email:{type: String, unique: true},
  password: {type: String},
  token: { type: String },
  firstName: { type: String},
  middleName: { type: String},
  surname: { type: String},
  secondSurname: { type: String},
  phoneNumber: { type: String, minlength: 10},
  identification:  { type: Number, unique: true},
  roles: { type: [String] },
  dependencyId: { type: mongoose.Types.ObjectId },
  contractType: { type: String},
  contractStatus: { type: String},
  contractStartDate: { type: Date},
  contractEndDate: { type: Date},
  identificationType: { type: String},
  status: { type: String }
})

module.exports = mongoose.model('User', UserSchema)