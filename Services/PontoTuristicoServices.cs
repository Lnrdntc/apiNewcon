using System;
using System.Collections.Generic;
using TesteNewcon.Models.Entrada;
using TesteNewcon.Models.Saida;
using TesteNewcon.Repositorys;

namespace TesteNewcon.Services
{
    public class PontoTuristicoServices
    {
        private readonly PontoTuristicoRepository _pontoTuristicoRepository;

        public PontoTuristicoServices(PontoTuristicoRepository pontoTuristicoRepository)
        {
            _pontoTuristicoRepository = pontoTuristicoRepository;
        }

        public SaidaPontoTuristico CriarPontoTuristico(EntradaCadastrarPontoTuristico entrada)
        {
            var resultado = _pontoTuristicoRepository.CriarPontoTuristico(entrada);

            return resultado;
        }

        public SaidaAtualizarPontoTuristico AtualizarPontoTuristico(EntradaPontoTuristico entrada)
        {
            var resultado = _pontoTuristicoRepository.AtualizarPontoTuristico(entrada);

            return resultado;
        }

        public SaidaAtualizarPontoTuristico DeletarPontoTuristico(string id)
        {
            return _pontoTuristicoRepository.DeletarPontoTuristico(id);

        }
        public List<SaidaListaPontosTuristicos> ListarPontosTuristicos(string buscar)
        {
            return _pontoTuristicoRepository.ListarPontosTuristicos(buscar);
        }
    }
}
