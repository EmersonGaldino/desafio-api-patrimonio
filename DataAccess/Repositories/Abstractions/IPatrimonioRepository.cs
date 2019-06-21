using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IPatrimonioRepository
    {
        IEnumerable<Patrimonio> Get();
        Patrimonio Get(int id);
        IEnumerable<Patrimonio> GetByMarcaId(int id);
        Patrimonio Insert(Patrimonio patrimonio);
        int? Update(int id, Patrimonio patrimonio);
        int? Delete(int id);
    }
}
