import React from "react";
import { PROCESS_STATES, VISIT_STATES } from "../../Utils/states";
import { Chip } from "@mui/material";

const ProcessStatusRender = (props) => {
    let color= "";
    if (props.value){
      
      if ( (PROCESS_STATES.VISIT_VALIDATION) || (props.value ===PROCESS_STATES.IN_VISIT) || (props.value === PROCESS_STATES.LEGAL_REVIEW) || (props.value === PROCESS_STATES.SANCTION_PROCESS)){
        color="success"
      }
      if ((props.value === PROCESS_STATES.PREVENTIVE_SUSPENSION) ){
        color="warning"
      }
      if (props.value ===PROCESS_STATES.ARCHIVED || props.value ===""){
        color="info"
      }
      return (
        <Chip label={props.value} color={color} />
    );
    }
    return null;
}
export default ProcessStatusRender;