using MemoriKeeper.Controllers;
using MemoriKeeper.Model.DatabaseContect;
using MemoriKeeper.Model.Models;

namespace MemoriKeeper.UnitTest
{
    [TestClass]
    public class FileTypeControllerUnitTest
    {
        [TestMethod]
        public void TestForIndex()
        {
            List<FileType> fileTypes = new List<FileType>();

            // Arrange
            var dbContext = new MemoriKeeperContext();
            var fileTypeController = new FileTypeController(dbContext);

            // Act
            var viewResult = fileTypeController.Index();

            // Assert
            Assert.AreEqual<ICollection<FileType>>(fileTypes, fileTypes);
        }
    }
}