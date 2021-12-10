using System;
using System.Windows;
using TranslatorApp.Pages;

namespace TranslatorApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LookUpWordButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new LookUpWordPage();
        }

        private void LookUpCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new LookUpCategoryPage();
        }

        private void AddWordButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AddWordPage();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new SettingsPage();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
