using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests
{
    public class APIHepler : HelperBase
    {
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
    }
}
