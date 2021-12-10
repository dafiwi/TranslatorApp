using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TranslatorApp.Pages
{
    public partial class LookUpCategoryPage : Page
    {
        public List<Word> WordsDatabase { get; private set; }
        public List<Word> CategoryDatabase { get; private set; }

        public LookUpCategoryPage()
        {
            InitializeComponent();
        }

        public void LookUpCategory()
        {
            using (DataContext dataContext = new DataContext())
            {
                try
                {
                    string categoryInput = CategoryTextBox.Text;
                    WordsDatabase = dataContext.Words.ToList();

                    CategoryDatabase = WordsDatabase.Where(index => index.Category == categoryInput).ToList();

                    if (categoryInput != null)
                    {
                        CategoryList.ItemsSource = CategoryDatabase;
                    }

                    if (CategoryDatabase.Count < 1)
                    {
                        MessageBox.Show("There are no entries in this category.");
                    }
                }

                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void LookUpCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            LookUpCategory();
        }
    }
}
