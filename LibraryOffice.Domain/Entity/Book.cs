using System;
using System.Collections.Generic;
public class Book : IEntity<Guid> {
  public Guid Id { get; set; }
  public string Title { get; set; }
  public Guid PublisherId { get; set; }
  public Publisher Publisher { get; set; }
  public bool IsActive { get; set; }
  public bool IsDeleted { get; set; }
}