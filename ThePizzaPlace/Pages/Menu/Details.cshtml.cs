﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThePizzaPlace.Data;
using ThePizzaPlace.Models;

namespace ThePizzaPlace.Pages.Menu
{
    public class DetailsModel : PageModel
    {
        private readonly ThePizzaPlace.Data.ThePizzaPlaceContext _context;

        public DetailsModel(ThePizzaPlace.Data.ThePizzaPlaceContext context)
        {
            _context = context;
        }

      public FoodItem FoodItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FoodItems == null)
            {
                return NotFound();
            }

            var fooditem = await _context.FoodItems.FirstOrDefaultAsync(m => m.ID == id);
            if (fooditem == null)
            {
                return NotFound();
            }
            else 
            {
                FoodItem = fooditem;
            }
            return Page();
        }
    }
}