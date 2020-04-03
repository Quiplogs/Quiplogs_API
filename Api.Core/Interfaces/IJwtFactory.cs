using Quiplogs.Core.Dto;
using System.Threading.Tasks;

namespace Quiplogs.Core.Interfaces
{
    public interface IJwtFactory
    {
        Task<Token> GenerateEncodedToken(GenerateJwtTokenRequest request);
    }
}
