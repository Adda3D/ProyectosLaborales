import React, { useContext, useEffect } from "react";
import {useNavigate} from 'react-router-dom';
import { signOut } from "../components/User/actions/Logout/Logout";
import axios from "axios";
import { AuthUserContext } from "../context/AuthContext";
import ErrorPage from "../pages/errorPage";
import { ERROR_PAGES } from "../Utils/ErrorPagesInfo";

const ProtectedRoute = (props) => {
  const { user, doSetUser, token } = useContext(AuthUserContext);
  const navigate = useNavigate();
  // axios.interceptors.request.use(req => {
  //   if(token){
  //     req.defaults.common['Authorization'] =  `Bearer ${token}`
  //      return req;
  //   }
       
  //  }, err => Promise.reject(err))

  axios.interceptors.response.use(function (response) {
    // Any status code that lie within the range of 2xx cause this function to trigger
    // Do something with response data
    if (response.status === 401) {
      signOut(doSetUser);
      navigate("/");
    }
    return response;
  },
    function(error) {
      if (error.response.status === 401) {
        signOut(doSetUser);
        navigate("/");
      }
      return Promise.reject(error);
    }
  );

  useEffect(() => {
    if (!user || !token){
      navigate("/");
    }
  }, [user, token, navigate]);

  if (user&&props.route.roles){
    if (!props.route.roles.includes(user.roles[0])) {
      return <ErrorPage {...ERROR_PAGES.fobbiden}/>
    }
  }
  
  return props.component;
}

export default ProtectedRoute;