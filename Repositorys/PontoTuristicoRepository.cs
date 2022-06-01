using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using TesteNewcon.Models.Entrada;
using TesteNewcon.Models.Saida;

namespace TesteNewcon.Repositorys
{
    public class PontoTuristicoRepository
    {
        private readonly IConfiguration _configuration;
        private object _pontoTuristicoRepository;
        public object UPDATE { get; private set; }



        public PontoTuristicoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SaidaPontoTuristico CriarPontoTuristico(EntradaPontoTuristico entrada)
        {
            SaidaPontoTuristico retorno = new SaidaPontoTuristico();

            try
            {
                using (var con = new SqlConnection(_configuration.GetSection("Conexao").Value))
                {
                    DynamicParameters _parametros = new DynamicParameters();

                    _parametros.Add("@Nome", entrada.Nome);
                    _parametros.Add("@Local", entrada.Local);
                    _parametros.Add("@Descricao", entrada.Descricao);

                    con.Open();

                    //Inserindo o Ponto Turistico
                    var sql = @"INSERT INTO PontoTuristico (Nome, 
                                                            Local, 
                                                            Descricao) 
                                VALUES (@Nome, 
                                        @Local, 
                                        @Descricao)";

                    con.Execute(sql: sql,
                                param: _parametros,
                                commandType: CommandType.Text);

                    //Obtendo o id do ponto turistico cadastrado
                    var consulta = @"SELECT idPontoTuristico
                                     FROM PontoTuristico
                                     WHERE Nome      = @Nome
                                       AND Local     = @Local
                                       AND Descricao = @Descricao";

                    var idPontoTuristico = con.QueryFirstOrDefault<int>(sql: consulta,
                                                                        param: _parametros,
                                                                        commandType: CommandType.Text);

                    retorno.Mensagem = "Ponto Turistico " + entrada.Nome + " adicionado com sucesso!";
                    retorno.IdPontoTuristico = idPontoTuristico;

                    return retorno;
                }
            }
            catch
            {

                retorno.Mensagem = "Erro ao tentar criar um Ponto Turistico";
                retorno.IdPontoTuristico = 0;

                return retorno;
            }

            return retorno;
        }


        public SaidaAtualizarPontoTuristico AtualizarPontoTuristico(EntradaPontoTuristico entrada)
        {
            SaidaAtualizarPontoTuristico retorno = new SaidaAtualizarPontoTuristico();
            try
            {

                using (var con = new SqlConnection(_configuration.GetSection("Conexao").Value))
                {


                    DynamicParameters _parametros = new DynamicParameters();

                    _parametros.Add("@id", entrada.Id);
                    _parametros.Add("@Nome", entrada.Nome);
                    _parametros.Add("@Local", entrada.Local);
                    _parametros.Add("@Descricao", entrada.Descricao);

                    con.Open();
                    var sql = @"UPDATE PontoTuristico
                                    SET  Nome =    @Nome, 
                                           Local = @Local,
                                    Descricao = @Descricao
                                                   
                                    WHERE idPontoTuristico = @id";

                    con.Execute(sql, new { id = entrada.Id, Nome = entrada.Nome, Local = entrada.Local, Descricao = entrada.Descricao });
                              

                    
                                    retorno.Mensagem = "Ponto Turistico " + entrada.Nome + " alterado com sucesso!";

                    return retorno;
                }

            }
            catch
            {

                retorno.Mensagem = "Erro ao tentar atualizar um Ponto Turistico";
                retorno.IdPontoTuristico = 0;

                return retorno;
            }

            return retorno;
        }

        public SaidaAtualizarPontoTuristico deletar (string Id)
        {
            string sql = "DELETE FROM PontoTuristico WHERE idPontoTuristico = @id";
            using (var con = new SqlConnection(_configuration.GetSection("Conexao").Value))
            {
                var affectedRows = con.Execute(sql, new { id = Id });
                Console.WriteLine(affectedRows);

                SaidaAtualizarPontoTuristico retorno = new SaidaAtualizarPontoTuristico();
                retorno.Mensagem = "Ponto turistico apagado com sucesso";
                return retorno;
            }
        }
    }
}


