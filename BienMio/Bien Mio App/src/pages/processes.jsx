import React, {useState, useContext} from "react";
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
import { DataContext } from "../context/DataContext";
import {  isAdmin } from "../Utils/states";
// import Pagination from "../components/Pagination/Pagination";
import "./style.scss"
import DateTimeRender from "../components/DateTimeRender/DateTimeRender";
import ProcessStatusRender from "../components/processStatus/ProcessStatus";
import EditProcessDialog from "../components/EditProcess/EditProcessDialog";


const Processes = () => {
  const { user, token,  doSetUser } = useContext(AuthUserContext);
  const {allVisits, allProcesses, allUsers, fetchProcessData } = useContext(DataContext);
  const navigate = useNavigate();
  const [openDialogue, setOpenDialogue] = useState(false);
  const [loader, setLoader] = useState(false);
  const [waitLoading, setWaitLoading] = useState(false);
  const [dataToEdit, setDataToEdit] = useState(null);

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
    navigate(`/user/${id}`);
  };

  const columns = [
    {
      label: "Abogado encargado",
      name: "lawyerId",
      options: {
        customBodyRender: (value) => {
          let name = value;
          // if(isAdmin(user)){
          //   const lawyer = allUsers.find(item => item._id===value);
          //   if (lawyer){
          //     name = `${lawyer.firstName} ${lawyer.surname}`
          //   }
          // }else{
          //   name = `${user.firstName} ${user.surname}`
          // }
          // return (
          //   <>{name}</>
          // );
          const user = allUsers.find((item) => item._id === value);
            if (user) {
              name = `${user?.firstName} ${user?.surname}`;
            }
          return <>{name}</>;
        },
      },
    },
    {
      label: "Referencia Catastral",
      name: "cadastralReference",
    },
    {
      label: "Fecha de solicitud",
      name: "requestDate",
      options: {
        customBodyRender: (value) => <DateTimeRender value={value} />,
      },
    },
    {
      label: "Fecha de asignacion",
      name: "assignedDate",
      options: {
        customBodyRender: (value) => <DateTimeRender value={value} />,
      },
    },
    // {
    //   label: "Visitas",
    //   name: "visits",
    // },
    {
      label: "Estado del proceso",
      name: "status",
      options: {
        customBodyRender: (value) => <ProcessStatusRender value={value} />,
      },
    },
    {
      label: "ACTIONS",
      name: "_id",
      options: {
        setCellProps: () => ({ style: { width: "60px" } }),
        customBodyRender: (value, tableMeta) => {
          return (
            <div className="action-col">
              <Tooltip title="View">
                <Edit
                  onClick={() => {setOpenDialogue(true);
                    setDataToEdit(allProcesses.find((item) => item._id=== value));} /*handleNavigate(value)*/}
                  style={{ color: "#515151" }}
                />
              </Tooltip>
            </div>
          );
        },
      },
    },
  ];

  const handleCloseDialogue = () => {
    setOpenDialogue(false);
  };


  
  return (
    <DashboardLayout route={ROUTES.appNavRoutes.processes} >
      <Box className="user-padding">
      <Box className="flex-box mt-10 pb-10">
        <Typography variant="h5" className="user-text">
        <div
              style={{
                fontFamily: "Fira Sans", 
                fontSize: "25px", 
                paddingTop: "2rem", 
                color:"#4F350B"}}>
                <b>Procesos</b>
            </div> 
        </Typography>
      </Box>
      {allProcesses ? (
        <>
          <MUIDataTable
            title={""}
            data={[...allProcesses]}
            columns={columns}
            options={options}
          />
        </>
      ) : (
        <>
          No existen procesos que editar!
        </>
      )}
      <EditProcessDialog
        open={openDialogue}
        setWaitLoading={setWaitLoading}
        waitLoading={waitLoading}
        handleCloseDialogue={handleCloseDialogue}
        process={dataToEdit}
        token={token}
        fetchProcessData={fetchProcessData}
        // limit={limit}
        // offset={offset}
      />
    </Box>
    </DashboardLayout>
  );
};
export default Processes;