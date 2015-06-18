namespace DataValidationApp
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
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.validateFunctionalityBtn = new System.Windows.Forms.Button();
            this.merchantToCheck = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(45, 32);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(205, 127);
            this.outputBox.TabIndex = 0;
            this.outputBox.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkBox1.Location = new System.Drawing.Point(267, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Print Boca";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // validateFunctionalityBtn
            // 
            this.validateFunctionalityBtn.Location = new System.Drawing.Point(267, 237);
            this.validateFunctionalityBtn.Name = "validateFunctionalityBtn";
            this.validateFunctionalityBtn.Size = new System.Drawing.Size(75, 23);
            this.validateFunctionalityBtn.TabIndex = 2;
            this.validateFunctionalityBtn.Text = "Validate Functionality";
            this.validateFunctionalityBtn.UseVisualStyleBackColor = true;
            this.validateFunctionalityBtn.Click += new System.EventHandler(this.onValidateFunctionalityBtnClick);
            // 
            // merchantToCheck
            // 
            this.merchantToCheck.Location = new System.Drawing.Point(45, 240);
            this.merchantToCheck.Name = "merchantToCheck";
            this.merchantToCheck.Size = new System.Drawing.Size(148, 20);
            this.merchantToCheck.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Desired Merchant To Validate";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 287);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.merchantToCheck);
            this.Controls.Add(this.validateFunctionalityBtn);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.outputBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox outputBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button validateFunctionalityBtn;
        private System.Windows.Forms.TextBox merchantToCheck;
        private System.Windows.Forms.Label label1;
    }
}

