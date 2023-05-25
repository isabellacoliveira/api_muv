using System.Data;
using System.Diagnostics;
using Dapper;

namespace Queries.Base
{
    public static class Query
    {

        public static IEnumerable<T> PesquisarSlapper<T, TL>(this IDbConnection connect, Dictionary<string, object> query, ILogger<TL> logger) where TL : class
        {
            IEnumerable<T> resultado = null;
            try
            {
                foreach (KeyValuePair<string, object> t in query)
                {
                    var stopWatch = new Stopwatch();

                    stopWatch.Start();

                    logger.LogInformation("Abrindo Conexão com Banco", connect);

                    connect.Open();

                    stopWatch.Stop();

                    logger.LogInformation($"Conexão aberta em {stopWatch.ElapsedMilliseconds}(ms)", connect);

                    stopWatch.Restart();

                    logger.LogInformation($"Iniciando consulta", query);

                    IEnumerable<dynamic> dados = connect.Query<dynamic>(t.Key, t.Value);

                    stopWatch.Stop();

                    logger.LogInformation($"Consulta realizada em {stopWatch.ElapsedMilliseconds}(ms)", query);

                    resultado = Slapper.AutoMapper.MapDynamic<T>(dados);

                    Slapper.AutoMapper.Cache.ClearAllCaches();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }
    }
}
