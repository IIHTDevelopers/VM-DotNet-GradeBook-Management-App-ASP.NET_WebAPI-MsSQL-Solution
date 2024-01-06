
using GradebookManagementApp.Models;
using System.Data.Entity;


namespace GradebookManagementApp.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<Grade> Grades { get; set; }
    }
}