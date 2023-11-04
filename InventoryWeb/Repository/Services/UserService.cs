using InventoryLogic.DataModels;
using InventoryLogic.Models;
using InventoryLogic.PaginationView;
using InventoryWeb.Repository.IInterface;

namespace InventoryWeb.Repository.Services
{
    public class UserService : IUser
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> Delete(Users model)
        {
            var result = await _httpClient.PostAsJsonAsync<Users>("api/User/Delete", model);
            return result;
        }
        public async Task<PaginationModel> GetAll(string sTerm = "", int pageNo = 1)
        {
            var views = await _httpClient.GetFromJsonAsync<PaginationModel>($"api/User/GetAll/{sTerm}/{pageNo}");
            return views;
        }
        public async Task<Users> GetbyId(int id)
        {
            return await _httpClient.GetFromJsonAsync<Users>($"api/User/GetbyId/{id}");
        }
        public async Task<HttpResponseMessage> Update(Users model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/User/Update", model);
            return result;
        }
    }
}