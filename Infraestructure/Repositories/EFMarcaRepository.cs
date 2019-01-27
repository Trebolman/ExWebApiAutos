using System;
using System.Linq;
using Domain;
using Domain.IRepositories;
using Infraestructure.Persistencia;

namespace Infraestructure.Repositories
{
    public class EFMarcaRepository : IMarcaRepository
    {
        CarsDbContext Context;

        //Constructor
        EFMarcaRepository(CarsDbContext context)
        {
            Context = context;
        }
        public IQueryable<TMarca> Items => Context.TMarca;

        public void Delete(Guid itemId)
        {
            TMarca dbEntry = Context.TMarca
                .FirstOrDefault(x => x.MarcaId == itemId);

            if (dbEntry != null)
            {
                Context.TMarca.Remove(dbEntry);
                Context.SaveChanges();
            }
        }

        public void Save(TMarca item)
        {
            if (item.MarcaId == Guid.Empty)
            {
                item.MarcaId = Guid.NewGuid();
                Context.TMarca.Add(item);
            }
            else
            {
                TMarca dbEntry = Context.TMarca
                .FirstOrDefault(x => x.MarcaId == item.MarcaId);
                if (dbEntry != null)
                {
                    dbEntry.MarcaName = item.MarcaName;
                }
            }
            Context.SaveChangesAsync();
        }
    }
}
