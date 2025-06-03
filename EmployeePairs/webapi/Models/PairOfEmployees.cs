namespace webapi.Models
{
    public class PairOfEmployees
    {
        public PairOfEmployees(int empID1, int empID2, int projectID, int daysWorked)
        {
            Employee1 = empID1;
            Employee2 = empID2;
            ProjectID = projectID;
            DaysWorked = daysWorked;
        }

        public int Employee1 { get; }
        public int Employee2 { get; }
        public int ProjectID { get; set; }
        public int DaysWorked { get; set; }

    }
}
