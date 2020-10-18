using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
public class LibraryOfficeDbContextFactory : IDesignTimeDbContextFactory<LibraryOfficeDbContext> {
    internal static string connectionString =
    "Host=localhost;Database=libraryoffice;Username=postgres;Password=0453;Port=5432";

    public LibraryOfficeDbContext CreateDbContext (string[] args) {
        var optionsBuilder = new DbContextOptionsBuilder<LibraryOfficeDbContext> ();
        optionsBuilder.UseNpgsql (connectionString);

        return new LibraryOfficeDbContext (optionsBuilder.Options);
    }
}

public class LibraryOfficeDbContext : DbContext {
    public LibraryOfficeDbContext (DbContextOptions options) : base (options) { }

    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
        if (!optionsBuilder.IsConfigured) {
            optionsBuilder.UseNpgsql (LibraryOfficeDbContextFactory.connectionString);
        }
        base.OnConfiguring (optionsBuilder);
    }

    protected override void OnModelCreating (ModelBuilder modelBuilder) {
        modelBuilder.HasPostgresExtension ("uuid-ossp");

        modelBuilder.Entity<Book> ()
            .HasOne (ca => ca.Publisher)
            .WithMany (cu => cu.Books)
            .HasForeignKey (ca => ca.PublisherId)
            .HasConstraintName ("FK_PUBLISHER");

        foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes ()) {

            modelBuilder.Entity (mutableEntityType.ClrType)
                .Property ("Id")
                .HasDefaultValueSql ("uuid_generate_v4()");

            modelBuilder.Entity (mutableEntityType.ClrType)
                .Property ("IsActive")
                .HasDefaultValue (true);

            modelBuilder.Entity (mutableEntityType.ClrType)
                .Property ("IsDeleted")
                .HasDefaultValue (false);
        }

    }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Book> Books { get; set; }
}