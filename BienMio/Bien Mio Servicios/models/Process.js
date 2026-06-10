const mongoose = require('mongoose');

const ProcessSchema = new mongoose.Schema({

  lawyerId: { type: mongoose.Types.ObjectId },
  cadastralReference: { type: String },
  requestDate: { type: Date},
  assignedDate: { type: Date},
  status: { type: String},
  visits: {type: [mongoose.Types.ObjectId]},
  documents: {type: [mongoose.Types.ObjectId]},
  notificationSupport: {type: [mongoose.Types.ObjectId]},
  notificationDate: { type: Date},
  indictment_docs: {type: [mongoose.Types.ObjectId]},
  evidence: {type: [mongoose.Types.ObjectId]},
  pleadingsDocs: {type: [mongoose.Types.ObjectId]},
  pleadings: { type: String},
  penaltyResolution: {type: mongoose.Types.ObjectId},
  
})

module.exports = mongoose.model('Process', ProcessSchema)