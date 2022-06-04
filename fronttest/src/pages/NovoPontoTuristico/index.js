import React, { useCallback, useEffect, useState } from "react";
import Button from "../../components/Button";
import api from "../../services/api";
import "./styles.js";
import { useNavigate } from "react-router-dom";
import App from "../../App";
// ***** lembrar de colocar o axios para consumir a api
import axios from "axios";

document.body.style.backgroundColor = "black";

//  botão para voltar para a tela inicial



// Deletar os pontos turisticos

const deletarPontoTuristico = async (idPontoTuristico) => {
  // puxando os dados atravez do axios
axios.delete('https://localhost:44384/deletar-ponto-turistico?id='+idPontoTuristico, {
}).then(response => {
    console.log(response.data);
    window.location.reload();
}).catch(function (error) {
    console.log(error)
    alert("erro!")
}).finally(function () {
    
});
};



// Cadastrar novo ponto

const NovoPontoTuristico = () => {
  const navigate = useNavigate();

  const voltar = useCallback(() => {
    navigate("/");
  }, [navigate]);

  const [data, setData] = useState([]);

  const handleClick = useCallback(() => {

// Obtendo os valores das variaveis de entrada

    let body = {
      nome: document.querySelector('#Nome').value,
      local: document.querySelector('#Local').value,
      descricao: document.querySelector('#Descricao').value
    };
  
    axios.post('https://localhost:44384/cadastrar-ponto-turistico', body, {
      
    })
      .catch(function (error) {
       console.log(error)
       alert("Erro!")
      })
      .finally(function () {
         window.location.reload();
        // atualizar a pagina
      });
    
  });

// Listar os pontos

  useEffect(() => {
    async function fetch() {
      const response = await api.get("/listar-pontos-turisticos");
      setData(response.data);
      console.log(response.data);
    }

    fetch();
  }, []);
  
  return <div

    style={{
          display: "flex",
          alignItems: "center",
          justifyContent: "center",
          flexDirection: "column",
          }}>

    <h1>Cadastrar Ponto Turistico</h1>
      <div  className="form-group"  >
      <label>Nome:</label>
      <br/>
      <input type="text" className="form-control" id="Nome" />
      <br/>
      <label>Local:</label>
      <br/>
      <input type="text" className="form-control" id="Local"/>
      <br/>
      <label >Descrição</label>
      <br/>
      <input type="text" className="form-control" id="Descricao"/>
      <br/>
      <Button
          text="Cadastrar Ponto Turistico"
          size="cadastrar"
          onClick={handleClick}
        />
      </div>

<br/>

      <div>


{/* fazendo o input de busca */}

        
<h1>Faça a sua busca aqui:</h1>

<form>
<label>
<input type="text" name="name"placeholder="Insira o que procura aqui!" />

</label>
<input type="submit" value="Pesquisar" />
</form>

</div>

      <br/>

      <table width="467" border="1px" className="table table-bordered">
          <thead>
            <tr>
              <th width="50" height="20">Nome</th>
              <th width="101" height="40">Local</th>
              <th width="101" height="40">Descrição</th>
              <th width="101" height="40">Ações</th>
            </tr>
          </thead>

      <tbody>
            {data.map((pontoTuristico) => (
              <tr>
                <th>{pontoTuristico.nome}</th>
                <th>{pontoTuristico.local}</th>
                <th>{pontoTuristico.descricao}</th>
                <div>
                  <Button text="Editar" size="editar" /> 
                  <Button text="Deletar" size="deletar" onClick={() =>deletarPontoTuristico(pontoTuristico.idPontoTuristico)}>Apagar</Button> 
                </div>
              </tr>
            ))}
          </tbody>
          </table>

          <Button
          text="Voltar"
          size="cadastrar"
          onClick={voltar}
        />

    </div>;



};


export default NovoPontoTuristico;