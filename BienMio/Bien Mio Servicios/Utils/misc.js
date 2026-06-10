const Process = require("../models/Process");
const User = require("../models/User");
const { ROLES } = require("./states");



exports.getTheLeastBusyLawyer= async () => {
  const lawyers = await User.find({roles:[ROLES.LEGAL.title]})
  const lawyerWithProcesNumber = [];
  await Promise.all(lawyers.map(async(lawyer) => {
    const processes = await Process.countDocuments({lawyerId: lawyer._id})
    lawyerWithProcesNumber.push({id: lawyer._id, processes})
  }))
  lawyerWithProcesNumber.sort((a, b) => a.processes - b.processes);
  return lawyerWithProcesNumber[0].id
}