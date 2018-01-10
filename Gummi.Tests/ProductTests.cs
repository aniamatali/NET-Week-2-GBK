using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gummi.Models;

namespace Gummi.Tests
{
	[TestClass]
	public class ProductTests
	{
		[TestMethod]
		public void GetDescription_ReturnsProductDescription_String()
		{
			//Arrange
			var product = new Product();
            product.Description = "Wash the dog";

			//Act
			var result = product.Description;

			//Assert
			Assert.AreEqual("Wash the dog", result);
		}

		[TestMethod]
        public void GetPrice_ReturnsProductPrice_Int()
		{
			//Arrange
			var product = new Product();
			product.Price = 5;

			//Act
			var result = product.Price;

			//Assert
			Assert.AreEqual(5,result);
		}


	}
}