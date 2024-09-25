
public class StringCalculator
{
    public int Add(string input)
    {
        int result = AddEmptyString(input);
        return result; 
    }

  public int AddEmptyString(string input)
  {
      if (string.IsNullOrEmpty(input))
        {
            return 0;
        }
      return 0;
  }
}
