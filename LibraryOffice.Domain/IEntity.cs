public interface IEntity<IdType> {
    IdType Id { get; set; }
    bool IsActive { get; set; }
    bool IsDeleted { get; set; }
}