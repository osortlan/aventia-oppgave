using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class CreateStreamSessionHandlerTest
{
    [Fact]
    public void CreateStreamSessionCommand_should_enter_data_in_db()
    {
        // setup
        var options = new DbContextOptionsBuilder<StreamSessionContext>()
            .UseInMemoryDatabase(databaseName: "StreamSessionDatabase")
            .Options;
        using var mockDb = new StreamSessionContext(options);
        
        var mockNotificationService = new Mock<INotificationService>();

        var request = new CreateStreamSessionRequest { title = "Test Session" };


        // run
        var handler = new CreateStreamSessionHandler(context, mockNotificationService.Object);
        handler.Handle(request);


        // verify
        mockNotificationService.Verify(ns => ns.SendNotification(
                "session-created",
                "new stream session created: Test Session",
                streamSession), Times.Once);
    }
}