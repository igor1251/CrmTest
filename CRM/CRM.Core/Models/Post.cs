using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Models
{
    public class Post : Default
    {
        public Post() : base() { }
        public Post(int id, string name) : base(id, name) { }
    }
}
