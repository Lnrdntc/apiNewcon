using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TesteNewcon.Models.Entrada;
using TesteNewcon.Models.Saida;

namespace TesteNewcon.Repositorys
{
    public class PontoTuristicoRepository
    {
        private readonly IConfiguration _configuration;

        public PontoTuristicoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SaidaPontoTuristico CriarPontoTuristico(EntradaCadastrarPontoTuristico entrada)
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
                                SET  Nome      = @Nome, 
                                     Local     = @Local,
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
        }

        public SaidaAtualizarPontoTuristico DeletarPontoTuristico(string Id)
        {
            string sql = @"DELETE FROM PontoTuristico
                           WHERE idPontoTuristico = @id";

            using (var con = new SqlConnection(_configuration.GetSection("Conexao").Value))
            {
                con.Execute(sql, new { id = Id });

                SaidaAtualizarPontoTuristico retorno = new SaidaAtualizarPontoTuristico();
                retorno.Mensagem = "Ponto turistico apagado com sucesso";
                return retorno;
            }
        }

        public List<SaidaListaPontosTuristicos> ListarPontosTuristicos(string buscar)
        {
            List<SaidaListaPontosTuristicos> retorno = new List<SaidaListaPontosTuristicos>();

            try
            {
                using (var con = new SqlConnection(_configuration.GetSection("Conexao").Value))
                {
                    DynamicParameters _parametros = new DynamicParameters();

                    var concat = '%' + buscar + '%';

                    _parametros.Add("@busca", concat);

                    con.Open();

                    var sql = "";

                    if (buscar == null || buscar == "")
                    {
                        sql = @"SELECT * 
                                FROM PontoTuristico";

                    }
                    else
                    {
                        sql = @"SELECT * 
                                FROM PontoTuristico
                                WHERE PontoTuristico.Nome      like @busca
                                   OR PontoTuristico.Local     like @busca
                                   OR PontoTuristico.Descricao like @busca";
                    }

                        var listaPontovenda = con.Query<SaidaListaPontosTuristicos>(sql: sql,
                                                                                    param: _parametros,
                                                                                    commandType: CommandType.Text);

                    listaPontovenda.ToList();

                    foreach (var _listaPontovenda in listaPontovenda)
                    {
                        retorno.Add(new SaidaListaPontosTuristicos()
                        {
                            idPontoTuristico = _listaPontovenda.idPontoTuristico,
                            Nome             = _listaPontovenda.Nome,
                            Local            = _listaPontovenda.Local,
                            Descricao        = _listaPontovenda.Descricao

                    });

                    }                 

                    return retorno;
                }

            }
            catch
            {
                return retorno;
            }
        }
    }
}


