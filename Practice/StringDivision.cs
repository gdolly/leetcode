namespace Practice;


public class Solution {
    public string GcdOfStrings(string str1, string str2) {
        if (str1 + str2 != str2 + str1) return "";

        return str1.Substring(0,GCD(str1.Length, str2.Length));
    }
    
    static int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }
}
public static class StringDivision
{
    public static string GcdOfStrings2(string str1, string str2)
    {
        if (str1 + str2 != str2 + str1) return "";

        return str1.Substring(0,GCD(str1.Length, str2.Length));

    }
    
    static int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }
    
    public static string GcdOfStrings(string str1, string str2)
    {
        var result = "";
        if (str1.Length < str2.Length)
        {
            var temp = str1;
            str1 = str2;
            str2 = temp;
        }

        var rep2 = rep(str2);
        if (rep2 != "")
            return rep2;
        
        for (var i = 1; i <= str2.Length; i++)
        {
            if (str1.Contains(str2.Substring(0, i)))
            {
                result = str2.Substring(0, i);
            }
        }

        if (result != "" && str1.Replace(result,"") != "")
        {
            return "";
        }
        return result;
    }

    public static string rep(string str)
    {
        var result = "";
        for (int i = 0; i < str.Length; i++)
        {
            
            if (str.LastIndexOf(result+str[i]) == 0)
            {
                return result;
            }
            result += str[i];
        }

        return result;
    }
}