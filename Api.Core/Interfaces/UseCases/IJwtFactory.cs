
using Api.Core.Dto;
using System.Threading.Tasks;

namespace Api.Core.Interfaces.UseCases
{
    public interface IJwtFactory
    {
        Task<Token> GenerateEncodedToken(string id, string userName, string role);
    }
}
