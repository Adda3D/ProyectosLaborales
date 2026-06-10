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
import EditUserDialog from "../components/EditUser/EditUserDialog";
import { DataContext } from "../context/DataContext";
import "./style.scss"
import { ROLES } from "../Utils/states";


const Users = () => {
  const { user, token,  doSetUser } = useContext(AuthUserContext);
  const {allUsers, fetchUserData } = useContext(DataContext);
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
      label: "NOMBRE",
      name: "firstName",
    },
    {
      label: "Apellido",
      name: "surname",
    },
    {
      label: "EMAIL",
      name: "email",
    },
    {
      label: "ROLES",
      name: "roles",
    },
    {
      label: "TELEFONO",
      name: "phoneNumber",
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
                    setDataToEdit(allUsers.find((item) => item._id=== value));} /*handleNavigate(value)*/}
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
    <DashboardLayout route={ROUTES.appNavRoutes.users} >
      <Box className="user-padding">
      <Box className="flex-box mt-10 pb-10">
        <Typography variant="h5" className="user-text">
        <div
              style={{
                fontFamily: "Fira Sans", 
                fontSize: "25px", 
                paddingTop: "2rem", 
                color:"#4F350B"}}>
                <b>Usuarios</b>
            </div> 
        </Typography>
      </Box>
      {allUsers ? (
        <>
          <MUIDataTable
            title={""}
            data={[...allUsers]}
            columns={columns}
            options={options}
          />
        </>
      ) : (
        <>
          No existen usuarios que editar!
        </>
      )}
      <EditUserDialog
        open={openDialogue}
        setWaitLoading={setWaitLoading}
        waitLoading={waitLoading}
        handleCloseDialogue={handleCloseDialogue}
        user={dataToEdit}
        token={token}
        fetchUserData={fetchUserData}
        isAdmin={user?.roles.includes(ROLES.ADMIN) || user?.roles.includes(ROLES.ASSIST)}
        // limit={limit}
        // offset={offset}
      />
    </Box>
    </DashboardLayout>
  );
};
export default Users;
