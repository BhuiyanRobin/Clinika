using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using CliniKa.Models.DatabaseObject;
using Clinika.Models.Relations;

namespace Clinika.Models.DatabaseObject
{
    public class AllocateMedicine
    {
        public int Id { set; get; }
        public int ServiceCenterId { set; get; }
        public double Quantity { set; get; }
        public int MedicineId { set; get; }
        public int DistrictUpazilaId { set; get; }
        public virtual ServiceCenter AServiceCenter { set; get; }
        public virtual Medicine AMedicine { set; get; }
        public IEnumerable<District> Districts { set; get; }
        public IEnumerable<Upazila> Upazilas { set; get; } 

    }
}