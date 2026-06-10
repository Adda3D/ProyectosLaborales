import React, { useContext, useState } from "react";
import {
  Dialog,
  Button,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
  MenuItem,
  FormControlLabel,
  Switch,
} from "@mui/material";

import { useFormik } from "formik";
import * as yup from "yup";
import { errorHandle } from "../../Utils/ErrorHandle";
import {
  ROLES,
  VISIT_CAUSAL_TYPES,
  VISIT_TYPES,
  BUILDING_TYPE,
  INTERVENTION_TYPE,
  editVisitTexts,
  PROCESS_STATES,
  posibleProcessNextState,
} from "../../Utils/states";
import { format } from "date-fns";
import { AuthUserContext } from "../../context/AuthContext";
import Thumb from "../Thumb/Thumb";
import VisitRender, { CommentsAsListRender } from "../VisitRender/VisitRender";
import "react-confirm-alert/src/react-confirm-alert.css";
import { findEstate } from "../../Utils/midas";
import { VISIT_TRANSLATES } from "../../Utils/Translations";
import { editProcess } from "../../api/process";
import _ from "lodash";
import Accordion from "@mui/material/Accordion";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import Typography from "@mui/material/Typography";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import CreateVisitDialog from "../CreateVisit/CreateVisitDialog";
import { DataContext } from "../../context/DataContext";

