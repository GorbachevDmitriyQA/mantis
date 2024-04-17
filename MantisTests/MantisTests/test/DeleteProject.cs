using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests
{
    public class DeleteProject : TestBase
    {
        [Test]

        public void DeleteProjects()
        {
            app.Login.AdminLogin();
            app.ProjectManager.CheckProject();
            List<ProjectData> oldList  = ProjectData.GetAllProject();
            ProjectData tobeRemoved = oldList[0];
            app.ProjectManager.DeleteProject(tobeRemoved);
            List<ProjectData> newList = ProjectData.GetAllProject();
            oldList.RemoveAt(0);
            Assert.AreEqual(oldList, newList);
        }
    }
}
