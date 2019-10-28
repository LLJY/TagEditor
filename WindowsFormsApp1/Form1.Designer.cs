namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.artist = new System.Windows.Forms.TextBox();
            this.album = new System.Windows.Forms.TextBox();
            this.genre = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.albumArt = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.confirm = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.file = new System.Windows.Forms.Button();
            this.folder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.songTitle = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.confirmSingle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.albumArt)).BeginInit();
            this.SuspendLayout();
            // 
            // artist
            // 
            this.artist.Location = new System.Drawing.Point(217, 32);
            this.artist.Name = "artist";
            this.artist.Size = new System.Drawing.Size(100, 20);
            this.artist.TabIndex = 0;
            // 
            // album
            // 
            this.album.Location = new System.Drawing.Point(217, 58);
            this.album.Name = "album";
            this.album.Size = new System.Drawing.Size(100, 20);
            this.album.TabIndex = 1;
            // 
            // genre
            // 
            this.genre.Location = new System.Drawing.Point(217, 84);
            this.genre.Name = "genre";
            this.genre.Size = new System.Drawing.Size(100, 20);
            this.genre.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Artist";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Album";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Genre";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // albumArt
            // 
            this.albumArt.Location = new System.Drawing.Point(12, 32);
            this.albumArt.Name = "albumArt";
            this.albumArt.Size = new System.Drawing.Size(158, 158);
            this.albumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.albumArt.TabIndex = 6;
            this.albumArt.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Album Art:";
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(340, 251);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(125, 31);
            this.confirm.TabIndex = 8;
            this.confirm.Text = "Apply All";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 251);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(308, 30);
            this.progressBar1.TabIndex = 9;
            // 
            // file
            // 
            this.file.Location = new System.Drawing.Point(192, 166);
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(125, 24);
            this.file.TabIndex = 10;
            this.file.Text = "Select File..";
            this.file.UseVisualStyleBackColor = true;
            this.file.Click += new System.EventHandler(this.file_Click);
            // 
            // folder
            // 
            this.folder.Location = new System.Drawing.Point(192, 136);
            this.folder.Name = "folder";
            this.folder.Size = new System.Drawing.Size(125, 24);
            this.folder.TabIndex = 11;
            this.folder.Text = "Select Folder..";
            this.folder.UseVisualStyleBackColor = true;
            this.folder.Click += new System.EventHandler(this.folder_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Title";
            // 
            // songTitle
            // 
            this.songTitle.Location = new System.Drawing.Point(217, 110);
            this.songTitle.Name = "songTitle";
            this.songTitle.Size = new System.Drawing.Size(100, 20);
            this.songTitle.TabIndex = 13;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(15, 196);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(155, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // confirmSingle
            // 
            this.confirmSingle.Location = new System.Drawing.Point(340, 214);
            this.confirmSingle.Name = "confirmSingle";
            this.confirmSingle.Size = new System.Drawing.Size(125, 31);
            this.confirmSingle.TabIndex = 15;
            this.confirmSingle.Text = "Apply";
            this.confirmSingle.UseVisualStyleBackColor = true;
            this.confirmSingle.Click += new System.EventHandler(this.ConfirmSingle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 294);
            this.Controls.Add(this.confirmSingle);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.songTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.folder);
            this.Controls.Add(this.file);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.albumArt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.genre);
            this.Controls.Add(this.album);
            this.Controls.Add(this.artist);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.albumArt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox artist;
        private System.Windows.Forms.TextBox album;
        private System.Windows.Forms.TextBox genre;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox albumArt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button file;
        private System.Windows.Forms.Button folder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox songTitle;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button confirmSingle;
    }
}

