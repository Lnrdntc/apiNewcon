import React, { useState, useEffect } from "react";
import Button from "../../components/Button";
import axios from "axios";



const App = () => {
  const [busca, setBusca] = useState([]); //declarei use state para mudar o estado na pagina dinamicamente

  const fetchData = async () => {
    const stringBusca = document.querySelector("#stringBusca").value;

    const result = await axios.get(
      "https://localhost:44384/listar-pontos-turisticos?buscar=" + stringBusca
    );
    const data = result.data.map((item, index) => {
      console.log(index);
      console.log(item);
      return {
        nome: item.nome,
        local: item.local,
        descricao: item.descricao,
      };
    });

    setBusca(data); //passa o resultado da busca para ultilizarmos a variavel com os dados no html
  };

  useEffect(() => { //chama fetch data ao carregar a pagina para buscar os dados do banco usando axios (fetch data funciona para realizar uma busca) 
    fetchData();
  }, []);

  return (
    <div>
      <h1>Tela de Pesquisa</h1>
      <input type="text" className="form-control" id="stringBusca" />

      <Button
        text="Buscar Ponto Turistico"
        size="cadastrar"
        onClick={fetchData}
      />
      <table width="467" border="1px" className="table table-bordered">
        <thead>
          <tr>
            <th width="50" height="20">
              Nome
            </th>
            <th width="101" height="40">
              Local
            </th>
            <th width="101" height="40">
              Descrição
            </th>
          </tr>
        </thead>
        <tbody>
          {busca.map((pontoTuristico) => (
            <tr>
              <th>{pontoTuristico.nome}</th>
              <th>{pontoTuristico.local}</th>
              <th>{pontoTuristico.descricao}</th>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default App;
