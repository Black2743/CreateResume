namespace CreateResume
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index= checkedListBox1.SelectedIndex;
            int count= checkedListBox1.Items.Count;
            for(int i=0; i<count; i++)
            {
                if(i!=index)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate= DateTime.Now.AddYears(-100);     //создание ограничение по минимальной дате
            dateTimePicker1.MaxDate= DateTime.Now;      //создание ограничения по максмильно возможной дате
   

           

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = checkedListBox1.SelectedIndex;
            int count = checkedListBox1.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (i != index)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }
    }
}