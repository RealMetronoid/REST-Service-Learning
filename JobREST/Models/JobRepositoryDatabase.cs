using Microsoft.JSInterop.Implementation;

namespace JobREST.Models
{
    public class JobRepositoryDatabase : IJobRepository
    {
        private readonly JobDBContext _context;

        public JobRepositoryDatabase(JobDBContext context)
        {
            _context = context;
        }

        public Job AddJob(Job job)
        {
            if (job is null)
            {
                throw new ArgumentNullException(nameof(job));
            }

            _context.Jobs.Add(job);
            _context.SaveChanges();
            return job;
        }

        public IEnumerable<Job> GetAllJobs(int? minimumLevel, int? maximumLevel, string? nameFilter)
        {
            return _context.Jobs;
        }

        public Job? GetJobById(int id)
        {
            return _context.Jobs.Find(id);
        }

        public Job? RemoveJob(int id)
        {
            var job = GetJobById(id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                _context.SaveChanges();
                return job;
            }

            return null;
        }

        public Job? UpdateJob(int id, Job updatedJob)
        {
            var existingJob = GetJobById(id);
            if (existingJob != null)
            {
                existingJob.Name = updatedJob.Name;
                existingJob.Role = updatedJob.Role;
                existingJob.Level = updatedJob.Level;
                _context.SaveChanges();
                return existingJob;
            }

            return null;
        }
    }
}
