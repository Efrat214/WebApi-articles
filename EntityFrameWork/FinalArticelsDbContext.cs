using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWork;

public partial class FinalArticelsDbContext : DbContext
{
    public FinalArticelsDbContext()
    {
    }

    public FinalArticelsDbContext(DbContextOptions<FinalArticelsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArticaleToUser> ArticaleToUsers { get; set; }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VocabularyToAriacle> VocabularyToAriacles { get; set; }

    public virtual DbSet<WordToCategory> WordToCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=final_articelsDB;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArticaleToUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__articale__3213E83F2B51EFB4");

            entity.ToTable("articaleToUser");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Articale).HasColumnName("articale");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.ArticaleNavigation).WithMany(p => p.ArticaleToUsers)
                .HasForeignKey(d => d.Articale)
                .HasConstraintName("FK__articaleT__artic__32E0915F");

            entity.HasOne(d => d.User).WithMany(p => p.ArticaleToUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__articaleT__userI__31EC6D26");
        });

        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Articles__3213E83F566CD8A3");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Link).HasColumnName("link");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Articles)
                .HasForeignKey(d => d.Category)
                .HasConstraintName("FK__Articles__catego__276EDEB3");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3213E83F4B00CA2F");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.NumArticals).HasColumnName("numArticals");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Levels__3213E83FA4CCB198");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.NumOfWords).HasColumnName("numOfWords");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83FE5ABD38C");

            entity.HasIndex(e => e.Mail, "UQ__Users__7A212904B364FC9F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsAdmin)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isAdmin");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Mail)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");

            entity.HasOne(d => d.LevelNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Level)
                .HasConstraintName("FK__Users__level__2B3F6F97");
        });

        modelBuilder.Entity<VocabularyToAriacle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vocabula__3213E83F41D38C51");

            entity.ToTable("VocabularyToAriacle");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Articale).HasColumnName("articale");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Word)
                .HasMaxLength(30)
                .HasColumnName("word");

            entity.HasOne(d => d.ArticaleNavigation).WithMany(p => p.VocabularyToAriacles)
                .HasForeignKey(d => d.Articale)
                .HasConstraintName("FK__Vocabular__artic__35BCFE0A");

            entity.HasOne(d => d.LevelNavigation).WithMany(p => p.VocabularyToAriacles)
                .HasForeignKey(d => d.Level)
                .HasConstraintName("FK__Vocabular__level__36B12243");
        });

        modelBuilder.Entity<WordToCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__wordToCa__3213E83F801A3545");

            entity.ToTable("wordToCategory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Frequency).HasColumnName("frequency");
            entity.Property(e => e.Word)
                .HasMaxLength(30)
                .HasColumnName("word");

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.WordToCategories)
                .HasForeignKey(d => d.Category)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__wordToCat__categ__2F10007B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
