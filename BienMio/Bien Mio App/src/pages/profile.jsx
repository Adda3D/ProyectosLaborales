import { Button, TextField, Typography } from "@mui/material";
import React, { useState, useContext, useEffect } from "react";
import DashboardLayout from "../components/DashboardLayout/DashboardLayout";
import { useNavigate } from "react-router-dom";
import { DataContext } from "../context/DataContext";
import { AuthUserContext } from "../context/AuthContext";
import { ROUTES } from "../routes/routesInfo";
import "./style.scss"
import { subscribeUser } from "../subscription";

const Profile = () => {
  const { user, token, doSetUser } = useContext(AuthUserContext);
  const { allVisits, allUsers, fetchVisitData, allTechnicalUsers } =
    useContext(DataContext);
  const navigate = useNavigate();
  const [openDialogue, setOpenDialogue] = useState(false);
  const [openCreateDialogue, setOpenCreateDialogue] = useState(false);
  const [loader, setLoader] = useState(false);
  const [waitLoading, setWaitLoading] = useState(false);
  const [dataToEdit, setDataToEdit] = useState(null);
  const [value, setValue] = React.useState("");

  const handleChange = (event) => {
    setValue(event.target.value);
  };
  useEffect(() => {
    if (!user){
      navigate("/");
    }
  }, [user, navigate]);


  return (
    <DashboardLayout route={ROUTES.otherRoutes.userProfile} >
      <div class="card-grey-4">
        <div class="container3 center-3">
          <h3><Typography 
            fontWeight={"bold"}
            fontSize={24}>
              {user?.roles}
            </Typography></h3>
          <img src={require('../img/img_avatar.png')} width="100" height="100" />
          <h5><Typography fontSize={18}>Hola {user?.firstName} {user?.surname}</Typography></h5>
          <h5><Typography fontSize={18}>Cambiar nombre</Typography></h5>
          <div class="section-3">
          <TextField
            id="outlined-multiline-flexible"
            label="Nombre"
            multiline
            maxRows={4}
            value={user?.firstName}
            onChange={handleChange}
          />
          <TextField
            id="outlined-multiline-flexible"
            label="Apellido"
            multiline
            maxRows={4}
            value={user?.surname}
            onChange={handleChange}
          />
          </div>

          <div class="section-3">
              <Button
                autoFocus
                className="button-edit"
                variant="contained"
                onClick={() => setOpenCreateDialogue(true)}
                style={{ background: "#F8BB18" }}>
                <div
                  style={{ background: '#F8BB18' }}>
                  <b>Cambiar Datos</b>
                </div>
              </Button>
          </div>
        </div>
      </div>      
    </DashboardLayout>
  );
};
export default Profile;
