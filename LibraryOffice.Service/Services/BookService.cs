using System;

public class BookService : BaseService<Book, Guid> {
  public BookService (IBaseRepository<Book, Guid> repository) : base (repository) { }
}