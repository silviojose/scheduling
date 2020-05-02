using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModel;
using Xunit;

namespace Tests
{
    public class Facts
    {
        private List<Job> list = new List<Job>();
        public Facts()
        {
            list.Add(new Job() { ID = 1, Description = "Importação de arquivos de fundos", MaxExecutionDate = DateTime.Parse("2019-11-10 12:00:00"), EstimatedTime = 2 });
            list.Add(new Job() { ID = 2, Description = "Importação de dados da Base Legada", MaxExecutionDate = DateTime.Parse("2019-11-11 12:00:00"), EstimatedTime = 4 });
            list.Add(new Job() { ID = 3, Description = "Importação de dados de integração", MaxExecutionDate = DateTime.Parse("2019-11-11 08:00:00"), EstimatedTime = 6 });
        }

        [Fact]
        public void Should_Return_All_Jobs()
        {
            var result = JobService.GetJobs(list, 8, DateTime.Parse("2019-11-10 09:00:00"), DateTime.Parse("2019-11-11 12:00:00"));
            var total = result.SelectMany((r) => r.Value.Select((x) => x.ID)).Count();
            Assert.Equal(3, total);
        }

        [Fact]
        public void Should_Return_Two_Jobs()
        {
            var result = JobService.GetJobs(list, 8, DateTime.Parse("2019-11-10 09:00:00"), DateTime.Parse("2019-11-11 08:00:00"));
            var total = result.SelectMany((r) => r.Value.Select((x) => x.ID)).Count();
            Assert.Equal(2, total);
        }

        [Fact]
        public void Should_Not_Return_Three_Groups()
        {
            var result = JobService.GetJobs(list, 8, DateTime.Parse("2019-11-10 09:00:00"), DateTime.Parse("2019-11-11 12:00:00"));
            Assert.False(result.Count.Equals(3));
        }
    }
}
