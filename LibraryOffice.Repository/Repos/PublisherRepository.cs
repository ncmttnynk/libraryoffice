using System;

public class PublisherRepository : BaseRepository<Publisher, Guid> {
  public PublisherRepository (LibraryOfficeDbContext dbContext) : base (dbContext) { }
}