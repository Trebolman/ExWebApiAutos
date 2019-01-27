using System;
using System.Linq;
using Domain;
using Domain.IRepositories;
using Infraestructure.Persistencia;

namespace Infraestructure.Repositories
{
    public class EFCarRepository : ICarRepository
    {
        CarsDbContext Context;

        //Constructor
        EFCarRepository(CarsDbContext context)
        {
            Context = context;
        }
        public IQueryable<TCar> Items => Context.TCar;

        public void Delete(Guid itemId)
        {
            TCar dbEntry = Context.TCar
                .FirstOrDefault(x => x.IdCar == itemId);

            if (dbEntry != null)
            {
                Context.TCar.Remove(dbEntry);
                Context.SaveChanges();
            }
        }

        public void Save(TCar item)
        {
            if (item.IdCar == Guid.Empty)
            {
                item.IdCar = Guid.NewGuid();
                Context.TCar.Add(item);
            }
            else
            {
                TCar dbEntry = Context.TCar
                .FirstOrDefault(x => x.IdCar == item.IdCar);
                if (dbEntry != null)
                {
                    dbEntry.CarCol = item.CarCol;
                    dbEntry.CarIsFull = item.CarIsFull;
                    dbEntry.CarIsMec = item.CarIsMec;
                    dbEntry.CarMarca = item.CarMarca;
                    dbEntry.CarNroAsien = item.CarNroAsien;
                    dbEntry.CarNroPlaca = item.CarNroPlaca;
                    dbEntry.CarYear = item.CarYear;
                    dbEntry.MarcaId = item.MarcaId;
                }
            }
            Context.SaveChangesAsync();
        }
    }
}
