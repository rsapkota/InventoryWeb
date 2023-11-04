
using InventoryLogic.DataModels;
using InventoryLogic.PaginationView;
using InventoryLogic.Setting;
using InventoryLogic.ViewModel;

namespace InventoryWeb.Repository.IInterface
{
    public interface IBrand
    {
        Task<BrandPagination> GetAll(string sTerm = "", int pageNo = 1);
		Task<IList<BrandView>> BrandAll();
		Task<HttpResponseMessage> Save(Brand model);
        Task<HttpResponseMessage> Update(Brand model);
        Task<Brand> GetbyId(int id);
        Task<HttpResponseMessage> Delete(Brand model);
    }
}
