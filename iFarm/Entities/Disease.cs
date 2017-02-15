using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFarm.Entities
{
    public class Disease
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Disease(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
