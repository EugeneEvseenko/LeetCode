using System.Text.RegularExpressions;

namespace LongestCommonPrefix;
/// <summary>
/// https://leetcode.com/problems/longest-common-prefix/
/// </summary>
public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length < 1 || strs.Length > 200)
            return string.Empty;

        if (strs.Where(x => x.Length >= 200 || !Regex.IsMatch(x, "^[a-zA-Z0-9]*$")).Count() > 0)
            return string.Empty;

        var firstWord = strs.First(x => x.Length == strs.Min(x => x.Length));

        var prefix = string.Empty;
        foreach (var item in firstWord)
        {
            var tempPrefix = string.Join(string.Empty, firstWord.Take(prefix.Length + 1));
            if (strs.All(x => x.StartsWith(tempPrefix)))
            {
                prefix = tempPrefix;
                continue;
            }
            else
                break;
        }

        return prefix;
    }
}