using Microsoft.AspNetCore.Mvc;
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

        public SaidaPontoTuristico CriarPontoTuristico(EntradaPontoTuristico entrada)
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

            return (SaidaAtualizarPontoTuristico)retorno;
        }

        //deletar ponto turistico
        [HttpDelete]
        [Route("Deletar-Ponto-Turistico")]

        public SaidaAtualizarPontoTuristico DeletarPontoTuristico(string id)
        {
            return _pontoTuristicoServices.DeletarPontoTuristico(id);
        }

    }
}
