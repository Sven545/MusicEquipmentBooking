using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicEquipmentBooking.BusinessLogicLayer.Interfaces;
using MusicEquipmentBooking.BusinessLogicLayer.DataTransferObjects;
using MusicEquipmentBooking.DataAcsessLayer.Interfaces;
using MusicEquipmentBooking.DataAcsessLayer.Entities;
using MusicEquipmentBooking.DataAcsessLayer.Repositories;
using AutoMapper;

namespace MusicEquipmentBooking.BusinessLogicLayer.Services
{
    public class ServiceObjectCrudService : ICrudService<ServiceObjectDTO>
    {
        private IRepository<ServiceObject> _repository;
        private Mapper _mapper;
        public ServiceObjectCrudService()
        {
            _repository = new ServiceObjectRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ServiceObject, ServiceObjectDTO>().ReverseMap();
               
            });
            _mapper = new Mapper(config);
        }
        public int Create(ServiceObjectDTO item)
        {
           return _repository.Create(_mapper.Map<ServiceObjectDTO, ServiceObject>(item));
           
        }
        /*
        public int Create(ServiceObjectDTO item)
        {
            throw new NotImplementedException();
        }
        */
        public void Delete(int id)
        {
           var objectForDelete = _repository.Get(id)??throw new ArgumentException($"Object with id:{id} not found");
            _repository.Delete(objectForDelete);
        }

        public ServiceObjectDTO Get(int id)
        {
            var serviceObject = _repository.Get(id)??throw new ArgumentException($"Object with id:{id} not found");
            return _mapper.Map<ServiceObject,ServiceObjectDTO>(serviceObject);
        }

        public IEnumerable<ServiceObjectDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<ServiceObject>,IEnumerable<ServiceObjectDTO>>(_repository.GetAll());
        }

        public void Update(ServiceObjectDTO item)
        {
            throw new NotImplementedException();
        }
        private bool ServiceObjectDTOValidation(ServiceObjectDTO serviceObject)
        {
            return true;
        }

    }
}
