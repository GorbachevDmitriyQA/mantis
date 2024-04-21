using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MantisTests
{
    public class APIHepler : HelperBase
    {
        public List<Mantis.ProjectData> existProject = null;
        public List<ProjectData> finalyList;
        public APIHepler(AppManager appManager) : base(appManager) { }

        public void CreateNewIssue(AccountData account, IssueData data, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issueData = new Mantis.IssueData();
            {
                issueData.summary = data.Summary;
                issueData.description = data.Decsription;
                issueData.category = data.Category;
                issueData.project = new Mantis.ObjectRef();
                issueData.project.id = project.Id;

            }
            Mantis.mc_issue_addRequest issueRequest = new Mantis.mc_issue_addRequest()
            {
                password = account.Password,
                username = account.Name,
                issue = issueData
            };
            client.mc_issue_add(issueRequest);
        }

        public List<Mantis.ProjectData> GetProjectsList(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.mc_projects_get_user_accessibleResponse response = new Mantis.mc_projects_get_user_accessibleResponse();
            Mantis.mc_projects_get_user_accessibleRequest user = new Mantis.mc_projects_get_user_accessibleRequest()
            {
                username = account.Name,
                password = account.Password
            };
            response = client.mc_projects_get_user_accessible(user);
            existProject = new List<Mantis.ProjectData>();
            foreach (Mantis.ProjectData qwe in response.@return)
            {
                string projectName = qwe.name;
                string projDescription = qwe.description;
                string projIdenty = qwe.id;
                existProject.Add(new Mantis.ProjectData()
                {
                    name = projectName,
                    description = projDescription,
                    id = projIdenty
                });
            }
            return existProject;
            
        }

        public void CreateProject(AccountData accountData, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projectRequest = new Mantis.ProjectData()
            {
                name = projectData.Name,
                description = projectData.Description
            };
            Mantis.mc_project_addRequest request = new Mantis.mc_project_addRequest()
            {
                username = accountData.Name,
                password = accountData.Password,
                project = projectRequest
            };
            client.mc_project_add(request);
        }
    }
}
