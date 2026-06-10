import DashboardIcon from "@mui/icons-material/Dashboard";
import GroupIcon from "@mui/icons-material/Group";
import CameraIndoorIcon from "@mui/icons-material/CameraIndoor";
import AssignmentIcon from "@mui/icons-material/Assignment";
import FolderIcon from '@mui/icons-material/Folder';
import HistoryIcon from '@mui/icons-material/History';
import AddLocationAltIcon from '@mui/icons-material/AddLocationAlt';
import { ROLES } from "../Utils/states";

export const ROUTES = {
  otherRoutes: {
    login: {
      title: "Login",
      link: "/",
    },
    register: {
      title: "Registro",
      link: "/register",
    },
    userProfile: {
      title: "Perfil",
      link: "/profile",
    },
    forgotPassword: {
      title: "Recuperar Contraseña",
      link: "/passwordold",
    },
    pdf: {
      title: "PDF",
      link: "/pdf",
    },
    
  },
  
  appNavRoutes: {
    home: {
      title: "Inicio",
      icon: <DashboardIcon />,
      link: "/home",
      state: false,
      roles: Object.values(ROLES),
      index: 0,
    },
    users: {
      title: "Usuarios",
      icon: <GroupIcon />,
      link: "/users",
      state: false,
      roles: [ROLES.ADMIN, ROLES.ASSIST],
      index: 1,
    },
    visits: {
      title: "Visitas",
      icon: <CameraIndoorIcon />,
      link: "/visits",
      state: false,
      roles: [ROLES.ADMIN, ROLES.ASSIST, ROLES.TECHNIC],
      index: 2,
    },
    processes: {
      title: "Procesos",
      icon: <AssignmentIcon />,
      link: "/processes",
      state: false,
      roles: [ROLES.ADMIN, ROLES.ASSIST, ROLES.LEGAL],
      index: 3,
    },
    
    events: {
      title: "Eventos",
      icon: <HistoryIcon />,
      link: "/events",
      state: false,
      roles: [ROLES.ADMIN, ROLES.ASSIST],
      index: 4,
    },
    // files: {
    //   title: "Archivos",
    //   icon: <FolderIcon />,
    //   link: "/files",
    //   state: false,
    //   roles: [ROLES.ADMIN, ROLES.ASSIST],
    //   index: 5,
    // },
    midas: {
      title: "Midas",
      icon: <AddLocationAltIcon />,
      link: "/midas",
      state: false,
      roles: Object.values(ROLES),
      index: 6,
    },

    // profile: {
    //   link: "/profile",
    //   state: false,
    //   roles: Object.values(ROLES),
    //   index: 0,
    // },
  },
};
