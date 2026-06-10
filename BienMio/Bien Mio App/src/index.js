import React from 'react'
import { createRoot } from 'react-dom/client';
import App from './App';
import * as serviceWorkerRegistration from './serviceWorker';
import { subscribeUser } from './subscription';



const container = document.getElementById('root'); 
const root = createRoot(container);
root.render(<App />);



// serviceWorkerRegistration.register();

// subscribeUser();
// ReactDOM.render(
//   ,
//   document.getElementById('root')
// );