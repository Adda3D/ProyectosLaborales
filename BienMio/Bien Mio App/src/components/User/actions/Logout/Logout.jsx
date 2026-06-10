import React, { useContext, useState } from "react";
import { useNavigate } from "react-router-dom";
import { AuthUserContext } from "../../../../context/AuthContext";
import { cleanUserDataStorage } from "../../../../Utils/localStorage"
import './Logout.scss';
import { Avatar, Box, Button, Container, Divider, IconButton, ListItemIcon, Menu, MenuItem, Tooltip, Typography } from "@mui/material";
import SvgIcon from '@mui/material/SvgIcon';
import { Settings } from "@mui/icons-material";
import PersonAdd from '@mui/icons-material/PersonAdd';
import { ROUTES } from "../../../../routes/routesInfo";


export const signOut = (doSetUser) => {
  cleanUserDataStorage();
  doSetUser(null);
}

const Logout = () => {
  const { user, token, doSetUser } = useContext(AuthUserContext);
  const [openDialogue, setOpenDialogue] = useState(false);
  const [openCreateDialogue, setOpenCreateDialogue] = useState(false);
  const [loader, setLoader] = useState(false);
  const [waitLoading, setWaitLoading] = useState(false);
  const [dataToEdit, setDataToEdit] = useState(null);
  const navigate = useNavigate();
  const handleSignOut = () => {
    cleanUserDataStorage();
  doSetUser(null);
  }

  const [anchorEl, setAnchorEl] = useState(null);
  const open = Boolean(anchorEl);

  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <>
      <Box sx={{ alignItems: 'center', textAlign: 'center' }}>
        <Tooltip title="Account settings">
          <IconButton
            onClick={handleClick}
            size="small"
            sx={{ ml: 2 }}
            aria-controls={open ? 'account-menu' : undefined}
            aria-haspopup="true"
            aria-expanded={open ? 'true' : undefined}
          >
            <Avatar sx={{ width: 50, height: 50, color: 'white', background: '#F8BB18' }}></Avatar>
            <Typography
              size="small"
              color="#F8BB18"
              paddingLeft="1rem"
            >
              {user?.firstName} {user?.surname}
            </Typography>
          </IconButton>
        </Tooltip>
      </Box>
      <Menu
        anchorEl={anchorEl}
        id="account-menu"
        open={open}
        onClose={handleClose}
        onClick={handleClose}
        PaperProps={{
          elevation: 0,
          sx: {
            overflow: 'visible',
            filter: 'drop-shadow(0px 2px 8px rgba(0,0,0,0.32))',
            mt: 1.5,
            '& .MuiAvatar-root': {
              width: 32,
              height: 32,
              ml: -0.5,
              mr: 1,
            },
            '&:before': {
              content: '""',
              display: 'block',
              position: 'absolute',
              top: 0,
              right: 14,
              width: 10,
              height: 10,
              bgcolor: 'background.paper',
              transform: 'translateY(-50%) rotate(45deg)',
              zIndex: 0,
            },
          },
        }}
        transformOrigin={{ horizontal: 'right', vertical: 'top' }}
        anchorOrigin={{ horizontal: 'right', vertical: 'bottom' }}
      >
        <MenuItem>

        </MenuItem>
        <MenuItem onClick={() => navigate(ROUTES.otherRoutes.userProfile.link)}>
          Perfil
        </MenuItem>
        <MenuItem onClick={() => handleSignOut()}>
          Cerrar Sesion
        </MenuItem>
      </Menu>
    </>
  );
}
export default Logout;