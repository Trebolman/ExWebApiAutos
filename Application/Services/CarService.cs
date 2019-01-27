using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOS;
using Application.IServices;
using Domain;
using Domain.IRepositories;

namespace Application.Services
{
    public class CarService : ICarService
    {
        ICarRepository repository;

        //constructor
        CarService(ICarRepository repository)
        {
            this.repository = repository;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<CarDTO> GetAll()
        {
            IQueryable<TCar> Entities = repository.Items;
            return Builders.GenericBuilder.BuilderListEntityDTO<CarDTO, TCar>(Entities);
        }

        public CarDTO GetCar(Guid entityId)
        {
            var entities = repository.Items;
            var elemento = repository.Items.Where(x => x.IdCar == entityId).FirstOrDefault();
            return Builders.GenericBuilder.BuilderEntityDTO<CarDTO, TCar>(elemento);
        }

        public void Insert(CarDTO entityDTO)
        {
            TCar entity = Builders.
                        GenericBuilder.
                        BuilderDTOEntity<TCar, CarDTO>
                        (entityDTO);
            repository.Save(entity);
        }

        public void Update(CarDTO entityDTO)
        {
            var entity = Builders.
                GenericBuilder.
                BuilderDTOEntity<TCar, CarDTO>
                (entityDTO);
            repository.Save(entity);
        }
    }
}
