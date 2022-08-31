using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Models
{
    public class Company : Default
    {
        public DateTime LunticDate { get; set; } = DateTime.MinValue;
        public string PaperAddress { get; set; } = string.Empty;
        public List<Department> Slaves { get; set; } = new List<Department>();
        public Company() : base() { }
        public Company(int id, string name, DateTime lunticDate, string paperAddress, List<Department> slaves) : base(id, name)
        {
            LunticDate = lunticDate;
            PaperAddress = paperAddress;
            Slaves = slaves;
            Info += $"LunticDate: {LunticDate}\nPaperAddress: {PaperAddress}\n";
        }
    }
}
