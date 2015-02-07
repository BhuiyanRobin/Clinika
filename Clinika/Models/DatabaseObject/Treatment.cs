using System;
using System.ComponentModel;
using CliniKa.Models.DatabaseObject;

namespace Clinika.Models.DatabaseObject
{
    public class Treatment
    {
        public int TreatmentId { get; set; }

        [DisplayName("Voter ID")]
        public string VoterId { get; set; }

        [DisplayName("Patient Name")]
        public string Name { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime DateOfBirht { get; set; }

        [DisplayName("Service Given")]
        public int ServiceGiven { get; set; }

        [DisplayName("Observation")]
        public string Observation { get; set; }

        [DisplayName("Observation Date")]
        public DateTime Date { get; set; }

        [DisplayName("Doctor")]
        public int DoctorId { get; set; }
        public int DiseaseId { get; set; }
        public int MedicineId { get; set; }
        public int DoseId { get; set; }
        public int MealId { set; get; }

        [DisplayName("Quantity Given")]
        public string QuantityGiven { get; set; }

        [DisplayName("Note")]
        public string Note { get; set; }
        public virtual Meal AMeal { set; get; }
        public virtual Dose ADose { get; set; }
        public virtual Medicine AMedicine { get; set; }
        public virtual Diseases ADiseases { get; set; }
        public virtual DoctorEntry ADoctorEntry { get; set; }
        
    }

   
}