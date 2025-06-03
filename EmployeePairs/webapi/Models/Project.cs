namespace webapi.Models
{
    public class Project
    {
        public int EmpID { get; set; }
        public int ProjectID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public Project()
        {
            
        }

        public int GetDurationInDays()
        {
            if (DateTo.HasValue)
            {
                return (DateTo.Value - DateFrom).Days;
            }

            return 0;
        }
    }
}
