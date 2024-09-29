using System;
using System.Collections.Generic;
using Xunit;


 public class StringCalculatorTest
{
  StringCalculator stringCalculator = new StringCalculator();
  [Fact]
  public void StringCalculator_EmptyString_ReturnZero()
  {
    var newTest = new Test("Testing - Empty String", "", 0);
    int result = stringCalculator.Add(Test.Input);

    Assert.Equal(Test.ExpectedOutput, result);
  }

  [Fact]
  public void StringCalculator_InputWithOnlyNewlines_ReturnsZero()
  {
    var newTest = new Test("Testing - Numbers separated by Newline", "/n/n", 0);
    int result = stringCalculator.Add(Test.Input);

    Assert.Equal(Test.ExpectedOutput, result);
  }

  [Fact]
  public void StringCalculator_MixedDelimitersWithWhitespaceInput_ReturnsZero()
  {
    var newTest = new Test("Testing - Numbers separated by Newline", "//;\\\\n\\", 0);
    int result = stringCalculator.Add(Test.Input);

    Assert.Equal(Test.ExpectedOutput, result);
  }

  [Fact]
  public void StringCalculator_SingleNumber_ReturnItself()
  {
    var newTest = new Test("Testing - Single Number", "555", 555);
    int result = stringCalculator.Add(Test.Input);

    Assert.Equal(Test.ExpectedOutput, result);
  }

  [Fact]
  public void StringCalculator_NumbersSeparatedByCommas_ReturnsSum()
  {
    var newTest = new Test("Testing - Multiple Numbers", "5,5,5", 15);
    int result = stringCalculator.Add(Test.Input);

    Assert.Equal(Test.ExpectedOutput, result);
  }

  [Fact]
  public void StringCalculator_NumbersSeparatedByNewlinesAndCommas_ReturnSum()
  {
    var newTest = new Test("Testing - Numbers separated by Newline", "5\n5,5", 15);
    int result = stringCalculator.Add(Test.Input);

    Assert.Equal(Test.ExpectedOutput, result);
  }

  [Fact]
  public void StringCalculator_NumbersGreaterThan1000_IgnoredInSum()
  {
    var newTest = new Test("Testing - Numbers separated by Newline", "5,1001", 5);
    int result = stringCalculator.Add(Test.Input);

    Assert.Equal(Test.ExpectedOutput, result);
  }

  [Fact]
  public void StringCalculator_NumbersLessThanOrEqualTo1000_IncludedInSum()
  {
    var newTest = new Test("Testing - Numbers separated by Newline", "1000, 2000, 5", 1005);
    int result = stringCalculator.Add(Test.Input);

    Assert.Equal(Test.ExpectedOutput, result);

  }

  [Fact]
  public void StringCalculator_NegativeNumber_ThrowNegativeNoException()
  {
    var newTest = new Test("Testing - Numbers separated by Newline", "1, -5", 1);
    var result = Assert.Throws<Exception>(() => stringCalculator.Add(Test.Input));
    Assert.Equal("Negatives not allowed: -5", result.Message);

  }

  [Fact]
  public void StringCalculator_MultipleNegatives_ThrowNegativeNoExceptionForAll()
  {
    var newTest = new Test("Testing - Numbers separated by Newline", "1, -5, -9", 1);
    var result = Assert.Throws<Exception>(() => stringCalculator.Add(Test.Input));
    Assert.Equal("Negatives not allowed: -5, -9", result.Message);

  }

  [Fact]
  public void StringCalculator_MultipleDelimitersIgnored_ReturnsValidSum()
  {
    var newTest = new Test("Testing - Numbers separated by Newline", "//[]\n123", 123);
    int result = stringCalculator.Add(Test.Input);

    Assert.Equal(Test.ExpectedOutput, result);
  }

  [Fact]
  public void StringCalculator_MixedNumbersDelimiters_GetSumIgnoreAllDelimeters()
  {
    var newTest = new Test("Testing - Numbers separated by Newline", "//;\n12;0,]", 12);
    int result = stringCalculator.Add(Test.Input);

    Assert.Equal(Test.ExpectedOutput, result);

  }
  
  

  }
  internal class Test
  {
    public static string TestCaseName;
    public static string Input;
    public static int ExpectedOutput;

    public Test(string testcaseName, string input, int output)
    {
      TestCaseName = testcaseName;
      Input = input;
      ExpectedOutput = output;
    }
  }
