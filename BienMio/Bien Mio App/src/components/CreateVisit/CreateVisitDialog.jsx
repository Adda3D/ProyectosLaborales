import React from "react";
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

import { Form, useFormik } from "formik";
import * as yup from "yup";
import { errorHandle } from "../../Utils/ErrorHandle";
import {
  INTERVENTION_TYPE,
  BUILDING_TYPE,
  ROLES,
  VISIT_CAUSAL_TYPES,
  VISIT_TYPES,
} from "../../Utils/states";
import { editUser } from "../../api/users";
import { createVisit, editVisit } from "../../api/visits";
import { format } from "date-fns";
import { findEstate } from "../../Utils/midas";
import { CommentsAsListRender } from "../VisitRender/VisitRender";
import { VISIT_TRANSLATES } from "../../Utils/Translations";
// import { NotificationManager } from "react-notifications";

export default function CreateVisitDialog(props) {
  const validationSchema = yup.object({
    // email: yup.string().required("Enter your em"),
         cadastralReference: yup
      .string().when('type', {
        is: VISIT_TYPES.SUSPEN,
        then: yup.string().required("Se requiere la referencia catastral"),
      }),
  });

  const formik = useFormik({
    //enableReinitialize: true,
    initialValues: {
      technicalId: "",
      requestDate: format(new Date(), "yyyy-MM-dd'T'hh:mm"),
      assignedDate: props?.request
        ? undefined
        : format(new Date(), "yyyy-MM-dd'T'hh:mm"),
      comments: props?.comments || "",
      type: "",
      interventionLevel: props?.request || "",
      buildingType: props?.request || "",
      causalType: props?.request ? VISIT_CAUSAL_TYPES.PJ : "",
      numAuto: "",
      request: props?.request,
      processId: props.processId? "si":"no",
      cadastralReference: "",
      address: "",
      nextProcessStatus: "",
      estate: null
    },
    validationSchema: validationSchema,
    onSubmit: async (values) => {
      try {
        props.setWaitLoading(true);
        if (values.type=== VISIT_TYPES.INSPEC){
          values.numAuto ="";
        }
        if (props.processId){
          values.processId=props.processId;
          values.nextProcessStatus=props.processState;
        }
        await createVisit(values, props.token);
        props.handleCloseDialogue();
        props.fetchVisitData(props?.limit, props?.offset, props.token);
        props.setWaitLoading(false);
      } catch (e) {
        errorHandle(e, "Crear Visita");
        props.handleCloseDialogue();
        props.setWaitLoading(false);
      }
    },
  });
  return (
    <>
      <Dialog
        maxWidth="sm"
        fullWidth={true}
        aria-labelledby="customized-dialog-title"
        open={props.open}
      >
        <DialogTitle
          id="customized-dialog-title"
          onClose={props.handleCloseDialogue}
        >
          {formik.values.request ? "Solicitar una Visita" : "Crear una visita"}
        </DialogTitle>
        <form onSubmit={formik.handleSubmit} style={{ width: "100%" }}>
          <DialogContent dividers>
            {formik.values.type === VISIT_TYPES.SUSPEN&&(
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
              </>
            )}
            {!formik.values.request && (
              <>
              {console.log(props.user?.roles.includes(ROLES.ASSIST))}
               {props.user&& props.user.roles.includes(ROLES.ASSIST) && (
                 <>
               <TextField
                      style={{ marginTop: "20px" }}
                      fullWidth
                      autoFocus
                      label="Direccion"
                      name="address"
                      variant="outlined"
                      onBlur={formik.handleBlur}
                      onChange={formik.handleChange}
                      error={
                        formik.touched.address &&
                        Boolean(formik.errors.address)
                      }
                      helperText={
                        formik.touched.address &&
                        formik.errors.address
                      }
                      type="text"
                      value={formik.values.address}
                    />
               <TextField
                  style={{ marginTop: "20px" }}
                  fullWidth
                  label="Arquitecto/Tecnico encargado"
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
                </>
                )}
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
                  label="Categoria de Intervención"
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
                    helperText={formik.touched.numAuto && formik.errors.numAuto}
                    type="text"
                    value={formik.values.numAuto}
                  />
                )}
                <TextField
                  style={{ marginTop: "20px" }}
                  fullWidth
                  focused
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
              </>
            )}
            <TextField
              style={{ marginTop: "20px" }}
              fullWidth
              autoFocus
              label="Comentarios"
              name="comments"
              variant="outlined"
              onBlur={formik.handleBlur}
              onChange={formik.handleChange}
              error={formik.touched.comments && Boolean(formik.errors.comments)}
              helperText={formik.touched.comments && formik.errors.comments}
              type="text"
              value={formik.values.comments}
            />
          </DialogContent>
          <DialogActions>
            <Button
              autoFocus
              color="primary"
              className="cancel"
              onClick={()=>{formik.resetForm(); props.handleCloseDialogue(); }}
            >
              Cancel
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
