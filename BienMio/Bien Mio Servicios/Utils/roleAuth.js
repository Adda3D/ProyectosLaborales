const { ROLES, ACTIONS, USER_STATES } = require("./states");
const _ = require('lodash');
const User = require("../models/User");

exports.canDoThis= (user, action) => {
  const allowedActions = [];
  if (user.roles.length > 0){
    user.roles.map((role) => {
      const actions = Object.entries(ROLES).find(([key, values])=> values.title===role)[1].actions;
      allowedActions.push(...actions);
    })
    return allowedActions.includes(action) ? true : false;
  }
  return false;
}

exports.canStayHere= async (id ) => { 
    const userInfo = await User.findById(id);
  if (userInfo.status !== USER_STATES.active){
    return false;
  }
  return true;
}




exports.isAdmin = (user) => user.roles.includes(ROLES.ASSIST.title) || user.roles.includes(ROLES.ADMIN.title);
exports.isTechnical = (user) => user.roles.includes(ROLES.TECHNIC.title);
exports.isLawyer = (user) => user.roles.includes(ROLES.LEGAL.title);

