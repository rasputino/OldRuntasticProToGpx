using OldRuntasticProToGpx.Library;
using System.Windows.Forms;

namespace OldRuntasticProToGpx
{
    public partial class Main : Form
    {
        private readonly ILogger _logger;

        public Main()
        {
            InitializeComponent();
            _logger = new ListBoxLogger(listBoxFiles);
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
                _logger.ClearAndLog("Invalid output path");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxSourceFile.Text) || !File.Exists(textBoxSourceFile.Text))
            {
                textBoxSourceFile.BackColor = Color.Yellow;
                _logger.ClearAndLog("Invalid source file");
                return;
            }

            try
            {
                Library.Converter.Convert(textBoxSourceFile.Text, textBoxOutputPath.Text, _logger);
            }
            catch(Exception ex)
            {
                _logger.ClearAndLog("Error converting data");
                _logger.LogSplitted(ex.ToString());
            }
        }


    }
}
