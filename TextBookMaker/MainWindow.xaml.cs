using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace TextBookMaker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Command for the New Book Wizard
        private void NewBook_Click(object sender, RoutedEventArgs e)
        {
            var bookWizard = new BookWizard(this);
            bookWizard.ShowDialog();
        }

        // Open the book content from .txtbook file
        private void OpenCommand(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "TextBook Files (*.txtbook)|*.txtbook"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                LoadBookContent(filePath);
            }
        }

        // Load the content from a file into RichTextBox (in RTF format)
        private void LoadBookContent(string filePath)
        {
            TextRange textRange = new TextRange(BookRichTextBox.Document.ContentStart, BookRichTextBox.Document.ContentEnd);
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                textRange.Load(fs, DataFormats.Rtf); // Load as Rich Text Format
            }
        }

        // Save the book content as .txtbook file
        private void SaveAsCommand(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "TextBook Files (*.txtbook)|*.txtbook"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                SaveBookContent(filePath);
            }
        }

        // Save the content from RichTextBox to a file (in RTF format)
        private void SaveBookContent(string filePath)
        {
            TextRange textRange = new TextRange(BookRichTextBox.Document.ContentStart, BookRichTextBox.Document.ContentEnd);
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                textRange.Save(fs, DataFormats.Rtf); // Save as Rich Text Format
            }
        }

        // Handle Bold button click - Applies bold formatting to selected text
        private void Bold_Click(object sender, RoutedEventArgs e)
        {
            if (BookRichTextBox.Selection.IsEmpty)
            {
                // Apply bold at the caret position
                BookRichTextBox.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            }
            else
            {
                // Apply bold to the selected text
                BookRichTextBox.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            }
        }

        // Handle Italic button click - Applies italic formatting to selected text
        private void Italic_Click(object sender, RoutedEventArgs e)
        {
            if (BookRichTextBox.Selection.IsEmpty)
            {
                // Apply italic at the caret position
                BookRichTextBox.Selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
            }
            else
            {
                // Apply italic to the selected text
                BookRichTextBox.Selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
            }
        }

        // Handle Underline button click - Applies underline formatting to selected text
        private void Underline_Click(object sender, RoutedEventArgs e)
        {
            if (BookRichTextBox.Selection.IsEmpty)
            {
                // Apply underline at the caret position using TextBlock.TextDecorationsProperty
                BookRichTextBox.Selection.ApplyPropertyValue(TextBlock.TextDecorationsProperty, TextDecorations.Underline);
            }
            else
            {
                // Apply underline to the selected text using TextBlock.TextDecorationsProperty
                BookRichTextBox.Selection.ApplyPropertyValue(TextBlock.TextDecorationsProperty, TextDecorations.Underline);
            }
        }

        // Handle Center button click - Centers the selected text or paragraph
        private void Center_Click(object sender, RoutedEventArgs e)
        {
            if (BookRichTextBox.Selection.IsEmpty)
            {
                // Apply center alignment at the caret position
                BookRichTextBox.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty, TextAlignment.Center);
            }
            else
            {
                // Apply center alignment to the selected text
                BookRichTextBox.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty, TextAlignment.Center);
            }
        }

        // Event handler to open the About window
        private void About_Click(object sender, RoutedEventArgs e)
        {
            var aboutWindow = new About();
            aboutWindow.ShowDialog();
        }
    }
}
