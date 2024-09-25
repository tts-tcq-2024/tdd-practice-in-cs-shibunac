using System;
using System.Collections.Generic;
using Xunit;


public class StringCalculatorTest
{
  StringCalculator stringCalculator = new StringCalculator();
  [Fact]
  public void StringCalculator_EmptyString_ShouldReturnZero()
  {
    var newTest = new Test("Testing - Empty String", "", 0);
    int result = stringCalculator.Add(Test.Input);

    Assert.Equal(Test.ExpectedOutput, result);
  }

  [Fact]
  public void StringCalculator_SingleNumber_ShouldReturnItself()
  {
    var newTest = new Test("Testing - Empty String", "555", 555);
    int result = stringCalculator.Add(Test.Input);

    Assert.Equal(Test.ExpectedOutput, result);
  }

  [Fact]
  public void StringCalculator_TwoOrMoreNumbersSeparatedByComma_ShouldReturnSum()
  {
    var newTest = new Test("Testing - Empty String", "5,5,5", 15);
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
