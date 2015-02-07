using System.Collections.Generic;

namespace Clinika.Models.DatabaseObject
{
    public class Dose
    {
        public int DoseId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Treatment> Treatments { set; get; }
        
    }
}