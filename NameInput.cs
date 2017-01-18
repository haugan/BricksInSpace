using System;
using System.Windows.Forms;

namespace BricksInSpace
{
    public partial class NameInput : Form
    {
        public string Name { get; set; }
        public static string staticName;

        public NameInput()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameInputBox.Text))
            {
                MessageBox.Show("Name can't be blank!", "Something went wrong..", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (nameInputBox.Text.Length > 3)
            {
                MessageBox.Show("Name must be less than 3 characters!", "Something went wrong..", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Name = nameInputBox.Text;
                staticName = Name;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
