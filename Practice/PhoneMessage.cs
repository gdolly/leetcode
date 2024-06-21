using System.Collections;

namespace Practice;

public class PhoneMessage
{
    public static List<string> combinations(string input)
    {
        var results = new string[]{};
        var keys = new Dictionary<int, string[]>()
        {
            { 2, new string[]{"a","b","c"}},
            { 3, new string[]{"d","e","f"}},
            { 4, new string[]{"g","h","i"}},
            { 5, ["j","k","l"] },
            { 6, new string[]{"m","n","o"}},
            { 7, new string[]{"p","q","r", "s"}},
            { 8, new string[]{"t","u", "v"}},
            { 9, new string[]{"w","x", "y", "z"}},
        };
        
        var dd = input.ToArray().Select(x => x.ToString()).ToList();
        return combination(dd, new List<string>(), keys);
    }

    static List<string>  combination(List<string> input, List<string> result, Dictionary<int, string[]> keys )
    {
        var n = int.Parse(input.First());
        var group = keys[n];
        input.RemoveAt(0);

        if (result.Count == 0)
        {
            result = new List<string>(group);
        }

        if (input.Count == 0)
        {
            return result;
        }

        result = group.SelectMany(alpha => result.Select(x => x + alpha).ToList()).ToList();
        

         result.ToList().AddRange(combination(input, result, keys));
         return result;
    }
   
}