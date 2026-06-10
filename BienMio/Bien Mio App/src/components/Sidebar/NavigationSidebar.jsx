import React, { useContext } from "react";
import { Box, Container, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { ROUTES } from "../../routes/routesInfo";
import './NavigationSidebar.scss';
import logos from "../../img/logos.png";
import { AuthUserContext } from "../../context/AuthContext";

const LeftBar = (props) => {
  const navigate = useNavigate();
  const {user} = useContext(AuthUserContext);
  let routes = [];
  if(user){
    Object.keys(ROUTES.appNavRoutes).map((item) => {
    if(ROUTES.appNavRoutes[item].roles.includes(user.roles[0])){
      routes.push(ROUTES.appNavRoutes[item]);
    }
  });
  }

  const handleNavigate = (link) => {
    navigate(link);
  };
 
  return (
    <Box className="back-white">
      <Box className="sidebar-text">
        {routes.map((x, index) => (
          <Box
            key={index}
            className={
              index === props.state ? "icon-heading active" : "icon-heading"
            }
            onClick={() => handleNavigate(x.link)}
          >
            <span className="nav-icon">
              {x.icon}
            </span>
            <span className="nav-label">
              {x.title} 
            </span>
          </Box>
        ))}
      </Box>
      <div className="logos-container">
        <img className="logos" src={logos} alt="logo"/>
      </div>
    </Box>
    
  );
};
export default LeftBar;
