using CFG_201220044.Models;

namespace CFG_201220044.Services;

public static class HandlerService
{
    public static CFGResponse HandleCFG(List<Symbol> symbolsAndContents)
    {
        HashSet<string> generatedWords = new(), duplicates = new(), contentIterator = new(symbolsAndContents[0].Contents);
        List<string> symbolNames = symbolsAndContents
            .Select(p => p.Name)
            .ToList();
        do
        {
            if (!contentIterator.Any(ci => symbolNames.Any(sn => ci.Contains(sn)))) break;
            foreach (var content in contentIterator)
            {
                bool isNonTerminal = default;
                for (int i = 0; i < content.Length; i++)
                    if (symbolNames.Contains(content[i].ToString()))
                    {
                        isNonTerminal = true;
                        var nonTerminal = symbolsAndContents.FirstOrDefault(p => p.Name == content[i].ToString());
                        foreach (var nonTerminalContent in nonTerminal.Contents)
                        {
                            string word = content[..i] + nonTerminalContent + content[(i + 1)..];
                            AddToLists(word, generatedWords, duplicates);
                        }
                    }
                if (!isNonTerminal) AddToLists(content, generatedWords, duplicates);
            }
            contentIterator = new(generatedWords);
            generatedWords.Clear();
        } while (true);
        return new(contentIterator, duplicates);
    }

    private static void AddToLists(string content, HashSet<string> generatedWords, HashSet<string> duplicateList)
    {
        if (!generatedWords.Contains(content))
            generatedWords.Add(content);
        else
            duplicateList.Add(content);
    }
}