using System;

public class PublisherService : BaseService<Publisher, Guid> {
  public PublisherService (IBaseRepository<Publisher, Guid> repository) : base (repository) { }
}