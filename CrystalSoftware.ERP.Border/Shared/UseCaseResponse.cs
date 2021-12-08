using System.Collections.Generic;

namespace CrystalSoftware.ERP.Border.Shared
{
    public class UseCaseResponse<T> : UseCaseResponse
    {
        public T Result { get; private set; }

        public UseCaseResponse()
        {
        }

        public new UseCaseResponse<T> SetSuccess()
        {
            return SetStatus(UseCaseResponseKind.Success);
        }

        public UseCaseResponse<T> SetSuccess(T result)
        {
            Result = result;
            return SetStatus(UseCaseResponseKind.Success);
        }

        public UseCaseResponse<T> SetCreated(T result)
        {
            Result = result;
            return SetStatus(UseCaseResponseKind.Created);
        }

        public new UseCaseResponse<T> SetNotFound(string errorMessage)
        {
            return SetStatus(UseCaseResponseKind.NotFound, errorMessage);
        }

        public new UseCaseResponse<T> SetBadRequest(string errorMessage)
        {
            return SetStatus(UseCaseResponseKind.BadRequest, errorMessage, null);
        }

        public new UseCaseResponse<T> SetBadRequest(string errorMessage, ErrorMessage[] errMsg)
        {
            return SetStatus(UseCaseResponseKind.BadRequest, errorMessage, errMsg);
        }

        public UseCaseResponse<T> SetInternalServerError(string errorMessage, IEnumerable<ErrorMessage> errors = null)
        {
            return SetStatus(UseCaseResponseKind.InternalServerError, errorMessage, errors);
        }

        public UseCaseResponse<T> SetUnavailable(T result)
        {
            Result = result;
            Status = UseCaseResponseKind.Unavailable;
            ErrorMessage = "Unavailable";
            return this;
        }

        private UseCaseResponse<T> SetStatus(UseCaseResponseKind status, string errorMessage = null, IEnumerable<ErrorMessage> errors = null)
        {
            Status = status;
            ErrorMessage = errorMessage;
            Errors = errors;
            return this;
        }

        public bool Success()
        {
            return ErrorMessage is null;
        }
    }
}
