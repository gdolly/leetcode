namespace Practice;

public class AlternateString
{
    public static string M(string word1, string word2)
    {
        var result = "";
        var resultLength = word1.Length > word2.Length ? word2.Length : word1.Length;
        for (
            var i=0; i < resultLength; i++)
        {
            result += word1[i];
            result += word2[i];
        }

        if (word1.Length > word2.Length)
        {
            result += word1.Substring(resultLength);
        }
        else
        {
            result += word2.Substring(resultLength);
        }

        return result;
    }
}