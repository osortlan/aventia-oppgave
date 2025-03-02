using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class CreateStreamSessionHandlerTest
{
    [Fact]
    public void CreateStreamSessionCommand_should_invoke_notification()
    {
        // setup
        var options = new DbContextOptionsBuilder<StreamSessionContext>()
            .UseInMemoryDatabase(databaseName: "StreamSessionDatabase1")
            .Options;
        using var mockDb = new StreamSessionContext(options);
        
        var mockNotificationService = new Mock<INotificationService>();

        var request = new CreateStreamSessionRequest("Test Session");


        // run
        var handler = new CreateStreamSessionHandler(mockDb, mockNotificationService.Object);
        handler.Handle(request);


        // verify
        mockNotificationService.Verify(ns => ns.SendNotification(
            "session-created", 
            "new stream session created: Test Session", 
            It.IsAny<object>()), Times.Once);
    }

    [Fact]
    public void CreateStreamSessionCommand_should_enter_data_in_db()
    {
        // setup
        var options = new DbContextOptionsBuilder<StreamSessionContext>()
            .UseInMemoryDatabase(databaseName: "StreamSessionDatabase2")
            .Options;
        using var mockDb = new StreamSessionContext(options);
        
        var mockNotificationService = new Mock<INotificationService>();

        var request = new CreateStreamSessionRequest("Test Session");


        // run
        var handler = new CreateStreamSessionHandler(mockDb, mockNotificationService.Object);
        handler.Handle(request);


        // verify
        var count = mockDb.StreamSessions.Count();
        Assert.Equal(1, count);
        var streamSession = mockDb.StreamSessions.SingleOrDefault();
        Assert.NotNull(streamSession);
        Assert.Equal("Test Session", streamSession.Title);
    }
}