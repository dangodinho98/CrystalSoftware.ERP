using System.Threading.Tasks;

namespace CrystalSoftware.ERP.Border.Shared
{
    public interface IUseCase<TRequest, TResponse>
    {
        Task<TResponse> Execute(TRequest request);
    }
}
