const Event = require("../models/Event");

exports.createEvent = async (userId, action, entity) => {
  try {
    return await Event.create({ action, userId, entity});
  } catch (error) {
    return error;
  }
};

exports.getUserEvents = async (userId) => {
  try {
    return await Event.find({ userId });
  } catch (error) {
    return error;
  }
};

exports.getEntityEvents = async (entityId) => {
  try {
    return await Event.find({ entity: {_id: entityId} });
  } catch (error) {
    return error;
  }
};

exports.getEvents = async () => {
  try {
    return await Event.find({});
  } catch (error) {
    return error;
  }
};
