import React, { useContext } from "react";
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
  VISIT_STATES,
  VISIT_TYPES,
  BUILDING_TYPE,
  INTERVENTION_TYPE,
  visitNextState,
  editVisitTexts,
} from "../../Utils/states";
// import { editUser } from "../../api/users";
import { editVisit } from "../../api/visits";
import { format } from "date-fns";
import { Map } from "google-maps-react";
import MapsContainer from "../Maps/MapsContainer";
import { AuthUserContext } from "../../context/AuthContext";
import Thumb from "../Thumb/Thumb";
import VisitRender, { CommentsAsListRender } from "../VisitRender/VisitRender";
// import { NotificationManager } from "react-notifications";
import { confirmAlert } from "react-confirm-alert"; // Import
import "react-confirm-alert/src/react-confirm-alert.css"; // Import css
import { findEstate } from "../../Utils/midas";
import { VISIT_TRANSLATES } from "../../Utils/Translations";

export default function EditVisitDialog(props) {
  const { user } = useContext(AuthUserContext);
  const validationSchema = yup.object({});
  const initialValues = {
    technicalId: props?.visit?.technicalId || "",
    fileType: "",
    requestDate: format(
      Date.parse(props?.visit?.requestDate) || new Date(),
      "yyyy-MM-dd'T'hh:mm"
    ),
    assignedDate: format(
      Date.parse(props?.visit?.assignedDate) || new Date(),
      "yyyy-MM-dd'T'hh:mm"
    ),
    entryDate: props?.visit?.entryDate || "",
    cadastralReference: props?.visit?.cadastralReference || "",
    comments: "",
    entryAllowed: props?.visit?.entryAllowed || false,
    status: props?.visit?.status || "",
    type: props?.visit?.type || "",
    interventionLevel: props?.visit?.interventionLevel || "",
    buildingType: props?.visit?.buildingType || "",
    causalType: props?.visit?.causalType || "",
    numAuto: props?.visit?.numAuto || "",
    serial: props?.visit?.serial || "",
    reportId: props?.visit?.reportId || "",
    id: props?.visit?._id || "",
    nextState: visitNextState(props?.visit),
    report: null,
    generalDescription: props?.visit?.report?.generalDescription || "",
    considerations: props?.visit?.report?.considerations || "",
    photos: [],
    authFile: null,
    licenseFile: null,
    address: props?.visit?.address || "",
      estate: undefined
  };
  const formik = useFormik({
    enableReinitialize: true,
    initialValues: initialValues,
    validationSchema: validationSchema,
    onSubmit: async (values) => {
      let confirmation = false;
      if (props.visit.status === VISIT_STATES.REPORT) {
        if (values.photos.length < 1) {
          confirmation = false;
        } else {
          confirmation = window.confirm(
            "Esta seguro que quiere enviar el formulario con los archivos adjuntos y finalizar el informe?"
          );
        }
      }
      if (props.visit.status === VISIT_STATES.VALIDATION) {
        if (!values.authFile || !values.licenseFile) {
          confirmation = window.confirm(
            "Esta seguro que quiere enviar el formulario con los archivos adjuntos?"
          );
        }
        confirmation = true;
      }
      if ((props.visit.status !== VISIT_STATES.VALIDATION) && (props.visit.status !== VISIT_STATES.REPORT)){
        confirmation=true;
      }

      if (confirmation) {
        try {
          props.setWaitLoading(true);
          const data = new FormData();
          for (const [key, value] of Object.entries(values)) {
            if (key !== "photos") {
              data.append(key, value);
            } else {
              Object.values(values.photos).map((file, index) => {
                // if (typeof file === "object") {
                  data.append("photos", file);
                // }
              });
            }
          }
          await editVisit(values.id, data, props.token);
          props.fetchVisitData(props?.limit, props?.offset, props.token);
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
          {editVisitTexts(props.visit?.status, "dialog-title", user?.roles[0])}
        </DialogTitle>
        <form onSubmit={formik.handleSubmit} style={{ width: "100%" }}>
          <DialogContent
            dividers
            className="form-container"
            //style={{ display: "flex", flexDirection: "row" }}
          >
            <div classname="info-section">
              <VisitRender visit={props?.visit} users={props?.technicalUsers} />
            </div>
            <div classname="form-section">
            {props.visit?.status === VISIT_STATES.REQUESTED && props.user?.roles.includes(ROLES.ASSIST) && (
              <TextField
                    style={{ marginTop: "20px" }}
                    fullWidth
                    label="Arquitecto/Tecnico"
                    name="technicalId"
                    variant="outlined"
                    onBlur={formik.handleBlur}
                    onChange={formik.handleChange}
                    error={
                      formik.touched.technicalId &&
                      Boolean(formik.errors.technicalId)
                    }
                    helperText={
                      formik.touched.technicalId && formik.errors.technicalId
                    }
                    select
                    value={formik.values.technicalId}
                  >
                    {props?.technicalUsers?.map((item, index) => (
                      <MenuItem key={index} value={item._id}>
                        {`${item.firstName} ${item.surname}`}
                      </MenuItem>
                    ))}
                  </TextField>
            )}
              {(props.visit?.status === VISIT_STATES.REQUESTED || props.visit?.status === VISIT_STATES.ASSIGNED) && (
                <>
                  { user?.roles.includes(ROLES.TECHNIC) &&(
                  <>
                  <TextField
              style={{ marginTop: "20px" }}
              fullWidth
              autoFocus
              label="Referencia Catastral"
              name="cadastralReference"
              variant="outlined"
              onBlur={formik.handleBlur}
              onChange={async(e)=>{
                formik.handleChange(e);
                if(formik.values.cadastralReference.length >= 10){
                  const data = await findEstate(formik.values.cadastralReference)
                  if (data){
                    formik.values.estate = data
                    formik.setFieldValue("estate", data);
                  }
                }
              }}
              error={
                formik.touched.cadastralReference &&
                Boolean(formik.errors.cadastralReference)
              }
              helperText={
                formik.touched.cadastralReference &&
                formik.errors.cadastralReference
              }
              type="text"
              value={formik.values.cadastralReference}
            />
            
            {formik.values.estate &&(
              <div>
                {CommentsAsListRender({0: formik.values.estate}, VISIT_TRANSLATES, [])}
              </div>
            )}
              </>)}
                  <TextField
                    style={{ marginTop: "20px" }}
                    fullWidth
                    label="Causal de la designación"
                    name="causalType"
                    variant="outlined"
                    onBlur={formik.handleBlur}
                    onChange={formik.handleChange}
                    error={
                      formik.touched.causalType &&
                      Boolean(formik.errors.causalType)
                    }
                    helperText={
                      formik.touched.causalType && formik.errors.causalType
                    }
                    select
                    value={formik.values.causalType}
                  >
                    {Object.entries(VISIT_CAUSAL_TYPES).map((item, index) => (
                      <MenuItem key={index} value={item[1]}>
                        {item[1]}
                      </MenuItem>
                    ))}
                  </TextField>
                  <TextField
                    style={{ marginTop: "20px" }}
                    fullWidth
                    label="Tipo de Obra"
                    name="buildingType"
                    variant="outlined"
                    onBlur={formik.handleBlur}
                    onChange={formik.handleChange}
                    error={
                      formik.touched.buildingType &&
                      Boolean(formik.errors.buildingType)
                    }
                    helperText={
                      formik.touched.buildingType && formik.errors.buildingType
                    }
                    select
                    value={formik.values.buildingType}
                  >
                    {Object.entries(BUILDING_TYPE).map((item, index) => (
                      <MenuItem key={index} value={item[1]}>
                        {item[1]}
                      </MenuItem>
                    ))}
                  </TextField>
                  <TextField
                    style={{ marginTop: "20px" }}
                    fullWidth
                    label="Categorias de Intervención"
                    name="interventionLevel"
                    variant="outlined"
                    onBlur={formik.handleBlur}
                    onChange={formik.handleChange}
                    error={
                      formik.touched.interventionLevel &&
                      Boolean(formik.errors.interventionLevel)
                    }
                    helperText={
                      formik.touched.interventionLevel &&
                      formik.errors.interventionLevel
                    }
                    select
                    value={formik.values.interventionLevel}
                  >
                    {Object.entries(INTERVENTION_TYPE).map((item, index) => (
                      <MenuItem key={index} value={item[1]}>
                        {item[1]}
                      </MenuItem>
                    ))}
                  </TextField>
                  <TextField
                    style={{ marginTop: "20px" }}
                    fullWidth
                    label="Tipo de la designación"
                    name="type"
                    variant="outlined"
                    onBlur={formik.handleBlur}
                    onChange={formik.handleChange}
                    error={formik.touched.type && Boolean(formik.errors.type)}
                    helperText={formik.touched.type && formik.errors.type}
                    select
                    value={formik.values.type}
                  >
                    {Object.entries(VISIT_TYPES).map((item, index) => (
                      <MenuItem key={index} value={item[1]}>
                        {item[1]}
                      </MenuItem>
                    ))}
                  </TextField>
                  {formik.values.type === VISIT_TYPES.SUSPEN && (
                    <TextField
                      style={{ marginTop: "20px" }}
                      fullWidth
                      autoFocus
                      label="Numero Auto"
                      name="numAuto"
                      variant="outlined"
                      onBlur={formik.handleBlur}
                      onChange={formik.handleChange}
                      error={
                        formik.touched.numAuto && Boolean(formik.errors.numAuto)
                      }
                      helperText={
                        formik.touched.numAuto && formik.errors.numAuto
                      }
                      type="text"
                      value={formik.values.numAuto}
                    />
                  )}
                  <TextField
                    style={{ marginTop: "20px" }}
                    fullWidth
                    autoFocus
                    label="Fecha asignada para la visita:"
                    name="assignedDate"
                    variant="outlined"
                    onBlur={formik.handleBlur}
                    onChange={formik.handleChange}
                    error={
                      formik.touched.assignedDate &&
                      Boolean(formik.errors.assignedDate)
                    }
                    helperText={
                      formik.touched.assignedDate && formik.errors.assignedDate
                    }
                    type="datetime-local"
                    value={formik.values.assignedDate}
                  />
                  <TextField
                    style={{ marginTop: "20px" }}
                    fullWidth
                    autoFocus
                    label="Visita requerida en la fecha:"
                    name="requestDate"
                    variant="outlined"
                    onBlur={formik.handleBlur}
                    onChange={formik.handleChange}
                    error={
                      formik.touched.requestDate &&
                      Boolean(formik.errors.requestDate)
                    }
                    helperText={
                      formik.touched.requestDate && formik.errors.requestDate
                    }
                    type="datetime-local"
                    value={formik.values.requestDate}
                    disabled
                  />
                </>
              )}
              {props.visit?.status === VISIT_STATES.ASSIGNED &&
                user?.roles.includes(ROLES.TECHNIC) && (
                  <FormControlLabel
                    label="Entrada permitida?"
                    labelPlacement="start"
                    control={
                      <Switch
                        margin="normal"
                        name="entryAllowed"
                        label="Display Card"
                        checked={formik.values.entryAllowed}
                        error={
                          formik.touched.entryAllowed &&
                          formik.errors.entryAllowed
                        }
                        onChange={formik.handleChange}
                      />
                    }
                  />
                )}

              {props.visit?.status === VISIT_STATES.VALIDATION &&
                user?.roles.includes(ROLES.TECHNIC) && (
                  <>
                    <FormControlLabel
                      style={{ marginTop: "20px" }}
                      label="Licencia Urbanistica"
                      labelPlacement="top"
                      control={
                        <input
                          id="licenseFile"
                          name="licenseFile"
                          type="file"
                          onChange={(event) => {
                            formik.setFieldValue(
                              "licenseFile",
                              event.currentTarget.files[0]
                            );
                            formik.setFieldValue("fileType", "licenses");
                          }}
                        />
                      }
                    />
                    <FormControlLabel
                      style={{ marginTop: "20px" }}
                      label="Autorizacion previa"
                      labelPlacement="top"
                      control={
                        <input
                          id="authFile"
                          name="authFile"
                          type="file"
                          onChange={(event) => {
                            formik.setFieldValue(
                              "authFile",
                              event.currentTarget.files[0]
                            );
                            formik.setFieldValue("fileType", "licenses");
                          }}
                        />
                      }
                    />
                  </>
                )}

              {props.visit?.status === VISIT_STATES.REPORT &&
                user?.roles.includes(ROLES.TECHNIC) && (
                  <>
                    <FormControlLabel
                      style={{ marginTop: "20px" }}
                      label="Evidencia fotografica"
                      labelPlacement="top"
                      control={
                        <input
                          id="photos"
                          name="photos"
                          type="file"
                          onChange={(event) => {
                            formik.setFieldValue(
                              "photos",
                              event.currentTarget.files
                            );
                            formik.setFieldValue("fileType", "report");
                          }}
                          multiple
                        />
                      }
                    />
                    {formik.values.photos&& Object.values(formik.values.photos).map((file) => {
                      if (typeof file === "object") {
                        return <Thumb file={file} />;
                      }
                    })}

                    <TextField
                      style={{ marginTop: "20px" }}
                      fullWidth
                      autoFocus
                      label="Descripcion General"
                      name="generalDescription"
                      variant="outlined"
                      onBlur={formik.handleBlur}
                      onChange={formik.handleChange}
                      error={
                        formik.touched.generalDescription &&
                        Boolean(formik.errors.generalDescription)
                      }
                      helperText={
                        formik.touched.generalDescription &&
                        formik.errors.generalDescription
                      }
                      type="text"
                      value={formik.values.generalDescription}
                    />
                    <TextField
                      style={{ marginTop: "20px" }}
                      fullWidth
                      autoFocus
                      label="Consideraciones"
                      name="considerations"
                      variant="outlined"
                      onBlur={formik.handleBlur}
                      onChange={formik.handleChange}
                      error={
                        formik.touched.considerations &&
                        Boolean(formik.errors.considerations)
                      }
                      helperText={
                        formik.touched.considerations &&
                        formik.errors.considerations
                      }
                      type="text"
                      value={formik.values.considerations}
                    />
                  </>
                )}
              {props.visit?.status !== VISIT_STATES.FINISHED && (<TextField
                style={{ marginTop: "20px" }}
                fullWidth
                autoFocus
                label="Comentarios"
                name="comments"
                variant="outlined"
                onBlur={formik.handleBlur}
                onChange={formik.handleChange}
                error={
                  formik.touched.comments && Boolean(formik.errors.comments)
                }
                helperText={formik.touched.comments && formik.errors.comments}
                type="text"
                value={formik.values.comments}
              />)}
            </div>
          </DialogContent>
          <DialogActions>
            <Button
              autoFocus
              color="primary"
              className="cancel"
              onClick={()=>{formik.resetForm(); props.handleCloseDialogue(); }}
            >
              Cancelar
            </Button>

            <Button
              autoFocus
              type="submit"
              color="primary"
              className={props.waitLoading ? "disabled" : "save"}
              disabled={props.waitLoading ? true : false}
            >
              {props.waitLoading ? "Por favor espere..." : "Guardar"}
            </Button>
          </DialogActions>
        </form>
      </Dialog>
    </>
  );
}
