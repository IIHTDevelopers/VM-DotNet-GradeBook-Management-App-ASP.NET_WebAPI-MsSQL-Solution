

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
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IGradebookService _gradebookService;
        public readonly Mock<IGradebookRepository>  gradebookservice = new Mock<IGradebookRepository>();

        private readonly Grade _grade;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
        {
            _gradebookService = new GradebookService( gradebookservice.Object);

            _output = output;

            _grade = new Grade
            {
               StudentId= 1,
               CourseCode= "CS101",
               Score= 85.5
            };
        }

        [Fact]
        public async Task<bool> Testfor_GradeCourseCode_NotEmpty()
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
                var actualLength = _grade.CourseCode.ToString().Length;
                if (result.CourseCode.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_GradeScore_NotEmpty()
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
                var actualLength = _grade.Score.ToString().Length;
                if (result.Score.ToString().Length == actualLength)
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