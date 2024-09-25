using System;
using System.Collections.Generic;
using Xunit;


public class StringCalculatorAddTests
{
    [Fact]
    public void StringCalculator_EmptyString_ShouldReturnZero()
    {
        int expectedResult = 0;
        string input = "";
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.Add(input);

       Assert.Equal(expectedResult, result);
    }

  
}
