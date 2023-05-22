namespace photoeditor
{
    partial class BinarizeDialog
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
            threshold_numeric = new NumericUpDown();
            ok_button = new Button();
            ((System.ComponentModel.ISupportInitialize)threshold_numeric).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(211, 20);
            label1.TabIndex = 0;
            label1.Text = "Select threshold for binarizing:";
            // 
            // threshold_numeric
            // 
            threshold_numeric.DecimalPlaces = 2;
            threshold_numeric.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            threshold_numeric.Location = new Point(229, 7);
            threshold_numeric.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            threshold_numeric.Name = "threshold_numeric";
            threshold_numeric.Size = new Size(75, 27);
            threshold_numeric.TabIndex = 2;
            threshold_numeric.Tag = "";
            threshold_numeric.ValueChanged += threshold_numeric_ValueChanged;
            // 
            // ok_button
            // 
            ok_button.DialogResult = DialogResult.OK;
            ok_button.Location = new Point(263, 104);
            ok_button.Name = "ok_button";
            ok_button.Size = new Size(94, 29);
            ok_button.TabIndex = 3;
            ok_button.Text = "OK";
            ok_button.UseVisualStyleBackColor = true;
            // 
            // BinarizeDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 145);
            Controls.Add(ok_button);
            Controls.Add(threshold_numeric);
            Controls.Add(label1);
            Name = "BinarizeDialog";
            Text = "Binarize";
            ((System.ComponentModel.ISupportInitialize)threshold_numeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown threshold_numeric;
        private Button ok_button;
    }
}