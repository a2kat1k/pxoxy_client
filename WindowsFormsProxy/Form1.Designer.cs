using System.Windows.Forms;

namespace WindowsFormsProxy
{
    partial class Form1 : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.B_Get = new System.Windows.Forms.Button();
            this.B_Set = new System.Windows.Forms.Button();
            this.B_Disable = new System.Windows.Forms.Button();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // B_Get
            // 
            this.B_Get.Location = new System.Drawing.Point(111, 32);
            this.B_Get.Name = "B_Get";
            this.B_Get.Size = new System.Drawing.Size(75, 23);
            this.B_Get.TabIndex = 0;
            this.B_Get.Text = "get";
            this.B_Get.UseVisualStyleBackColor = true;
            this.B_Get.Click += new System.EventHandler(this.B_Get_Click);
            // 
            // B_Set
            // 
            this.B_Set.Location = new System.Drawing.Point(12, 32);
            this.B_Set.Name = "B_Set";
            this.B_Set.Size = new System.Drawing.Size(75, 23);
            this.B_Set.TabIndex = 1;
            this.B_Set.Text = "set";
            this.B_Set.UseVisualStyleBackColor = true;
            this.B_Set.Click += new System.EventHandler(this.B_Set_Click);
            // 
            // B_Disable
            // 
            this.B_Disable.Location = new System.Drawing.Point(209, 32);
            this.B_Disable.Name = "B_Disable";
            this.B_Disable.Size = new System.Drawing.Size(75, 23);
            this.B_Disable.TabIndex = 2;
            this.B_Disable.Text = "disable";
            this.B_Disable.UseVisualStyleBackColor = true;
            this.B_Disable.Click += new System.EventHandler(this.B_Disable_Click);
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(38, 6);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(135, 20);
            this.TextBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(179, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "PORT:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(225, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(59, 20);
            this.textBox2.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(290, 67);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.B_Disable);
            this.Controls.Add(this.B_Set);
            this.Controls.Add(this.B_Get);
            this.Controls.Add(this.TextBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Proxer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Get;
        private System.Windows.Forms.Button B_Set;
        private System.Windows.Forms.Button B_Disable;
        private System.Windows.Forms.TextBox TextBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
    }
}

