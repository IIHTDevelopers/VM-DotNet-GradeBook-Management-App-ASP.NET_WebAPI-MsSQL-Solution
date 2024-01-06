using GradebookManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradebookManagementApp.DAL.Interrfaces
{
    public interface IGradebookService
    {
        List<Grade> GetGradebook();
        Task<Grade> AddGrades(Grade grade);
        Task<Grade> GetGradeById(long id);
        Task<bool> DeleteGradeById(long id);
        Task<Grade> UpdateGradebook(Grade model);
    }
}
