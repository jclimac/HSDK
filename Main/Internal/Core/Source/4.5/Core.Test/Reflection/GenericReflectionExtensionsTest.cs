﻿namespace EyeSoft.Test.Reflection
{
	using System;

	using EyeSoft.Reflection;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SharpTestsEx;

	[TestClass]
	public class GenericReflectionExtensionsTest
	{
		[TestMethod]
		public void VerifyGenericMethodWithGenericArgumentIsCalledUsingReflection()
		{
			var called = false;
			Action<bool> a = t => called = true;

			new TypeToReflect().Invoke("Method", new[] { typeof(bool) }, a);

			called.Should().Be.True();
		}

		private class TypeToReflect
		{
			public void Method<T>(Action<T> action)
			{
				action(default(T));
			}
		}
	}
}