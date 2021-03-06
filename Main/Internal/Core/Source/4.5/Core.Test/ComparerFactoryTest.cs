﻿namespace EyeSoft.Test
{
	using EyeSoft.Collections.Generic;
	using EyeSoft.SharpTests.Extensions;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SharpTestsEx;

	[TestClass]
	public class ComparerFactoryTest
	{
		[TestMethod]
		public void CreateComparerFromExpression()
		{
			var comparer = ComparerFactory<Person>.Create(x => x.Age);

			comparer.Compare(new Person { Age = 1 }, new Person { Age = 1 })
				.Should().Be.Zero();
		}

		private class Person
		{
			public int Age { get; set; }
		}
	}
}