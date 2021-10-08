using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JinyusGo.Models;

namespace JinyusGo.Services
{
    public class DojosDataStore : IDojosDataStore
    {
        private readonly List<Dojo> _dojos;

        public DojosDataStore()
        {
            _dojos = GetDojos();
        }

        private List<Dojo> GetDojos()
        {
            var dojos = new List<Dojo>
            {
                new Dojo
                {
                    Name = "North side",
                    ContactName = "Kay Schemz",
                    EmailAddress = "Kay@gmail.com",
                    Location = "123 Abc, North Side",
                    PhoneNumber = "555-123-4444",
                    ImageUrl = "northside.jpg",
                    BackgroundColor = "#b5d5c6",
                    LabelColor = "#014d37"
                },
                new Dojo
                {
                    Name = "Downtown",
                    ContactName = "Larry Tomas",
                    EmailAddress = "larry@gmail.com",
                    Location = "9 western Ave, Downtown",
                    PhoneNumber = "555-123-5555",
                    ImageUrl = "downtown.jpg",
                    BackgroundColor = "#f1eed0",
                    LabelColor = "#575213"
                },
                new Dojo
                {
                    Name = "London",
                    ContactName = "Kyu Lee",
                    EmailAddress = "kyu@gmail.com",
                    Location = "flat 6, Kingston",
                    PhoneNumber = "07765432123",
                    ImageUrl = "london.jpg",
                    BackgroundColor = "#91b0ca",
                    LabelColor = "#265e7d"
                }
            };
            
            return dojos;
        }
        
        public async Task<Dojo> GetItemAsync(string id)
        {
            return await Task.FromResult(_dojos.FirstOrDefault(d => d.Id == id));
        }

        public async Task<IEnumerable<Dojo>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_dojos);
        }

        public async Task<Dojo> GetNewestDojoAsync()
        {
            return await Task.FromResult(_dojos.LastOrDefault());
        }
    }
}