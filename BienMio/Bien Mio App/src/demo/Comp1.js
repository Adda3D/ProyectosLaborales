import React, { Component } from "react";  
class Comp1 extends Component {  
  constructor() {  
    super();  
    this.state = {  
      name: "ReactJS" 
    };  
  }  
   
  render() {  
    return <div>This is component1</div>;  
  }  
}  
   
export default Comp1;  