namespace CFG_201220044.Models;

public class CFGResponse
{
    public CFGResponse(IEnumerable<string> words, IEnumerable<string> duplicates)
    {
        Words = words;
        Duplicates = duplicates;
    }

    public IEnumerable<string> Words { get; set; }
    public IEnumerable<string> Duplicates { get; set; }
}

