namespace EmployeeManagementWeb.Common
{
    public interface ILocalStorage
    {
        public Task SetLocalStorage(string key, string token);

        public Task<string> GetKeyFromLocalStorage(string key);

        public Task ClearLocalStorage(string key);
        public Task<bool> isUserLoggedIn();
    }
}
