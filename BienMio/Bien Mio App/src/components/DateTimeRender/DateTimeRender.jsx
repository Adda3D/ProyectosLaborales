import React from "react";
import { format, parse, parseISO } from "date-fns";
import { es } from "date-fns/locale";
//import {} from "date-fns/esm/locale/e"
import { zonedTimeToUtc, formatInTimeZone } from 'date-fns-tz'


const DateTimeRender = (props) => {
    if (props.value){
      const date = formatInTimeZone(new Date(props.value), 'UTC', "dd 'de' MMMM yyyy 'a las' hh:mm aaa", { locale: es }) 
      return (
    <span>{date}</span>
    );
    }
    return null;
}
export default DateTimeRender;