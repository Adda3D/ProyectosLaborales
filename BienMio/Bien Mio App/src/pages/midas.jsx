import React, { useContext, useEffect, Component, ReactDOM, useState } from "react";
import DashboardLayout from "../components/DashboardLayout/DashboardLayout";

import { AuthUserContext } from "../context/AuthContext";
import { ROUTES } from "../routes/routesInfo";
import { subscribeUser } from "../subscription";

import Comp1 from "../demo/Comp1";
import Comp2 from "../demo/Comp2";
import { Search } from "@mui/icons-material";
import "./style.scss"
import { Box, Button, Container, Stack } from "@mui/material";

const Midas = () => {
  const onClick = (role) => {
  }

  return (
    <DashboardLayout route={ROUTES.appNavRoutes.home} >
      <Box className="home-padding">
          {/* <h3>Iframes in React</h3> */}
          <embed src="https://midas.cartagena.gov.co/" sandbox="" width={"100%"} height={"800px"}></embed>
      </Box>
    </DashboardLayout>
  )
}


export default Midas;
