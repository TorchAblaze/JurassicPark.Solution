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
  }
}