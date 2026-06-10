import React, { Component} from "react";
import logo from "../img/logo_password.svg";
import '../css/main.scss';
import { BrowserRouter } from "react-router-dom";

class login extends Component{
    handleClick = () => {
        BrowserRouter.push('/register.js');
    };

    render(){
        return (
            <div className="logo-container">
                <div className="logo-space">
                    <img src={logo} alt=""/>
                </div>

                <div className="passwordold-box">
                    <h3> Parece que olvidaste</h3>
                    <h3> tu contraseña </h3>
                    <p> Ingresa tu número de identificación o correo <br></br> electronico 
                        para recuperar tu contraseña
                    </p>
                    <form>
                        <input type="text" placeholder="Identificación o e-mail"/>
                        <input type="submit" onClick={this.handleClick} value="Enviar" /><br></br>
                        <a href="/"> Ingresar al sistema </a>
                    </form>
                </div>
            </div>
        );
    }
}
// 
export default login;