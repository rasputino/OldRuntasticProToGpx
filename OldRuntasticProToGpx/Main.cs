namespace OldRuntasticProToGpx
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxSourceFile.Text = openFileDialog1.FileName;
            }
            else
            {
                textBoxSourceFile.Text = string.Empty;
            }
        }

        private void buttonOutPath_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxOutputPath.Text = folderBrowserDialog1.SelectedPath;
            }
            else
            {
                textBoxOutputPath.Text = string.Empty;
            }

        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxOutputPath.Text) || !Directory.Exists(textBoxOutputPath.Text))
            {
                textBoxOutputPath.BackColor = Color.Yellow;
                ClearAndLog("Invalid output path");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxSourceFile.Text) || !File.Exists(textBoxSourceFile.Text))
            {
                textBoxSourceFile.BackColor = Color.Yellow;
                ClearAndLog("Invalid source file");
                return;
            }

            try
            {
                Library.Converter.Convert(textBoxSourceFile.Text, textBoxOutputPath.Text);
            }
            catch(Exception ex)
            {
                ClearAndLog("Error converting data");
                AppendLog(ex.ToString());
            }
        }


        private void ClearAndLog(string msj)
        {
            listBoxFiles.Items.Clear();
            listBoxFiles.Items.Add(msj);
        }

        private void AppendLog(string msj)
        {
            listBoxFiles.Items.Add(string.Empty);
            var splittedText = msj.Split('\n');
            foreach (var line in splittedText)
            {
                listBoxFiles.Items.Add(line);
            }
        }
    }
}
