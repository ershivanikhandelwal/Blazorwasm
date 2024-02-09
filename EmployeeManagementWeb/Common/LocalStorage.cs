using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagementWeb.Common
{
    public class LocalStorage: ILocalStorage
    {
        public bool isLoginin { get; set; }
        public ILocalStorageService _localStorage { get; set; }
        public LocalStorage(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task SetLocalStorage(string key ,string token)
        {
            await _localStorage.SetItemAsync("isLoginin", true);
			await _localStorage.SetItemAsStringAsync(key, token);
        }

        public async Task<string> GetKeyFromLocalStorage(string key)
        {
            return await _localStorage.GetItemAsStringAsync(key);
        }

        public async Task ClearLocalStorage(string key)
        {
            await _localStorage.RemoveItemAsync("isLoginin");
			await _localStorage.RemoveItemAsync(key);
        }

        public async Task<bool> isUserLoggedIn()
        {
			bool response=await _localStorage.GetItemAsync<bool>("isLoginin");
            if (response)
                return true;
            else return false;
		}
	}
}
