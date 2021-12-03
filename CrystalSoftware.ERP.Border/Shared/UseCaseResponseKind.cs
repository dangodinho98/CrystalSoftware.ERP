namespace CrystalSoftware.ERP.Border.Shared
{
    public enum UseCaseResponseKind
    {
        Success = 200,
        Created = 201,
        BadRequest = 400,
        NotFound = 404,
        InternalServerError = 500,
        Unavailable = 503
    }
}
