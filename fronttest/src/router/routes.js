import { Routes, Route } from "react-router-dom";
import NovoPontoTuristico from "../pages/NovoPontoTuristico";
import PaginaInicial from "../pages/PaginaInicial";

const Router = () => {
  return (
    <Routes>
      <Route path="/" element={<PaginaInicial />} />
      <Route path="/novo-ponto-turistico" element={<NovoPontoTuristico />} />
    </Routes>
  );
};

export default Router;
