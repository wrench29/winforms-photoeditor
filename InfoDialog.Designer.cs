using System.Drawing.Imaging;

namespace photoeditor
{
    partial class InfoDialog
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            groupBox1 = new GroupBox();
            bits_per_pixel_label = new Label();
            has_transparency_label = new Label();
            pixels_format = new Label();
            filename_label = new Label();
            path_label = new Label();
            extension_label = new Label();
            size_cm_label = new Label();
            size_px_label = new Label();
            resolution_label = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 23);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 0;
            label1.Text = "File name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 43);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 1;
            label2.Text = "Path:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 63);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 2;
            label3.Text = "Extension:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 83);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 3;
            label4.Text = "Size (px):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 123);
            label5.Name = "label5";
            label5.Size = new Size(138, 20);
            label5.TabIndex = 4;
            label5.Text = "Resolution (px/cm):";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(5, 103);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 5;
            label6.Text = "Size (cm):";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 143);
            label7.Name = "label7";
            label7.Size = new Size(119, 20);
            label7.TabIndex = 6;
            label7.Text = "Pixels format (?):";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 163);
            label8.Name = "label8";
            label8.Size = new Size(125, 20);
            label8.TabIndex = 7;
            label8.Text = "Has transparency:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 183);
            label9.Name = "label9";
            label9.Size = new Size(98, 20);
            label9.TabIndex = 8;
            label9.Text = "Bits per pixel:";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(bits_per_pixel_label);
            groupBox1.Controls.Add(has_transparency_label);
            groupBox1.Controls.Add(pixels_format);
            groupBox1.Controls.Add(filename_label);
            groupBox1.Controls.Add(path_label);
            groupBox1.Controls.Add(extension_label);
            groupBox1.Controls.Add(size_cm_label);
            groupBox1.Controls.Add(size_px_label);
            groupBox1.Controls.Add(resolution_label);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(660, 339);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Properties";
            // 
            // bits_per_pixel_label
            // 
            bits_per_pixel_label.AutoSize = true;
            bits_per_pixel_label.Location = new Point(150, 183);
            bits_per_pixel_label.Name = "bits_per_pixel_label";
            bits_per_pixel_label.Size = new Size(0, 20);
            bits_per_pixel_label.TabIndex = 17;
            // 
            // has_transparency_label
            // 
            has_transparency_label.AutoSize = true;
            has_transparency_label.Location = new Point(150, 163);
            has_transparency_label.Name = "has_transparency_label";
            has_transparency_label.Size = new Size(0, 20);
            has_transparency_label.TabIndex = 16;
            // 
            // pixels_format
            // 
            pixels_format.AutoSize = true;
            pixels_format.Location = new Point(150, 143);
            pixels_format.Name = "pixels_format";
            pixels_format.Size = new Size(0, 20);
            pixels_format.TabIndex = 15;
            // 
            // filename_label
            // 
            filename_label.AutoSize = true;
            filename_label.Location = new Point(150, 23);
            filename_label.Name = "filename_label";
            filename_label.Size = new Size(0, 20);
            filename_label.TabIndex = 14;
            // 
            // path_label
            // 
            path_label.AutoSize = true;
            path_label.Location = new Point(150, 43);
            path_label.Name = "path_label";
            path_label.Size = new Size(0, 20);
            path_label.TabIndex = 13;
            // 
            // extension_label
            // 
            extension_label.AutoSize = true;
            extension_label.Location = new Point(150, 63);
            extension_label.Name = "extension_label";
            extension_label.Size = new Size(0, 20);
            extension_label.TabIndex = 12;
            // 
            // size_cm_label
            // 
            size_cm_label.AutoSize = true;
            size_cm_label.Location = new Point(150, 103);
            size_cm_label.Name = "size_cm_label";
            size_cm_label.Size = new Size(0, 20);
            size_cm_label.TabIndex = 11;
            // 
            // size_px_label
            // 
            size_px_label.AutoSize = true;
            size_px_label.Location = new Point(150, 83);
            size_px_label.Name = "size_px_label";
            size_px_label.Size = new Size(0, 20);
            size_px_label.TabIndex = 10;
            // 
            // resolution_label
            // 
            resolution_label.AutoSize = true;
            resolution_label.Location = new Point(150, 123);
            resolution_label.Name = "resolution_label";
            resolution_label.Size = new Size(0, 20);
            resolution_label.TabIndex = 9;
            // 
            // InfoDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 363);
            Controls.Add(groupBox1);
            Name = "InfoDialog";
            Text = "Info about image";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private GroupBox groupBox1;
        private Label bits_per_pixel_label;
        private Label has_transparency_label;
        private Label pixels_format;
        private Label filename_label;
        private Label path_label;
        private Label extension_label;
        private Label size_cm_label;
        private Label size_px_label;
        private Label resolution_label;
    }
}