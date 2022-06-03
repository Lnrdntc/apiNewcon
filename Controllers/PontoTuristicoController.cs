using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TesteNewcon.Models.Entrada;
using TesteNewcon.Models.Saida;
using TesteNewcon.Services;

namespace TesteNewcon.Controllers
{
    public class PontoTuristicoController : ControllerBase
    {
        private readonly PontoTuristicoServices _pontoTuristicoServices;

        public PontoTuristicoController(PontoTuristicoServices pontoTuristicoServices)
        {
            _pontoTuristicoServices = pontoTuristicoServices;
        }

        ///<sumary>
        /// Cadastrar um novo ponto turistico
        ///</sumary>
        [HttpPost]
        [Route("cadastrar-ponto-turistico")]

        public SaidaPontoTuristico CriarPontoTuristico([FromBody] EntradaCadastrarPontoTuristico entrada)
        {
            var retorno = _pontoTuristicoServices.CriarPontoTuristico(entrada);

            return retorno;
        }

        ///<sumary>
        /// Atualizar ponto turistico
        ///</sumary>
        [HttpPut]
        [Route("atualizar-ponto-turistico")]

        public SaidaAtualizarPontoTuristico AtualizarPontoTuristico(EntradaPontoTuristico entrada)
        {
            var retorno = _pontoTuristicoServices.AtualizarPontoTuristico(entrada);

            return retorno;
        }

        ///<sumary>
        //Deletar ponto turistico
        ///</sumary>
        [HttpDelete]
        [Route("deletar-ponto-turistico")]

        public SaidaAtualizarPontoTuristico DeletarPontoTuristico(string id)
        {
            return _pontoTuristicoServices.DeletarPontoTuristico(id);
        }

        ///<sumary>
        //Listar pontos turisticos
        ///</sumary>
        [HttpGet]
        [Route("listar-pontos-turisticos")]

        public List<SaidaListaPontosTuristicos> ListarPontosTuristicos(string buscar)
        {
            return _pontoTuristicoServices.ListarPontosTuristicos(buscar);
        }
    }
}
