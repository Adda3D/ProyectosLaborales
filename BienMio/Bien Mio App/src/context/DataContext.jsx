import React, { createContext, useContext, useEffect, useState } from "react";
import { getAllProcesses } from "../api/process";
import { getAllUsers } from "../api/users";
import { getAllVisits } from "../api/visits";
import { errorHandle } from "../Utils/ErrorHandle";
import { getUserDataLocal } from "../Utils/localStorage";
import { ROLES } from "../Utils/states";
import { AuthUserContext } from "./AuthContext";

export const DataContext = createContext();

const DataContextProvider = (props) => {
  const { user, token, doSetUser } = useContext(AuthUserContext);
  const [Loader, setLoader] = useState(true);
  const [allUsers, setAllUsers] = useState(null);
  const [allTechnicalUsers, setAllTechnicalUsers] = useState(null);
  const [allVisits, setAllVisits] = useState(null);
  const [allProcesses, setAllProcesses] = useState(null);
  const [tableName] = useState("user");
  const [callAPI, setCallAPI] = useState(false);

  const [limit] = useState(10);
  const [offset, setOffset] = useState(0);

  const [totalRecords, setTotalRecords] = useState(0);


  const fetchUserData = async (limit, offset, token) => {
    try {
      const data = await getAllUsers(token);
      setAllUsers(data);
      const techs = [];
      data.map((user) => {
      if (user.roles.includes(ROLES.TECHNIC)){
        techs.push(user)
      }
    })
    setAllTechnicalUsers(techs);
      setLoader(false);
    } catch (e) {
      errorHandle(e, "Getting Users");

      setLoader(false);
    }
  };

  const fetchVisitData = async (limit, offset, token) => {
    try {
      const data = await getAllVisits(token);
            const visitWithCadastralReference = [];
            if (allProcesses){
              data.map((visit)=>{
                visit.cadastralReference = allProcesses.find((process)=> process.visits.includes(visit._id))?.cadastralReference;
              visitWithCadastralReference.push(visit);
            });
          }else{
            const processes = await getAllProcesses(token);
            data.map((visit)=>{
              visit.cadastralReference = processes.find((process)=> process.visits.includes(visit._id))?.cadastralReference;
            visitWithCadastralReference.push(visit);
          });
              }
            setAllVisits(visitWithCadastralReference);
      setLoader(false);
    } catch (e) {
      errorHandle(e, "Getting Visits");

      setLoader(false);
    }
  };

  const fetchProcessData = async (limit, offset, token) => {
    try {
      const data = await getAllProcesses(token);
      
      setAllProcesses(data);
      setLoader(false);
    } catch (e) {
      errorHandle(e, "Getting Processes");

      setLoader(false);
    }
  };


  useEffect(() => {
    if (token){
      fetchProcessData(limit, offset, token);
      fetchUserData(limit, offset, token);
      fetchVisitData(limit, offset, token);
    }
  }, [limit, offset, token]);

  return (
    <DataContext.Provider
      value={{
        allUsers,
        allProcesses,
        allVisits,
        allTechnicalUsers,
        setAllUsers,
        setAllProcesses,
        setAllVisits,
        fetchUserData,
        fetchVisitData,
        fetchProcessData
      }}
    >
      {props.children}
    </DataContext.Provider>
  );
};

export default DataContextProvider;
