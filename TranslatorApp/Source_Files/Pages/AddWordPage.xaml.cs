using System;
using System.Windows;
using System.Windows.Controls;

namespace TranslatorApp.Pages
{
    public partial class AddWordPage : Page
    {
        public AddWordPage()
        {
            InitializeComponent();
        }

        public void AddWord()
        {
            using (DataContext dataContext = new DataContext())
            {
                try
                {
                    string term = TermTextBox.Text;
                    string translation = TranslationTextBox.Text;
                    string category = CategoryTextBox.Text;

                    if (term != null && translation != null && category != null)
                    {
                        dataContext.Words.Add(new Word() { Term = term, Translation = translation, Category = category });
                        dataContext.SaveChanges();

                        MessageBox.Show($"{term} was added to the database.");

                        TermTextBox.Clear();
                        TranslationTextBox.Clear();
                        CategoryTextBox.Clear();
                    }
                }

                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void AddWordButton_Click(object sender, RoutedEventArgs e)
        {
            AddWord();
        }
    }
}
