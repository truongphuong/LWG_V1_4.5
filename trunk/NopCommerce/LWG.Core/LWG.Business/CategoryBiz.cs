using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Core.Models;

namespace LWG.Business
{
    public class CategoryBiz
    {
        private LudwigContext context;

        public CategoryBiz()
        {
            context = new LudwigContext();
        }

        public List<Nop_Category> GetAllParentCategory()
        {
            return context.Nop_Category.Where(c => c.ParentCategoryID == 0).ToList();
        }
    }
}
