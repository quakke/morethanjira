using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoreThanJira.Api.Models;

namespace MoreThanJira.Api.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskEntity>> GetTasksAsync();
        Task<TaskEntity> GetTaskByIdAsync(int id);
        Task<int> SaveTaskAsync(TaskEntity task);
        Task<int> DeleteTaskAsync(TaskEntity task);
    }
}
