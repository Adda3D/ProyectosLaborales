const Process = require("../models/Process");
const User = require("../models/User");
const Visit = require("../models/Visit");
const { HandleResponse } = require("../Utils/httpResponses");
const { isAdmin, isTechnical, canStayHere, canDoThis } = require("../Utils/roleAuth");
const { PROCESS_STATES, ACTIONS } = require("../Utils/states");
const { upload } = require("./Files");
const _ = require('lodash');
const Document = require("../models/Document");
const { createEvent } = require("../handlers/events");

exports.updateProcess = async (req, res) => {
  try {
    if (!req.params.id)
      return HandleResponse(res, 400, "Se requiere el Parametro 'id'"); //res.status(400).json({ error: "No id provided" });
    if (!canStayHere(req.res.user.id))
      return HandleResponse(res, 401, ACTIONS.modifyProcess);
    if (!canDoThis(req.res.user, ACTIONS.modifyProcess))
      return HandleResponse(res, 403, ACTIONS.modifyProcess);
    const {
      lawyerId,
      requestDate,
      assignedDate,
      status,
      documents,
      notificationSupport,
      notificationDate,
      evidence,
      pleadingsDocs,
      pleadings,
      penaltyResolution,
      nextState,
      requireFinish,
    } = req.body;
    
    const userToken = req.res.user;
    const id = req.params.id;
    const user = await User.findById(lawyerId);

    if (!user) return HandleResponse(res, 404, "Lawyer"); //res.status(400).json({ error: "Technical don't exist" });

    const process = await Process.findById(id);

    if (requireFinish === "true"){
      process.status = PROCESS_STATES.TO_ARCHIVE;
      await process.save();
      createEvent(userToken.id, ACTIONS.modifyProcess, process);
      return HandleResponse(res, 200, null, process);
    }

    switch (process.status) {
      case PROCESS_STATES.VISIT_VALIDATION:
        if (nextState!==""){
          process.status = nextState//PROCESS_STATES.ARCHIVED;
          await process.save();
          createEvent(userToken.id, ACTIONS.modifyProcess, process);
          return HandleResponse(res, 200, null, process);
        }
        break;
      case PROCESS_STATES.PREVENTIVE_SUSPENSION:
        if (nextState!==""){
          process.status = nextState//PROCESS_STATES.ARCHIVED;
          await process.save();
          createEvent(userToken.id, ACTIONS.modifyProcess, process);
          return HandleResponse(res, 200, null, process);
        }
        break;
      case PROCESS_STATES.PRELIMINARY_INVESTIGATION:
        if (nextState!==""){
          process.status = nextState//PROCESS_STATES.ARCHIVED;
          await process.save();
          createEvent(userToken.id, ACTIONS.modifyProcess, process);
          return HandleResponse(res, 200, null, process);
        }
        break;
      // case PROCESS_STATES.SANCTION_PROCESS:
      //   break;
      case PROCESS_STATES.INDICTMENT:
        if (!notificationDate) {
          return HandleResponse(res, 400, "Se requiere fecha de notificacion");
        }
        console.log(req.files.documents[0].path);
        if ( req.files.documents.length <1) {
          return HandleResponse(res, 400, "Se requiere Auto de pliego de Cargos");
        }
        if (!req.files.notificationSupport) {
          return HandleResponse(
            res,
            400,
            "Se requieren soportes de notificacion"
          );
        }
        process.notificationDate = notificationDate;
      
            const document = await Document.create({
              file_url: req.files.documents[0].path,
              title: "Auto Pliego de cargos",
            });
            if (document.code && document.code === 11000)
              return HandleResponse(
                res,
                400,
                "Can't upload file, this file already exist"
              );
            process.documents.push(document._id);
            createEvent(userToken.id, ACTIONS.uploadFile, document);
          await process.save();
     
          await Promise.all(
            req.files.notificationSupport.map(async (file, index) => {
              if (file) {
                const document = await Document.create({
                  file_url: file.path,
                  title: `Soporte de notificacion #${index}`,
                });
                if (document.code && document.code === 11000)
                  return HandleResponse(
                    res,
                    400,
                    "Can't upload file, this file already exist"
                  );
                process.notificationSupport.push(document._id);
                createEvent(userToken.id, ACTIONS.uploadFile, document);
              }
            })
           );
          process.status = PROCESS_STATES.EVIDENTIARY_STAGE;
          await process.save();
          createEvent(userToken.id, ACTIONS.modifyProcess, process);
          return HandleResponse(res, 200, null, process);
        
        break;

      case PROCESS_STATES.EVIDENTIARY_STAGE:
        if (!req.files.evidence){
          return HandleResponse(res, 400, "Se requieren Evidencias");
        }
       
          await Promise.all(
            req.files.evidence.map(async (file, index) => {
              if (file) {
                const document = await Document.create({
                  file_url: file.path,
                  title: `Evidencia #${index}`,
                });
                if (document.code && document.code === 11000)
                  return HandleResponse(
                    res,
                    400,
                    "Can't upload file, this file already exist"
                  );
                process.evidence.push(document._id);
                createEvent(userToken.id, ACTIONS.uploadFile, document);
              }
            })
          );
          process.status = PROCESS_STATES.PLEADINGS_STAGE;
          await process.save();
          createEvent(userToken.id, ACTIONS.modifyProcess, process);
          return HandleResponse(res, 200, null, process);
       
        break;
      case PROCESS_STATES.PLEADINGS_STAGE:
        if (!req.files.pleadingsDocs && !pleadings){
          return HandleResponse(res, 400, "Es necesario añadir las conclusiones");
        }
        if(pleadings){
          process.status = PROCESS_STATES.PENALTY_RESOLUTION;
          await process.save();
        }
        if(req.files.pleadingsDocs){
          
          await Promise.all(
            req.files.pleadingsDocs.map(async (file, index) => {
              if (file) {
                const document = await Document.create({
                  file_url: file.path,
                  title: `Evidencia #${index}`,
                });
                if (document.code && document.code === 11000)
                  return HandleResponse(
                    res,
                    400,
                    "Can't upload file, this file already exist"
                  );
                process.pleadingsDocs.push(document._id);
                createEvent(userToken.id, ACTIONS.uploadFile, document);
              }
            })
          );
          process.status = PROCESS_STATES.PENALTY_RESOLUTION;
          await process.save();
          createEvent(userToken.id, ACTIONS.modifyProcess, process);
          return HandleResponse(res, 200, null, process);
        // });
        }
        createEvent(userToken.id, ACTIONS.modifyProcess, process);
          return HandleResponse(res, 200, null, process);
        break;
      case PROCESS_STATES.PENALTY_RESOLUTION:
        
        if(!req.files.penaltyResolution){
          return HandleResponse(res, 400, "Se requiere resolucion sancionatoria");
        }
        
          if (req.files.penaltyResolution) {
            const document = await Document.create({
              file_url: req.files.penaltyResolution.path,
              title: "Resolucion Sancionatoria",
            });
            if (document.code && document.code === 11000)
              return HandleResponse(
                res,
                400,
                "Can't upload file, this file already exist"
              );
            process.penaltyResolution = document._id;
            createEvent(userToken.id, ACTIONS.uploadFile, document);
           }
          process.status = PROCESS_STATES.FOLLOW_UP;
          await process.save();
          createEvent(userToken.id, ACTIONS.modifyProcess, process);
          return HandleResponse(res, 200, null, process);
        
      break;
      case PROCESS_STATES.FOLLOW_UP:
        process.status = nextState//PROCESS_STATES.TO_ARCHIVE;
      await process.save();
      createEvent(userToken.id, ACTIONS.modifyProcess, process);
      return HandleResponse(res, 200, null, process);
      break;
      case PROCESS_STATES.TO_ARCHIVE:
        if (nextState!==""){
          process.status = nextState//PROCESS_STATES.ARCHIVED;
          await process.save();
          createEvent(userToken.id, ACTIONS.modifyProcess, process);
          return HandleResponse(res, 200, null, process);
        }
        
        break;
        default:
          process.status = process.status = nextState;
          await process.save();
          createEvent(userToken.id, ACTIONS.modifyProcess, process);
          return HandleResponse(res, 200, null, process);
    }

    await process.save();
    return HandleResponse(res, 200, null, process);
  } catch (error) {
    console.log(error);
    return res.status(400).json(error);
  }
};

