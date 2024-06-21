// See https://aka.ms/new-console-template for more information

using System.Collections;
using Practice;

static void DD() {
    var input = "pwwkew";
    var inputArr = input.ToArray();
    var results = new List<string>();

    var result = "";
    foreach (var chr in inputArr)
    {

        if (!result.Contains(chr.ToString()))
        {
            result += (chr.ToString());
        }
        else
        {
            results.Add(string.Join("", result));

            var indexOf = result.IndexOf(chr.ToString());

            result = result.Substring(indexOf + 1);
            result += (chr.ToString());
            //result.Clear();
        }
    }

    results.Add(string.Join("", result));
    var max = results.Max(x => x.Length);
    Console.WriteLine(max);
    
    // --------------------------------------------------------------------------------
    var strs = new List<string>()
    {
        "flower",
        "flow",
        "flight"
    };
    var result2 = "";
    var resultMaxSize = strs.MinBy(x => x.Length).Length ;
    for (int i = 0; i <= resultMaxSize; i++)
    {
        var temp = strs[0][i];
        foreach (var str in strs)
        {
            if (str[i] != temp)
            {
                break;
            } 
        }

        result2 += temp;
    }
}

