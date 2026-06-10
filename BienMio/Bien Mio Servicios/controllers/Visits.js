const Visit = require("../models/Visit");
const User = require("../models/User");
const Document = require("../models/Document");
const { createEstate } = require("../handlers/estates");
const { createProcess } = require("../handlers/processes");
const {
  VISIT_STATES,
  PROCESS_STATES,
  VISIT_TYPES,
  ACTIONS,
  ROLES,
} = require("../Utils/states");
const { HandleResponse } = require("../Utils/httpResponses");
const { FindEstate } = require("../handlers/midas");
const Process = require("../models/Process");
const {
  isAdmin,
  isLawyer,
  canDoThis,
  canStayHere,
  isTechnical,
} = require("../Utils/roleAuth");
const { upload } = require("../app");
const { createEvent } = require("../handlers/events");
const { createDocument } = require("../handlers/documents");
const { transporter } = require("../app");
const { default: mongoose } = require("mongoose");
const multer = require("multer");
const { getTheLeastBusyLawyer } = require("../Utils/misc");

exports.createVisit = async (req, res) => {
  try {
    const {
      technicalId,
      requestDate,
      assignedDate,
      type,
      comments,
      interventionLevel,
      buildingType,
      causalType,
      numAuto,
      cadastralReference,
      request,
      processId,
      nextProcessStatus,
      estate,
      address,
    } = req.body;

    let user = undefined;

    if (request) {
      if (!canStayHere(req.res.user.id))
        return HandleResponse(res, 401, ACTIONS.requestVisit);
      if (!canDoThis(req.res.user, ACTIONS.requestVisit))
        return HandleResponse(res, 403, ACTIONS.requestVisit);
        if (!processId) {
          return HandleResponse(res, 400, "Se requiere el 'id' del Proceso");
        }
    }

    if (!request) {
      if (!canStayHere(req.res.user.id))
        return HandleResponse(res, 401, ACTIONS.createVisit);
      if (!canDoThis(req.res.user, ACTIONS.createVisit))
        return HandleResponse(res, 403, ACTIONS.createVisit);
      if (technicalId) {
        user = await User.findById(technicalId);
        if (!user) {
          return HandleResponse(res, 404, "Usuario Tecnico");
        }
      }

      if (!type) return HandleResponse(res, 400, "Se requiere el Tipo");
    }

    const formatedComments = [];
    // if (!estate) return HandleResponse(res, 404, "Predio");
    if (type === VISIT_TYPES.SUSPEN) {
      if (!numAuto) return HandleResponse(res, 400, "numAuto");
      if (!cadastralReference)
        return HandleResponse(res, 400, "Se requiere la Referencia Catastral");
      formatedComments.unshift(estate);
    }

    const visitsCount = await Visit.find({}).countDocuments();
    let visit = undefined;

    if (request) {
      visit = await Visit.create({
        status: VISIT_STATES.REQUESTED,
        requestDate,
        comments: [...formatedComments, comments],
        serial: Date.now(),
      });
    } else {
      visit = await Visit.create({
        technicalId: technicalId==="" ? req.res.user.id : technicalId,
        status: VISIT_STATES.ASSIGNED,
        requestDate,
        assignedDate,
        type,
        causalType,
        buildingType,
        interventionLevel,
        numAuto,
        address,
        comments: [...formatedComments, comments],
        serial: Date.now(),
      });
    }

    if (!visit) return res.status(400).json({ error: "Can't create visit" });

    let processData = undefined;
    if (!request) {
      processData = await Process.create({
        cadastralReference,
        status: PROCESS_STATES.REQUESTED,
        visits: [visit.id],
      });
    }

    if (request && processId) {
      processData = await Process.findById(processId);
      if (!processData) {
        return HandleResponse(res, 404, "Proceso");
      }
      processData.visits.push(visit);
      processData.status = nextProcessStatus;// ==="" ? PROCESS_STATES.REQUESTED : nextProcessStatus;
      await processData.save();
    }

    if (!processData)
      return res.status(400).json({ error: "Can't create process" });
    createEvent(req.res.user.id, ACTIONS.createVisit, visit);
    return HandleResponse(res, 200, null, processData);
  } catch (error) {
    console.log(error);
    res.status(400).json(error);
  }
};


