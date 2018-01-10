using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gummi.Models;

namespace Gummi.Tests
{
	[TestClass]
	public class CategoryTests
	{
        
		[TestMethod]
		public void GetName_ReturnsCategorytName_String()
		{
			//Arrange
			var category = new Category();
			category.Name = "Keyboards";

			//Act
			var result = category.Name;

			//Assert
			Assert.AreEqual("Keyboards", result);
		}

		[TestMethod]
		public void GetId_ReturnsId_Int()
		{
			//Arrange
			var category = new Category();
			category.CategoryId = 2;

			//Act
			var result = category.CategoryId;

			//Assert
			Assert.AreEqual(2, result);
		}

	}
}