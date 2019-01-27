using Application.DTOS;
using System;
using System.Collections.Generic;


namespace Application.IServices
{
    public interface IMarcaService
    {
        void Insert(MarcaDTO entityDTO);
        IList<MarcaDTO> GetAll();
        void Update(MarcaDTO entityDTO);
        void Delete(Guid entityId);
        MarcaDTO GetMarca(Guid entityId);
    }
}
