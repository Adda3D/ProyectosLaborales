const Estate = require("../models/Estate")


exports.createEstate = async ({address,
  block,
  estateNumber,
  latitude,
  longitude,
  currentLegislation,
  estateType,
  typology,
  ownerFirstName,
  ownerSurname,
  email,
  phoneNumber,
  estateUse,
  intervention,
  processes,
  sanctions,
}) => {
  
  return await Estate.create({
    address,
    block,
    estateNumber,
    latitude,
    longitude,
    currentLegislation,
    estateType,
    typology,
    ownerFirstName,
    ownerSurname,
    email,
    phoneNumber,
    estateUse,
    intervention,
    processes,
    sanctions,
  })

  // record.save(function (err, estate) {
  //   if (err) console.log(err);
  // })
  // console.log("record: ",record);
  // return record._id;
}

exports.updateEstate = async ({
  id,
  address,
  block,
  estateNumber,
  latitude,
  longitude,
  currentLegislation,
  estateType,
  typology,
  ownerFirstName,
  ownerSurname,
  email,
  phoneNumber,
  estateUse,
  intervention,
  processes,
  sanctions,
}) => {
  return  await Estate.findByIdAndUpdate(id,{
    address,
    block,
    estateNumber,
    latitude,
    longitude,
    currentLegislation,
    estateType,
    typology,
    ownerFirstName,
    ownerSurname,
    email,
    phoneNumber,
    estateUse,
    intervention,
    processes,
    sanctions,
  }, function (err) {
    if (err) return err;
  });
}
