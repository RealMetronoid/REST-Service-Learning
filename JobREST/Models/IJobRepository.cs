using System.Collections;

namespace JobREST.Models
{
    public interface IJobRepository
    {
        Job AddJob(Job job);
        IEnumerable<Job> GetAllJobs(int? minimumLevel, int? maximumLevel, string? nameFilter);
        Job? GetJobById(int id);
        Job? RemoveJob(int id);
        Job? UpdateJob(int id, Job updatedJob);
    }
}
