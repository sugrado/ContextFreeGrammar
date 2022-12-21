using CFG_201220044.Helpers;
using CFG_201220044.Models;
using CFG_201220044.Services;

Console.WriteLine("Sembolleri ve içeriklerini girin. Boş küme elemanı için boşluk(space) kullanabilirsiniz:");
string inputString = Console.ReadLine();

IEnumerable<Symbol> symbolsAndContents = InputExtension.GetSymbolsAndContents(inputString);
CFGResponse cfgResponse = HandlerService.HandleCFG(symbolsAndContents.ToList());

Console.WriteLine($"{Environment.NewLine}Kelimeler:");
foreach (var words in cfgResponse.Words)
    Console.WriteLine(words);

Console.WriteLine($"{Environment.NewLine}Tekrar Eden Kelimeler:");
foreach (var duplicateWord in cfgResponse.Duplicates)
    Console.WriteLine(duplicateWord);
Console.ReadLine();