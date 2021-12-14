﻿using CrystalSoftware.ERP.Border;
using CrystalSoftware.ERP.Border.Dto.Account;
using CrystalSoftware.ERP.Border.Interfaces.UseCase;
using CrystalSoftware.ERP.Border.Repositories;
using CrystalSoftware.ERP.Border.Shared;
using CrystalSoftware.ERP.Shared.Resources;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.UseCases.Account
{
    public class EditProfileUseCase : IEditProfileUseCase
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly IFileManagerRepository _fileManagerRepository;
        private string _fileName;

        public EditProfileUseCase(IIdentityRepository identityRepository,
            IFileManagerRepository fileManagerRepository)
        {
            _identityRepository = identityRepository;
            _fileManagerRepository = fileManagerRepository;
        }

        public async Task<UseCaseResponse<ApplicationUser>> Execute(EditProfileRequest request)
        {
            var useCaseResponse = new UseCaseResponse<ApplicationUser>();
            try
            {
                if (request.File != null)
                    _fileName = _fileManagerRepository.UploadAvatarImage(request.File);

                var applicationUser = await _identityRepository.FindApplicationUserByName(request.UserName);
                if (applicationUser == null)
                    return useCaseResponse.SetBadRequest(Messages.UserNotFound);

                UpdateModalFields(ref applicationUser, request);

                var response = await _identityRepository.UpdateApplicationUser(applicationUser);
                return useCaseResponse.SetSuccess(response);
            }
            catch(ValidationException ex)
            {
                return useCaseResponse.SetBadRequest(ex.Message);
            }
            catch (Exception)
            {
                return useCaseResponse.SetInternalServerError(Messages.UserNotFound, null);
            }
        }

        private void UpdateModalFields(ref ApplicationUser applicationUser, EditProfileRequest request)
        {
            //TODO: Implementar automapper

            if (!string.IsNullOrEmpty(_fileName))
                applicationUser.Avatar = _fileName;

            applicationUser.FullName = request.FullName;
            applicationUser.PhoneNumber = request.PhoneNumber;
        }
    }
}
