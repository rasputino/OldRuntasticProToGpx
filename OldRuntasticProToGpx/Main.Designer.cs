namespace OldRuntasticProToGpx
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileDialog1 = new OpenFileDialog();
            buttonChooseFile = new Button();
            textBoxSourceFile = new TextBox();
            textBoxOutputPath = new TextBox();
            buttonOutPath = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            buttonConvert = new Button();
            panelMain = new Panel();
            panelProgress = new Panel();
            listBoxFiles = new ListBox();
            progressBar1 = new ProgressBar();
            panelMain.SuspendLayout();
            panelProgress.SuspendLayout();
            SuspendLayout();
            // 
            // buttonChooseFile
            // 
            buttonChooseFile.Location = new Point(688, 22);
            buttonChooseFile.Name = "buttonChooseFile";
            buttonChooseFile.Size = new Size(100, 23);
            buttonChooseFile.TabIndex = 1;
            buttonChooseFile.Text = "Source file";
            buttonChooseFile.UseVisualStyleBackColor = true;
            buttonChooseFile.Click += buttonChooseFile_Click;
            // 
            // textBoxSourceFile
            // 
            textBoxSourceFile.Location = new Point(12, 23);
            textBoxSourceFile.Name = "textBoxSourceFile";
            textBoxSourceFile.Size = new Size(670, 23);
            textBoxSourceFile.TabIndex = 2;
            // 
            // textBoxOutputPath
            // 
            textBoxOutputPath.Location = new Point(12, 52);
            textBoxOutputPath.Name = "textBoxOutputPath";
            textBoxOutputPath.Size = new Size(670, 23);
            textBoxOutputPath.TabIndex = 4;
            // 
            // buttonOutPath
            // 
            buttonOutPath.Location = new Point(688, 51);
            buttonOutPath.Name = "buttonOutPath";
            buttonOutPath.Size = new Size(100, 23);
            buttonOutPath.TabIndex = 3;
            buttonOutPath.Text = "Output path";
            buttonOutPath.UseVisualStyleBackColor = true;
            buttonOutPath.Click += buttonOutPath_Click;
            // 
            // buttonConvert
            // 
            buttonConvert.Location = new Point(688, 81);
            buttonConvert.Name = "buttonConvert";
            buttonConvert.Size = new Size(100, 23);
            buttonConvert.TabIndex = 5;
            buttonConvert.Text = "Convert";
            buttonConvert.UseVisualStyleBackColor = true;
            buttonConvert.Click += buttonConvert_Click;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(textBoxSourceFile);
            panelMain.Controls.Add(buttonConvert);
            panelMain.Controls.Add(buttonChooseFile);
            panelMain.Controls.Add(textBoxOutputPath);
            panelMain.Controls.Add(buttonOutPath);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(800, 289);
            panelMain.TabIndex = 6;
            // 
            // panelProgress
            // 
            panelProgress.Controls.Add(listBoxFiles);
            panelProgress.Controls.Add(progressBar1);
            panelProgress.Dock = DockStyle.Bottom;
            panelProgress.Location = new Point(0, 289);
            panelProgress.Name = "panelProgress";
            panelProgress.Size = new Size(800, 161);
            panelProgress.TabIndex = 7;
            // 
            // listBoxFiles
            // 
            listBoxFiles.Dock = DockStyle.Fill;
            listBoxFiles.FormattingEnabled = true;
            listBoxFiles.ItemHeight = 15;
            listBoxFiles.Location = new Point(0, 23);
            listBoxFiles.Name = "listBoxFiles";
            listBoxFiles.Size = new Size(800, 138);
            listBoxFiles.TabIndex = 1;
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Top;
            progressBar1.Location = new Point(0, 0);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(800, 23);
            progressBar1.TabIndex = 0;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelMain);
            Controls.Add(panelProgress);
            Name = "Main";
            Text = "Old Runtastic PRO to GPX";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelProgress.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button buttonChooseFile;
        private TextBox textBoxSourceFile;
        private TextBox textBoxOutputPath;
        private Button buttonOutPath;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button buttonConvert;
        private Panel panelMain;
        private Panel panelProgress;
        private ListBox listBoxFiles;
        private ProgressBar progressBar1;
    }
}
