using System;
using Microsoft.Extensions.DependencyInjection;

public static class RepositoryExtension {
  public static void RegisterLibraryOfficeRepos (this IServiceCollection services) {
    services.AddTransient<IBaseRepository<Book, Guid>, BookRepository> ();
    services.AddTransient<IBaseRepository<Publisher, Guid>, PublisherRepository> ();
  }
}