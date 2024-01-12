using DAL;
using DAL.FakeDAL;
using LogicLayer.Classes;
using LogicLayer.Controllers;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class MediaItemControllerTest
    {
        [TestMethod]
        public void AddMediaItemTest()
        {
            // Arrange
            MediaItemController mediaController = new MediaItemController(createTestRepo());
            byte[] pictureBytes = new byte[] { 1, 2, 3 };
            byte[] pictureBytes2 = new byte[] { 5, 6, 7 };

            Movie movie = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);

            // Act
            bool result = mediaController.AddMediaItem(movie, pictureBytes, pictureBytes2);

            // Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void GetAllTest()
        {
            // Arrange
            MediaItemController mediaController = new MediaItemController(createTestRepo());
            byte[] pictureBytes1 = new byte[] { 1, 2, 3 };
            byte[] pictureBytes2 = new byte[] { 4, 5, 6 };
            byte[] pictureBytes3 = new byte[] { 5, 6, 7 };
            byte[] pictureBytes4 = new byte[] { 8, 9, 1 };
            Movie movie1 = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Movie movie2 = new Movie("Interstellar", "Sci-fi masterpiece", DateTime.Now, "USA", 9.7, "Christopher Nolan", "Jonathan Nolan", 169);
            mediaController.AddMediaItem(movie1, pictureBytes1, pictureBytes3);
            mediaController.AddMediaItem(movie2, pictureBytes2, pictureBytes4);

            // Act
            MediaItem[] result = mediaController.GetAll();

            // Assert
            CollectionAssert.AreEquivalent(new MediaItem[] { movie1, movie2 }, result);
        }

        [TestMethod]
        public void GetAll_ReturnNullTest()
        {
            // Arrange
            MediaItemController mediaController = new MediaItemController(createTestRepo());
            
            //Act
            MediaItem[] result = mediaController.GetAll();

            // Assert
            CollectionAssert.AreEqual(Array.Empty<MediaItem>(), result);
        }

        [TestMethod]
        public void GetMediaItem_Test()
        {
            // Arrange
            MediaItemController mediaController = new MediaItemController(createTestRepo());
            byte[] pictureBytes1 = new byte[] { 1, 2, 3 };
            byte[] pictureBytes2 = new byte[] { 5, 6, 7 };

            Movie movie1 = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);

            //Act
            mediaController.AddMediaItem(movie1, pictureBytes1, pictureBytes2);
            MediaItem result = mediaController.GetMediaItem("Inception") ;

            //Assert
            Assert.AreEqual(movie1, result);
        }

        [TestMethod]
        public void GetMediaItem_NotFoundTest()
        {
            // Arrange
            MediaItemController mediaController = new MediaItemController(createTestRepo());
            byte[] pictureBytes1 = new byte[] { 1, 2, 3 };
            byte[] pictureBytes2 = new byte[] { 5, 6, 7 };

            Movie movie1 = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);

            //Act
            mediaController.AddMediaItem(movie1, pictureBytes1, pictureBytes2);
            MediaItem result = mediaController.GetMediaItem("Some title");

            //Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetMediaItemByIdTest()
        {
            // Arrange
            MediaItemController mediaController = new MediaItemController(createTestRepo());
            byte[] pictureBytes1 = new byte[] { 1, 2, 3 };
            byte[] pictureBytes2 = new byte[] { 5, 6, 7 };

            Movie movie1 = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);

            //Act
            mediaController.AddMediaItem(movie1, pictureBytes1, pictureBytes2);
            MediaItem result = mediaController.GetMediaItemById(1);

            //Assert
            Assert.AreEqual(movie1, result);
        }

        [TestMethod]
        public void GetMediaItemById_NotFoundTest()
        {
            // Arrange
            MediaItemController mediaController = new MediaItemController(createTestRepo());
            byte[] pictureBytes1 = new byte[] { 1, 2, 3 };
            byte[] pictureBytes2 = new byte[] { 5, 6, 7 };

            Movie movie1 = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            mediaController.AddMediaItem(movie1, pictureBytes1, pictureBytes2);

            //Act
            MediaItem result = mediaController.GetMediaItemById(34);

            //Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetAllGivenRatingsTest()
        {
            //Arrange
            MediaItemController mediaController = new MediaItemController(createTestRepo());
            byte[] pictureBytes1 = new byte[] { 1, 2, 3 };
            byte[] pictureBytes2 = new byte[] { 5, 6, 7 };
            Movie movie1 = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            movie1.SetId(1);
            movie1.AddRating(2);
            movie1.AddRating(5);
            movie1.AddRating(4);

            //Act
            mediaController.AddMediaItem(movie1, pictureBytes1, pictureBytes2);
            int[] ratings = mediaController.GetAllGivenRatings(movie1);

            //Assert
            CollectionAssert.AreEquivalent(new int[] { 2, 5, 4 }, ratings);
        }

        [TestMethod]
        public void GetAllGivenRatings_ReturnNullTest()
        {
            //Arrange
            MediaItemController mediaController = new MediaItemController(createTestRepo());
            byte[] pictureBytes1 = new byte[] { 1, 2, 3 };
            byte[] pictureBytes2 = new byte[] { 5, 6, 7 };

            Movie movie1 = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            movie1.SetId(2);

            //Act
            mediaController.AddMediaItem(movie1, pictureBytes1, pictureBytes2);
            int[] ratings = mediaController.GetAllGivenRatings(movie1);

            //Assert
            CollectionAssert.AreEquivalent(Array.Empty<int>(), ratings);
        }

        [TestMethod]
        public void GetAllGivenRatings_MediaItemNotFoundTest()
        {
            //Arrange
            MediaItemController mediaController = new MediaItemController(createTestRepo());
            MediaItem mediaItem =new Serie();
            mediaItem.SetId(2);
            //Act
            int[] ratings = mediaController.GetAllGivenRatings(mediaItem);

            //Assert
            Assert.IsNull(ratings);
        }

        [TestMethod]
        public void GetMediaItemImageByIDTest()
        {
            // Arrange
            MediaItemController mediaController = new MediaItemController(createTestRepo());
            byte[] pictureBytes1 = new byte[] { 1, 2, 3 };
            byte[] pictureBytes2 = new byte[] { 5, 6, 7 };

            Movie movie1 = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            movie1.SetId(1);
            movie1.Picture = pictureBytes1;
            mediaController.AddMediaItem(movie1, pictureBytes1, pictureBytes2);
            
            // Act
            string result = mediaController.GetMediaItemImageByID(movie1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetMediaItemImageByID_NonExistingItemTest()
        {
            // Arrange
            MediaItemController mediaController = new MediaItemController(createTestRepo());
            MediaItem mediaItem = new Movie();
            mediaItem.SetId(2);
            // Act
            string result = mediaController.GetMediaItemImageByID(mediaItem);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetMediaItemImageByID_NullPictureTest()
        {
            // Arrange
            MediaItemController mediaController = new MediaItemController(createTestRepo());
            byte[] pictureBytes1 = null;
            byte[] pictureBytes2 = null;

            Movie movie1 = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            movie1.SetId(1);
            movie1.Picture = null;
            mediaController.AddMediaItem(movie1, pictureBytes1, pictureBytes2);

            // Act
            string result = mediaController.GetMediaItemImageByID(movie1);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UpdateMediaItemTest()
        {
            // Arrange
            MediaItemController mediaController = new MediaItemController(createTestRepo());
            byte[] pictureBytes1 = new byte[] { 1, 2, 3 };
            byte[] pictureBytes2 = new byte[] { 5, 6, 7 };

            Movie movie1 = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            mediaController.AddMediaItem(movie1, pictureBytes1, pictureBytes2);

            Movie movie2 = new Movie("Interstellar", "Sci-fi masterpiece", DateTime.Now, "USA", 9.7, "Christopher Nolan", "Jonathan Nolan", 169);
            movie2.SetId(movie1.GetId());
            byte[] pictureBytes3 = new byte[] { 2, 5, 6 };
            byte[] pictureBytes4 = new byte[] { 5, 6, 0 };



            //Act
            bool result = mediaController.UpdateMediaItem(movie2, pictureBytes3, pictureBytes4);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateMediaItem_UnsuccessfulTest()
        {
            // Arrange
            MediaItemController mediaController = new MediaItemController(createTestRepo());
            byte[] pictureBytes1 = new byte[] { 1, 2, 3 };
            byte[] pictureBytes2 = new byte[] { 4, 5, 6 };

            Movie movie1 = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            movie1.SetId(2);

            //Act
            bool result = mediaController.UpdateMediaItem(movie1, pictureBytes1, pictureBytes2);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveMediaItemTest()
        {
            // Arrange
            MediaItemController mediaController = new MediaItemController(createTestRepo());
            byte[] pictureBytes1 = new byte[] { 1, 2, 3 };
            byte[] pictureBytes2 = new byte[] { 4, 5, 6 };
            byte[] pictureBytes3 = new byte[] { 2, 5, 6 };
            byte[] pictureBytes4 = new byte[] { 5, 6, 0 };
            Movie movie1 = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Movie movie2 = new Movie("Interstellar", "Sci-fi masterpiece", DateTime.Now, "USA", 5.0, "Christopher Nolan", "Jonathan Nolan", 169);
            movie1.SetId(2);
            movie2.SetId(3);

            mediaController.AddMediaItem(movie1, pictureBytes1, pictureBytes3);
            mediaController.AddMediaItem(movie2, pictureBytes2, pictureBytes4);

            //Act
            bool result = mediaController.RemoveMediaItem(movie1);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveMediaItem_NoMediaItemFoundTest()
        {
            // Arrange
            MediaItemController mediaController = new MediaItemController(createTestRepo());
            byte[] pictureBytes1 = new byte[] { 1, 2, 3 };
            byte[] pictureBytes2 = new byte[] { 4, 5, 6 };
            byte[] pictureBytes3 = new byte[] { 2, 5, 6 };
            byte[] pictureBytes4 = new byte[] { 5, 6, 0 };
            Movie movie1 = new Movie("Inception", "Mind-bending movie", DateTime.Now, "USA", 9.5, "Christopher Nolan", "Jonathan Nolan", 148);
            Movie movie2 = new Movie("Interstellar", "Sci-fi masterpiece", DateTime.Now, "USA", 9.7, "Christopher Nolan", "Jonathan Nolan", 169);
            Movie movie3 = new Movie("Interstellar", "Sci-fi masterpiece", DateTime.Now, "USA", 9.7, "Christopher Nolan", "Jonathan Nolan", 169);

            mediaController.AddMediaItem(movie1, pictureBytes1, pictureBytes3);
            mediaController.AddMediaItem(movie2, pictureBytes2, pictureBytes4);

            //Act
            bool result = mediaController.RemoveMediaItem(movie3);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RecordView()
        {

        }

        private IMediaItemDAL createTestRepo()
        {
            return new FakeMediaItemDAL();
        }
    }
}
