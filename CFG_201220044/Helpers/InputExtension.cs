using CFG_201220044.Models;

namespace CFG_201220044.Helpers;

public static class InputExtension
{
    public static IEnumerable<Symbol> GetSymbolsAndContents(string input)
    {
        string[] symbols = input.Split(',');
        foreach (var symbol in symbols)
        {
            string[] symbolAndContent = symbol.Split("->");
            string[] symbolContent = symbolAndContent[1].Split('|');
            yield return new(symbolAndContent[0], symbolContent.ToList());
        }
    }
}
