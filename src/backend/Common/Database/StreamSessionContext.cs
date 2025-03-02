using Microsoft.EntityFrameworkCore;

public class StreamSessionContext : DbContext
{
    public DbSet<StreamSession> StreamSessions { get; set; }

    public StreamSessionContext(DbContextOptions<StreamSessionContext> options)
        : base(options)
    {}
}