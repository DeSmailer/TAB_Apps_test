using System;

public static class TextValidator
{
    public static bool StringIsNotNullOrEmpty(string str)
    {
        if (String.IsNullOrEmpty(str))
            return true;
        return false;
    }

    public static bool StringIsNumber(string str, out int number)
    {
        bool isNumber = int.TryParse(str, out number);

        if (isNumber)
            return true;
        return false;
    }
}