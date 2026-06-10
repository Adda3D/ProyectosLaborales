import React, {useState, useContext, useEffect} from "react";
import DashboardLayout from "../components/DashboardLayout/DashboardLayout";
import { ROUTES } from "../routes/routesInfo";
import MUIDataTable from "mui-datatables";
import {
  Box,
  Typography,
  Tooltip,
} from "@mui/material";
import { AuthUserContext } from "../context/AuthContext";
import { useNavigate } from "react-router-dom";
import { Edit } from "@mui/icons-material";
import EditUserDialog from "../components/EditUser/EditUserDialog";
import { DataContext } from "../context/DataContext";
import "./style.scss"
import { getAllEvents } from "../api/events";
import { errorHandle } from "../Utils/ErrorHandle";
import { isAdmin } from "../Utils/states";

const Events = () => {
  const {user, token} = useContext(AuthUserContext);
  const navigate = useNavigate();
  const [openDialogue, setOpenDialogue] = useState(false);
  const [loader, setLoader] = useState(false);
  const [waitLoading, setWaitLoading] = useState(false);
  const [allEvents, setAllEvents] = useState(null);
  const [limit] = useState(10);
  const [offset, setOffset] = useState(0);
  const { allUsers } = useContext(DataContext);
  const fetchEventData = async (limit, offset, token) => {
    try {
      setLoader(true);
      const data = await getAllEvents(token);
      setAllEvents(data);
      setLoader(false);
    } catch (e) {
      errorHandle(e, "Getting Events");
      setLoader(false);
    }
  };
  useEffect(() => {
    if (!user || !token){
      navigate("/");
    }
  }, [user, token, navigate]);
  useEffect(() => {
    if (token){
      fetchEventData(limit, offset, token);
    }
  }, [limit, offset, token]);


  const options = {
    responsive: "standard",
    selectableRows: "none",
    customSearchRender: () => null,
    search: false,
    filter: true,
    pagination: false,
    print: false,
    download: false,
    viewColumns: true,
  };

  const handleNavigate = async (id) => {
    navigate(`/event/${id}`);
  };

  const columns = [
    {
      label: "NOMBRE",
      name: "userId",
      options: {
        customBodyRender: (value) => {
          let name = value;
          // if (user){
          //   if (isAdmin(user)) {
            
          // } else {
          //   name = `${user.firstName} ${user.surname}`;
          // }}
          const user = allUsers?.find((item) => item._id === value);
            if (user) {
              name = `${user.firstName} ${user.surname}`;
            }
          return <>{name}</>;
        },
      },
    },
    {
      label: "ACCION REALIZADA",
      name: "action",
    },
    {
      label: "EVENTO",
      name: "entity",
      options: {
        customBodyRender: (value) => <div> {value?._id} </div>,
      },
    },    
  ];

  const handleCloseDialogue = () => {
    setOpenDialogue(false);
  };

  return (
    <DashboardLayout route={ROUTES.appNavRoutes.events} >
      <Box className="event-padding">
      <Box className="flex-box mt-10 pb-10">
        <Typography variant="h5" className="user-text">
        <div
              style={{
                fontFamily: "Fira Sans", 
                fontSize: "25px", 
                paddingTop: "2rem", 
                color:"#4F350B"}}>
                <b>Eventos</b>
            </div> 
        </Typography>
      </Box>
      {allEvents ? (
        <>
          <MUIDataTable
            title={""}
            data={[...allEvents]}
            columns={columns}
            options={options}
          />
        </>
      ) : (
        <>
          No existen eventos
        </>
      )}
      {/* <EditEventDialog
        open={openDialogue}
        setWaitLoading={setWaitLoading}
        waitLoading={waitLoading}
        handleCloseDialogue={handleCloseDialogue}
        event={dataToEdit}
        token={token}
        fetchUserData={fetchEventData}
      /> */}
    </Box>
    </DashboardLayout>
  );
};
export default Events;
