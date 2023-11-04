using InventoryLogic.PaginationView;
using InventoryLogic.Setting;
using InventoryLogic.ViewModel;
using InventoryWeb.Repository.IInterface;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace InventoryWeb.Repository.Services
{
    public class BrandService : IBrand
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
		}
		public async Task<IList<BrandView>> BrandAll()
		{
			var views = await _httpClient.GetFromJsonAsync<IList<BrandView>>("api/Brand/BrandAll");
			return views;
		}

		public async Task<HttpResponseMessage> Delete(Brand model)
        {
            var result = await _httpClient.PostAsJsonAsync<Brand>("api/Brand/Delete", model);
            return result;
        }

        public async Task<BrandPagination> GetAll(string sTerm = "", int pageNo = 1)
        {
            var views = await _httpClient.GetFromJsonAsync<BrandPagination>($"api/Brand/GetAll/{sTerm}/{pageNo}");
            return views;
        }

        public async Task<Brand> GetbyId(int id)
        {
            return await _httpClient.GetFromJsonAsync<Brand>($"api/Brand/GetbyId/{id}");
        }

        public async Task<HttpResponseMessage> Save(Brand model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Brand/Save", model);
            return result;
        }

        public async Task<HttpResponseMessage> Update(Brand model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Brand/Update", model);
            return result;
        }
    }
}