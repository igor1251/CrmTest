using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Models
{
    public class Default : IDefault
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public virtual string DisplayName { get; set; } = string.Empty;
        public virtual string Info { get; set; } = string.Empty;
        public Default() { }
        public Default(int id, string name)
        {
            Id = id;
            Name = name;
            DisplayName = $"{Name} ({Id})";
            Info = $"Id: {Id}\nName: {Name}\nDisplayName: {DisplayName}\n";
        }
    }
}
