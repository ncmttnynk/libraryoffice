using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class LibraryOfficeDbContextFactory : IDesignTimeDbContextFactory<LibraryOfficeDbContext>
{
    internal static string connectionString =
        "Server=localhost;Database=libraryoffice;User Id=sa;Password=Passw0rd*;Trust Server Certificate=true";

    public LibraryOfficeDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LibraryOfficeDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new LibraryOfficeDbContext(optionsBuilder.Options);
    }
}

public class LibraryOfficeDbContext : DbContext
{
    public LibraryOfficeDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(LibraryOfficeDbContextFactory.connectionString);
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(ca => ca.Publisher)
            .WithMany(cu => cu.Books)
            .HasForeignKey(ca => ca.PublisherId)
            .HasConstraintName("FK_PUBLISHER");

        foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes())
        {
            modelBuilder.Entity(mutableEntityType.ClrType)
                .Property("Id")
                .HasDefaultValueSql("NewId()");

            modelBuilder.Entity(mutableEntityType.ClrType)
                .Property("IsActive")
                .HasDefaultValue(true);

            modelBuilder.Entity(mutableEntityType.ClrType)
                .Property("IsDeleted")
                .HasDefaultValue(false);
        }
    }

    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Book> Books { get; set; }
}