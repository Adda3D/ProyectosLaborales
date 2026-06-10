import React, { Component, useEffect, useContext } from "react";
import logo from "../img/logo_registro.svg";
import '../css/main.scss';
import { useNavigate } from "react-router-dom";
import { Field, Formik, Form } from "formik";
import * as yup from "yup";
import { signUp } from "../api/auth";
import { saveUserDataLocal } from "../Utils/localStorage";
import { AuthUserContext } from "../context/AuthContext";
import { errorHandle } from "../Utils/ErrorHandle";
import { identificationTypes } from "../Utils/states";
import { ROUTES } from "../routes/routesInfo";


const Register = () => {
    const { user, doSetUser } = useContext(AuthUserContext);
    const navigate = useNavigate();
    const initialValues = {
        email: "",
        firstName: "",
        middleName: "",
        surname: "",
        secondSurname: "",
        phoneNumber: "",
        identificationType: "",
        identification: "",
        confirmPassword: "",
        password: ""
    }

    const validationSchema = yup.object().shape({
        email: yup.string().required("Ingresa tu correo electronico"),
        password: yup.string().required("Ingresa tu contraseña"),
        identification: yup.string().required("Ingresa el numero de tu documento de identidad"),
        identificationType: yup.string().required("Selecciona el tipo de tu documento de identidad"),
        firstName: yup.string().required("Ingresa tu nombre"),
        surname: yup.string().required("Ingresa tu apellido"),
        confirmPassword: yup.string().when("password", {
            is: val => (val && val.length >= 8 ? true : false),
            then: yup.string().oneOf(
                [yup.ref("password")],
                "Both password need to be the same"
            )
        }),
    });

    useEffect(() => {
        if (user) {
            navigate(ROUTES.appNavRoutes.home.link);
        }
    }, [user, navigate]);


    return ( 
        <div className="login-container">
            <div className="logoRegister-space">
                <img src={logo} alt="" />
            </div>

            <div className="register-box">
                <Formik
                    enableReinitialize={true}
                    initialValues={initialValues}
                    validationSchema={validationSchema}

                    onSubmit={async (values,) => {
                        try {
                            const data = await signUp(values);
                            if (data) {
                                navigate('/');
                            }
                        } catch (e) {
                            errorHandle(e, "Can't login");
                            console.log(e);
                        }
                    }}
                >
                    {({ errors, touched }) => (
                        <Form>
                            <div>
                                <label> Primer nombre: </label>
                                <Field type="text" id="firstName" name="firstName" placeholder="Primer nombre" />
                                {errors.firstName && touched.firstName ? (
                                    <div className="form-errors">{errors.firstName}</div>
                                ) : null}
                            </div>
                            <div>
                                <label> Segundo nombre(opcional):</label>
                                <Field type="text" id="middleName" name="middleName" placeholder="Segundo nombre" />
                                {errors.middleName && touched.middleName ? (
                                    <div className="form-errors">{errors.middleName}</div>
                                ) : null}
                            </div>
                            <div>
                                <label> Primer apellido: </label>
                                <Field type="text" id="surname" name="surname" placeholder="Primer apellido" />
                                {errors.surname && touched.surname ? (
                                    <div className="form-errors">{errors.surname}</div>
                                ) : null}
                            </div>
                            <div>
                                <label> Segundo apellido(opcional):</label>
                                <Field type="text" id="secondSurname" name="secondSurname" placeholder="Segundo apellido" />
                                {errors.secondSurname && touched.secondSurname ? (
                                    <div className="form-errors">{errors.secondSurname}</div>
                                ) : null}
                            </div>
                            <div>
                                <label> Numero de Telefono: </label>
                                <Field type="text" id="phoneNumber" name="phoneNumber" placeholder="Ej: 321 6547980" />
                                {errors.phoneNumber && touched.phoneNumber ? (
                                    <div className="form-errors">{errors.phoneNumber}</div>
                                ) : null}
                            </div>
                            <div>
                                <label> Tipo de Identificación: </label>
                                <div className="group-options" role="group" aria-labelledby="my-radio-group">
                                    {Object.entries(identificationTypes).map((item) =>
                                    (<label className="options">
                                        <Field type="radio" name="identificationType" value={item[0]} />
                                        {item[1]}
                                    </label>)
                                    )}
                                </div>
                                {errors.identificationType && touched.identificationType ? (
                                    <div className="form-errors">{errors.identificationType}</div>
                                ) : null}
                            </div>
                            <div>
                                <label> Numero de Identificación: </label>
                                <Field type="text" id="identification" name="identification" placeholder="Numero de Identificación" />
                                {errors.identification && touched.identification ? (
                                    <div className="form-errors">{errors.identification}</div>
                                ) : null}
                            </div>
                            <div>
                                <label> Email: </label>
                                <Field type="text" id="email" name="email" placeholder="Ej: correo@electronico.com" />
                                {errors.email && touched.email ? (
                                    <div className="form-errors">{errors.email}</div>
                                ) : null}
                            </div>
                            <div>
                                <label> Contraseña: </label>
                                <Field type="password" id="password" name="password" placeholder="Contraseña" />
                                
                                {errors.password && touched.password ? (
                                    <div className="form-errors">{errors.password}</div>
                                ) : null}
                            </div>
                            <div>
                                <label> Confirmar Contraseña: </label>
                                <Field type="password" id="confirmPassword" name="confirmPassword" placeholder="Contraseña" />
                                {errors.confirmPassword && touched.confirmPassword ? (
                                    <div className="form-errors">{errors.confirmPassword}</div>
                                ) : null}
                            </div>
                            <button type="submit">Ingresar</button>
                            <br></br>
                            <a href="/"> Ya tengo una cuenta </a>
                        </Form>)}

                </Formik>

            </div>
        </div>
    );
}

export default Register;