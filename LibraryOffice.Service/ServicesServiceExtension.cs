using System;
using Microsoft.Extensions.DependencyInjection;

public static class ServicesServiceExtension {
    public static void RegisterLibraryOfficeServices (this IServiceCollection services) {
        services.AddTransient<IBaseService<Book, Guid>, BookService> ();
        services.AddTransient<IBaseService<Publisher, Guid>, PublisherService> ();
    }
}