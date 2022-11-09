using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecordStore.BusinessLogic.Handlers.Commands.InStock;
using RecordStore.DataAccess.Context;
using RecordStore.DataAccess.Repositories;

namespace RecordStore.BusinessLogic.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        //context
        var context = new RecordStoreContext();
        services.AddSingleton(context);
        services.AddSingleton<DbContext>(context);
            
        //repositories
        services.AddScoped<IAlbumRepository, AlbumRepository>();
        services.AddScoped<IInStockRepository, InStockRepository>();
            
        //validators
        //services.AddScoped<IValidator<>, >();
        services.AddScoped<IValidator<AddInStockCommand>, AddInStockCommandValidator>();
        services.AddScoped<IValidator<UpdateInStockCommand>, UpdateInStockCommandValidator>();
        services.AddScoped<IValidator<DeleteInStockCommand>, DeleteInStockCommandValidator>();
    }
}
