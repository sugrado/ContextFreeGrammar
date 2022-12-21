namespace CFG_201220044.Models;

public class Symbol
{
    public string Name { get; set; }
    public IEnumerable<string> Contents;

    public Symbol(string name, IEnumerable<string> contents)
    {
        Name = name;
        Contents = contents;
    }
}
