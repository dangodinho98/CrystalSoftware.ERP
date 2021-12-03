using System.Collections.Generic;

namespace CrystalSoftware.ERP.Border.Shared
{
    public class UseCaseResponse : IResponse
    {
        public string ErrorMessage { get; set; }
        public IEnumerable<ErrorMessage> Errors { get; set; }
        public UseCaseResponseKind Status { get; set; }

        public UseCaseResponse SetSuccess()
        {
            return SetStatus(UseCaseResponseKind.Success);
        }

        public UseCaseResponse SetCreated()
        {
            return SetStatus(UseCaseResponseKind.Created);
        }

        public UseCaseResponse SetNotFound(string errorMessage)
        {
            return SetStatus(UseCaseResponseKind.NotFound, errorMessage);
        }

        public UseCaseResponse SetInternalServerError(string errorMessage, ErrorMessage[] errors)
        {
            return SetStatus(UseCaseResponseKind.InternalServerError, errorMessage, errors);
        }

        public UseCaseResponse SetBadRequest(string errorMessage)
        {
            return SetStatus(UseCaseResponseKind.BadRequest, errorMessage);
        }

        public UseCaseResponse SetBadRequest(string errorMessage, ErrorMessage[] errors)
        {
            return SetStatus(UseCaseResponseKind.BadRequest, errorMessage, errors);
        }

        private UseCaseResponse SetStatus(UseCaseResponseKind status, string errorMessage = null, IEnumerable<ErrorMessage> errors = null)
        {
            Status = status;
            ErrorMessage = errorMessage;
            Errors = errors;
            return this;
        }
    }
}
