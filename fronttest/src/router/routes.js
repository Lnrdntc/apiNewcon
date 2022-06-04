import { Routes, Route } from "react-router-dom";
import NovoPontoTuristico from "../pages/NovoPontoTuristico";
import PaginaInicial from "../pages/PaginaInicial";
import Busca from "../pages/Busca/busca"

// importar o busca para usar na função 

const Router = () => {
  return (

    // todas as paginas que eu for fazer vai ter que abrir uma rota com o caminho da pag (path vai receber o caminho do navegador)

    <Routes>
      <Route path="/" element={<PaginaInicial />} />
      <Route path="/novo-ponto-turistico" element={<NovoPontoTuristico />} />
      <Route path="/busca" element={<Busca />} />
    </Routes>
  );
};

export default Router;

