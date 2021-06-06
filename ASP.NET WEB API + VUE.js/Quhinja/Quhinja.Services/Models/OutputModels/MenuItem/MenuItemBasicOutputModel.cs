﻿using Quhinja.Services.Models.OutputModels.Recipe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.OutputModels.MenuItem
{
     public class MenuItemBasicOutputModel
    {
        public int Id { get; set; }

        public DateTime DateOfDish { get; set; }

        public ICollection<MissedLunchBasicOutputModel> MissedUsers { get; set; }

        public RecipeWithDishOutputModel Recipe { get; set; }

        public int RecipeId { get; set; }

    }
}
