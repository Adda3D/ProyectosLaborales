import React from "react";
import {BrowserRouter, Routes, Route} from 'react-router-dom';
import Login from '../pages/login';
import Register from '../pages/register';
import Passwordold from '../pages/passwordold';
import Home from "../pages/home";
import Midas from "../pages/midas";
import Profile from "../pages/profile";
import { ROUTES } from "./routesInfo";
import Users from "../pages/users";
import Visits from "../pages/visits";
import Processes from "../pages/processes";
import ProtectedRoute from "./ProtectedRoutes";
import Events from "../pages/events";
import Files from "../pages/files";
import ErrorPage from "../pages/errorPage";
import Pdf from "../pages/pdf";
import { ERROR_PAGES } from "../Utils/ErrorPagesInfo";

const AppRoutes = () => {

  return (
    <BrowserRouter>
      <Routes>
        <Route exact path={ROUTES.otherRoutes.login.link} element={<Login />}/>
        <Route exact path={ROUTES.otherRoutes.register.link} element={<Register />}/>
        {/* <Route exact path={ROUTES.otherRoutes.forgotPassword.link} element={<Passwordold />}/> */}
        <Route exact path={ROUTES.appNavRoutes.home.link} element={<ProtectedRoute route={ROUTES.appNavRoutes.home} component={<Home />}/>}/>
        <Route exact path={ROUTES.appNavRoutes.users.link} element={<ProtectedRoute route={ROUTES.appNavRoutes.users} component={<Users />}/>}/>
        <Route exact path={ROUTES.appNavRoutes.visits.link} element={<ProtectedRoute route={ROUTES.appNavRoutes.visits} component={<Visits />}/>}/>
        <Route exact path={ROUTES.appNavRoutes.processes.link} element={<ProtectedRoute route={ROUTES.appNavRoutes.processes} component={<Processes />}/>}/>
        <Route exact path={ROUTES.appNavRoutes.events.link} element={<ProtectedRoute route={ROUTES.appNavRoutes.events} component={<Events />}/>}/>
         {/* <Route exact path={ROUTES.appNavRoutes.files.link} element={<ProtectedRoute route={ROUTES.appNavRoutes.files} component={<Files />}/>}/>  */}
        <Route exact path={ROUTES.otherRoutes.pdf.link} element={<ProtectedRoute route={ROUTES.otherRoutes.pdf} component={<Pdf />}/>}/>
         <Route exact path={ROUTES.otherRoutes.userProfile.link} element={<ProtectedRoute route={ROUTES.otherRoutes.userProfile} component={<Profile />}/>}/>
         <Route exact path={ROUTES.appNavRoutes.midas.link} element={<ProtectedRoute route={ROUTES.appNavRoutes.midas} component={<Midas />}/>}/>
         <Route path= "*" element={<ErrorPage {...ERROR_PAGES.notFound} />}/>
      </Routes>
    </BrowserRouter>
  );
}

export default AppRoutes;
