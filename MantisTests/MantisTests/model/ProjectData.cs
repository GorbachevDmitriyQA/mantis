using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Configuration;
using System.Linq;
using LinqToDB.Mapping;

namespace MantisTests
{
    [Table(Name= "mantis_project_table")]
    public class ProjectData :IComparable<ProjectData>
    {
        [Column(Name="name")]
        public string Name { get; set; }

        [Column(Name="description")]
        public string Description { get; set; }

        [Column(Name="id")]
        public int Id { get; set; }

        public int CompareTo(ProjectData other)
        {
            if (other == null)
            {
                return 1;
            }
            else
            {
                return Name.CompareTo(other.Name);
            }
        }

        public static List<ProjectData> GetAllProject()
        {
            using (MantisDB mantis = new MantisDB())
            {
                return (from m in mantis.Project
                          select m).ToList();
            }
        }
    }

}