exports.updateVisit = async (req, res) => {
  const appURL = process.env.APP_URL;

  try {
    if (!req.params.id) return HandleResponse(res, 400, "Parametro 'id'"); //res.status(400).json({ error: "No id provided" });
    if (!canStayHere(req.res.user.id))
      return HandleResponse(res, 401, ACTIONS.modifyVisit);
    if (!canDoThis(req.res.user, ACTIONS.modifyVisit))
      return HandleResponse(res, 403, ACTIONS.modifyVisit);
    const {
      technicalId,
      requestDate,
      assignedDate,
      type,
      comments,
      status,
      entryAllowed,
      causalType,
      buildingType,
      interventionLevel,
      nextState,
      generalDescription,
      considerations,
      cadastralReference,
      numAuto,
      estate,
      authDescription,
      licenseDescription
    } = req.body;
    const userToken = req.res.user;
    const { authFile, licenseFile, photos } = req.files;
    const id = req.params.id;

    const user = await User.findById(technicalId);
    if (!user) return HandleResponse(res, 404, "Tecnico");

    const visit = await Visit.findById(id);
    if (visit.status === VISIT_STATES.REQUESTED) {
      if (technicalId) {
        visit.technicalId = technicalId;
      }
      if (type) {
        visit.type = type;
      }
      if (causalType) {
        visit.causalType = causalType;
      }
      if (buildingType) {
        visit.buildingType = buildingType;
      }
      if (numAuto) {
        visit.numAuto = numAuto;
      }
      if (interventionLevel) {
        visit.interventionLevel = interventionLevel;
      }
      if (assignedDate) {
        visit.assignedDate = assignedDate;
        visit.status = VISIT_STATES.ASSIGNED;
      }
    }
    if (user.roles.includes(ROLES.TECHNIC.title)) {
      if (visit.status === VISIT_STATES.ASSIGNED) {
        if (causalType) {
          visit.causalType = causalType;
        }
        if (buildingType) {
          visit.buildingType = buildingType;
        }
        if (interventionLevel) {
          visit.interventionLevel = interventionLevel;
        }
      }
      if (
        visit.status === VISIT_STATES.VALIDATION && //.IN_PROCESS
        nextState === VISIT_STATES.REPORT //.VALIDATION
      ) {
        const files = [
          authFile ? authFile[0] : authFile,
          licenseFile ? licenseFile[0] : licenseFile,
        ];
        const descriptions = [
          authDescription,
          licenseDescription,
        ];
        const title = [
          authFile ? `Autorizacion Previa - ${cadastralReference}` : undefined,
          licenseFile
            ? `Licencia Urbanistica - ${cadastralReference}`
            : undefined,
        ];

        return await upload(req, res, async function (err) {
          if (err) {
            return res.status(400).json({ error: "Error uploading file." });
          }
          await Promise.all(
            files.map(async (file, index) => {
              if (file) {
                const document = await Document.create({
                  file_url: file.path,
                  title: title[index],
                  description: descriptions[index]
                });
                if (document.code && document.code === 11000)
                  return HandleResponse(
                    res,
                    400,
                    "Can't upload file, this file already exist"
                  );
                visit.authDocs.push(document._id);
                createEvent(userToken.id, ACTIONS.uploadFile, document);
              }
            })
          );
          visit.status = VISIT_STATES.REPORT;
          if (comments) {
            visit.comments.push(comments);
          }

          await visit.save();
          createEvent(userToken.id, ACTIONS.modifyVisit, visit);

          return HandleResponse(res, 200, null, visit);
        });
      }

      if (
        visit.status === VISIT_STATES.REPORT && //.VALIDATION
        nextState === VISIT_STATES.FINISHED //.REPORT
      ) {
        visit.report = {
          evidence: [],
          generalDescription,
          considerations,
        };

        return await upload(req, res, async function (err) {
          if (err) {
            console.log(err);
            return HandleResponse(res, 400, "Error cargando el archivo."); //res.status(400).json({ error: "Error uploading file." });
          }
          photos.map((file) => {
            if (!visit.report.evidence.includes(file.path)) {
              visit.report.evidence.push(file.path);
            }
          });
          if (comments) {
            visit.comments.push(comments);
          }
          visit.status = VISIT_STATES.FINISHED; //.REPORT;
          const process = await Process.findOne({ visits: [id] });
          if (process.status=== PROCESS_STATES.IN_VISIT){
            process.assignedDate = new Date();
            process.status =  PROCESS_STATES.VISIT_VALIDATION;
            await process.save();
          }
          await visit.save();
          createEvent(userToken.id, ACTIONS.modifyVisit, visit);
          return HandleResponse(res, 200, null, visit);
        });
      }
      if (
        visit.status === VISIT_STATES.ASSIGNED &&
        nextState === VISIT_STATES.REPORT &&
        entryAllowed !== undefined
      ) {
        visit.entryAllowed = entryAllowed;
        visit.status = VISIT_STATES.REPORT;
      }

      if (
        visit.status === VISIT_STATES.ASSIGNED &&
        nextState === VISIT_STATES.VALIDATION &&
        entryAllowed !== undefined
      ) {
        visit.entryAllowed = entryAllowed;
        visit.status = entryAllowed ? VISIT_STATES.VALIDATION : VISIT_STATES.ENTRY;
        
        const process = await Process.findOne({ visits: [id] });
        process.lawyerId = await getTheLeastBusyLawyer();
        if (!interventionLevel) {
          return HandleResponse(
            res,
            400,
            "Se requiere el nivel de intervencion"
          );
        }

        if (!buildingType) {
          return HandleResponse(res, 400, "Se requiere el tipo de obra");
        }
        if (!causalType) {
          return HandleResponse(
            res,
            400,
            "Se requiere el causal de la designacion"
          );
        }
        if (!cadastralReference) {
          return HandleResponse(
            res,
            400,
            "Se requiere la Referencia catastral"
          );
        }

        visit.causalType = causalType;
        visit.buildingType = buildingType;
        visit.interventionLevel = interventionLevel;
        process.cadastralReference = cadastralReference;
        const formatedComments = [];
        formatedComments.unshift(estate);
        visit.comments=[...formatedComments, comments]
        if (entryAllowed !== "false") {
          if (process.status=== PROCESS_STATES.REQUESTED){
            process.status = PROCESS_STATES.IN_VISIT;
          // }
          await process.save();}
          visit.entryDate = new Date().toISOString();
          await visit.save();          
          createEvent(userToken.id, ACTIONS.modifyVisit, visit);

        } else {
          if (process.status=== PROCESS_STATES.REQUESTED){
            process.requestDate = new Date();
            process.assignedDate = new Date();
            process.status = PROCESS_STATES.PREVENTIVE_SUSPENSION;
            await process.save();
          }
          
          const mailData = {
            from: process.env.SMTP_EMAIL, // sender address
            to: process.env.ADMIN_EMAIL, // list of receivers
            subject: `Suspension preventiva sobre el predio ${cadastralReference}`,
            html: `<b>Saludos! </b>
              <br> La notificacion de SUSPENSION PREVENTIVA sobre el predio ${cadastralReference} por motivo: ${"No fue permitido el ingreso al predio"} <br/>
              <a href="${appURL}/visits">CLICK AQUI PARA IR A LAS VISITAS</a>`,
          };
          transporter.sendMail(mailData, function (err, info) {
            if (err) {
              console.log(err);
              res.status(400).json(error);
            } else console.log(info);
          });
        }
      }
    }
    if (visit.status !== VISIT_STATES.FINISHED) {
      if (comments) {
        visit.comments.push(comments);
        await visit.save();
      }
    }

    // if (status) {
    //   visit.status = status;
    // }
          createEvent(userToken.id, ACTIONS.modifyVisit, visit);
    await visit.save();
    return HandleResponse(res, 200, null, visit);
  } catch (error) {
    console.log(error);
    return res.status(400).json(error);
  }
};

