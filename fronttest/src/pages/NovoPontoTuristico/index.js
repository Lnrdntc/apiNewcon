import React, { useCallback, useEffect, useState } from "react";
import Button from "../../components/Button";
import api from "../../services/api";
import "../../App.css";
import { useNavigate } from "react-router-dom";

const [localCriado, setLocalCriado]=useState({
  id:'',
  nome:'',
  local:'',
  descricao:''
})
const handleChange = e =>{
  const {name,value} = e.target;
  setLocalCriado({
    ...localCriado,[name]:value
  });
  console.log(localCriado);
}



const NovoPontoTuristico = () => {
  return <div

    style={{
          display: "flex",
          alignItems: "center",
          justifyContent: "center",
          flexDirection: "column",}}>

    <h1>Cadastrar Ponto Turistico</h1>
      <div className="form-group">
      <label>Nome:</label>
      <br/>
      <input type="text" className="form-control" name="nome" onChange={handleChange}/>
      <br/>
      <label>Local:</label>
      <br/>
      <input type="text" className="form-control"name="nome" onChange={handleChange}/>
      <br/>
      <label>Descrição</label>
      <br/>
      <input type="text" className="form-control"name="nome" onChange={handleChange}/>
      <br/>
      </div>

    </div>;



};


export default NovoPontoTuristico;
