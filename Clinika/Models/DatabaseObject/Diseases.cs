using System.ComponentModel;
using CliniKa.Models.DatabaseObject;

namespace Clinika.Models.DatabaseObject
{
    public class Diseases
    {
        public int DiseasesId { get; set; }

        [DisplayName ("Disease Name")]
        public string Name { get; set; }

        [DisplayName ("Disease Description")]
        public string Description { get; set; }

        [DisplayName("Treatment Procedure")]
        public string TreatmentProcedure { get; set; }

        
        public int MedicineId { get; set; }

       
        public virtual Medicine AMedicine { get; set; }
    }
}