exports.deleteVisit = async (req, res) => {
  try {
    if (!req.params.id)
      return res.status(400).json({ error: "No id provided" });

    const id = req.params.id;
    const visit = await Visits.findById(id);
    if (!visit) {
      return res.status(404).json({ error: "Visit not found" });
    }
    return res.status(200).json(visit);
  } catch (error) {
    return res.status(400).json(error);
  }
};
exports.getVisits = async (req, res) => {
  try {
    if (req.params.id) {
      const id = req.params.id;
      const visit = await Visit.findById(id);
      if (
        !visit ||
        (!isAdmin(req.res.user) && process.lawyerId !== req.res.user.id)
      ) {
        return res.status(404).json({ error: "Visit not found" });
      }
      const data = await Process.findOne({ visits: [visit._id] });
      return HandleResponse(res, 200, null, {
        ...visit._doc,
        cadastralReference: data ? data.cadastralReference : null,
      });
    }
    let visits = [];

    if (isLawyer(req.res.user)) {
      const process = await Process.find({ lawyerId: req.res.user.id });
      let lawyerVisits = [];
      await Promise.all(
        process.map(async (process) => {
          const data = await Visit.find({ _id: process.visits });
          lawyerVisits.push(...data);
        })
      );
      visits = await Visit.find({ technicalId: req.res.user.id });
      //return HandleResponse(res, 200, null, visits);
    }

    if (isAdmin(req.res.user)) {
      visits = await Visit.find({});
    }

    if (isTechnical(req.res.user)) {
      visits = await Visit.find({ technicalId: req.res.user.id });
    }

    //const visits = await Visit.find({ technicalId: req.res.user.id });
    //const process = [];

    const visitsWithCadastralReference = [];
    await Promise.all(
      visits.map(async (visit) => {
        const data = await Process.findOne({ visits: [visit._id] });
        if (data)
          visitsWithCadastralReference.push({
            ...visit._doc,
            cadastralReference: data.cadastralReference,
          });
      })
    );

    return HandleResponse(res, 200, null, visitsWithCadastralReference);
  } catch (error) {
    console.log(error);
    return res.status(400).json(error.messaje);
  }
};
