namespace JobREST.Models
{
    public class JobRepositoryList : IJobRepository
    {
        private readonly List<Job> jobs = new();
        private int nextId = 1;

        public JobRepositoryList(bool includeData = false)
        {
            if (includeData)
            {
                AddJob(new Job { Name = "Warrior", Role = "Tank", Level = 100 });
                AddJob(new Job { Name = "Dancer", Role = "Ranged", Level = 70 });
                AddJob(new Job { Name = "Dark Knight", Role = "Tank", Level = 30 });
                AddJob(new Job { Name = "Scholar", Role = "Healer", Level = 30 });
                AddJob(new Job { Name = "Red Mage", Role = "Caster", Level = 50 });
            }
        }

        public Job AddJob(Job job)
        {
            if (job is null)
            {
                throw new ArgumentNullException(nameof(job));
            }

            job.Id = nextId++;
            jobs.Add(job);
            return job;
        }

        public IEnumerable<Job> GetAllJobs(int? minimumLevel, int? maximumLevel, string? nameFilter)
        {
            if (minimumLevel > maximumLevel &&
                minimumLevel != null && maximumLevel != null)
            {
                throw new ArgumentException("Minimum weight " +
                    "cannot be greater than maximum weight.");
            }

            IEnumerable<Job> result = jobs.AsReadOnly();

            if (minimumLevel != null)
            {
                result = result.Where(j => j.Level >= minimumLevel);
            }
            if (maximumLevel != null)
            {
                result = result.Where(j => j.Level <= maximumLevel);
            }
            if (nameFilter != null)
            {
                result = result.Where(j => j.Name.
                Contains(nameFilter, StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }

        public Job? GetJobById(int id)
        {
            return jobs.FirstOrDefault(j => j.Id == id);
        }

        public Job? RemoveJob(int id)
        {
            var job = GetJobById(id);
            if (job != null)
            {
                jobs.Remove(job);
                return job;
            }

            return null;
        }

        public Job? UpdateJob (int id, Job updatedJob)
        {
            var existingJob = GetJobById(id);

            if (existingJob != null) {
                existingJob.Name = updatedJob.Name;
                existingJob.Role = updatedJob.Role;
                existingJob.Level = updatedJob.Level;
                return existingJob;
            }

            return null;
        }
    }
}
