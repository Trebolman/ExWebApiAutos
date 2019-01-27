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
    public class MarcaService : IMarcaService
    {
        IMarcaRepository repository;

        //constructor
        MarcaService(IMarcaRepository repository)
        {
            this.repository = repository;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<MarcaDTO> GetAll()
        {
            IQueryable<TMarca> Entities = repository.Items;
            return Builders.GenericBuilder.BuilderListEntityDTO<MarcaDTO, TMarca>(Entities);
        }

        public MarcaDTO GetMarca(Guid entityId)
        {
            var entities = repository.Items;
            var elemento = repository.Items.Where(x => x.MarcaId == entityId).FirstOrDefault();
            return Builders.GenericBuilder.BuilderEntityDTO<MarcaDTO, TMarca>(elemento);
        }

        public void Insert(MarcaDTO entityDTO)
        {
            TMarca entity = Builders.
                        GenericBuilder.
                        BuilderDTOEntity<TMarca, MarcaDTO>
                        (entityDTO);
            repository.Save(entity);
        }

        public void Update(MarcaDTO entityDTO)
        {
            var entity = Builders.
                GenericBuilder.
                BuilderDTOEntity<TMarca, MarcaDTO>
                (entityDTO);
            repository.Save(entity);
        }
    }
}
