
public class StringCalculator
{
  public int Add(string input)
  {
    int result = 0;

    if (string.IsNullOrEmpty(input))
    {
      result = AddEmptyString(input);
    }
    else
    {
      result = AddNumber(input);
    }
    return result;
  }

  public int AddEmptyString(string input)
  {
    if (string.IsNullOrEmpty(input))
      return 0;
    return 0;
  }

  public int AddNumber(string input)
  {
    string[] numberArray = input.Split(',');

    // Parse and sum the numbers
    int sum = 0;
    foreach (var number in numberArray)
    {
      sum += int.Parse(number);
    }
    return sum;
  }
}
