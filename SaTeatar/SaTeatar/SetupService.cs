using Microsoft.EntityFrameworkCore;
using SaTeatar.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaTeatar.WebAPI
{
    public class SetupService
    {
        public void Init(SaTeatarDbContext context)
        {
            context.Database.Migrate(); //pokrece migraciju

            //add new data or update

            if (!context.Uloge.Any(x => x.Naziv == "generic"))
            {
                context.Uloge.Add(new Uloge() { Naziv = "generic", Opis = "opisni" });
            }

            context.SaveChanges();
        }
    }
}
