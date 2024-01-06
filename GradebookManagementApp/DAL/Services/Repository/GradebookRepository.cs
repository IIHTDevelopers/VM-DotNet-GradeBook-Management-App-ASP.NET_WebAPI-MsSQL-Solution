using GradebookManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GradebookManagementApp.DAL.Services.Repository
{
    public class GradebookRepository : IGradebookRepository
    {
        private readonly DatabaseContext _dbContext;
        public GradebookRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Grade> AddGrades(Grade grade)
        {
            try
            {
                var result = _dbContext.Grades.Add(grade);
                await _dbContext.SaveChangesAsync();
                return grade;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteGradeById(long id)
        {
            try
            {
                _dbContext.Grades.Remove(_dbContext.Grades.Single(a => a.StudentId == id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Grade> GetGradebook()
        {
            try
            {
                var result = _dbContext.Grades.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Grade> GetGradeById(long id)
        {
            try
            {
                return await _dbContext.Grades.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Grade> UpdateGradebook(Grade model)
        {
            var ex = await _dbContext.Grades.FindAsync(model.StudentId);
            try
            {
                ex.StudentId = model.StudentId;
                await _dbContext.SaveChangesAsync();
                return ex;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}