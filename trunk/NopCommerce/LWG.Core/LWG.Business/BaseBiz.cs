using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Core;
using LWG.Core.Models;

namespace LWG.Business
{
    public class BaseBiz
    {
        protected LudwigContext dbContext;
        public BaseBiz()
        {
            dbContext = new LudwigContext();
        }
    }
}
