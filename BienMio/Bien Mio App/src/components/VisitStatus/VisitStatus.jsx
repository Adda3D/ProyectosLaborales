import React from "react";
import { VISIT_STATES } from "../../Utils/states";
import { Chip } from "@mui/material";

const VisitStatusRender = (props) => {
    let color= "";
    if (props.value){
      if ((props.value.toLowerCase() === (VISIT_STATES.REQUESTED).toLowerCase())){
        color="error"
      }
      if ((props.value.toLowerCase() === (VISIT_STATES.ASSIGNED).toLowerCase()) || (props.value === VISIT_STATES.ENTRY)){
        color="warning"
      }
      if ((props.value ===VISIT_STATES.IN_PROCESS) || (props.value ===VISIT_STATES.REPROGRAMED)||(props.value ===VISIT_STATES.VALIDATION)||(props.value ===VISIT_STATES.REPORT)){//
        color="success"
      }
      if (props.value ===VISIT_STATES.FINISHED){
        color="info"
      }
      return (
        <Chip label={props.value} color={color} />
    );
    }
    return null;
}
export default VisitStatusRender;