using Microsoft.VisualBasic;
namespace TTracker.Models
{
    public class Task
    {
        public int Id { get; set; }
        public bool TaskStatus { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime? dueDate { get; set; }
       
    }
}
