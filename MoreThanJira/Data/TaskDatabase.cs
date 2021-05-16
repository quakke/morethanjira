using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoreThanJira.Model;
using SQLite;

namespace MoreThanJira.Data
{
    public class TaskDatabase
    {
        readonly SQLiteAsyncConnection database;

        public TaskDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TaskEntity>().Wait();
        }

        public Task<List<TaskEntity>> GetTasksAsync()
        {
            //Get all tasks.
            return database.Table<TaskEntity>().ToListAsync();
        }

        public Task<TaskEntity> GetTaskByIdAsync(int id)
        {
            // Get a specific task by id.
            return database.Table<TaskEntity>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveTaskAsync(TaskEntity task)
        {
            if (task.Id != 0)
            {
                // Update an existing task.
                return database.UpdateAsync(task);
            }
            else
            {
                // Save a new task.
                return database.InsertAsync(task);
            }
        }

        public Task<int> DeleteTaskAsync(TaskEntity task)
        {
            // Delete a task.
            return database.DeleteAsync(task);
        }
    }
}
