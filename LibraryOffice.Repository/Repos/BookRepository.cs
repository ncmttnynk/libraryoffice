using System;

public class BookRepository : BaseRepository<Book, Guid> {
  public BookRepository (LibraryOfficeDbContext dbContext) : base (dbContext) { }
}