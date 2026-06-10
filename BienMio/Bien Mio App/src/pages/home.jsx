import React, { useContext, useEffect, Component, ReactDOM, useState } from "react";
import DashboardLayout from "../components/DashboardLayout/DashboardLayout";

import { AuthUserContext } from "../context/AuthContext";
import { ROUTES } from "../routes/routesInfo";
import { subscribeUser } from "../subscription";

import Comp1 from "../demo/Comp1";
import Comp2 from "../demo/Comp2";
import logo from "../img/logo.svg";
import "./style.scss"
import { Box, Button, Container, Stack } from "@mui/material";

import ChatBot from 'react-simple-chatbot';
import { ThemeProvider } from 'styled-components';

const Home = () => {
  const [showTutorialArquitecto, setShowTutorialArquitecto] = useState(false)
  const [showTutorialAsistencial, setShowTutorialAsistencial] = useState(false)
  const [showTutorialJuridico, setShowTutorialJuridico] = useState(false)
  const { user, token, doSetUser } = useContext(AuthUserContext);

  const onClick = (role) => {
    switch (role) {
      case 'juridico':
        setShowTutorialJuridico(!showTutorialJuridico);
        setShowTutorialArquitecto(false);
        setShowTutorialAsistencial(false);
        break;
      case 'arquitecto':
        setShowTutorialArquitecto(!showTutorialArquitecto);
        setShowTutorialJuridico(false);
        setShowTutorialAsistencial(false);
        break;
      case 'asistencial':
        setShowTutorialAsistencial(!showTutorialAsistencial);
        setShowTutorialJuridico(false);
        setShowTutorialArquitecto(false);
        break;
      default: break;
    }
  }

  const theme = {
    background: '#f5f8fb',
    headerBgColor: '#F8BB18',
    headerFontColor: '#fff',
    headerFontSize: '15px',
    botBubbleColor: '#F8BB18',
    botFontColor: '#fff',
    userBubbleColor: '#fff',
    userFontColor: '#4a4a4a',
  };

  const valor1= "suspencion";
  const valor2 = "visita";

  return (
    <DashboardLayout route={ROUTES.appNavRoutes.home} >
      <Box className="home-padding">
        {/* <Box
          component="img"
          sx={{
            height: 233,
            //width: 350,
            maxHeight: { xs: 233, md: 167 },
            minWidth: "100%",
          }}
          src={require('../img/BANNER.PNG')}
        /> */}
        <Container maxWidth="sm">
          <Stack spacing={2} direction="row" justifyContent="center" marginTop={5}>
            <Button variant="contained" style={{ background: "#F8BB18", justifySelf: "flex-end" }} onClick={() => onClick("arquitecto")}> Arquitecto </Button>
            <Button variant="contained" style={{ background: "#F8BB18", justifySelf: "flex-end" }} onClick={() => onClick("asistencial")}> Asistencial </Button>
            <Button variant="contained" style={{ background: "#F8BB18", justifySelf: "flex-end" }} onClick={() => onClick("juridico")}> Juridico </Button>
          </Stack>

          {showTutorialJuridico && (<TutorialJuridico />)}
          {showTutorialArquitecto && (<TutorialArquitecto />)}
          {showTutorialAsistencial && (<TutorialAsistencial />)}
        </Container>
      </Box>
      <ThemeProvider theme={theme}>
      <ChatBot
            floating = {true}
            botAvatar =  {logo}
            headerTitle= "Tu asistente"
            recognitionEnable={true}
              steps={[
                {
                  id: '1',
                  message: `Hola ${user?.firstName} ¿Cómo puedo ayudarte?`,
                  trigger: '2',
                },
                {
                  id: '2',
                  options: [
                    { value: 1, label: 'Consulta Tecnicos', trigger: '3' },
                    { value: 2, label: 'Consulta Asistencial', trigger: '4' },
                    { value: 3, label: 'Consulta Juridicos', trigger: '5' },
                  ],
                },
                {
                  id: '3',
                  message: '¿Que deseas saber sobre el procedimiento de los tecnicos?',
                  trigger: '6',
                },

                {
                  id: '4',
                  options: [
                    { value: 1, label: 'Los asistenciales son los roles que pueden asignar una visita, asegurate de tener el contacto de ellos, ya que son los unicos con estos permisos'},
                    { value: 2, label: 'Volver', trigger: '1' },
                    { value: 3, label: 'Gracias', trigger: 'gracias' },
                  ],
                  
                },
                {
                  id: '5',
                  options: [
                    { value: 1, label: 'Los juridicos son los encargados de revisar los procesos que tienen algun tipo de sanción o en los cuales se ha realizado un procedimiento de suspención.' },
                    { value: 2, label: 'Volver', trigger: '1' },
                    { value: 3, label: 'Gracias', trigger: 'gracias' },
                  ],
                },

                {
                  id: '6',
                  options: [
                    { value: 1, label: 'Sobre el uso del MIDAS', trigger: '7' },
                    { value: 2, label: 'Sobre un predio', trigger: '8' },
                    { value: 3, label: 'Otra consulta', trigger: '9' },
                    { value: 4, label: 'Volver', trigger: '1' },
                    { value: 5, label: 'Agregar una consulta', trigger: 'formulario' },
                  ],
                },

                {
                  id: '7',
                  component: (
                    <div><p>El MIDAS es una aplicación web que permite la visualización 
                      de los datos geográficos del Sistema de Información Geográfica de la 
                      0Alcaldía Mayor de Cartagena. Para más información, he encontrado este 
                       </p> <a href="https://midas.cartagena.gov.co/Content/Help/25">ENLACE</a> 
                       <p>para ti</p></div>
                  ),
                },
                {
                  id: '8',
                  options: [
                    { value: 1, label: '¿Como busco el numero de un predio?', trigger: '14' },
                    { value: 2, label: '¿Como inicio una visita a un predio?', trigger: '13' },
                    { value: 3, label: 'Volver', trigger: '1' },
                  ],
                },
                {
                  id: '9',
                  message: 'Por favor escribe tu consulta brevemente (ejemplo: visita)',
                  trigger: '10',
                },
                {
                  id: '10',
                  user: true,
                  validator: (value) => {
                    if (value.includes(valor2)||value.includes(valor1)){
                      return true;
                    }
                    else{
                      return 'No he encontrado nada, por favor agrega tu consulta en el formulario';
                    }
                  },
                  trigger: '11',
                },
                {
                  id: '11',
                  options: [
                    { value: 1, label: '¿Ayuda con Visitas?', trigger: '15' },
                    { value: 2, label: '¿Ayuda con Suspenciones?', trigger: '16' },
                    { value: 3, label: 'Volver', trigger: '1' },
                  ],
                  trigger: '10',
                },
                {
                  id: '12',
                  message: 'No he encontrado nada, repitelo por favor',
                  trigger: '10',
                },
                {
                  id: '14',
                  options: [
                    { value: 1, label: 'Debes utilizar la herramienta del MIDAS agregada en esta aplicación, busca la ubicación del predio da clic sobre el mismo y en resultados busca predios y vera la referencia del predio' },
                    { value: 2, label: 'Volver', trigger: '1' },
                    { value: 3, label: 'Gracias', trigger: 'gracias' },
                  ],

                },
                {
                  id: '13',
                  options: [
                    { value: 1, label: 'Debes solicitarle a un usuario de rol Asistencial que te cree la visita. O solicitar un usuario con este rol.' },
                    { value: 2, label: 'Volver', trigger: '1' },
                    { value: 3, label: 'Gracias', trigger: 'gracias' },
                  ],
                },
                {
                  id: '15',
                  options: [
                    { value: 1, label: 'Las visitas son asignadas por el rol asistencial a un tecnico. Una vez asignadas es deber del tecnico darle seguimiento y de ser el caso escalarlo al Juridico.'},
                    { value: 2, label: 'Volver', trigger: '1' },
                    { value: 3, label: 'Gracias', trigger: 'gracias' },
                  ],
                },
                {
                  id: '16',
                  options: [
                    { value: 1, label: 'Las suspeciones se dan en varios casos, si no le dan entrada al tecnico para ingresar al predio, si en el predio se ejecuta una obra y no cuentan con los documentos requeridos o si no se ha subsanado una sanción' },
                    { value: 2, label: 'Volver', trigger: '1' },
                    { value: 3, label: 'Gracias', trigger: 'gracias' },
                  ],
                },
                {
                  id: 'gracias',
                  message: `Feliz de ayudar`,
                  end: true,
                },
                {
                  id: 'formulario',
                  component: (
                    <div><p>Para agregar una consulta por favor ingresa y llena el siguiente forumario, estaremos trabajando en tu consulta lo mas pronto posible.
                       </p> <a href="https://forms.office.com/Pages/ResponsePage.aspx?id=FKBvWb-gek2qlgbZkLnm-xVun_unwkRFllFdYYC7V8dUNDdHTEExMTRSMjUyWTYxMkFIQk9NTFNXOC4u">ENLACE</a> </div>
                  ),
                },
              ]}     
        /></ThemeProvider>
    </DashboardLayout>
  )
}

