using System.Text;
using MusicEquipmentBooking.BusinessLogicLayer.Interfaces;
using MusicEquipmentBooking.BusinessLogicLayer.DataTransferObjects;
using MusicEquipmentBooking.DataAcsessLayer.Interfaces;
using MusicEquipmentBooking.DataAcsessLayer.Entities;
using MusicEquipmentBooking.DataAcsessLayer.Repositories;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

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
            string validationErrorMessage;
            if (ServiceObjectDTOValidation(item, out validationErrorMessage))
            {
                return _repository.Create(_mapper.Map<ServiceObjectDTO, ServiceObject>(item));
            }
            else throw new ValidationException(validationErrorMessage);

        }


        public void Delete(int id)
        {
            var objectForDelete = _repository.Get(id) ?? throw new ArgumentException($"Объект с id:{id} не найден");
            _repository.Delete(objectForDelete);
        }


        public ServiceObjectDTO Get(int id)
        {
            var serviceObject = _repository.Get(id) ?? throw new ArgumentException($"Объект с id:{id} не найден");
            return _mapper.Map<ServiceObject, ServiceObjectDTO>(serviceObject);
        }


        public IEnumerable<ServiceObjectDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<ServiceObject>, IEnumerable<ServiceObjectDTO>>(_repository.GetAll());
        }


        public int Update(ServiceObjectDTO item)
        {
            string validationErrorMessage;
            if (ServiceObjectDTOValidation(item, out validationErrorMessage))
            {
                return _repository.Update(_mapper.Map<ServiceObjectDTO, ServiceObject>(item));
            }
            else throw new ValidationException(validationErrorMessage);
        }


        private bool ServiceObjectDTOValidation(ServiceObjectDTO serviceObject, out string errorMessage)
        {
            StringBuilder errorMessageBuilder = new StringBuilder();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(serviceObject);
            if (!Validator.TryValidateObject(serviceObject, context, results, true))
            {

                foreach (var error in results)
                {
                    errorMessageBuilder.Append($"{error.ErrorMessage}\n");
                   // Console.WriteLine(error.ErrorMessage);
                }
                errorMessage = errorMessageBuilder.ToString();
                return false;
            }
            errorMessage = "";
            return true;
        }

    }
}
