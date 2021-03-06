﻿namespace EyeSoft.Test
{
	using System;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SharpTestsEx;

	[TestClass]
	public class StringExtensionsTest
	{
		private enum EnumTest
		{
			Value1,
			// ReSharper disable once UnusedMember.Local
			Value2
		}

		[TestMethod]
		public void VerifyFormatStringThatNotStartingWithSpacesUsingMnemonicsIsCorrect()
		{
			"{Drop} test1 {Create} this {Drop}"
				.NamedFormat("one", "Two")
				.Should().Be.EqualTo("one test1 Two this one");
		}

		[TestMethod]
		public void VerifyFormatStringThatStartingWithSpacesUsingMnemonicsIsCorrect()
		{
			" {Drop} test1 {Create} this {Drop}"
				.NamedFormat("one", "Two")
				.Should().Be.EqualTo(" one test1 Two this one");
		}

		[TestMethod]
		public void VerifyFormatStringThatNotStartingWithSpacesUsingNumbersIsCorrect()
		{
			"{0} test1 {1} this {0}"
				.NamedFormat("one", "Two")
				.Should().Be.EqualTo("one test1 Two this one");
		}

		[TestMethod]
		public void VerifyFormatStringThatStartingWithSpacesUsingNotAllowedMnemonicsThrow()
		{
			Executing
				.This(() => "{ Drop} test1".NamedFormat("one"))
				.Should().Throw<ArgumentException>();
		}

		[TestMethod]
		public void VerifyFormatStringWihoutSpacesThatNotStartingWithSpacesUsingMnemonicIsCorrect()
		{
			"{0}test1{1}this{0}"
				.NamedFormat("one", "Two")
				.Should().Be.EqualTo("onetest1Twothisone");
		}

		[TestMethod]
		public void NameFormatWithWrongNumberOfArgumentsThrowAnException()
		{
			Executing.This(() => "{0} {1}".NamedFormat("one"))
				.Should().Throw<ArgumentException>();
		}

		[TestMethod]
		public void VerifyParsingOfValidEnumIsCorrect()
		{
			"Value1".ToEnum<EnumTest>().Should().Be.EqualTo(EnumTest.Value1);
		}

		[TestMethod]
		public void VerifyParsingOfNotValidThrow()
		{
			Executing.This(() => "NotValidValue".ToEnum<EnumTest>()).Should().Throw<ArgumentException>();
		}

		[TestMethod]
		public void ConvertStringToByteArray()
		{
			"Hello!".ToByteArray()
				.Should().Have.SameSequenceAs(new byte[] { 72, 0, 101, 0, 108, 0, 108, 0, 111, 0, 33, 0 });
		}

		[TestMethod]
		public void ContainsInvariantLowerCaseShouldBeTrue()
		{
			"HEllo".ContainsInvariant("he").Should().Be.True();
		}

		[TestMethod]
		public void ContainsInvariantUpperCaseShouldBeTrue()
		{
			"hello".ContainsInvariant("HE").Should().Be.True();
		}

		[TestMethod]
		public void SplittedToTitleCaseIsCorrect()
		{
			@"c:\test\TWO paRts".SplittedToTitleCase('\\').Should().Be.EqualTo(@"C:\Test\Two Parts");
		}

		[TestMethod]
		public void ContainsUpperCaseShouldBeTrue()
		{
			@"c:\test\TEMP".ContainsUpperCase().Should().Be.True();
		}

		[TestMethod]
		public void ReplaceOfMultipleStrings()
		{
			"Bill,Tony!Mike".Replace(new[] { ",", "!" }, ";").Should().Be.EqualTo("Bill;Tony;Mike");
		}

		[TestMethod]
		public void ReplaceOfMultipleCharsWithNull()
		{
			"Bill,Tony!Mike".Replace(new[] { ',', '!' }).Should().Be.EqualTo("BillTonyMike");
		}

		[TestMethod]
		public void ReplaceOfMultipleCharsWithNew()
		{
			"Bill,Tony!Mike".Replace(new[] { ',', '!' }, ';').Should().Be.EqualTo("Bill;Tony;Mike");
		}
	}
}