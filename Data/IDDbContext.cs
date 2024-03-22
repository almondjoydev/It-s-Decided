using Microsoft.EntityFrameworkCore;
using ItsDecidedDemo.Models;

namespace ItsDecidedDemo.Data;
public class IDDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<Poll> Polls {get;set;}
    public DbSet<PollType> PollTypes {get;set;}
    // public DbSet<PollEntry> PollEntries {get;set;}  

    public IDDbContext(DbContextOptions<IDDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<PollType>().HasData(new PollType[]
        {
            new PollType
            {
                Id = 1,
                Name = "Ranking Poll",
                Description = "Create a Poll and settle things once and for all!"
            },
            new PollType
            {
                Id = 2,
                Name = "Flip-A-Coin",
                Description = "Create a Poll and settle things once and for all!"
            },
            new PollType
            {
                Id = 3,
                Name = "Roll The Dice",
                Description = "A dice rolling simiulator"
            },
            new PollType
            {
                Id = 4,
                Name = "Pick A Number",
                Description = "The digital form of drawing straws"
            },
        });
        modelBuilder.Entity<Poll>().HasData(new Poll[]
        {
            new Poll
            {
                Id = 1,
                CustomName = "Binos Poll",
                CustomDescription = "CustomDescription",
                PIN = "3525",  
                PollTypeId = 1,
                PublicResults = false,
                TotalSubmission = 0,
            }

        }
        );
    }
}