namespace CreateResume
{
    internal class WordHelper
    {
        private FileInfo _fileInfo;

        public WordHelper() { }
        public WordHelper(string word)
        {
            if (File.Exists(word))
            {
                _fileInfo = new FileInfo(word);

            }
        }

        internal void Process(Dictionary<string, string> items)
        {
            try
            {
                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                Object file = _fileInfo.FullName;
                Object missing = Type.Missing;
                app.Documents.Open(file);
                foreach (var item in items)
                {
                    Microsoft.Office.Interop.Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
                    Object replace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;

                    find.Execute(Type.Missing, false, false, false, missing, false, true, wrap, false, missing, replace);
                   

                }
                Object newFile = Path.Combine(_fileInfo.DirectoryName,DateTime.Now.ToString("yyyyMMdd HHmmss")+_fileInfo.Name);
                app.ActiveDocument.SaveAs2(newFile);
                app.ActiveDocument.Close();
                app.Quit();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
