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
            dateTimePicker1.MaxDate = DateTime.Now;      //создание ограничени€ по максмильно возможной дате
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
        private string callOpenAI(int tokens, string input, string engine, double temperature, int topP, int frequencyPenalty, int presencePenalty)
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
                            return ("openAiKey is null. Cannot perform runtime binding.");

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
                            return ("input is null. Cannot perform runtime binding.");

                        }
                        var response = httpClient.SendAsync(request).Result;
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
                return (ex.ToString());
            }
            return "CRASH";

        }

        private bool ReadyToContinue()
        {
            if (CheckField.CheckedTextBoxToFillIn(NameSurnamePatronomic_textBox, PhoneNomber_textBox, Email_textBox) &
           CheckField.CheckedListBoxToTheSelectedElement(Country_checkedListBox, Education_checkedListBox, FillMethod_checkedListBox))
            {
                if (CheckField.CheckNSPtoCorrectFill(NameSurnamePatronomic_textBox) &
                CheckField.CheckPhoneNumber(PhoneNomber_textBox) &
                CheckField.IsValidEmail(Email_textBox))
                {
                    return true;
                }
            }
            return false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //if (ReadyToContinue())
            {
                MessageBox.Show("OK");
                var helper=new WordHelper("C:\\Users\\gadzi\\OneDrive\\–абочий стол\\resume.docx");
                var items=new Dictionary<string, string> 
                {
                    { "<NAME_SURNAME_PATRONOMIC>", NameSurnamePatronomic_textBox.Text},
                    { "<>",PhoneNomber_textBox.Text}
                };

                helper.Process(items);
            }
            //else
            {
                MessageBox.Show("NOT");
            }
            //String country = new((string?)Country_checkedListBox.SelectedItem);
            //String education = new((string?)Country_checkedListBox.SelectedItem);
            //String fillMethod = new((string?)Country_checkedListBox.SelectedItem);

            //String strMessage = "напиши резюме дл€ "+NameSurnamePatronomic_textBox.Text+" с навыками с++ java python css Mysql с неоконченным высшим образованием";
            //var answer = callOpenAI(1000, strMessage, "text-davinci-003", 0.9, 1, 0, 0);
        }



    }


}