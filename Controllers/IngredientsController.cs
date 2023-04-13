using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendfoodapi.Models;
using backendfoodapi.Models.DTO;
using backendfoodapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace backendfoodapi.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class IngredientsController : ControllerBase
   {
    private readonly IngredientService _data;
    public IngredientsController(IngredientService dataFromService){
        _data = dataFromService;
    }

        [HttpPost]
        [Route("AddIngredients")]  
      public bool AddIngredients(IngredientItemModel newIngredientItem){
        return _data.AddIngredients(newIngredientItem);
      }

      [HttpGet]
      [Route("GetAllIngredientsItems")]
      public IEnumerable<IngredientItemModel> GetAllIngredientsItems(){
        return _data.GetAllIngredientsItems();
      }
        
        // got rid of get ingredient by userId

        [HttpGet]
        [Route("GetIngredientById/{Id}")]
        public IEnumerable<IngredientItemModel> GetIngredientById(int Id){
            return _data.GetIngredientById(Id);
        }

        [HttpGet]
        [Route("UpdateIngredientItem")]
        // changed IpdateBlogItem to UpdateIngredientItem
            public bool UpdateIngredientItem(IngredientItemModel IngredientUpdate){
                return _data.UpdateIngredientItem(IngredientUpdate);
            }

        [HttpPost]
        [Route("DeleteIngredientItem")]
        public bool DeleteIngredientItem(IngredientItemModel IngredientDelete)
        {
            return _data.DeleteIngredientItem(IngredientDelete);
        }


   }
}