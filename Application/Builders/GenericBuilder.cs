using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Builders
{
    public class GenericBuilder
    {
        //Convertir entities a DTOs
        public static DTO BuilderEntityDTO<DTO, Entity>(Entity entity)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Entity, DTO>(); //es para mapear desde entity a dto
            });
            IMapper iMapper = config.CreateMapper();
            var destination = iMapper.Map<Entity, DTO>(entity);
            return destination;
        }

        //Convertir dtos en entities.
        public static Entity BuilderDTOEntity<Entity, DTO>(DTO entity)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTO, Entity>(); //es para mapear desde entity a dto
            });
            IMapper iMapper = config.CreateMapper();
            var destination = iMapper.Map<DTO, Entity>(entity);
            return destination;
        }

        public static IList<DTO> BuilderListEntityDTO<DTO, Entity>(IQueryable<Entity> listaInput)
        {
            var listOutput = new List<DTO>();
            foreach (Entity entity in listaInput)
            {
                //listOutput.Add(builderEntityDTO<DTO, Entity>(entity));
            }
            return listOutput;
        }
    }
}
