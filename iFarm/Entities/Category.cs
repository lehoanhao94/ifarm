using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFarm.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string UrlImage { get; set; }

        public string Name { get; set; }

        public int Count { get { return LstDiseases.Count; } }

        public List<Disease> LstDiseases { get; set; }
    
        public Category(int id, string name, string urlImage, List<Disease> lstDiseases)
        {
            this.Id = id;
            this.Name = name;
            this.UrlImage = urlImage;
            this.LstDiseases = lstDiseases;
        }
    }
}
