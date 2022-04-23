using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Laba2_OOPR.Models;
using Laba2_OOPR.Models.ModelsInit;

namespace Laba2_OOPR
{
    public partial class treatmentForm : Form
    {

        public treatmentForm(){}
        public treatmentForm(doctorForm docForm)
        {
            _docForm = docForm;
            InitializeComponent();
        }

        private doctorForm _docForm;


        public event EventHandler<string> TreatmentDescribed;

        protected void OnButtonClicked()
        {
            TreatmentDescribed?.Invoke(this, richTextBox1.Text);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
                MessageBox.Show("Випишіть лікування.");
            else
            {
                OnButtonClicked();
                //PatientWritter patienWriter = new PatientWritter();
                //patienWriter.WriteTherapy(_docForm, this);
                richTextBox1.Clear();
                this.Close();
            }
        }

    }
}
