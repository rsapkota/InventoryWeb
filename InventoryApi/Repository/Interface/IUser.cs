
using InventoryLogic.DataModels;
using InventoryLogic.Models;

namespace InventoryApi.Repository.Interface
{
	public interface IUser
	{
		Task<List<UserModel>> GetAll();
		Task<Response> Save(Users model);
		Task<Response> Update(Users model);
		Task<Users> GetById(int id);
		Task<Response> Delete(int id);
	}
}
