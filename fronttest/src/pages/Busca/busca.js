import React, {useState} from 'react';
import './styles.css';

const busca =[
    idPontoTuristico
   
];

export default function App()  {

    const [busca, setBusca] = useState('');

    const idFiltradas = id.filter((procurar)=>procurar.startsWith(busca));

    return (
        <div className = "App">
            <h1>Tela de Pesquisa</h1>
            <input 
            type="text" 
            value={busca}
            onChange={(ev) => setBusca(ev.target.value)}
            />
            <ul>
                {procurarFiltradas.map((procurar) =>(
                    <li key={procurar}>{procurar}</li>
                    ))}
                <ul/>
        </div>
    );
}
