using CFG_201220044.Helpers;
using CFG_201220044.Models;
using CFG_201220044.Services;

namespace CFGForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RemoveLists();
            IEnumerable<Symbol> symbolsAndContents = InputExtension.GetSymbolsAndContents(textBox1.Text);
            CFGResponse cfgResponse = HandlerService.HandleCFG(symbolsAndContents.ToList());
            AddNewItemsToListBoxes(cfgResponse.Words, cfgResponse.Duplicates);
        }

        private void AddNewItemsToListBoxes(IEnumerable<string> wordsResponse, IEnumerable<string> duplicatesResponse)
        {
            foreach (var item in wordsResponse)
                generatedWords.Items.Add(item);

            foreach (var item in duplicatesResponse)
                duplicates.Items.Add(item);
        }

        private void RemoveLists()
        {
            generatedWords.Items.Clear();
            duplicates.Items.Clear();
        }
    }
}