const TutorialJuridico = () => (

  <div id="results" className="search-results">
    <div class="blog-container">
      <div class="blog-header">
        <div class="blog-cover">
          <div class="blog-author">
            <h3>Primeros pasos</h3>
          </div>
        </div>
      </div>
      <div class="blog-body">
        <div class="blog-title">
          <h1><a href="#">Tutorial Juridico</a></h1>
        </div>
        <div class="blog-summary">
          <p>Bienvenido abogado en este espacio podras conocer tus procesos activos para realizar seguimiento, realizar suspenciones o notificar a los arquitectos cambios en sus procesos activos. Para cualquier información o sugerencia comunicate al correo desarrollo4oai@cartagena.gov.co</p>
        </div>
      </div>
    </div>
  </div>
)

const TutorialArquitecto = () => (
 
  <div id="results" className="search-results">
    <div class="blog-container">
      <div class="blog-header">
        <div class="blog-cover">
          <div class="blog-author">
            <h3>Primeros pasos</h3>
          </div>
        </div>
      </div>
      <div class="blog-body">
        <div class="blog-title">
          <h1><a href="#">Tutorial Arquitecto</a></h1>
        </div>
        <div class="blog-summary">
          <p>Bienvenido arquitecto/tecnico, en este espacio podras conocer tus procesos activos o visias asignadas para realizar seguimiento, construir informes, solicitar suspenciones o notificar a los abogados cambios en sus procesos activos. Para cualquier información o sugerencia comunicate al correo desarrollo4oai@cartagena.gov.co</p>
        </div>
      </div>
    </div>
  </div>
)

const TutorialAsistencial = () => (
  
  <div id="results" className="search-results">
    <div class="blog-container">
      <div class="blog-header">
        <div class="blog-cover">
          <div class="blog-author">
            <h3>Primeros pasos</h3>
          </div>
        </div>
      </div>
      <div class="blog-body">
        <div class="blog-title">
          <h1><a href="#">Tutorial Asistencial</a></h1>
        </div>
        <div class="blog-summary">
          <p>Bienvenido asistente, en este espacio podras asignadar visitas, realizar seguimiento, descargar documentos o notificar a los abogados cambios en sus procesos activos. Para cualquier información o sugerencia comunicate al correo desarrollo4oai@cartagena.gov.co</p>
        </div>
      </div>
    </div>
  </div>
)

export default Home;
