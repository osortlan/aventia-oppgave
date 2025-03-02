using Microsoft.EntityFrameworkCore;

public class StreamSessionContext : DbContext
{
    public DbSet<StreamSessionDao> StreamSessions { get; set; }

    public StreamSessionContext(DbContextOptions<StreamSessionContext> options)
        : base(options)
    {}
}