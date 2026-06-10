import React, { useContext, useEffect } from "react";
import { Link } from "react-router-dom";
import DashboardLayout from "../components/DashboardLayout/DashboardLayout";
import Logout from "../components/User/actions/Logout/Logout";
//import background from "";
import { AuthUserContext } from "../context/AuthContext";
import { ROUTES } from "../routes/routesInfo";
import { subscribeUser } from "../subscription";
import "./style.scss"; 

const ErrorPage = (props) => {
  // useEffect(() => {
  //   if (token){
  //     subscribeUser(token);
  //   }
  // }, [token])
  return (
    <div className="notFound">
      {props.img}
      <h1>
        {props.title}
      </h1>
      <p>
        {props.message}
      </p>
      <Link to="/"> Volver al inicio</Link>
      <Logout/>
    </div>
  );
};
export default ErrorPage;