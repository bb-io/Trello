using Apps.Trello.Actions;
using Apps.Trello.Models.Requests.Card;
using TrelloTests.Base;

namespace Tests.Trello
{
    [TestClass]
    public class DataSources : TestBase
    {
        [TestMethod]
        public async Task AddAtachmentToCardReturnsValues()
        {
            var action = new CardActions(InvocationContext, FileManager);

            var input = new AddAttachmentRequest
            {
                BoardId = "6620e3459331613297aa5221",
                CardId = "67adfa517138d64180ad1fa1",
                File=new Blackbird.Applications.Sdk.Common.Files.FileReference { Name= "Test.docx" },
                //Url = "https://drive.google.com/file/d/1UeQN70xnnVKBqNHqgILWsDLaEhrH8wFM/view?usp=drive_link"
            };
            var response = await action.AddAttachmentToCard(input);

            Assert.IsNotNull(response);
        }
    }
}
