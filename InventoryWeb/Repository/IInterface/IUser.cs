using InventoryLogic.Models;
using InventoryLogic.PaginationView;

namespace InventoryWeb.Repository.IInterface
{
    public interface IUser
	{
        Task<PaginationModel> GetAll(string sTerm = "", int pageNo = 1);
        Task<HttpResponseMessage> Update(Users model);
        Task<Users> GetbyId(int id);
        Task<HttpResponseMessage> Delete(Users model);
    }
}
