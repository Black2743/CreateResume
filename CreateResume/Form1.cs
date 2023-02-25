using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Headers;

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
                            return await Task.FromResult("openAiKey is null. Cannot perform runtime binding.");

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
                            return await Task.FromResult("input is null. Cannot perform runtime binding.");

                        }
                        var response =  Task.FromResult(await httpClient.SendAsync(request)).Result;
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
                return await Task.FromResult(ex.ToString());
            }
            return await Task.FromResult("CRASH");

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


        private async void button1_ClickAsync(object sender, EventArgs e)
        {

            //if (ReadyToContinue())
            //{

            //    var helper = new WordHelper("C:\\Users\\gadzi\\OneDrive\\Рабочий стол\\resume.docx");
            //    var items = new Dictionary<string, string>
            //    {
            //        { "<NAME_SURNAME_PATRONOMIC>", NameSurnamePatronomic_textBox.Text},
            //        { "<PHONE>",PhoneNomber_textBox.Text},
            //        { "<EMAIL>",Email_textBox.Text},
            //        { "<COUNTRY>",(string)Country_checkedListBox.CheckedItems[0]},
            //        { "<EDUCATIO_TYPE>",(string)Education_checkedListBox.CheckedItems[0]},
            //    };



            //helper.Process(items);
            //}
            //else
            //{
            //    MessageBox.Show("NOT");
            //}

            // MethodOfWriting(new((string?)FillMethod_checkedListBox.SelectedItem));
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            int secondsElapsed = 0;
            timer.Elapsed += (sender, e) =>
            {
                // Увеличиваем счетчик секунд на 1
                secondsElapsed++;
            };
            timer.Start();
            
            string result = Microsoft.VisualBasic.Interaction.InputBox("Введите ваши навыки:", "Автоматически");
            String strMessage = "напиши резюме для " + NameSurnamePatronomic_textBox.Text + " с навыками " + result;
            var answer = await callOpenAI(1000, strMessage, "text-davinci-003", 0.9, 1, 0, 0);
            MessageBox.Show(answer);
            timer.Stop();
            MessageBox.Show(secondsElapsed.ToString());

        }
        String OpenFileDialogAndGetFileType(ref String fileContent, ref String filePath)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Document files (*.doc,*.docx)|*.doc;*.docx|txt files (*.txt)|*.txt|All files (*.*)|*.* ";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
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
        void MethodOfWriting(String method)
        {

            int size = method.Length;
            if (size == 13)
            {
                string result = Microsoft.VisualBasic.Interaction.InputBox("Введите ваши навыки:", "Автоматически");
                String strMessage = "напиши резюме для " + NameSurnamePatronomic_textBox.Text + " с навыками " + result;
                var answer = callOpenAI(1000, strMessage, "text-davinci-003", 0.9, 1, 0, 0);

            }

            else if (size == 8)
            {
                string result = Microsoft.VisualBasic.Interaction.InputBox("Введите информацию о себе:", "О себе");
            }
            else
            {
                String? fileContent = null;
                String? filePath = null;
                String fileType = OpenFileDialogAndGetFileType(fileContent: ref fileContent, filePath: ref filePath);
                MessageBox.Show(fileContent);
                MessageBox.Show(filePath);
                MessageBox.Show(fileType);
            }

        }




    }


}