using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IMarcaRepository
    {
        IEnumerable<Marca> Get();
        Marca Get(int id);
        IEnumerable<Patrimonio> GetPatrimonio(int id);
        Marca Insert(Marca marca);
        int? Update(int id, Marca marca);
        int? Delete(int id);
    }
}
