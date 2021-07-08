using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.WebAPI.Database;

namespace SaTeatar.WebAPI.Services
{
    public class PredstavaService : BaseCRUDService<mPredstave, Predstave, rPredstavaSearch, rPredstavaInsert, rPredstavaUpdate>
        , IPredstavaService
    {
        public PredstavaService(SaTeatarDbContext context, IMapper mapper)
            :base(context,mapper)
        {

        }
    }
}
