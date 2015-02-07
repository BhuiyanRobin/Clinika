using System.Collections.Generic;

namespace Clinika.Models.DatabaseObject
{
    public class Meal
    {
        public int MealId { set; get; }
        public string Name { set; get; }
        public virtual ICollection<Treatment> Treatments { set; get; }
    }
}