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

namespace CreateResume
{
    public partial class WorkForm : Form
    {
        Dictionary<String, String> pairs;
        bool b = false;
        public WorkForm(ref Dictionary<String,String> pairs)
        {
            InitializeComponent();
            this.pairs = pairs;
        }

        public WorkForm(String label1, String label2, String label3,String label4,String label5,String FormName, ref Dictionary<String, String> pairs)
        {
            InitializeComponent();
            labelWorkPosition.Text = label1;
            labelCompanyName.Text = label2;
            labelCompanyLocation.Text = label3;
            labelCompanyExpiriense.Text = label4;
            labelWorkTime.Text = label5;
            this.Text = FormName;
            this.pairs = pairs;
            this.b = true;
        }

        private void WorkForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> items=null;
            if (b)
            {
                items = NewDictionaryForWork();
                pairs = pairs.Concat(items).ToDictionary(x => x.Key, x => x.Value);
                WorkForm workForm = new WorkForm("Название", "Тип", "Специализация", "Местонахождение", "Время учебы", "Образование", ref pairs);
                workForm.Show();
                
            }
            else
            {
                items = NewDictionaryForEducation();
                var helper = new WordHelper("C:\\Users\\gadzi\\OneDrive\\Рабочий стол\\resume.docx");
                pairs = pairs.Concat(items).ToDictionary(x => x.Key, x => x.Value);
                helper.Process(pairs);
                this.Close();
            }
           
          
        }
        private Dictionary<String,String> NewDictionaryForWork()
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
