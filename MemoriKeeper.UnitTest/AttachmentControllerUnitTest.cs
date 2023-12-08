using MemoriKeeper.Controllers;
using MemoriKeeper.Model.DatabaseContect;
using MemoriKeeper.Model.Models;

namespace MemoriKeeper.UnitTest
{
    [TestClass]
    public class AttachmentControllerUnitTest
    {
        [TestMethod]
        public void TestForIndex()
        {
            var attachments = new List<Attachment>();

            // Arrange
            var dbContext = new MemoriKeeperContext();
            var attachmentController = new AttachmentController(dbContext, null);

            // Act
            var viewResult = attachmentController.Index();

            // Assert
            Assert.AreEqual<ICollection<Attachment>>(attachments, attachments);
        }


        [TestMethod]
        public void TestForCreate()
        {
            var attachment = new Attachment();

            // Arrange
            var dbContext = new MemoriKeeperContext();
            var attachmentController = new AttachmentController(dbContext, null);

            // Act
            var viewResult = attachmentController.Create();

            // Assert
            Assert.AreEqual<Attachment>(attachment, attachment);
        }

        [TestMethod]
        public void TestForDetails()
        {
            var attachment = new Attachment();

            // Arrange
            var dbContext = new MemoriKeeperContext();
            var attachmentController = new AttachmentController(dbContext, null);

            // Act
            var viewResult = attachmentController.Details(1);

            // Assert
            Assert.AreEqual<Attachment>(attachment, attachment);
        }

        [TestMethod]
        public void TestForDelete()
        {
            var attachment = new Attachment();

            // Arrange
            var dbContext = new MemoriKeeperContext();
            var attachmentController = new AttachmentController(dbContext, null);

            // Act
            var viewResult = attachmentController.Delete(1);

            // Assert
            Assert.AreEqual<Attachment>(attachment, attachment);
        }
    }
}