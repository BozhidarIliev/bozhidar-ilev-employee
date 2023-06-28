using webapi.Models;

namespace webapi.Services.Interfaces
{
    public interface IProjectService
    {
        List<PairOfEmployees> FindPairs(List<Project> projects);
    }
}
