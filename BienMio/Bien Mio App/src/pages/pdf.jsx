
import React, { useContext, useEffect } from "react";
import DashboardLayout from "../components/DashboardLayout/DashboardLayout";
import { AuthUserContext } from "../context/AuthContext";
import { ROUTES } from "../routes/routesInfo";
import { subscribeUser } from "../subscription";
import ReactDOMServer from "react-dom/server";
import { Typography, Box } from "@mui/material";
import { useNavigate } from "react-router-dom"
import { Button } from "@mui/material";

const Pdf = () => {
  const { user, doSetUser } = useContext(AuthUserContext);
  const navigate = useNavigate();
  // useEffect(() => {
  //   if (token){
  //     subscribeUser(token);
  //   }
  // }, [token])

  return (
    <DashboardLayout route={ROUTES.otherRoutes.pdf} >
      <Box className="event-padding">
        <Box className="flex-box mt-10 pb-10">
          <Typography variant="h5" className="user-text">
            <div
              style={{
                fontFamily: "Fira Sans",
                fontSize: "25px",
                paddingTop: "2rem",
                color: "#4F350B"
              }}>
              <b>Archivo PDF</b>
            </div>
          </Typography>
        </Box>
        <Button
          autoFocus
          className="button-edit"
          variant="contained"
          onClick={() => navigate(ROUTES.appNavRoutes.files.link)}
          style={{ background: "#F8BB18" }}>
          <div
            style={{ background: '#F8BB18' }}>
            <b>volver</b>
          </div>
        </Button>
        <div>
          <object
            data={require("../docs/requisitos.pdf")}
            type="application/pdf"
            style={{width: '70vw', height: '60vh', margin: '2rem' }}
          >
          </object>
        </div>
      </Box>
    </DashboardLayout>
  );
};
export default Pdf; 
