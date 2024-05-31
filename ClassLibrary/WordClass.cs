using System.Runtime.InteropServices;
using Word = Microsoft.Office.Interop.Word;

namespace ClassLibrary
{
    internal class WordClass
    {
        public void ExportToWord(string text, string filePath)
        {
            Word.Application wordApp = new Word.Application();
            Word.Document document = wordApp.Documents.Add();

            try
            {
                Word.Paragraph paragraph = document.Content.Paragraphs.Add();
                paragraph.Range.Text = text;
                document.SaveAs2(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Error writing Word document", ex);
            }
            finally
            {
                document.Close();
                Marshal.FinalReleaseComObject(document);
                wordApp.Quit();
                Marshal.FinalReleaseComObject(wordApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        public string ImportFromWord(string filePath)
        {
            Word.Application wordApp = new Word.Application();
            Word.Document document = null;
            string formattedText = string.Empty;

            try
            {
                document = wordApp.Documents.Open(filePath);
                Word.Range range = document.Content;
                formattedText = range.FormattedText.Text;
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading Word document", ex);
            }
            finally
            {
                document.Close();
                Marshal.FinalReleaseComObject(document);
                wordApp.Quit();
                Marshal.FinalReleaseComObject(wordApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            return formattedText;
        }
    }
}
