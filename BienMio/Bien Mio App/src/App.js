import "./App.css";
import "react-notifications/lib/notifications.css";
import AuthUserContextProvider from "./context/AuthContext";
import React, { useEffect } from "react";
import AppRouter from "./routes/Routes";
import { NotificationContainer } from "react-notifications";
import DataContextProvider from "./context/DataContext";


function App() {
  useEffect(() => {}, []);

 return (
    <div className="App">
      <AuthUserContextProvider>
        <DataContextProvider>
          <AppRouter />
        </DataContextProvider>
      </AuthUserContextProvider>
      <NotificationContainer />
    </div>    
  );
}

export default App;
