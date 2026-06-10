import React from "react";
import {Container, Grid, Text, Image, listItemClasses} from "@mui/material";
import LeftBar from "../Sidebar/NavigationSidebar";
import Logout from "../User/actions/Logout/Logout";
import "./DashboardLayout.scss"
import logo from "../../img/logo_dashboard.svg";

const DashboardLayout = (props) => {
	return (
		<>
		<Container className="dashBoard-sup">
			<Container className="dashBoard-content">
				<Grid container className="container" spacing={3}>
					<Grid item lg={2} xs={6}>
						<div style={{minWidth:"100%"}}><img src={logo} alt="logo" /></div>
					</Grid>
					<Grid item lg={6} display={{xs: "none", lg:"block"}}>
						<div className="inicio">| {props.route.title}</div>
					</Grid>
					<Grid item lg={4} xs={6}>
						<div>
							<Logout />
						</div>
					</Grid>
				</Grid>	
			</Container>
		</Container>
		<Container className="dashBoard-fondo">
			<Container maxWidth="xxl">
				<Grid container>
					<Grid item lg={2} xs={12}>
						<LeftBar state={props.route.state} />
					</Grid>
					<Grid item lg={10} xs={12}>
						{props.children}
					</Grid>
				</Grid>
			</Container>
		</Container>
		</>
	);
};

export default DashboardLayout;