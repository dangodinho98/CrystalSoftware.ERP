using CrystalSoftware.ERP.Border.Dto;
using CrystalSoftware.ERP.Border.Interfaces.UseCase;
using CrystalSoftware.ERP.Border.Repositories;
using CrystalSoftware.ERP.Border.Shared;
using CrystalSoftware.ERP.Border.Validators;
using FluentValidation;
using System;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.UseCases.Person
{
    public class CreatePersonUseCase : ICreatePersonUseCase
    {
        private readonly IPersonRepository _personRepository;
        private readonly CreatePersonValidator _createPersonValidator;

        public CreatePersonUseCase(IPersonRepository personRepository, CreatePersonValidator validator)
        {
            _personRepository = personRepository;
            _createPersonValidator = validator;
        }

        public async Task<UseCaseResponse<CreatePersonResponse>> Execute(CreatePersonRequest request)
        {
            try
            {
                _createPersonValidator.ValidateAndThrow(request);

                var person = await _personRepository.GetById(request.Id);

                return new UseCaseResponse<CreatePersonResponse>().SetSuccess(new CreatePersonResponse());
            }
            catch (ValidationException e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
