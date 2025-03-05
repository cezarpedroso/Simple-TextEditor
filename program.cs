using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.IO;

namespace TelerikWinFormsApp1
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        public RadForm1()
        {
            InitializeComponent();
        }

        private void radMenuItem2_Click_1(object sender, EventArgs e)
        {
            radRichTextEditor1.Text = "";
        }

        private void radMenuItem3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*) | *.* ";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filepath = openFileDialog.FileName;
                    radRichTextEditor1.Text = File.ReadAllText(filepath);
                }
            }
        }

        private void radMenuItem4_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*) | *.* ";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filepath = saveFileDialog.FileName;
                    File.WriteAllText(filepath, radRichTextEditor1.Text);

                }
            }
        }

        private void radMenuItem5_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit without saving?", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void radMenuItem7_Click(object sender, EventArgs e)
        {
            radRichTextEditor1.Cut();
        }

        private void radMenuItem8_Click(object sender, EventArgs e)
        {
            radRichTextEditor1.Copy();
        }

        private void radMenuItem9_Click(object sender, EventArgs e)
        {
            radRichTextEditor1.Paste();
        }

        private void radMenuItem11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simple Text Editor v1.0\\nDeveloped by Cezar Pedroso");
        }



        private void radLabelElement1_Click(object sender, EventArgs e)
        {
            int wordCount = radRichTextEditor1.Text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
            radLabelElement1.Text = $"Word Count: {wordCount}";
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            radRichTextEditor1.Commands.ToggleBoldCommand.Execute(null);
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            radRichTextEditor1.Commands.ToggleItalicCommand.Execute(null);

        }
    }
}
