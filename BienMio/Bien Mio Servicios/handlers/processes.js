const Process = require("../models/Process")

exports.createProcess = async ({
  lawyerId,
estateId,
requestDate,
assignedDate,
status,
visits,
}) => {
  return await Process.create({
    lawyerId,
estateId,
requestDate,
assignedDate,
status,
visits,
  })
}

exports.updateProcess = async ({
  id,
  lawyerId,
estateId,
requestDate,
assignedDate,
status,
visits,
}) => {
  return await Process.findByIdAndUpdate(id,{
    lawyerId,
estateId,
requestDate,
assignedDate,
status,
visits,
  })
}
