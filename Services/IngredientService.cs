using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendfoodapi.Models;
using backendfoodapi.Models.DTO;
using backendfoodapi.Services.Context;

namespace backendfoodapi.Services
{
    public class IngredientService
    {
        private readonly DataContext _context;
        public IngredientService(DataContext context)
        {
            _context = context;
        }
         public bool AddIngredients(IngredientItemModel newIngredientItem){
        _context.Add(newIngredientItem);
        return _context.SaveChanges() !=0;
      }

       public IEnumerable<IngredientItemModel> GetAllIngredientsItems(){
        return _context.IngredientInfo; 
      }
        
         public IEnumerable<IngredientItemModel> GetItemsByUserId(int userId){
            return _context.IngredientInfo.Where(GetItemsByUserId => GetItemsByUserId.Userid == userId);
        }

        public IEnumerable<IngredientItemModel> GetIngredientById(int Id){
            return _context.IngredientInfo.Where(GetIngredientById => GetIngredientById.Id == Id);
        }



        public bool UpdateIngredientItem (IngredientItemModel IngredientUpdate){
            _context.Update<IngredientItemModel>(IngredientUpdate);
            return _context.SaveChanges() !=0;
        }

        // public IEnumerable<IngredientItemModel> GetItemsByCategory(string category){
        //     return _context.IngredientInfo.Where(GetItemsByCategory => GetItemsByCategory.Category == category);
        // }

        // public IEnumerable<IngredientItemModel> GetItemsByDate(string date){
        //     return _context.IngredientInfo.Where(GetItemsByCategory => GetItemsByCategory.Date == date);
        // }

        // public IEnumerable<IngredientItemModel> GetPublishedItems(){
        //     return _context.IngredientInfo.Where(item => item.isPublished);
        // }

        //  public List<IngredientItemModel> GetItemsByTag(string Tag){
        //    var allItems = GetAllIngredientsItems().ToLists();
        //    for(int i = 0; i < allItems.Count; i++)
        //    {
        //     IngredientItemModel Item = allItems[i];
        //     var itemArr = Item.Tags.Split(",");

        //     for(int j = 0; j < itemArr.Length; j++)
        //     {
        //         if(itemArr[j].Contains(Tag))
        //         {
        //             AllInrgedientsWithTag.Add(Item);

        //         }
        //     }
        //    }

        //    return AllInrgedientsWithTag;
        // }

        // public IngredientItemModel GetIngredientById(int id){
        //     return _context.BlogInfo.SingleOrDefault(item => item.id == id);
        // }

            public bool UpdateBlogItem(IngredientItemModel IngredientUpdate){
                _context.Update<IngredientItemModel>(IngredientUpdate);
                return _context.SaveChanges() !=0;
            }

          public bool DeleteIngredientItem(IngredientItemModel IngredientDelete)
        {
           IngredientDelete.isDeleted = true;
           _context.Update<IngredientItemModel>(IngredientDelete);
           return _context.SaveChanges() !=0;
        }

        



    }
}