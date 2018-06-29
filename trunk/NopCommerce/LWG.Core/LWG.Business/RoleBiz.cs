using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Core.Models;

namespace LWG.Business
{
    public class RoleBiz
    {
        private LudwigContext dbContext;

        public RoleBiz()
        {
            dbContext = new LudwigContext();
        }

        public List<lwg_Role> GetListRole()
        {
            return dbContext.lwg_Role.OrderByDescending(p => p.RoleId).ToList();
        }

        public bool SaveRole(lwg_Role p)
        {
            if (p != null)
            {
                if (p.RoleId > 0)
                {
                    lwg_Role c = dbContext.lwg_Role.SingleOrDefault(ht => ht.RoleId == p.RoleId);
                    if (c != null)
                    {
                        c.Name = p.Name;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (dbContext.lwg_Role.Count() > 0)
                    {
                        p.RoleId = dbContext.lwg_Role.OrderByDescending(pe => pe.RoleId).First().RoleId + 1;
                    }
                    else
                    {
                        p.RoleId = 1;
                    }
                    dbContext.lwg_Role.Add(p);
                }
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public lwg_Role GetByID(int id)
        {
            if (id > 0)
            {
                return dbContext.lwg_Role.SingleOrDefault(h => h.RoleId == id);
            }
            return null;
        }

        public bool DeleteRole(int p)
        {
            if (p > 0 )
            {
                if (!dbContext.lwg_PersonInRole.Any(cl => cl.RoleId == p))
                {
                    lwg_Role lg = dbContext.lwg_Role.SingleOrDefault(lw => lw.RoleId == p);
                    dbContext.lwg_Role.Remove(lg);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public int CheckAndInsertRole(string roleName)
        {
            try
            {
                lwg_Role lwg = dbContext.lwg_Role.SingleOrDefault(o => o.Name.ToLower().Equals(roleName.ToLower()));
                if (lwg == null)
                {
                    lwg = new lwg_Role();
                    lwg.Name = roleName;
                    dbContext.lwg_Role.Add(lwg);
                    dbContext.SaveChanges();
                }
                return lwg.RoleId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