export default function EditProcessDialog(props) {
  const { token, user } = useContext(AuthUserContext);
  const { allVisits, allUsers, fetchVisitData, allTechnicalUsers } = useContext(
    DataContext
  );
  const [openCreateDialogue, setOpenCreateDialogue] = useState(false);
  const [waitLoading, setWaitLoading] = useState(false);
  const [processId, setProcessId] = useState(null);

  const handleCloseCreateDialogue = () => {
    setOpenCreateDialogue(false);
    setProcessId(null);
  };
  // const {allVisits}= useContext()
  const validationSchema = yup.object({});
  const initialValues = {
    id: props?.process?._id,
    fileType: "processes",
    lawyerId: props?.process?.lawyerId,
    cadastralReference: props?.process?.cadastralReference,
    // requestDate: props?.process?.requestDate,
    // assignedDate: format(
    //   Date.parse(props?.process?.assignedDate) || new Date(),
    //   "yyyy-MM-dd'T'hh:mm"
    // ),
    status: props?.process?.status,
    visits: props?.process?.visits,
    documents: [],
    notificationSupport: [],
    notificationDate: format(
      Date.parse(props?.process?.assignedDate) || new Date(),
      "yyyy-MM-dd'T'hh:mm"
    ),
    evidence: [],
    pleadingsDocs: [],
    pleadings: props?.process?.pleadings || "",
    penaltyResolution: [],
    nextState: "",
    requireFinish: false,
  };
  const formik = useFormik({
    enableReinitialize: true,
    initialValues: initialValues,
    validationSchema: validationSchema,
    onSubmit: async (values) => {
      let confirmation = false;
      const fileKeys = [
        "documents",
        "notificationSupport",
        "evidence",
        "pleadingsDocs",
      ];
      if (!confirmation) {
        confirmation = window.confirm(
          "Está seguro que quiere enviar el formulario?"
        );
      }

      if (confirmation) {
        try {
          props.setWaitLoading(true);
          const data = new FormData();
          for (const [key, value] of Object.entries(values)) {
            if (fileKeys.includes(key)) {
              console.log(fileKeys.includes(key), key);
              Object.values(values[key]).map((file, index) => {
                data.append(key, file);
              });
            } else {
              data.append(key, value);
            }
          }
          await editProcess(values.id, data, props.token);
          props.fetchProcessData(props?.limit, props?.offset, props.token);
          props.handleCloseDialogue();
          props.setWaitLoading(false);
        } catch (e) {
          errorHandle(e, "Create Admin User");
          props.handleCloseDialogue();
          props.setWaitLoading(false);
        }
      } else {
        props.handleCloseDialogue();
        props.setWaitLoading(false);
      }
    },
  });

  return (
    <>
      <Dialog
        maxWidth="md"
        fullWidth={true}
        aria-labelledby="customized-dialog-title"
        open={props.open}
      >
        <DialogTitle
          id="customized-dialog-title"
          onClose={props.handleCloseDialogue}
        >
          Editar Proceso
        </DialogTitle>
        <form
          onSubmit={formik.handleSubmit}
          style={{ width: "100%" }}
          encType="multipart/form-data"
        >
          <DialogContent
            dividers
            className="form-container"
            //style={{ display: "flex", flexDirection: "row" }}users={props?.technicalUsers}
          >
            <div>
              <div className="info-section">
                {props.process?.visits.map((visit, index) => {
                  return (
                    <Accordion>
                      <AccordionSummary
                        expandIcon={<ExpandMoreIcon />}
                        aria-controls={`panel${index}a-content`}
                        id={`panel${index}a-header`}
                      >
                        <Typography>{`Visita #${index + 1}`}</Typography>
                      </AccordionSummary>
                      <AccordionDetails>
                        <Typography>
                          <VisitRender visit={visit} />
                        </Typography>
                      </AccordionDetails>
                    </Accordion>
                  );
                })}
              </div>
              {Object.values(
                _.pick(PROCESS_STATES, [
                  "PRELIMINARY_INVESTIGATION",
                  "FOLLOW_UP",
                ])
              ).includes(props.process?.status) &&
                user?.roles.includes(ROLES.LEGAL) && (
                  <div>
                    <Button
                      autoFocus
                      className="button-edit"
                      variant="contained"
                      onClick={() => {
                        setProcessId(formik.values.id);
                        console.log(processId);
                        setOpenCreateDialogue(true);
                      }}
                      style={{ background: "#F8BB18", justifySelf: "flex-end" }}
                    >
                      <div style={{ background: "#F8BB18" }}>
                        <b>Solicitar Visita</b>
                      </div>
                    </Button>
                  </div>
                )}
            </div>
            <div className="form-section">
              {console.log(props.process?.status)}
              {Object.values(
                _.pick(PROCESS_STATES, [
                  "VISIT_VALIDATION",
                  "PRELIMINARY_INVESTIGATION",
                  "PENALTY_RESOLUTION",
                ])
              ).includes(props.process?.status) &&
                user?.roles.includes(ROLES.LEGAL) && (
                  <FormControlLabel
                    label="Cerrar proceso/ Archivar "
                    labelPlacement="start"
                    control={
                      <Switch
                        margin="normal"
                        name="requireFinish"
                        label="Display Card"
                        checked={formik.values.requireFinish}
                        error={
                          formik.touched.requireFinish &&
                          formik.errors.requireFinish
                        }
                        onChange={formik.handleChange}
                      />
                    }
                  />
                )}
              {
              Object.values(
                _.pick(PROCESS_STATES, [
                  "VISIT_VALIDATION",
                  "PREVENTIVE_SUSPENSION",
                  "PRELIMINARY_INVESTIGATION",
                  "FOLLOW_UP",
                ])
              ).includes(props.process?.status) &&
                user?.roles.includes(ROLES.LEGAL) && (
                  <>
                    <TextField
                      style={{ marginTop: "20px" }}
                      fullWidth
                      label="Proximo Estado"
                      name="nextState"
                      variant="outlined"
                      onBlur={formik.handleBlur}
                      onChange={formik.handleChange}
                      error={
                        formik.touched.nextState &&
                        Boolean(formik.errors.nextState)
                      }
                      helperText={
                        formik.touched.nextState && formik.errors.nextState
                      }
                      select
                      value={formik.values.nextState}
                    >
                      {Object.entries(
                        posibleProcessNextState(props.process?.status)
                      ).map((item, index) => (
                        <MenuItem key={index} value={item[1]}>
                          {item[1]}
                        </MenuItem>
                      ))}
                    </TextField>
                  </>
                )}
              {props.process?.status === PROCESS_STATES.INDICTMENT &&
                user?.roles.includes(ROLES.LEGAL) && (
                  <>
                    <FormControlLabel
                      style={{ marginTop: "20px" }}
                      label="Auto de Pliego de Cargos"
                      labelPlacement="top"
                      control={
                        <input
                          id="documents"
                          name="documents"
                          type="file"
                          onChange={(event) => {
                            formik.setFieldValue(
                              "documents",
                              event.currentTarget.files
                            );
                          }}
                          multiple
                        />
                      }
                    />
                    {formik.values.documents &&
                      Object.values(formik.values.documents).map((file) => {
                        if (typeof file === "object") {
                          return <Thumb file={file} />;
                        }
                      })}

                    <FormControlLabel
                      style={{ marginTop: "20px" }}
                      label="Soportes de notificacion"
                      labelPlacement="top"
                      control={
                        <input
                          id="notificationSupport"
                          name="notificationSupport"
                          type="file"
                          onChange={(event) => {
                            formik.setFieldValue(
                              "notificationSupport",
                              event.currentTarget.files
                            );
                          }}
                          multiple
                        />
                      }
                    />
                    {formik.values.notificationSupport &&
                      Object.values(formik.values.notificationSupport).map(
                        (file) => {
                          if (typeof file === "object") {
                            return <Thumb file={file} />;
                          }
                        }
                      )}

                    <TextField
                      style={{ marginTop: "20px" }}
                      fullWidth
                      autoFocus
                      label="Fecha de Notificacion:"
                      name="notificationDate"
                      variant="outlined"
                      onBlur={formik.handleBlur}
                      onChange={formik.handleChange}
                      error={
                        formik.touched.notificationDate &&
                        Boolean(formik.errors.notificationDate)
                      }
                      helperText={
                        formik.touched.notificationDate &&
                        formik.errors.notificationDate
                      }
                      type="datetime-local"
                      value={formik.values.notificationDate}
                    />
                  </>
                )}

              {props.process?.status === PROCESS_STATES.EVIDENTIARY_STAGE &&
                user?.roles.includes(ROLES.LEGAL) && (
                  <>
                    <FormControlLabel
                      style={{ marginTop: "20px" }}
                      label="Evidencias"
                      labelPlacement="top"
                      control={
                        <input
                          id="evidence"
                          name="evidence"
                          type="file"
                          onChange={(event) => {
                            formik.setFieldValue(
                              "evidence",
                              event.currentTarget.files
                            );
                          }}
                          multiple
                        />
                      }
                    />
                    {formik.values.evidence &&
                      Object.values(formik.values.evidence).map((file) => {
                        if (typeof file === "object") {
                          return <Thumb file={file} />;
                        }
                      })}
                  </>
                )}

              {props.process?.status === PROCESS_STATES.PLEADINGS_STAGE &&
                user?.roles.includes(ROLES.LEGAL) && (
                  <>
                    <TextField
                      style={{ marginTop: "20px" }}
                      fullWidth
                      autoFocus
                      label="Alegatos/Conclusiones"
                      name="pleadings"
                      variant="outlined"
                      onBlur={formik.handleBlur}
                      onChange={formik.handleChange}
                      error={
                        formik.touched.pleadings &&
                        Boolean(formik.errors.pleadings)
                      }
                      helperText={
                        formik.touched.pleadings && formik.errors.pleadings
                      }
                      type="text"
                      value={formik.values.pleadings}
                    />
                    <FormControlLabel
                      style={{ marginTop: "20px" }}
                      label="Documentos de alegatos"
                      labelPlacement="top"
                      control={
                        <input
                          id="pleadingsDocs"
                          name="pleadingsDocs"
                          type="file"
                          onChange={(event) => {
                            formik.setFieldValue(
                              "pleadingsDocs",
                              event.currentTarget.files
                            );
                          }}
                          multiple
                        />
                      }
                    />
                    {formik.values.pleadingsDocs &&
                      Object.values(formik.values.pleadingsDocs).map((file) => {
                        if (typeof file === "object") {
                          return <Thumb file={file} />;
                        }
                      })}
                  </>
                )}
              {props.process?.status === PROCESS_STATES.PENALTY_RESOLUTION &&
                user?.roles.includes(ROLES.LEGAL) && (
                  <>
                    <FormControlLabel
                      style={{ marginTop: "20px" }}
                      label="Resolucion Sancionatoria"
                      labelPlacement="top"
                      control={
                        <input
                          id="penaltyResolution"
                          name="penaltyResolution"
                          type="file"
                          onChange={(event) => {
                            console.log(event.currentTarget.files);
                            formik.setFieldValue(
                              "penaltyResolution",
                              event.currentTarget.files[0]
                            );
                          }}
                          //multiple
                        />
                      }
                    />
                  </>
                )}

              {props.process?.status === PROCESS_STATES.TO_ARCHIVE &&
                user?.roles.includes(ROLES.ADMIN) && (
                  <>
                    <TextField
                      style={{ marginTop: "20px" }}
                      fullWidth
                      label="Proximo Estado"
                      name="nextState"
                      variant="outlined"
                      onBlur={formik.handleBlur}
                      onChange={formik.handleChange}
                      error={
                        formik.touched.nextState &&
                        Boolean(formik.errors.nextState)
                      }
                      helperText={
                        formik.touched.nextState && formik.errors.nextState
                      }
                      select
                      value={formik.values.nextState}
                    >
                      {Object.entries(
                        posibleProcessNextState(props.process?.status)
                      ).map((item, index) => (
                        <MenuItem key={index} value={item[1]}>
                          {item[1]}
                        </MenuItem>
                      ))}
                    </TextField>
                  </>
                )}
            </div>
          </DialogContent>
          <DialogActions>
            <Button
              autoFocus
              color="primary"
              className="cancel"
              onClick={() => {
                formik.resetForm();
                props.handleCloseDialogue();
              }}
            >
              Cancelar
            </Button>

            {((props.process?.status !== PROCESS_STATES.TO_ARCHIVE &&
              user?.roles.includes(ROLES.LEGAL)) ||
              (props.process?.status === PROCESS_STATES.TO_ARCHIVE &&
                user?.roles.includes(ROLES.ADMIN))) && (
              <Button
                autoFocus
                type="submit"
                color="primary"
                className={props.waitLoading ? "disabled" : "save"}
                disabled={props.waitLoading ? true : false}
              >
                {props.waitLoading ? "Por favor espere..." : "Guardar"}
              </Button>
            )}

            {((props.process?.status === PROCESS_STATES.TO_ARCHIVE &&
              user?.roles.includes(ROLES.LEGAL)) ||
              (props.process?.status !== PROCESS_STATES.TO_ARCHIVE &&
                user?.roles.includes(ROLES.ADMIN))) && (
              <Button
                autoFocus
                color="primary"
                className={props.waitLoading ? "disabled" : "save"}
                disabled={props.waitLoading ? true : false}
                onClick={() => {
                  props.handleCloseDialogue();
                }}
              >
                {props.waitLoading ? "Por favor espere..." : "Cerrar"}
              </Button>
            )}
          </DialogActions>
        </form>
        {console.log(processId)}
        <CreateVisitDialog
          cadastralReference={undefined}
          open={openCreateDialogue}
          setWaitLoading={setWaitLoading}
          waitLoading={waitLoading}
          handleCloseDialogue={handleCloseCreateDialogue}
          token={token}
          fetchVisitData={fetchVisitData}
          technicalUsers={allTechnicalUsers}
          request={true}
          processId={processId}
          processState={props?.process?.status}
        />
      </Dialog>
    </>
  );
}
