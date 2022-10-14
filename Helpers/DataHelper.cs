using Net6AddressBook.Data;
using Microsoft.EntityFrameworkCore;

namespace Net6AddressBook.Helpers
{
    public static class DataHelper
    {
        public static async Task ManageDataAsync(IServiceProvider svcProvider)
        {
            //get an instance of the db application context
            var dbContextSvc = svcProvider.GetRequiredService<ApplicationDbContext>();
            
            //migration: this is equivalent to update-database
            await dbContextSvc.Database.MigrateAsync();
        }
    }
}
