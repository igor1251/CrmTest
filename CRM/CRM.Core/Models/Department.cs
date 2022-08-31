using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Models
{
    public class Department : Default
    {
        public Staff Master { get; set; } = new Staff();
        public List<Staff> Slaves { get; set; } = new List<Staff>();
        public Department() : base() { }
        public Department(int id, string name, Staff master, List<Staff> slaves) : base(id, name)
        {
            Master = master;
            Slaves = slaves;
            Info += $"Master: {Master.DisplayName}\n";
        }
    }
}
