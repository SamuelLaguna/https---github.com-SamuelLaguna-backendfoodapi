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
    public IngredientController(IngredientService dataFromService){
        _data = dataFromService;
    }

        [HttpPost]
        [Route("AddIngredients")]  
      public bool AddIngredients(IngredientItemModel newIngredientItem){
        return _data.AddIngredients(newIngredientItem);
      }

      [HttpGet]
      [Route("GetAllIngredientsItems")]
      public IEnuerable<IngredientItemModels> GetAllIngredientsItems(){
        return _data.GetAllIngredientsItems();
      }
        
        [HttpGet]
        [Route("GetItemsByUserId/{UserId}")]
        public IEnumerable<IngredientsItemModel> GetItemsByUserId(int userId){
            return _data.GetItemsByUserId(userId);
        }

        [HttpGet]
        [Route("GetItemsCatagory/{catagory}")]
        public IEnumerable<BlogItemModel> GetItemByCatagory(string category){
            return _data.GetItemsByCategory(GetItemByCategory);
        }

        [HttpGet]
        [Route("GetItemsByDate/{date}")]
        public IEnumerable<BlogItemModel> GetItemsByDate(string date){
                return _data.GetItemsByDate(date);
        }

        [HttpGet]
        [Route("GetPublishedItems")]
        public IEnumerable<IngredientItemModel> GetPublishedItems(){
            return _data.GetPusblishedItems();
        }

        [HttpGet]
        [Route("GetItemByTag/{Tag}")]
        public List<IngredientItemModel> GetItemByTag(string Tag){
            return _data.GetItemsByTag(Tag);
        }

        [HttpGet]
        [Route("GetItemsByTag/{Tag}")]
        public List<IngredientItemModel> GetItemsByTag(string Tag){
            return  _data.GetItemsByTag(Tag);
        }

        [HttpGet]
        [Route("GetBlogItemById/{id}")]
        public IngredientItemModel GetINgredientItemById(int id){
            return _data.GetIngredientById(id);
        }


        [HttpGet]
        [Route("UpdateBlogItem")]
            public bool UpdateBlogItem(IngredientItemModel IngredientUpdate){
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