
import React, { useContext, useEffect, useState } from "react";
import DashboardLayout from "../components/DashboardLayout/DashboardLayout";

import { AuthUserContext } from "../context/AuthContext";
import { ROUTES } from "../routes/routesInfo";
import { subscribeUser } from "../subscription";
import "./style.scss"
import { useNavigate } from "react-router-dom"

import ReactDOMServer from "react-dom/server";
import jsPDF from "jspdf";
import { Box, Button, Typography } from "@mui/material";


import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';


function createData(name, fecha, link) {
  return { name, fecha, link };

}



const doc = new jsPDF();
const Foo = <b>foo</b>;

const Files = () => {
  const { user, doSetUser } = useContext(AuthUserContext);
  const navigate = useNavigate();
  const { token } = useContext(AuthUserContext);

    const [pdfFile, setPdfFile]=useState(null);
    const [pdfFileError, setPdfFileError] = useState('');

    const [viewPdf, setViewPdf]=useState(null);


  const save = () => {
    doc.html(ReactDOMServer.renderToStaticMarkup(Foo), {
      callback: () => {
        doc.save("myDocument.pdf");
      }
    });
  };
  // useEffect(() => {
  //   if (token){
  //     subscribeUser(token);
  //   }
  // }, [token])
  //<button onClick={save}>save</button>
  const rows = [

    createData('Requisitos del software', '20/02/2022',

      <Button
        autoFocus
        className="button-edit"
        variant="contained"
        onClick={() => navigate(ROUTES.otherRoutes.pdf.link)}
        style={{ background: "#F8BB18" }}>
        <div
          style={{ background: '#F8BB18' }}>
          <b>Ir a PDF</b>
        </div>
      </Button>
    ),
    createData('Informe Inicial', '14/02/2022', 
    <Button
        autoFocus
        className="button-edit"
        variant="contained"
        onClick={() => navigate(ROUTES.otherRoutes.pdf.link)}
        style={{ background: "#F8BB18" }}>
        <div
          style={{ background: '#F8BB18' }}>
          <b>Ir a PDF</b>
        </div>
      </Button>
      ),
  ];

  return (
    <DashboardLayout route={ROUTES.appNavRoutes.files} >
      <Box className="event-padding">
        <Box className="flex-box mt-10 pb-10">
          <Typography variant="h5" className="user-text">
            <div
              style={{
                fontFamily: "Fira Sans",
                fontSize: "25px",
                paddingTop: "2rem",
                color: "#4F350B"
              }}>
              <b>Archivos</b>
            </div>
          </Typography>
        </Box>

        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>Nombre del documento</TableCell>
                <TableCell align="right">Fecha de creacion</TableCell>
                <TableCell align="right">Enlace</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {rows.map((row) => (
                <TableRow
                  key={row.name}
                  sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                >
                  <TableCell component="th" scope="row">
                    {row.name}
                  </TableCell>
                  <TableCell align="right">{row.fecha}</TableCell>
                  <TableCell align="right">{row.link}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Box>
      <div>
        {/* <form className="form-group" onSubmit={handlePdfFileSubmit}>
          <input type="file" className="form-control"
          />
          <button type="submit" className="btn">UPLOAD</button>
        </form> */}
      </div>
    </DashboardLayout >
  );
};
export default Files;
