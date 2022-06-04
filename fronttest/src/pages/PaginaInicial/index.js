import React, { useCallback, useEffect, useState } from "react";
import logoCadastro from "../../assets/imagem.jpg";
import Button from "../../components/Button";
import "../../App.css";
import { useNavigate } from "react-router-dom";

document.body.style.backgroundColor = "white";


// começar a fazer o botão para navegar para a pagina de cadastro ***pag 2 do teste

const PaginaInicial = () => {

  
  
    const navigate = useNavigate();
  
// const hadleclick é a variavel com uma funcao dentro dela que ao clicar ela redireciona a pagina (pag busca)

    const leo = useCallback(() => {
      navigate("/busca");
    }, [navigate]);
  
// vai para a pagina de cadastro

  const handleClick = useCallback(() => {
    navigate("/novo-ponto-turistico");
  }, [navigate]);


  return (
    <div
      style={{
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        flexDirection: "column",
      }}
    >
      
      <div style={{
        display: "flex",
        alignItems: "center",
        justifyContent: "space-evenly",
        flexDirection: "row",
      }}>
      <img src={logoCadastro} alt="Cadastro" width="20%" />
      </div>
      
      <div
        style={{
          display: "flex",
          alignItems: "center",
          justifyContent: "center",
          flexDirection: "column",
        }}
        >
        <h1> Pontos Turisticos Brasil </h1>

        <br />
        <Button
          text="Cadastrar Ponto Turistico"
          size="cadastrar"
          onClick={handleClick}
        />

        <Button
        text="Tela de busca"
        size="cadastrar"
        onClick={leo}/>

      
      </div>
    </div>
  );
};

export default PaginaInicial;



