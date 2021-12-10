using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace TranslatorApp.Pages
{
    public partial class SettingsPage : Page
    {
        public List<Word> WordsDatabase { get; private set; }

        public SettingsPage()
        {
            InitializeComponent();
        }

        public void ExportDatabase()
        {
            using (DataContext dataContext = new DataContext())
            {
                try
                {
                    WordsDatabase = dataContext.Words.ToList();

                    if (WordsDatabase != null)
                    {
                        string fileName = @".\wordsDatabase";
                        string fileType = ".csv";
                        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);                        
                        
                        using (StreamWriter streamWriter = new StreamWriter(filePath + fileName + fileType))
                        {
                            foreach (Word word in WordsDatabase)
                            {
                                streamWriter.Write(word.Term + ",");
                                streamWriter.Write(word.Translation + ",");
                                streamWriter.Write(word.Category + "\n");
                            }
                        }
                        
                        MessageBox.Show($"The database was exported to your desktop as a {fileType} file.");
                    }
                    else
                    {
                        MessageBox.Show("There is no data to save.");
                    }
                }

                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }           
        }

        public void ImportDatabase()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                string fullFilePath = System.IO.Path.GetFullPath(openFileDialog.FileName);

                string[] wordEntries = File.ReadAllLines(fullFilePath);                

                using (DataContext dataContext = new DataContext())
                {
                    WordsDatabase = dataContext.Words.ToList();

                    char seperator = ',';

                    foreach (string wordEntry in wordEntries)
                    {
                        Console.WriteLine("Line: " + wordEntry);

                        string[] wordAttributes = wordEntry.Split(seperator);

                        dataContext.Words.Add(new Word() { Term = wordAttributes[0], Translation = wordAttributes[1], Category = wordAttributes[2] });    
                    }

                    dataContext.SaveChanges();

                    MessageBox.Show($"The content of the file {openFileDialog.FileName} was imported to your database.");
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void DeleteDatabase()
        {
            try
            {
                using (DataContext dataContext = new DataContext())
                {
                    WordsDatabase = dataContext.Words.ToList();

                    foreach (Word word in WordsDatabase)
                    {
                        dataContext.Words.Remove(word);
                    }

                    dataContext.SaveChanges();

                    MessageBox.Show($"The database was deleted.");
                }                
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }        

        private void ExportDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            ExportDatabase();
        }

        private void ImportDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            ImportDatabase();
        }       

        private void DeleteDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteDatabase();
        }
    }
}
