

using System.Text.RegularExpressions;
public class StringCalculator
{
  public int Add(string input)
  {
    int result = 0;

    if (string.IsNullOrEmpty(input))
    {
      result = 0;
    }
    else
    {
      result = AddNumber(input);
    }
    return result;
  }


  private int AddNumber(string input)
  {
    var numberList = DelimeterCheck(input);

    // Convert to numbers and handle empty values
    List<int> parsedNumbers = new List<int>();
    foreach (var number in numberList)
    {
      if (int.TryParse(number, out int result))
      {
        parsedNumbers.Add(result);
      }
    }

    //throw for negative numbers if any
    HandleNegative(parsedNumbers);

    // Ignore numbers greater than 1000
    var calculatableNumber = LimitCheck(parsedNumbers);
    return calculatableNumber.Sum();
  }

  private List<int> LimitCheck(List<int> parsedNumbers)
  {
    var filteredNumbers = parsedNumbers.Where(n => n <= 1000).ToList();
    return filteredNumbers;
  }

  private void HandleNegative(List<int> parsedNumbers)
  {
    var negativeNumbers = parsedNumbers.Where(n => n < 0).ToList();
    if (negativeNumbers.Any())
      throw new Exception($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
  }

  private string[] DelimeterCheck(string input)
  {
    // Custom delimiter check
    string delimiterPattern = "//(.*?)\n";
    string delimiters = ",|\n";
    if (Regex.IsMatch(input, delimiterPattern))
    {
      Match match = Regex.Match(input, delimiterPattern);
      string customDelimiter = match.Groups[1].Value;

      // Support for delimiters of any length
      customDelimiter = Regex.Escape(customDelimiter); // Escape special characters if present
      delimiters = customDelimiter;

      input = input.Substring(match.Length);
    }

    // Split by default or custom delimiters
    var numList =  Regex.Split(input, delimiters);

    return numList;
  }
}
