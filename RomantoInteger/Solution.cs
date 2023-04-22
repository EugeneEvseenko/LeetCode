namespace RomantoInteger;
/// <summary>
/// https://leetcode.com/problems/roman-to-integer/
/// </summary>
public class Solution
{
    protected class Symbol
    {
        public char Char { get; set; }
        public short Value { get; set; }
        public char[] SubstactIfAfter { get; set; } = Array.Empty<char>();
    }

    protected class SumbolPairs : List<Symbol>
    {
        public SumbolPairs()
        {
            this.AddRange(new []
            {
                new Symbol() { Char = 'I', Value = 1, SubstactIfAfter = new[] { 'V', 'X' } },
                new Symbol() { Char = 'V', Value = 5 },
                new Symbol() { Char = 'X', Value = 10, SubstactIfAfter = new[] { 'L', 'C' } },
                new Symbol() { Char = 'L', Value = 50 },
                new Symbol() { Char = 'C', Value = 100, SubstactIfAfter = new[] { 'D', 'M' } },
                new Symbol() { Char = 'D', Value = 500 },
                new Symbol() { Char = 'M', Value = 1000 }
            });
        }

        public bool ContainsValue(char @char, out Symbol symbol)
        {
            symbol = null;
            if (this.Exists(x => x.Char == @char))
            {
                symbol = this.First(x => x.Char == @char);
                return true;
            }

            return false;
        }

        public Symbol GetSymbol(char @char) => this.FirstOrDefault(x => x.Char == @char);
    }

    public int RomanToInt(string s)
    {
        var pairs = new SumbolPairs();
        var outputNumber = 0;
        int i = 0;
        while (i < s.Length)
        {
            if (pairs.ContainsValue(s[i], out var symbol))
            {
                if (i == s.Length) break;
                if (i < s.Length - 1 && symbol.SubstactIfAfter.Contains(s[i + 1]))
                {
                    outputNumber += pairs.GetSymbol(symbol.SubstactIfAfter.First(x => x == s[i + 1])).Value - symbol.Value;
                    i += 2;
                }
                else
                {
                    outputNumber += symbol.Value;
                    i++;
                }
            }
        }

        return outputNumber;
    }
}