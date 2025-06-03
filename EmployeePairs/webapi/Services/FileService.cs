using System.Globalization;
using webapi.Models;
using webapi.Services.Interfaces;

namespace webapi.Services
{
    public class FileService : IFileService
    {
        public FileService()
        {
        }

        public async Task<List<Project>> ReadPairsFromFile(IFormFile file)
        {
            var employees = new List<Project>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    var values = line.Split(',');

                    if (values.Length == 4)
                    {
                        DateTime dateFrom;
                        if (DateTime.TryParse(values[2].Trim(), out dateFrom))
                        {
                            DateTime? dateTo = null;

                            DateTime tempDateTo;
                            if (DateTime.TryParse(values[3].Trim(), out tempDateTo))
                            {
                                dateTo = tempDateTo;
                            }
                            else
                            {
                                dateTo = DateTime.Now;
                            }

                            if (dateFrom > dateTo)
                            {
                                continue;
                            }

                            var employee = new Project
                            {
                                EmpID = int.Parse(values[0]),
                                ProjectID = int.Parse(values[1]),
                                DateFrom = dateFrom.Date,
                                DateTo = dateTo?.Date
                            };

                            employees.Add(employee);
                        }
                    }
                }
            }

            return employees;
        }
    }
}
