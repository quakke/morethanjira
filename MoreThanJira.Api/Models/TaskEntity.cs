using System;
using SQLite;

namespace MoreThanJira.Api.Models
{
    public class TaskEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        // TODO: сделать статус
        //public StatusValue
    }
}
