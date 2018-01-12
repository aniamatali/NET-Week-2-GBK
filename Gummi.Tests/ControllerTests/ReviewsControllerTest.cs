using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Gummi.Models;
using Gummi.Controllers;
using Moq;
using System.Linq;

namespace Gummi.Tests.ControllerTests
{

    [TestClass]
    public class ReviewsControllerTests
    {
        Mock<IReviewRepository> mock = new Mock<IReviewRepository>();

        private void DbSetup2()
        {
            mock.Setup(m => m.Reviews).Returns(new Review[]
            {
                new Review {ReviewId = 1, Description = "Wash the dog", Rating = 5 },
                new Review {ReviewId = 2, Description = "Do the dishes", Rating = 6 },
                new Review {ReviewId = 3, Description = "Sweep the floor", Rating = 7 }
            }.AsQueryable());
        }


        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult() // Confirms route returns view
        {
            //Arrange
            DbSetup2();
            ReviewsController controller = new ReviewsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexContainsModelData_List() // Confirms model as list of items
        {
            // Arrange
            DbSetup2();
            ViewResult indexView = new ReviewsController(mock.Object).Index() as ViewResult;

            // Act
            var result = indexView.ViewData.Model;

            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Review>));
        }

        [TestMethod]
        public void Mock_IndexModelContainsReviews_Collection() // Confirms presence of known entry
        {
            // Arrange
            DbSetup2();
            ReviewsController controller = new ReviewsController(mock.Object);
            Review testReview = new Review();
            testReview.Description = "Wash the dog";
            testReview.ReviewId = 1;
            testReview.Rating = 5;

            // Act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Review> collection = indexView.ViewData.Model as List<Review>;

            // Assert
            CollectionAssert.Contains(collection, testReview);
        }

        [TestMethod]
        public void Mock_PostViewResultCreate_ViewResult()
        {
            // Arrange
            Review testReview = new Review
            {
                ReviewId = 1,
                Description = "Wash the dog",
                Rating = 5
            };

            DbSetup2();
            ReviewsController controller = new ReviewsController(mock.Object);

            // Act
            var resultView = controller.Create(testReview) as ViewResult;


            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));

        }
        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            // Arrange
            Product testProduct = new Product
            {
                ProductId = 1,
                Name = "Wash the dog"
            };

            DbSetup2();
            ReviewsController controller = new ReviewsController(mock.Object);

            // Act
            var resultView = controller.Details(testProduct.ProductId) as ViewResult;
            var model = resultView.ViewData.Model as Product;

            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Product));
        }
    }
}