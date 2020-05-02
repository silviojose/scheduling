using System;
using System.Collections.Generic;
using System.Linq;
using ViewModel;

namespace Business
{
    public static class JobService
    {
        /// <summary>
        /// Metodo que trata o retorno via Dictionary
        /// </summary>
        /// <param name="list">Listagem de Jobs</param>
        /// <param name="limit">Limite de execucao</param>
        /// <param name="dtInit">Data de Inicio da Janela de Execucao</param>
        /// <param name="dtEnd">Data de Termino da Janela de Execucao</param>
        /// <returns>Retorno do grupo</returns>
        public static Dictionary<int, List<Job>> GetJobs(List<Job> list, int limit, DateTime dtInit, DateTime dtEnd)
        {
            Dictionary<int, List<Job>> groups = new Dictionary<int, List<Job>>();
            int control = 0;

            // filtrando os jobs para contemplar a janela de execucao
            // ordenando pela data maxia de execucao
            foreach (var job in list.Where((r) => r.MaxExecutionDate >= dtInit && r.MaxExecutionDate <= dtEnd).OrderBy((r) => r.MaxExecutionDate))
            {
                // atualizando o controle de tempo do grupo para determinar se deve ser criado um novo grupo
                control = control + job.EstimatedTime;

                // criar um grupo quando:
                // 1 - nao houver nenhum grupo criado
                // 2 - controle for superior ao limite
                if (groups.Count == 0 || control > limit)
                    groups.Add(groups.Count + 1, new List<Job>());

                // adicionando o job ao grupo
                groups[groups.Count].Add(job);
            }

            // retornando o agrupamento
            return groups;
        }
    }
}
