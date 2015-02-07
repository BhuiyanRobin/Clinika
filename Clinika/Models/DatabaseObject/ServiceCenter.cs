using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CliniKa.Models.DatabaseObject
{
    public class ServiceCenter
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Name need to fill Up")]
        [Remote("ExistName", "ServiceCenter")]
        public string Name { set; get; }
        public string Code { set; get; }
        public string Password { set; get; } 
        public int DistrictId { set; get; }
        public int UpazilaId { set; get; }
        public virtual District ADistrict { set; get; }
        public virtual Upazila AUpazila { set; get; }
        }
}