using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RecordStore.BusinessLogic;
using RecordStore.DataAccess.Context;
using RecordStore.DataAccess.Repositories;

namespace RecordStore.BusinessLogic.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddSingleton(new RecordStoreContext());
            services.AddScoped<IInStockRepository, InStockRepository>();
            services.AddScoped<IInStocksService, InStocksService>();
        }
    }
}
