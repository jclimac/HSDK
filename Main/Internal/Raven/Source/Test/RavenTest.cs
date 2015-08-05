﻿namespace EyeSoft.Data.Raven.Test
{
	using System;
	using System.Linq;

	using EyeSoft.Data.Raven.Test.Helpers;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SharpTestsEx;

	[TestClass]
	public class RavenTest
	{
		private static RavenHelper helper;

		[ClassInitialize]
		public static void ClassInitialize(TestContext context)
		{
			helper = new RavenHelper(false, "SpeedTest");
		}

		[ClassCleanup]
		public static void ClassCleanup()
		{
			helper.Dispose();
		}

		[TestMethod]
		public void SaveAnEntityAndRietrieveItCheckIsCorrect()
		{
			using (var session = helper.CreateSession())
			{
				session.Store(new Customer("1", "Bill"));
				session.SaveChanges();
			}

			Action action = () =>
				{
					using (var session = helper.CreateSession())
					{
						var customer = session.Load<Customer>("1");

						customer.Name.Should().Be.EqualTo("Bill");
					}
				};

			Enumerable.Range(1, RavenHelper.Readings).ToList().ForEach(x => action());
		}
	}
}