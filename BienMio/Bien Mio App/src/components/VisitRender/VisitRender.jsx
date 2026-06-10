import React, { useState, useEffect, useContext } from "react";
import { getDocument } from "../../api/documents";
import { AuthUserContext } from "../../context/AuthContext";
import { config } from "../../settings";
import { VISIT_STATES } from "../../Utils/states";
import { VISIT_TRANSLATES } from "../../Utils/Translations";
import MapsContainer from "../Maps/MapsContainer";
import _ from "lodash";
import DateTimeRender from "../DateTimeRender/DateTimeRender";
import Backdrop from '@mui/material/Backdrop';
import CircularProgress from '@mui/material/CircularProgress';

const VisitRender = (props) => {
  const visit = props.visit;
  const users = useState(props.users);
  const { token } = useContext(AuthUserContext);
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    setLoading(true)
    if (!data) {
      const visitComplete = prepareVisitToRender(visit, token);
      setData(visitComplete);
      
    }
    setLoading(false)
  }, [data, setData, visit, token]);

  if (data && token) {
    if (
      data.status === VISIT_STATES.REQUESTED
    ) {
      return <MapsContainer style={{ width: "50%" }} />;
    } else {
      let render = {};
      switch (data.status) {
        case VISIT_STATES.ASSIGNED:
          render = _.pick(data, [
            "technicalId",
            "cadastralReference",
            "assignedDate",
            "requestDate",
            "causalType",
            "type",
            "numAuto",
            "buildingType",
            "interventionLevel",
            "comments"
          ]);
          break;
        case VISIT_STATES.VALIDATION:
          render = _.pick(data, [
            "technicalId",
            "cadastralReference",
            "assignedDate",
            "requestDate",
            "causalType",
            "type",
            "numAuto",
            "buildingType",
            "interventionLevel",
            "entryDate",
            "comments"
          ]);
          break;
        case VISIT_STATES.ENTRY:
          render = _.pick(data, [
            "technicalId",
            "cadastralReference",
            "assignedDate",
            "requestDate",
            "causalType",
            "type",
            "numAuto",
            "buildingType",
            "interventionLevel",
            "comments"
          ]);
          break;
        case VISIT_STATES.REPORT:
          render = _.pick(data, [
            "technicalId",
            "cadastralReference",
            "assignedDate",
            "requestDate",
            "causalType",
            "type",
            "numAuto",
            "buildingType",
            "interventionLevel",
            "entryDate",
            "authDocs",
            "comments"
          ]);
          break;
        case VISIT_STATES.FINISHED:
          render = _.pick(data, [
            "technicalId",
            "cadastralReference",
            "assignedDate",
            "requestDate",
            "causalType",
            "type",
            "numAuto",
            "buildingType",
            "interventionLevel",
            "entryDate",
            "authDocs",
            "report",
            "comments"
          ]);
          break;
      }
      return ( <>
        {!loading ? (<div>
            {visit && ObjectAsListRender(render, VISIT_TRANSLATES, users)}
          </div>): (<Backdrop
        sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
        open={loading}
      >
        <CircularProgress color="inherit" />
      </Backdrop>)}
      </>
        
      );
    }
  }
  return null;
};

const RenderOtherProperties = (title, prop, users) => {
  if (
    prop?.toString().includes("report") ||
    prop?.toString().includes("licenses")
  ) {
    return (
      <img
        src={prop}
        height={200}
        width={200}
        alt={
          prop?.includes("report")
            ? "Evidencia fotografica perteneciente al Informe"
            : "Documento de autorización"
        }
      />
    );
  }
  // if(title==="technicalId"){
  //   if(users){
  //     const technical = users[0].find((user) => prop===user._id);
  //     return technical ? `${technical.firstName} ${technical.surname}` : prop;
  //   }
  // }
  if(title.includes("Date")){
    return <DateTimeRender value={prop} />;
  }
  // if(title.includes("0")){
  //   return <DateTimeRender value={prop} />;
  // }
  return prop;
};

const ObjectAsListRender = (object, objectTranslates, users) => {
  return (
    <ul>
      {Object.entries(object).map((objectProperty, index) => {
        if(objectProperty[0]!=="comments"){
           return (
          <li key={index}>
            <b>{`${translateTitles(objectProperty[0], objectTranslates)}: `}</b>
            {typeof objectProperty[1] === "object"
              ? ObjectAsListRender(objectProperty[1], objectTranslates, users)
              : RenderOtherProperties(objectProperty[0], objectProperty[1], users)}
          </li>
        );
        }
        if(objectProperty[0]==="comments"){
          return (
         <li key={index}>
           <b>{`${translateTitles(objectProperty[0], objectTranslates)}: `}</b>
           {typeof objectProperty[1] === "object"
             ? CommentsAsListRender(objectProperty[1], objectTranslates, users)
             : RenderOtherProperties(objectProperty[0], objectProperty[1], users)}
         </li>
       );
       }
      })}
    </ul>
  );
};

export const CommentsAsListRender = (object, objectTranslates, users) => {
  return (
    <ul>
      {Object.entries(object).map((objectProperty, index) => {
        if(objectProperty[0]==="0"){
          const estateInfo=_.pick(objectProperty[1],["BARRIO.valor", "DIRECCION.valor", "PERIMETRO.valor", "USO.valor", "RIESGO PRI.valor", "TRATAMIENTO.valor", "CLASIF SUELO.valor", "AREA TERRENO.valor", "AREA CONSTRUIDA.valor"])
          return (
            <li key={index}>
              <b>{`${translateTitles("Informacion del Predio", objectTranslates)}: `}</b>
              {typeof objectProperty[1] === "object"
                ? CommentsAsListRender(estateInfo, objectTranslates, users)//
                : RenderOtherProperties(objectProperty[0], objectProperty[1], users)}
            </li>
          );
        }else{
          return (
          <li key={index}>
            <b>{`${translateTitles(objectProperty[0], objectTranslates)}: `}</b>
            {typeof objectProperty[1] === "object"
              ? CommentsAsListRender(objectProperty[1], objectTranslates, users)
              : RenderOtherProperties(objectProperty[0], objectProperty[1], users)}
          </li>
        );
        }
           
      })}
    </ul>
  );
};

const translateTitles = (propertyTitle, translations) => {
  if (translations[propertyTitle]) {
    return translations[propertyTitle];
  } else {
    return propertyTitle;
  }
};

const prepareVisitToRender = (visit, token) => {
  const fullVisit = visit;
  
  if (typeof fullVisit.authDocs[0] === "string") {
    const authDocs = [];
    fullVisit.authDocs.map(async (id) => {
      const doc = await getDocument(token, id);
      if (doc.status !== 404){
        const document = {};
      document[`${doc.title.replace(` - ${fullVisit.cadastralReference}`, "")}`] = `${config.baseAPIUrl}/${doc.file_url}`
        authDocs.push(document)
      }
    });
    fullVisit.authDocs = authDocs;
  }

  if (fullVisit.report) {
    const evidence = [];
    fullVisit.report.evidence.map((item) => {
      if (!item.includes(config.baseAPIUrl)) {
        evidence.push(`${config.baseAPIUrl}/${item}`);
      }
    });
    // if(evidence[0]?.length!==0){
      fullVisit.report.evidence = evidence;
    // }
  }

  return fullVisit;
};
export default VisitRender;
