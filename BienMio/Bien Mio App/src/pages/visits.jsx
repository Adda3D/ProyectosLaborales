import React, { useState, useContext } from "react";
import DashboardLayout from "../components/DashboardLayout/DashboardLayout";
import { ROUTES } from "../routes/routesInfo";
import MUIDataTable from "mui-datatables";
import {
  Box,
  Typography,
  Button,
  Tooltip,
} from "@mui/material";
import { AuthUserContext } from "../context/AuthContext";
import { useNavigate } from "react-router-dom";
import { Edit } from "@mui/icons-material";
import { DataContext } from "../context/DataContext";
import {
  isAdmin, ROLES, VISIT_STATES,
} from "../Utils/states";
import EditVisitDialog from "../components/EditVisit/EditVisitDialog";
import CreateVisitDialog from "../components/CreateVisit/CreateVisitDialog";
import "./style.scss"
import DateTimeRender from "../components/DateTimeRender/DateTimeRender";
import VisitStatusRender from "../components/VisitStatus/VisitStatus";
import VisibilityIcon from '@mui/icons-material/Visibility';

const Visits = () => {
  const { user, token, doSetUser } = useContext(AuthUserContext);
  const { allVisits, allUsers, fetchVisitData, allTechnicalUsers } =
    useContext(DataContext);
  const navigate = useNavigate();
  const [openDialogue, setOpenDialogue] = useState(false);
  const [openCreateDialogue, setOpenCreateDialogue] = useState(false);
  const [loader, setLoader] = useState(false);
  const [waitLoading, setWaitLoading] = useState(false);
  const [dataToEdit, setDataToEdit] = useState(null);
  // useEffect(() => {
  //   if (!user || !token){
  //     navigate("/");
  //   }
  // }, [user, token, navigate]);
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
      label: "Direccion",
      name: "address",
    },
    {
      label: "Tecnico encargado",
      name: "technicalId",
      options: {
        customBodyRender: (value) => {
          let name = value;
          if (user){
            if (isAdmin(user)) {
            const tech = allUsers.find((item) => item._id === value);
            if (tech) {
              name = `${tech.firstName} ${tech.surname}`;
            }
          } else {
            name = `${user.firstName} ${user.surname}`;
          }
          }
          return <>{name}</>;
        },
      },
    },
    {
      label: "Fecha de asignacion",
      name: "assignedDate",
      options: {
        customBodyRender: (value) => <DateTimeRender value={value} />,
      },
    },
    {
      label: "Tipo de visita",
      name: "type",
    },
    {
      label: "Causal de la Visita",
      name: "causalType",
    },
    {
      label: "Estado de la visita",
      name: "status",
      options: {
        customBodyRender: (value) => <VisitStatusRender value={value} />,
      },
    },
    {
      label: "ACTIONS",
      name: "_id",
      options: {
        setCellProps: () => ({ style: { width: "60px" } }),
        customBodyRender: (value, tableMeta) => {
         const visitToEdit=allVisits.find((item) => item._id === value)
          return (
            <div className="action-col">
              {visitToEdit.status!==VISIT_STATES.FINISHED &&(<Tooltip title="Edit">
                <Edit
                  onClick={
                    () => {
                      setDataToEdit(
                        visitToEdit
                      );
                      setOpenDialogue(true);
                    }
                  }
                  style={{ color: "#515151" }}
                />
              </Tooltip>)}
              {visitToEdit.status===VISIT_STATES.FINISHED && (<Tooltip title="View">
                <VisibilityIcon
                  onClick={
                    () => {
                      setDataToEdit(
                        visitToEdit
                      );
                      setOpenDialogue(true);
                    }
                  }
                  style={{ color: "#515151" }}
                />
              </Tooltip>)}
            </div>
          );
        },
      },
    },
  ];

  const adminColumns = [
    {
      label: "Referencia Catastral",
      name: "cadastralReference",
    },
    {
      label: "Tecnico encargado",
      name: "technicalId",
      options: {
        customBodyRender: (value) => {
          let name = value;
          if (user){
            if (isAdmin(user)) {
            const tech = allUsers.find((item) => item._id === value);
            if (tech) {
              name = `${tech.firstName} ${tech.surname}`;
            }
          } else {
            name = `${user.firstName} ${user.surname}`;
          }
          }
          return <>{name}</>;
        },
      },
    },
    {
      label: "Fecha de asignacion",
      name: "assignedDate",
      options: {
        customBodyRender: (value) => <DateTimeRender value={value} />,
      },
    },
    {
      label: "Tipo de visita",
      name: "type",
    },
    {
      label: "Causal de la Visita",
      name: "causalType",
    },
    {
      label: "Tipo de Obra",
      name: "buildingType",
    },
    {
      label: "Categoria de Intervención",
      name: "interventionLevel",
    },
    {
      label: "Estado de la visita",
      name: "status",
      options: {
        customBodyRender: (value) => <VisitStatusRender value={value} />,
      },
    }
  ];

  const handleCloseDialogue = () => {
    setOpenDialogue(false);
  };
  const handleCloseCreateDialogue = () => {
    setOpenCreateDialogue(false);
  };

  return (
    <DashboardLayout route={ROUTES.appNavRoutes.visits}>
      <Box className="user-padding">
        <Box className="box-title">
          <Typography variant="h5" className="user-text">
            <div
              style={{
                fontFamily: "Fira Sans", 
                fontSize: "25px", 
                paddingTop: "2rem", 
                color:"#4F350B"}}>
                <b>Visitas</b>
            </div> 
          </Typography>
          <Button 
          autoFocus
          className="button-edit"
          variant="contained"
          onClick={() => setOpenCreateDialogue(true)}
          style={{ background: "#F8BB18", justifySelf: "flex-end" }}>
            <div
              style={{ background: '#F8BB18' }}>
                <b>Crear Visita</b>
            </div>
        </Button>
        </Box>

        <CreateVisitDialog
          cadastralReference={undefined}
          open={openCreateDialogue}
          setWaitLoading={setWaitLoading}
          waitLoading={waitLoading}
          handleCloseDialogue={handleCloseCreateDialogue}
          token={token}
          user={user}
          fetchVisitData={fetchVisitData}
          technicalUsers={allTechnicalUsers}
          request={(user?.roles.includes(ROLES.LEGAL)) ? true : false}
        />
        {allVisits ? (
          <>
            <MUIDataTable
              title={""}
              data={[...allVisits]}
              columns={user?.roles.includes(ROLES.ADMIN)?adminColumns: columns}
              options={options}
            />
          </>
        ) : (
          <>No existen visitas que editar!</>
        )}
        <EditVisitDialog
          open={openDialogue}
          setWaitLoading={setWaitLoading}
          waitLoading={waitLoading}
          handleCloseDialogue={handleCloseDialogue}
          visit={dataToEdit}
          token={token}
          fetchVisitData={fetchVisitData}
          technicalUsers={allTechnicalUsers}
          user={user}
          // limit={limit}
          // offset={offset}
        />
      </Box>
    </DashboardLayout>
  );
};
export default Visits;
