import React from "react";
import {
  Dialog,
  Button,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
  MenuItem,
} from "@mui/material";

import { useFormik } from "formik";
import * as yup from "yup";
import { errorHandle } from "../../Utils/ErrorHandle";
import { ROLES, USER_STATES } from "../../Utils/states";
import { editUser } from "../../api/users";
// import { NotificationManager } from "react-notifications";

export default function EditUserDialog(props) {
  const validationSchema = yup.object({
    // email: yup.string().required("Enter your em"),
  });
  const formik = useFormik({ 
    enableReinitialize: true,
    initialValues: {
      email: "",
      id: props?.user?._id || "",
      roles: props?.user?.roles[0] ||"",
    },
    validationSchema: validationSchema,
    onSubmit: async (values) => {
      const data = new FormData();
      for (const [key, value] of Object.entries(values)) {
        data.append(key, value);
      }
      try {
        props.setWaitLoading(true);
        await editUser(values.id, values, props.token);
        props.handleCloseDialogue();
        props.fetchUserData(props?.limit, props?.offset, props.token);
        props.setWaitLoading(false);
      } catch (e) {
        errorHandle(e, "Create Admin User");
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
          EditUser
        </DialogTitle>
        <form onSubmit={formik.handleSubmit} style={{ width: "100%" }}>
          <DialogContent dividers>
          <TextField
              style={{ marginTop: "20px" }}
              fullWidth
              label="Roles"
              name="roles"
              variant="outlined"
              onBlur={formik.handleBlur}
              onChange={formik.handleChange}
              error={formik.touched.roles && Boolean(formik.errors.roles)}
              helperText={formik.touched.roles && formik.errors.roles}
              select
              value={formik.values.roles}
            >
              {Object.entries(ROLES).map((item, index) => (
                <MenuItem key={index} value={item[1]}>
                  {item[1]}
                </MenuItem>
              ))}
            </TextField>
            {props.isAdmin &&(<TextField
              style={{ marginTop: "20px" }}
              fullWidth
              label="Estado"
              name="status"
              variant="outlined"
              onBlur={formik.handleBlur}
              onChange={formik.handleChange}
              error={formik.touched.status && Boolean(formik.errors.status)}
              helperText={formik.touched.status && formik.errors.status}
              select
              value={formik.values.status}
            >
              {Object.entries(USER_STATES).map((item, index) => (
                <MenuItem key={index} value={item[1]}>
                  {item[1]}
                </MenuItem>
              ))}
            </TextField>)}
          </DialogContent>
          <DialogActions>
            <Button
              autoFocus
              color="primary"
              className="cancel"
              onClick={props.handleCloseDialogue}
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
