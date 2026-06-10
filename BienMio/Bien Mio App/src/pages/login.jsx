import React, { useContext, useEffect } from "react";
import logo from "../img/logo.svg";
import '../css/main.scss';
import { useNavigate } from "react-router-dom";
import { Field, Formik, Form } from "formik";
import * as yup from "yup";
import { signIn } from "../api/auth";
import { saveUserDataLocal } from "../Utils/localStorage";
import { AuthUserContext } from "../context/AuthContext";
import { errorHandle } from "../Utils/ErrorHandle";
import { ROUTES } from "../routes/routesInfo";
import "./style.scss";
import { Backdrop, Button, CircularProgress } from "@mui/material";


const Login = () => {
  const { user, doSetUser } = useContext(AuthUserContext);
  const navigate = useNavigate();
  const validationSchema = yup.object().shape({
    email: yup.string().required("Ingresa tu correo electronico"),
    password: yup.string().required("Ingresa tu contraseña"),
  });

  const [open, setOpen] = React.useState(false);
  const handleClose = () => {
    setOpen(false);
  };
  const handleToggle = () => {
    setOpen(!open);
  };

  useEffect(() => {
    if (user) {
      navigate(ROUTES.appNavRoutes.home.link);
    }

  }, [user, navigate]);

  return (
    <>
    <Backdrop
      sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
      open={open}
      onClick={handleClose}
    >
      <CircularProgress color="inherit" />
    </Backdrop>
    <div className="login-container">
      <div className="logo-space">
        <img src={logo} alt="" />
      </div>

      <div className="login-box">
        <h1> Ingresa tu </h1>
        <h2> Usuario y contraseña </h2>
        <Formik
          enableReinitialize={true}
          initialValues={{
            email: "",
            password: ""
          }}
          validationSchema={validationSchema}

          onSubmit={async (values) => {
            try {
              const data = await signIn(values);

              if (data) {
                saveUserDataLocal(data);
                doSetUser(data)
              }
            } catch (e) {
              errorHandle(e, "Can't login");
              console.log(e);
            }
          }}
        >
          {({ errors, touched }) => (<Form>
            <div>
              <label> Email </label>
              <Field style={{width:"100%"}} type="text" id="email" name="email" placeholder="Usuario" />
              {errors.email && touched.email ? (
                <div className="form-errors">{errors.email}</div>
              ) : null}
            </div>
            <div>
              <label> Password </label>
              <Field style={{width:"100%"}} type="password" id="password" name="password" placeholder="Contraseña" />
              {errors.password && touched.password ? (
                <div className="form-errors">{errors.password}</div>
              ) : null}
            </div>
            <Button variant="contained" style={{ background: "#F8BB18", width:"100%", color: "#4F350B", fontWeight: "bold", marginTop: "1rem"}} type="submit"> Ingresar </Button>
            {/* <button class="button-login" type="submit">Ingresar</button> */}
            <br></br>
            {/* <a href="/passwordold"> ¿Olvidaste tu contraseña?<br></br></a> */}
            <a href="/register"> Registrate </a>
          </Form>)}
        </Formik>

      </div>
    </div>
    </>
  );
}
// 
export default Login;