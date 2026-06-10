const mongoose = require('mongoose');

const EventSchema = new mongoose.Schema({
  userId: {type: mongoose.Types.ObjectId},
  action: {type: String, unique: true},
  entity: {type: Object},
}, { timestamps: true });

module.exports = mongoose.model('Event', EventSchema)