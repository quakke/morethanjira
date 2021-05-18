using System.Collections.Generic;
using System.Threading.Tasks;
using MoreThanJira.Api.Models;
using MoreThanJira.Api.Utils;
using SQLite;

namespace MoreThanJira.Api.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private static SQLiteAsyncConnection _database;

        public TaskRepository()
        {
            _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }


        public Task<List<TaskEntity>> GetTasksAsync()
        {
            //Get all tasks.
            return _database.Table<TaskEntity>().ToListAsync();
        }

        public Task<TaskEntity> GetTaskByIdAsync(int id)
        {
            // Get a specific task by id.
            return _database.Table<TaskEntity>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveTaskAsync(TaskEntity task)
        {
            if (task.Id != 0)
            {
                // Update an existing task.
                return _database.UpdateAsync(task);
            }
            else
            {
                // Save a new task.
                return _database.InsertAsync(task);
            }
        }

        public Task<int> DeleteTaskAsync(TaskEntity task)
        {
            // Delete a task.
            return _database.DeleteAsync(task);
        }
    }
}
