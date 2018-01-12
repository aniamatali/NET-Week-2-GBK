using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gummi.Models;

namespace Gummi.Tests
{
	[TestClass]
	public class ReviewTests
	{
		[TestMethod]
		public void GetDescription_ReturnsReviewDescription_String()
		{
			//Arrange
			var review = new Review();
            review.Description = "Wash the dog";

			//Act
			var result = review.Description;

			//Assert
			Assert.AreEqual("Wash the dog", result);
		}

		[TestMethod]
        public void GetPrice_ReturnsReviewPrice_Int()
		{
			//Arrange
			var review = new Review();
			review.Price = 5;

			//Act
			var result = review.Price;

			//Assert
			Assert.AreEqual(5,result);
		}


	}
}