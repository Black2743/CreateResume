using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using System.Globalization;
using System.IO;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace CreateResume
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now.AddYears(-100);     //создание ограничение по минимальной дате
            dateTimePicker1.MaxDate = DateTime.Now;      //создание ограничения по максмильно возможной дате
            dateTimePicker1.Value = DateTime.Now.AddDays(-1);
        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Education_checkedListBox.SelectedIndex;
            int count = Education_checkedListBox.Items.Count;

            for (int i = 0; i < count; i++)
            {
                if (i != index)
                {
                    Education_checkedListBox.SetItemChecked(i, false);
                }
            }
        }
        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = FillMethod_checkedListBox.SelectedIndex;
            int count = FillMethod_checkedListBox.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (i != index)
                {
                    FillMethod_checkedListBox.SetItemChecked(i, false);
                }
            }
        }
        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Country_checkedListBox.SelectedIndex;
            int count = Country_checkedListBox.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (i != index)
                {
                    Country_checkedListBox.SetItemChecked(i, false);
                }
            }
        }
        private async Task<string> callOpenAI(int tokens, string input, string engine, double temperature, int topP, int frequencyPenalty, int presencePenalty)
        {
            var openAiKey = "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";
            var apiCall = "https://api.openai.com/v1/engines/" + engine + "/completions";
            this.Hide();
         
            MessageBox.Show("ОЖИДАЙТЕ");
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), apiCall))
                    {
                        if (openAiKey != null)
                        {
                            request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + openAiKey);
                        }
                        else
                        {
                            return await System.Threading.Tasks.Task.FromResult("openAiKey is null. Cannot perform runtime binding.");

                        }
                        if (input != null)
                        {
                            request.Content = new StringContent("{\n  \"prompt\": \"" + input + "\",\n  \"temperature\": " +
                                                                temperature.ToString(CultureInfo.InvariantCulture) + ",\n  \"max_tokens\": " + tokens + ",\n  \"top_p\": " + topP +
                                                                ",\n  \"frequency_penalty\": " + frequencyPenalty + ",\n  \"presence_penalty\": " + presencePenalty + "\n}");
                            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        }
                        else
                        {
                            return await System.Threading.Tasks.Task.FromResult("input is null. Cannot perform runtime binding.");

                        }
                        var response = System.Threading.Tasks.Task.FromResult(await httpClient.SendAsync(request)).Result;
                        var json = response.Content.ReadAsStringAsync().Result;
                        dynamic dynObj = JsonConvert.DeserializeObject(json);
                        if (dynObj != null)
                        {
                            return dynObj.choices[0].text.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return await System.Threading.Tasks.Task.FromResult(ex.ToString());
            }
            return await System.Threading.Tasks.Task.FromResult("CRASH");

        }

        private bool ReadyToContinue()
        {
            if (CheckField.CheckedTextBoxToFillIn(NameSurnamePatronomic_textBox, PhoneNomber_textBox, Email_textBox) &
            CheckField.CheckedListBoxToTheSelectedElement(Country_checkedListBox, Education_checkedListBox, FillMethod_checkedListBox))
            {
                if (CheckField.CheckNSPtoCorrectFill(ref NameSurnamePatronomic_textBox) &
                CheckField.CheckPhoneNumber(ref PhoneNomber_textBox) &
                CheckField.IsValidEmail(ref Email_textBox))
                {
                    return true;
                }
            }
            return false;
        }

        public static string Show(string caption, string prompt, string defaultValue = "")
        {
            Form promptForm = new Form() { Width = 500, Height = 400 };
            promptForm.Text = caption;
            Label promptLabel = new Label() { Left = 50, Top = 20, Text = prompt };
            TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 400, Height = 200, Text = defaultValue, Multiline = true };
            Button okButton = new Button() { Text = "ОК", Left = 250, Width = 100, Height = 50, Top = 280 };
            Button cancelButton = new Button() { Text = "Отмена", Left = 360, Width = 100, Height = 50, Top = 280 };
            okButton.Click += (sender, e) => { promptForm.DialogResult = DialogResult.OK; };
            cancelButton.Click += (sender, e) => { promptForm.DialogResult = DialogResult.Cancel; };
            promptForm.Controls.Add(promptLabel);
            promptForm.Controls.Add(inputBox);
            promptForm.Controls.Add(okButton);
            promptForm.Controls.Add(cancelButton);
            promptForm.AcceptButton = okButton;
            promptForm.CancelButton = cancelButton;
            promptForm.StartPosition = FormStartPosition.CenterScreen;
            promptForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            promptForm.MaximizeBox = false;
            promptForm.MinimizeBox = false;
            string result = promptForm.ShowDialog() == DialogResult.OK ? inputBox.Text : "";
            return result;
        }
        private async void button1_Click(object sender, EventArgs e)
        {

            if (ReadyToContinue())
            {
                var items = new Dictionary<String, String>
                {
                    { "<NAME_SURNAME_PATRONOMIC>", NameSurnamePatronomic_textBox.Text},
                    { "<PHONE>",PhoneNomber_textBox.Text},
                    { "<EMAIL>",Email_textBox.Text},
                    { "<COUNTRY>",(string)Country_checkedListBox.CheckedItems[0]},
                    { "<EDUCATIO_TYPE>",(string)Education_checkedListBox.CheckedItems[0]},
                    { "<BIRTHDAY>",dateTimePicker1.Value.ToString("dd/MM/yyyy") },
                };
                String s=await MethodOfWriting((string)FillMethod_checkedListBox.CheckedItems[0]);
                if (s == null || s=="")
                {
                    return;
                }
                items.Add("<EXPIRIENSE>", s);
                WorkForm workForm = new WorkForm(ref items);
                workForm.Show();
                this.Hide();
                
            }
        }
        private String GetAllInFile(ref String filePath, ref String fileType)
        {
            String fileContent = "";
            var fileStream = File.OpenRead(filePath);
            if (fileType.Length == 4)
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }

            }
            else
            {
                Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                // Открытие файла
                Document doc = word.Documents.Open(filePath);

                // Чтение содержимого документа
                fileContent = doc.Content.Text;

                // Закрытие документа и приложения
                doc.Close();
                word.Quit();


            }

            return fileContent;
        }
        private String OpenFileDialogAndGetFileType(ref String filePath)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Document files (*.docx)|*.docx|txt files (*.txt)|*.txt|All files (*.*)|*.* ";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                }
                else
                {
                    MessageBox.Show("Вы не выбрали файл");
                    return null;
                }
                string extension = Path.GetExtension(filePath);

                return extension.ToLower();
            }

        }
        private async Task<string> WaitForResultAsync(String strMessage)
        {
            string result = await callOpenAI(1000, strMessage, "text-davinci-003", 0.9, 1, 0, 0);
            return result;
        }
        async Task<String> MethodOfWriting(String method)
        {

            int size = method.Length;
            if (size == 13)
            {
                string result = Show("Введите ваши навыки:", "Автоматически");
                String strMessage = "напиши в 3 предложения резюме для человека с навыками " + result;
                var answer = await callOpenAI(1000, strMessage, "text-davinci-003", 0.9, 1, 0, 0);
                return await System.Threading.Tasks.Task.FromResult(answer);
            }
            else if (size == 7)
            {
                string result = Show("Введите информацию о себе:", "О себе");
                return await System.Threading.Tasks.Task.FromResult(result);
            }
            String? filePath = null;
            String? fileContent = null;
            String fileType = OpenFileDialogAndGetFileType(filePath: ref filePath);
            if (fileType != null)
            {
                fileContent = GetAllInFile(filePath: ref filePath, ref fileType);
            }

            return await System.Threading.Tasks.Task.FromResult(fileContent);

        }




    }


}