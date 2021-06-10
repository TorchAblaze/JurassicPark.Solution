using Microsoft.EntityFrameworkCore;

namespace JurassicPark.Models
{
  public class JurassicParkContext : DbContext
  {
    public JurassicParkContext(DbContextOptions<JurassicParkContext> options)
      : base(options)
    {   
    }

    public DbSet<Dinosaur> Dinosaurs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Dinosaur>()
        .HasData(
          new Dinosaur { DinosaurId = 1, Name = "Matilda", Species = "Dinosaur", Age = 7, Gender = "Female" },
          new Dinosaur { DinosaurId = 2, Name = "Rex", Species = "Dinosaur", Age = 10, Gender = "Female" },
          new Dinosaur { DinosaurId = 3, Name = "Trey Ceratops", Age = 2, Gender = "Female" },
          new Dinosaur { DinosaurId = 4, Name = "Pip", Species = "Dinosaur", Age = 4, Gender = "Male" },
          new Dinosaur { DinosaurId = 5, Name = "Bartholomew", Species = "Dinosaur", Age = 22, Gender = "Male" }
        );
    }
  }
}