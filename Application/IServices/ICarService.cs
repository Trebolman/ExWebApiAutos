
using Application.DTOS;
using System;
using System.Collections.Generic;

namespace Application.IServices
{
    public interface ICarService
    {
        void Insert(CarDTO entityDTO);
        IList<CarDTO> GetAll();
        void Update(CarDTO entityDTO);
        void Delete(Guid entityId);
        CarDTO GetCar(Guid entityId);
    }
}
