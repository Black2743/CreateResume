using Microsoft.Office.Interop.Word;

namespace CreateResume
{
    internal class WordHelper
    {
        private FileInfo _fileInfo;

  
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
                Microsoft.Office.Interop.Word.Find find = app.Selection.Find;
                foreach (var item in items)
                {
                    if(item.Key == "<EXPIRIENSE>")
                    {
                        find.Text = "<EXPIRIENSE>";
                        find.Forward = true;
                        find.Wrap = WdFindWrap.wdFindContinue;
                        find.Format = false;
                        find.MatchCase = false;
                        find.MatchWholeWord = false;
                        find.MatchWildcards = false;
                        find.MatchSoundsLike = false;
                        find.MatchAllWordForms = false;

                        // Разбиваем очень большой текст на части
                        string[] parts = item.Value.Split(' ');
                        for (int i = 0; i < parts.Length; i++)
                        {
                            parts[i] = parts[i]+ " <EXPIRIENSE>";
                        }

                        foreach (string part in parts)
                        {
                            find.Replacement.Text = part;
                            find.Execute(Replace: WdReplace.wdReplaceOne);
                        }

                        continue;
                    }
                   
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
                    Object replace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;

                    find.Execute(Type.Missing, false, false, false, missing, false, true, wrap, false, missing, replace);
                   

                }
                Object newFile = Path.Combine(_fileInfo.DirectoryName, items["<NAME_SURNAME_PATRONOMIC>"]);
                app.ActiveDocument.SaveAs2(newFile);
                app.ActiveDocument.Close();
                app.Quit();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
