const mongoose = require('mongoose');

const VisitSchema = new mongoose.Schema({

  technicalId: { type: String },
  requestDate: { type: Date},
  assignedDate: { type: Date},
  entryDate: { type: Date},
  comments: { type: [Object]},
  entryAllowed: { type: Boolean},
  status: { type: String},
  type:  { type: String},
  interventionLevel: { type: String},
  buildingType: {type: String},
  causalType: { type: String},
  numAuto: { type: String},
  serial: { type: Number},
  authDocs: { type: [mongoose.Types.ObjectId] },
  report: { type: Object },
  address: { type: String},
})

module.exports = mongoose.model('Visit', VisitSchema);


// Foto (descripción de fotos)
// Descripción general
// Consideraciones