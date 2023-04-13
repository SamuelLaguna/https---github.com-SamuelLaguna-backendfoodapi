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

        public IEnumerable<IngredientItemModel> GetIngredientById(int Id){
            return _context.IngredientInfo.Where(GetIngredientById => GetIngredientById.Id == Id);
        }
        // cahnged id names so the Id was capitalized

        public bool UpdateIngredientItem (IngredientItemModel IngredientUpdate){
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