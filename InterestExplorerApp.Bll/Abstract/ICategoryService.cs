﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Entities.Concrete;
using InterestExplorerApp.Entities.DTOs;

namespace InterestExplorerApp.Bll.Abstract
{
   public interface ICategoryService
    {
        List<Category> GetAll();

        Category GetById(int Id);

        void Update(Category category);

        void Add(Category category);

        void Delete(int Id);

        List<CategoryDTO> GetAllByMainCategoryId(int mainCategoryId);

        List<Category> SearchByCategoryName(string search);

        string GetCategoryNameByCategoryId(int categoryId);

        int GetTotalCategoryCount();

    }
}
