using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gummi.Models;

namespace Gummi.Tests
{
	[TestClass]
	public class ProductTests
	{
        
		[TestMethod]
		public void GetName_ReturnsProducttName_String()
		{
			//Arrange
			var product = new Product();
			product.Name = "Keyboards";

			//Act
			var result = product.Name;

			//Assert
			Assert.AreEqual("Keyboards", result);
		}

		[TestMethod]
		public void GetId_ReturnsId_Int()
		{
			//Arrange
			var product = new Product();
			product.ProductId = 2;

			//Act
			var result = product.ProductId;

			//Assert
			Assert.AreEqual(2, result);
		}

	}
}