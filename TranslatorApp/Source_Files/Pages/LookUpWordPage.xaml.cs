using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TranslatorApp.Pages
{
    public partial class LookUpWordPage : Page
    {
        public List<Word> WordsDatabase { get; private set; }

        public LookUpWordPage()
        {
            InitializeComponent();
        }

        public void LookUpWord()
        {
            using (DataContext dataContext = new DataContext())
            {
                try
                {
                    string termInput = TermTextBox.Text;
                    WordsDatabase = dataContext.Words.ToList();

                    Word selectedWord = WordsDatabase.Where(index => index.Term == termInput).FirstOrDefault();

                    if (selectedWord != null)
                    {
                        TermTextBox.Text = selectedWord.Term;
                        TranslationTextBox.Text = selectedWord.Translation;
                        CategoryTextBox.Text = selectedWord.Category;
                    }
                    else
                    {
                        MessageBox.Show("This word is not in the database.");
                    }
                }

                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void LookUpWordButton_Click(object sender, RoutedEventArgs e)
        {
            LookUpWord();
        }
    }
}
