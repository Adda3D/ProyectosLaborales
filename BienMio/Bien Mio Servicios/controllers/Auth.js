require("dotenv").config();
const User = require("../models/User");
const jwt = require("jsonwebtoken");
const expressjwt = require("express-jwt");
const bcrypt = require("bcrypt");
const { HandleResponse } = require("../Utils/httpResponses");
const { USER_STATES } = require("../Utils/states");
require("cookie-parser");

exports.signup = async (req, res) => {
  try {
    const {
      email,
      password,
      firstName,
      middleName,
      surname,
      secondSurname,
      phoneNumber,
      identificationType,
      identification,
    } = req.body;
    if (!(email && password)) {
      return res.status(400).send("email and password are required");
    }
    const existingUser = await User.findOne({ email });
    if (existingUser) {
      return res.status(409).send("User already exist. Please Login");
    }
    const encryptedPassword = await bcrypt.hash(password, 10);
    const user = await User.create({
      email: email.toLowerCase() ,
      password: encryptedPassword,
      firstName,
      secondSurname,
      surname,
      identification,
      identificationType,
      phoneNumber,
      middleName,
      status: USER_STATES.active
    });

    return HandleResponse(res, 200, null, user);//res.status(200).json(user);
  } catch (error) {
    console.log(error);
    return res.status(400).json(error);
  }
};

exports.signin = async (req, res) => {
  try {
    const { email, password } = req.body;
    const user = await User.findOne({ email: email.toLowerCase() });

    if (!user) {
      return res.json({
        status: "error",
        message: "Invalid username",
      });
    }

    if (user.status === USER_STATES.inactive) {
      return  HandleResponse(res, 401, "Este usuario esta inactivo");
    }
    const passwordCompare = await bcrypt.compare(password, user.password);
    
    if (passwordCompare) {
      const token = jwt.sign(
        {
          id: user._id,
          email: user.email,
          roles: user.roles,
          status: user.status
        },
        process.env.JWT_SECRET,
        { expiresIn: 86400 }
      );

      return HandleResponse(res, 200, null, {user, token})//res.json({ user, token: token });
    } else {
      return HandleResponse(res, 400, "Contraseña Incorrecta")//res.json({ status: "error", error: "Incorrect password" });
    }
  } catch (error) {
    console.log(error);
    return res.status(400).json(error);
  }
};

exports.isSignedIn = expressjwt({ //Saber si esta autenticado
  secret: process.env.JWT_SECRET,
  userProperty: "auth",
  algorithms: ["HS256"],
  resultProperty: 'user',
  getToken: function fromHeaderOrQuerystring(req) {
    if (
      req.headers.authorization &&
      req.headers.authorization.split(" ")[0] === "Bearer"
    ) {
      return req.headers.authorization.split(" ")[1];
    } else if (req.query && req.query.token) {
      return req.query.token;
    }
    return null;
  },
});