using BackendAPI.Models;
using System.Net.NetworkInformation;

namespace BackendAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            var locations = new ms_storage_location[]
            {
                new ms_storage_location { location_id = "LOC001", location_name = "Warehouse 1" },
                new ms_storage_location { location_id = "LOC002", location_name = "Warehouse 2" },
                new ms_storage_location { location_id = "LOC003", location_name = "Warehouse 3" },
                new ms_storage_location { location_id = "LOC004", location_name = "Warehouse 4" },
                new ms_storage_location { location_id = "LOC005", location_name = "Warehouse 5" }
            };

            var users = new ms_user[]
            {
                new ms_user {user_name = "jhonUmiro", password = "admin1*", is_active = false},
                new ms_user {user_name = "trisNatan", password = "admin2@", is_active = false},
                new ms_user {user_name = "hugoRess", password = "admin3#", is_active = false}
            };
            context.Database.EnsureCreated();

            // Seed data storage hanya ketika db kosong
            
            //seeding data storage locations dummy 
            if (!context.ms_storage_location.Any())
            {
                foreach (var loc in locations)
                {
                    context.ms_storage_location.Add(loc);
                }   
                
            }

            //seeding data user dummy
            if (!context.ms_user.Any())
            {
                foreach (var user in users)
                {
                    context.ms_user.Add(user);
                }

            }

            context.SaveChanges();
        }
    }
}
