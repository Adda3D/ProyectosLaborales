
const Event = require("../models/Event");
const { HandleResponse } = require("../Utils/httpResponses");
const { ACTIONS } = require("../Utils/states");
const {
  canDoThis,
  canStayHere,
} = require("../Utils/roleAuth");

exports.getEvents = async (req, res) => {
  try {
    const { userId, entityId } = req.body;
    if (!canStayHere(req.res.user.id)) return HandleResponse(res, 401);
    if (!canDoThis(req.res.user, ACTIONS.readEvents))
    if (req.params.id) {
      const id = req.params.id;
      const event = await Event.findById(id);
      if (!event) {
        return res.status(404).send("Event not found");
      }
      return res.status(200).json(event);
    }
    if (!userId && !entityId) {
        const events = await Event.find({});
        return HandleResponse(res,200,null,events); //.status(200).json(events);
    } 
  } catch (error) {
    res.status(400).json(error);
  }
}

exports.updateEvent = async (req, res) => {
  try {
    const { id, name } = req.body;
    if (!id) {
        const event = await Event.findByIdAndUpdate(id, { name });
      if (!event) {
        return res.status(404).send("Event not found");
      }
      return res.status(200).json(role);
    }

    return res.status(400).send("Event id is required");

  } catch (error) {
    res.status(400).json(error);
  }
}