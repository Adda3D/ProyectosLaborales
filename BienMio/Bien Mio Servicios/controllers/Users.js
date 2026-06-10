const User = require("../models/User");
const { HandleResponse } = require("../Utils/httpResponses");


exports.getUsers = async (req, res) => {
  try {
    if (req.params.id) {
      console.log(req.params.id);
      const id = req.params.id;
      const user = await User.findById(id);
      if (!user) {
        return HandleResponse(res, 404, "Usuario");
      }
      return HandleResponse(res, 200, null, user);//res.status(200).json(user);
    }
    const users = await User.find({}, 'roles email firstName surname');
    return HandleResponse(res, 200, null, users);//res.status(200).json(users);

  } catch (error) {
    console.log(error);
    return res.status(400).json(error);
  }
}

exports.updateUser = async (req, res) => {
  try {
    if (!req.params.id) {
      return HandleResponse(res, 400, "Se requiere el Parametro 'id'");
    }
    const {
      email,
      firstName,
      middleName,
      surname,
      secondSurname,
      phoneNumber,
      identification,
      roles,
      dependencyId,
      contractType,
      contractStatus,
      contractStartDate,
      contractEndDate,
      identificationType,
      status
    } = req.body;
    
    const id = req.params.id;
    const user = await User.findById(id);
    if (!user) {
      return HandleResponse(res, 404, "Usuario");//res.status(404).send("User not found");
    }

    if (email) {
      user.email = email;
    }
    if (firstName) {
      user.firstName = firstName;
    }
    if (middleName) {
      user.middleName = middleName;
    }
    if (surname) {
      user.surname = surname;
    }
    if (secondSurname) {
      user.secondSurname = secondSurname;
    }
    if (phoneNumber) {
      user.phoneNumber = phoneNumber;
    }
    if (identification) {
      user.identification = identification;
    }
    if (identificationType) {
      user.identificationType = identificationType;
    }
    if (roles) {
      user.roles = roles;
    }
    if (contractEndDate) {
      user.contractEndDate = contractEndDate;
    }
    if (contractType) {
      user.contractType = contractType;
    }
    if (contractStatus) {
      user.contractStatus = contractStatus;
    }
    if (contractStartDate) {
      user.contractStartDate = contractStartDate;
    }
    if (dependencyId) {
      user.dependencyId = dependencyId;
    }
    if (status){
      user.status = status;
    }

    await user.save();

    res.status(200).json(user);
  } catch (error) {
    console.log(error);
    return res.status(400).json(error);
  }
}

exports.deleteUser = async (req, res) => {
  try {
    res.status(200).json(user)
  } catch (error) {
    console.log(error);
    return res.status(400).json(error);
  }
}