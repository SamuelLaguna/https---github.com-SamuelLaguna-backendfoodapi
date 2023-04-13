using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendfoodapi.Models
{
    public class IngredientItemModel
    {
        public int? Id {get; set;}
// got rid userId in ingredient model
         public string? IngredientName {get; set;}

         public int? Calories {get; set;}

         public int? Protien {get; set;}

         public int? Carbs {get; set;}
        
         public int? Fat {get; set;}

         public int? Sodium {get; set;}
// got rid of is delted item

        public IngredientItemModel(){}

    }
}