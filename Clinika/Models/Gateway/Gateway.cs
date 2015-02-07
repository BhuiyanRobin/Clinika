using System.Data.Entity;
using CliniKa.Models.DatabaseObject;
using Clinika.Models.DatabaseObject;
using Clinika.Models.Relations;

namespace Clinika.Models.Gateway
{
    public class Gateway : DbContext
    {
        public Gateway()
            : base("connection")
        {
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<District> Districts { set; get; }
        public DbSet<Upazila> Upazilas { set; get; }
        public DbSet<DistrictUpazila> DistrictUpazilaRelation { set; get; }
        public DbSet<ServiceCenter> ServiceCenters { set; get; }
        public DbSet<Medicine> Medicines { set; get; }
        public DbSet<Diseases> Diseaseses { set; get; }
        public DbSet<DoctorEntry> Doctors { set; get; }
        public DbSet<Dose> Doses { set; get; }
        public DbSet<Meal> Meals { set; get; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<AllocateMedicine> AllocateMedicines { set; get; }
        public DbSet<PatientCount> PatientList { set; get; }
    }
}