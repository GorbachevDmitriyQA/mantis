using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace MantisTests
{
    public class ProjectManagmentHelper : HelperBase
    {
        public ProjectManagmentHelper(AppManager manager) : base(manager) { }

        public List<ProjectData> projectListCashe = null;

        public void CreateProject(ProjectData project)
        {
            InitCreateProject();
            FillProjectForm(project);
            CommitProjectCreate();
        }

        public void CommitProjectCreate()
        {
            driver.FindElement(By.CssSelector("input.button[value='Добавить проект']")).Click();
            Thread.Sleep(1500);
        }

        public void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            driver.FindElement(By.Id("project-description")).SendKeys(project.Description);
        }

        public void InitCreateProject()
        {
            driver.FindElement(By.CssSelector(".button-small[value='создать новый проект']")).Click();
        }

        public void DeleteProject(ProjectData project)
        {
            manager.ManageMenuNavigator.ProjectMenu();
            OpenProject(project.Id);
            driver.FindElement(By.Id("project-delete-form")).Click();
            driver.FindElement(By.CssSelector("input[class='button']")).Click();
        }

        public void OpenProject(string id)
        {
            driver.FindElement(By.XPath("//a[@href='manage_proj_edit_page.php?project_id="+id+"']")).Click();
        }

        public void CheckProject()
        {
            List<ProjectData> project = ProjectData.GetAllProject();
            if (project.Count == 0)
            {
                ProjectData testProject = new ProjectData()
                {
                    Name = "superSitu",
                    Description = "This project has benn create to autoprocedure"
                };
                manager.ManageMenuNavigator.ProjectMenu();
                manager.ProjectManager.CreateProject(testProject);
            }
            else return;
        }
    }
}
