using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Models
{
    public class Staff : Default
    {
        public string Surname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; } = DateTime.MinValue;
        public DateTime Hireddate { get; set; } = DateTime.MinValue;
        public Post Post { get; set; } = new Post();
        public decimal Money { get; set; } = 0.0M;
        public Staff() { }
        public Staff(int id, string name, string surname, string lastname, DateTime birthdate, DateTime hireddate, Post post, decimal money)
            : base(id, name)
        {
            Surname = surname;
            Lastname = lastname;
            Birthdate = birthdate;
            Hireddate = hireddate;
            Post = post;
            Money = money;
            Info += $"Surname: {Surname}\nLastname: {Lastname}\nBirthdate: {Birthdate}\nHiredate: {Hireddate}\nPost: {Post?.DisplayName}\nMoney: {Money}";
        }
    }
}
