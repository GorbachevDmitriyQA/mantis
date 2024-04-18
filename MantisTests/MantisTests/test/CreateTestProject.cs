using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisTests
{
    public class CreateTestProject : TestBase
    {

        [Test]
        public void CreateProjetc()
        {
            ProjectData project = new ProjectData()
            {
                Name = "testProject",
                Description = "This projcet for C# tests"
            };

            app.Auth.AdminLogin();
            app.ManageMenuNavigator.ProjectMenu();
            List<ProjectData> oldProject = ProjectData.GetAllProject();
            app.ProjectManager.CreateProject(project);
            List<ProjectData> newProject = ProjectData.GetAllProject();
            Assert.AreEqual(oldProject.Count + 1, newProject.Count);
        }
    }
}