exports.getProcesses = async (req, res) => {
  try {
    if (req.params.id) {
      const id = req.params.id;
      const process = await Process.findById(id);
      if (
        !process ||
        (!isAdmin(req.res.user) && process.lawyerId !== req.res.user.id)
      ) {
        return res.status(404).json({ error: "Visit not found" });
      }
      return HandleResponse(res, 200, null, process);
    }

    const processWithFullInfo=async (process)=>{
      const processesWithVisits= [];
    await Promise.all(process.map(async (proc) => {
      const visits=[];
      await Promise.all(proc.visits.map(async(visitId) => {
        const visit = await Visit.findById(visitId);
        
        visits.push(visit);
      })).then(()=>{
      processesWithVisits.push({...proc._doc, visits});
      })
    }))
    return processesWithVisits;
    }

    if (isAdmin(req.res.user)) {
      const process = await Process.find({});
      const fullProcesses= await processWithFullInfo(process);
    return HandleResponse(res, 200, null, fullProcesses);
      //return HandleResponse(res, 200, null, process);
    }

    if (isTechnical(req.res.user)) {
      const visits = await Visit.find({ technicalId: req.res.user.id });
      const process = [];
      await Promise.all(
        visits.map(async (visit) => {
          const data = await Process.findOne({ visits: [visit._id] });
          process.push(data);
        })
      );
      return HandleResponse(res, 200, null, process);
    }

    const process = await Process.find({ lawyerId: req.res.user.id,
       status: Object.values(_.pick(PROCESS_STATES, ["VISIT_VALIDATION","PREVENTIVE_SUSPENSION", "PRELIMINARY_INVESTIGATION",
    //"SANCTION_PROCESS",
    "INDICTMENT",
    "EVIDENTIARY_STAGE",
    "PLEADINGS_STAGE",
    "PENALTY_RESOLUTION",
    "FOLLOW_UP", 
    "TO_ARCHIVE",
    "ARCHIVED"])) 
  });
    

    const fullProcesses= await processWithFullInfo(process);
    return HandleResponse(res, 200, null, fullProcesses);
  } catch (error) {
    console.log(error);
    return res.status(400).json(error);
  }
};
