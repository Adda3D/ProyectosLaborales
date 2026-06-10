import React, { createContext, useEffect, useState } from "react";
import { getUserDataLocal } from "../Utils/localStorage";


export const AuthUserContext = createContext();

const AuthUserContextProvider = (props) => {
  const [user, setUser] = useState({ ...getUserDataLocal() });//
  const [Loader, setLoader] = React.useState(true);
  useEffect(() => {
    console.log("user: ", user);
    setLoader(false);
  }, [user]);

  const doSetUser = (user) => {
    setUser(user);
  };

  return (
    <AuthUserContext.Provider
      value={{
        user: user ? user.user : null,
        token: user ? user.token: null,
        doSetUser: doSetUser,
        Loader,
      }}
    >
      {props.children}
    </AuthUserContext.Provider>
  );
};

export default AuthUserContextProvider;
