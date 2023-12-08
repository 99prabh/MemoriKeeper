using MemoriKeeper.Controllers;
using MemoriKeeper.Model.DatabaseContect;
using MemoriKeeper.Model.Models;

namespace MemoriKeeper.UnitTest
{
    [TestClass]
    public class DiaryentryControllerUnitTest
    {
        [TestMethod]
        public void TestForIndex()
        {
            var diaryentries = new List<Diaryentry>();

            // Arrange
            var dbContext = new MemoriKeeperContext();
            var diaryentryController = new DiaryentryController(dbContext);

            // Act
            var viewResult = diaryentryController.Index();

            // Assert
            Assert.AreEqual<ICollection<Diaryentry>>(diaryentries, diaryentries);
        }


        [TestMethod]
        public void TestForCreate()
        {
            var diaryentry = new Diaryentry();

            // Arrange
            var dbContext = new MemoriKeeperContext();
            var diaryentryController = new DiaryentryController(dbContext);

            // Act
            var viewResult = diaryentryController.Create();

            // Assert
            Assert.AreEqual<Diaryentry>(diaryentry, diaryentry);
        }

        [TestMethod]
        public void TestForDetails()
        {
            var diaryentry = new Diaryentry();

            // Arrange
            var dbContext = new MemoriKeeperContext();
            var diaryentryController = new DiaryentryController(dbContext);

            // Act
            var viewResult = diaryentryController.Details(1);

            // Assert
            Assert.AreEqual<Diaryentry>(diaryentry, diaryentry);
        }

        [TestMethod]
        public void TestForDelete()
        {
            var diaryentry = new Diaryentry();

            // Arrange
            var dbContext = new MemoriKeeperContext();
            var diaryentryController = new DiaryentryController(dbContext);

            // Act
            var viewResult = diaryentryController.Delete(1);

            // Assert
            Assert.AreEqual<Diaryentry>(diaryentry, diaryentry);
        }
    }
}