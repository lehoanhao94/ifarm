using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFarm.Entities
{
    public class Category
    {
        private int Id { get; set; }

        private string UrlImage { get; set; }

        private string Name { get; set; }

        private int Count { get { return LstDiseases.Count; } }

        private List<Disease> LstDiseases { get; set; }
    
        public Category(int id, string name, string urlImage, List<Disease> lstDiseases)
        {
            this.Id = id;
            this.Name = name;
            this.UrlImage = urlImage;
            this.LstDiseases = lstDiseases;
        }
    }
}
