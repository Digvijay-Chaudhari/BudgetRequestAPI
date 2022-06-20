using BudgetRequestAPI.DataModel.Entities;

namespace BudgetRequestAPI.Services.Interface
{
    public interface ITokenService
    {
        string CreateToken(UserInfo userInfo);
    }
}
