using System;
using System.Windows;
using System.Windows.Documents;

namespace TextBookMaker
{
    public partial class BookWizard : Window
    {
        private MainWindow _mainWindow;

        public BookWizard(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void CreateBookButton_Click(object sender, RoutedEventArgs e)
        {
            string bookName = BookNameTextBox.Text;
            string authorName = AuthorNameTextBox.Text;
            string bookDescription = BookDescriptionTextBox.Text;

            if (string.IsNullOrWhiteSpace(bookName) || string.IsNullOrWhiteSpace(authorName))
            {
                MessageBox.Show("Please enter both book name and author name.");
                return;
            }

            // Create book content and add it to the main window
            string bookContent = $"Book Name: {bookName}\nAuthor: {authorName}\nDescription: {bookDescription}\n\n";

            // Pass this content to the RichTextBox of the MainWindow
            _mainWindow.BookRichTextBox.Document.Blocks.Clear();
            _mainWindow.BookRichTextBox.Document.Blocks.Add(new Paragraph(new Run(bookContent)));

            this.Close();
        }
    }
}
