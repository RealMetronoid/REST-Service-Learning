using JobREST.Models;
using System.Collections.ObjectModel;

namespace JobRepositoryTests
{
    public class JobRepositoryTest
    {
        private IJobRepository repo;

        [Fact]
        public void AddJobAssigns()
        {
            IJobRepository repo = new JobRepositoryList(includeData: false);

            Job newJob = new Job { Name = "Gunbreaker", Role = "Tank", Level = 60 };
            Job added = repo.AddJob(newJob);

            int firstId = added.Id;
            Assert.Equal(1, firstId);
            Assert.Equal("Gunbreaker",added.Name);
            Assert.Equal("Tank", added.Role);
            Assert.Equal(60, added.Level);
        }


    }
}
