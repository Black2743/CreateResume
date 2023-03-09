using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Reflection.Emit;

namespace CreateResume
{
    public partial class WorkForm : Form
    {
        Dictionary<String, String> pairs;

        bool b = true;
        public WorkForm(ref Dictionary<String, String> pairs)
        {
            InitializeComponent();
            this.pairs = pairs;

        }
        private void WorkForm_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckField.CheckedTextBoxToFillIn(textBoxCompanyExpiriense, textBoxCompanyLocation, textBoxCompanyName, textBoxWorkPosition))
            {
                Dictionary<String, String> items = null;
                if (b)
                {
                    b = false;
                    items = NewDictionaryForWork();
                    pairs = pairs.Concat(items).ToDictionary(x => x.Key, x => x.Value);
                    labelWorkPosition.Text = "Название";
                    labelCompanyName.Text = "Тип";
                    labelCompanyLocation.Text = "Специализация";
                    labelCompanyExpiriense.Text = "Местонахождение";
                    labelWorkTime.Text = "Время учебы";
                    this.Text = "Образование";
                    textBoxCompanyExpiriense.Text =" ";
                    textBoxCompanyLocation.Text = " ";
                    textBoxCompanyName.Text = " ";
                    textBoxWorkPosition.Text = " ";
                }
                else
                {
                    items = NewDictionaryForEducation();
                    var helper = new WordHelper("resume.docx");
                    pairs = pairs.Concat(items).ToDictionary(x => x.Key, x => x.Value);
                    helper.Process(pairs);
                    
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Close();
                }
            }
        }
        private Dictionary<String, String> NewDictionaryForWork()
        {
            var items = new Dictionary<String, String>()
            {
                {"<WORK_POSITION>", textBoxWorkPosition.Text},
                {"<WORK_START>", dateTimePickerWorkStar.Value.ToString("MM/yyyy") },
                {"<WORK_END>", dateTimePickerWorkEnd.Value.ToString("MM/yyyy") },
                {"<COMPANY_NAME>", textBoxCompanyName.Text },
                {"<COMPANY_LOCATION>", textBoxCompanyLocation.Text },
                {"<COMPANY_EXPIRIENSE>", textBoxCompanyExpiriense.Text },
            };

            return items;
        }
        private Dictionary<String, String> NewDictionaryForEducation()
        {
            var items = new Dictionary<String, String>()
            {
                {"<EDUCATION_NAME>", textBoxWorkPosition.Text},
                {"<EDUCATION_START>", dateTimePickerWorkStar.Value.ToString("MM/yyyy") },
                {"<EDUCATION_END>", dateTimePickerWorkEnd.Value.ToString("MM/yyyy") },
                {"<EDUCATION_TYPE>", textBoxCompanyName.Text },
                {"<EDUCATION_SPECIALIZATION>", textBoxCompanyLocation.Text },
                {"<EDUCATION_LOCATION>", textBoxCompanyExpiriense.Text },
            };
            return items;
        }

    }
}
