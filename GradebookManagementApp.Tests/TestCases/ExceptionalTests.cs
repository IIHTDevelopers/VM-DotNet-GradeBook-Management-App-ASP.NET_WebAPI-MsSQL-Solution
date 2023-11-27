


using GradebookManagementApp.DAL.Interrfaces;
using GradebookManagementApp.DAL.Services;
using GradebookManagementApp.DAL.Services.Repository;
using GradebookManagementApp.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace GradebookManagementApp.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IGradebookService _gradebookService;
        public readonly Mock<IGradebookRepository>  gradebookservice = new Mock<IGradebookRepository>();

        private readonly Grade _grade;

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
        {
            _gradebookService = new GradebookService( gradebookservice.Object);

            _output = output;

            _grade = new Grade
            {
                StudentId = 1,
                CourseCode = "CS101",
                Score = 85.5
            };
        }


        [Fact]
        public async Task<bool> Testfor_Validate_IfInvalidStudentIdIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                 gradebookservice.Setup(repo => repo.AddGrades(_grade)).ReturnsAsync(_grade);
                var result = await _gradebookService.AddGrades(_grade);
                if (result != null || result.StudentId !=0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Validate_IfInvalidCourseCodeIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                 gradebookservice.Setup(repo => repo.AddGrades(_grade)).ReturnsAsync(_grade);
                var result = await _gradebookService.AddGrades(_grade);
                if (result != null || result.CourseCode.Length!=0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidGradeScoreIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                 gradebookservice.Setup(repo => repo.AddGrades(_grade)).ReturnsAsync(_grade);
                var result = await _gradebookService.AddGrades(_grade);
                if (result != null || result.Score>0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidGradeIdIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                 gradebookservice.Setup(repo => repo.AddGrades(_grade)).ReturnsAsync(_grade);
                var result = await _gradebookService.AddGrades(_grade);
                if (result != null || result.StudentId !=null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}