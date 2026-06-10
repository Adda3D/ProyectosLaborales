const multer = require('multer');
const { createDocument } = require('../handlers/documents');
const Visit = require('../models/Visit');
const fs = require('fs-extra');
const { canDoThis } = require('../Utils/roleAuth');
const { ACTIONS, VISIT_STATES } = require('../Utils/states');
const { HandleResponse } = require('../Utils/httpResponses');
const { createEvent } = require('../handlers/events');

exports.isReport = (type) => {return type==="report"};
exports.isLicenses = (type) => {return type==="licenses"};
exports.isArchive = (type) => {return type==="archive";}
exports.isProcessFile = (type) => {return type==="processes";}

const storage = multer.diskStorage({
  destination: function (req, file, callback) {
    let type = req.params.type;
    let cadastralReference = req.body.cadastralReference;
    let path = process.env.FILES_BASE_PATH; 
    if (isReport(type) || isLicenses(type)) {
      path += (cadastralReference ? `/${cadastralReference}` : "") + `/${type}` ;
    }
    if(isArchive(type)){
      path += `/${type}` + (cadastralReference ? `/${cadastralReference}` : "") ;
    }

    fs.mkdirsSync(path);
    callback(null, path);
    callback(null, path);
  },
  filename: function (req, file, callback) {
    callback(null, file.originalname);
  }
});

exports.upload = multer({ storage: storage }).fields([
  {name: 'authFile', maxcount: 1, limits: {
  fieldSize: 104857600,
  fieldNameSize: 52428800,
  fileSize: 52428800
}}, 
{name: 'licenseFile', maxcount: 1, limits: {
  fieldSize: 104857600,
  fieldNameSize: 52428800,
  fileSize: 52428800
}},
{name: 'photos', maxcount: 15, limits: {
  fieldSize: 104857600,
  fieldNameSize: 52428800,
  fileSize: 52428800
}},
{name: 'evidence', maxcount: 15, limits: {
  fieldSize: 104857600,
  fieldNameSize: 52428800,
  fileSize: 52428800
}},
{name: 'notificationSupportFiles', maxcount: 15, limits: {
  fieldSize: 104857600,
  fieldNameSize: 52428800,
  fileSize: 52428800
}},
{name: 'documentsFiles', maxcount: 15, limits: {
  fieldSize: 104857600,
  fieldNameSize: 52428800,
  fileSize: 52428800
}},
{name: 'pleadingsDocsFiles', maxcount: 15, limits: {
  fieldSize: 104857600,
  fieldNameSize: 52428800,
  fileSize: 52428800
}},
{name: 'penaltyResolutionFile', maxcount: 1, limits: {
  fieldSize: 104857600,
  fieldNameSize: 52428800,
  fileSize: 52428800
}},
])//.single('file');//

exports.uploadFile = async (req, res) => {
  try {
    const { title, visitId, cadastralReference } = req.body;
    const { type } = req.params;
    const user = req.res.user;
    if (!canStayHere(user.id)) return HandleResponse(res, 401);
    if (!canDoThis(user, ACTIONS.uploadFile)) return HandleResponse(res, 403, ACTIONS.uploadFile);

    if (isReport(type) && !visitId) return HandleResponse(res, 400, "Se requiere visitId");
    if (isReport(type) && !cadastralReference) return HandleResponse(res, 400, "Se requiere referencia catastral");

    await upload(req, res, async function (err) {
      if (err) {
        return res.status(400).json({ error: "Error uploading file." });
      }

      const document = await createDocument(res.req.file.path.toString(), title);
      if (document.code && document.code === 11000) return res.status(400).json({ error: "Can't upload file, this file already exist" });

      if (isReport(type)) {
        const visit = await Visit.findByIdAndUpdate(visitId, { reportId: document.id, status: VISIT_STATES.FINISHED });
        createEvent(user.id, ACTIONS.uploadFile, {document, visit} );
        return HandleResponse(res, 200, null, { ...document, visit });
      }

      createEvent(user.id, ACTIONS.uploadFileToArchive, document )
      return HandleResponse(res, 200, null, document);
    });

  } catch (error) {
    console.log(error);
    return res.status(400).json({ error });
  }
}
