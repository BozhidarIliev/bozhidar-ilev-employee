using System.Globalization;
using webapi.Models;
using webapi.Services.Interfaces;

namespace webapi.Services
{
    public class ProjectService : IProjectService
    {
        public ProjectService()
        {

        }

        public List<PairOfEmployees> FindPairs(List<Project> projects)
        {
            List<PairOfEmployees> pairs = new List<PairOfEmployees>();

            for (int i = 0; i < projects.Count - 1; i++)
            {
                for (int j = i + 1; j < projects.Count; j++)
                {
                    var project1 = projects[i];
                    var project2 = projects[j];

                    if (projects[i].ProjectID == projects[j].ProjectID)
                    {
                        var duration = GetDurationOverlap(project1, project2);  

                        if (duration != 0)
                        {
                            PairOfEmployees pair;
                            if (project1.DateFrom > project2.DateFrom)
                            {
                                pair = new PairOfEmployees(project2.EmpID, project1.EmpID, project1.ProjectID, duration);
                            }
                            else
                            {
                                pair = new PairOfEmployees(project1.EmpID, project2.EmpID, project1.ProjectID, duration);
                            }
                            pairs.Add(pair);
                        }
                    }
                }
            }

            return pairs.OrderByDescending(p => p.DaysWorked).ToList();
        }

        public int GetDurationOverlap(Project project1, Project project2)
        {
            DateTime overlapStart = project1.DateFrom > project2.DateFrom ? project1.DateFrom : project2.DateFrom;
            DateTime? overlapEnd = null;

            if (project1.DateTo.HasValue && project2.DateTo.HasValue)
            {
                overlapEnd = project1.DateTo.Value < project2.DateTo.Value ? project1.DateTo.Value : project2.DateTo.Value;
            }
            else 
            {
                return 0;
            }

            int overlapDays = (overlapEnd.Value - overlapStart).Days + 1;

            if (overlapDays < 0)
            {
                return 0;
            }

            return overlapDays;
        }

    }
}
