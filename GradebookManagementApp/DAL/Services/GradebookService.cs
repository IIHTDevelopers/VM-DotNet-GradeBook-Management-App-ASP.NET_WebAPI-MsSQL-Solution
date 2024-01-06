using GradebookManagementApp.DAL.Interrfaces;
using GradebookManagementApp.DAL.Services.Repository;
using GradebookManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GradebookManagementApp.DAL.Services
{
    public class GradebookService : IGradebookService
    {
        private readonly IGradebookRepository _repository;

        public GradebookService(IGradebookRepository repository)
        {
            _repository = repository;
        }

        public Task<Grade> AddGrades(Grade grade)
        {
            return _repository.AddGrades(grade);
        }

        public Task<bool> DeleteGradeById(long id)
        {
            return _repository.DeleteGradeById(id);
        }

        public List<Grade> GetGradebook()
        {
            return _repository.GetGradebook();
        }

        public Task<Grade> GetGradeById(long id)
        {
            return _repository.GetGradeById(id); ;
        }

        public Task<Grade> UpdateGradebook(Grade model)
        {
            return _repository.UpdateGradebook(model);
        }
    }
}