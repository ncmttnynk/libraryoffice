using System;
using System.Collections.Generic;
public class Publisher : IEntity<Guid> {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public ICollection<Book> Books { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}