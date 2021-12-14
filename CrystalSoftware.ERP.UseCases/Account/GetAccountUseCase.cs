using CrystalSoftware.ERP.Border;
using CrystalSoftware.ERP.Border.Dto.Account;
using CrystalSoftware.ERP.Border.Interfaces.UseCase;
using CrystalSoftware.ERP.Border.Repositories;
using CrystalSoftware.ERP.Border.Shared;
using CrystalSoftware.ERP.Border.Validators;
using CrystalSoftware.ERP.Shared.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.UseCases.Account
{
    public class GetAccountUseCase : IGetAccountUseCase
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly GetAccountFiltersRequestValidator _validator;

        public GetAccountUseCase(IIdentityRepository identityRepository,
            GetAccountFiltersRequestValidator validator)
        {
            _identityRepository = identityRepository;
            _validator = validator;
        }

        public async Task<UseCaseResponse<IEnumerable<ApplicationUser>>> Execute(GetAccountFiltersRequest request)
        {
            var useCaseResponse = new UseCaseResponse<IEnumerable<ApplicationUser>>();
            try
            {
                _validator.ValidateAndThrow(request);

                var applicationUser = await _identityRepository.FindApplicationUsersWithFilters(request);
                return useCaseResponse.SetSuccess(applicationUser);
            }
            catch (ValidationException e)
            {
                return useCaseResponse.SetBadRequest("", e.Errors.ToErrorMessages().ToArray());
            }
            catch (Exception ex)
            {
                return useCaseResponse.SetInternalServerError(ex.Message);
            }
        }
    }
}
