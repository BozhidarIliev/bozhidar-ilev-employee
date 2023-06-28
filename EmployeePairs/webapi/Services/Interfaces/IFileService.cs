using webapi.Models;

namespace webapi.Services.Interfaces
{
    public interface IFileService
    {
        Task<List<Project>> ReadPairsFromFile(IFormFile file);
    }
}
