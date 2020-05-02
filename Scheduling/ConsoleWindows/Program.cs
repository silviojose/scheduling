using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModel;

namespace ConsoleWindows
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Job> list = new List<Job>();
            list.Add(new Job() { ID = 1, Description = "Importação de arquivos de fundos", MaxExecutionDate = DateTime.Parse("2019-11-10 12:00:00"), EstimatedTime = 2 });
            list.Add(new Job() { ID = 2, Description = "Importação de dados da Base Legada", MaxExecutionDate = DateTime.Parse("2019-11-11 12:00:00"), EstimatedTime = 4 });
            list.Add(new Job() { ID = 3, Description = "Importação de dados de integração", MaxExecutionDate = DateTime.Parse("2019-11-11 08:00:00"), EstimatedTime = 6 });

            DateTime dtInit = DateTime.Parse("2019-11-10 09:00:00");
            DateTime dtEnd = DateTime.Parse("2019-11-11 12:00:00");
            int limit = 8;

            #region obtendo os jobs classificados
            var groups = JobService.GetJobs(list, limit, dtInit, dtEnd);
            foreach (var group in groups)
            {
                Console.WriteLine($"Group: {group.Key}");
                foreach (var job in group.Value)
                    Console.WriteLine($"ID: {job.ID} - Description: {job.Description}");
            }
            #endregion
        }
    }
}
