using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Core.Models;

namespace LWG.Business
{
    public class HtmlContentBiz
    {
        private LudwigContext dbContext;

        public HtmlContentBiz()
        {
            dbContext = new LudwigContext();
        }        
    }
}
