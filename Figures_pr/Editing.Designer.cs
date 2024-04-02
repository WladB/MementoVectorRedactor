
namespace Figures_pr
{
    partial class Editing
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
            this.Ok = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.WidthB = new System.Windows.Forms.HScrollBar();
            this.HeightB = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DeltaApexB = new System.Windows.Forms.HScrollBar();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Ok
            // 
            this.Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok.Location = new System.Drawing.Point(141, 400);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 0;
            this.Ok.Text = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(397, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(279, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 319);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // WidthB
            // 
            this.WidthB.Location = new System.Drawing.Point(20, 154);
            this.WidthB.Name = "WidthB";
            this.WidthB.Size = new System.Drawing.Size(218, 12);
            this.WidthB.TabIndex = 6;
            this.WidthB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar2_Scroll);
            // 
            // HeightB
            // 
            this.HeightB.Location = new System.Drawing.Point(20, 232);
            this.HeightB.Name = "HeightB";
            this.HeightB.Size = new System.Drawing.Size(218, 12);
            this.HeightB.TabIndex = 7;
            this.HeightB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Height_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Figure Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Figure Height";
            // 
            // DeltaApexB
            // 
            this.DeltaApexB.Location = new System.Drawing.Point(340, 49);
            this.DeltaApexB.Name = "DeltaApexB";
            this.DeltaApexB.Size = new System.Drawing.Size(218, 12);
            this.DeltaApexB.TabIndex = 10;
            this.DeltaApexB.Visible = false;
            this.DeltaApexB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DeltaApexB_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(418, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "DeltaApex";
            this.label3.Visible = false;
            // 
            // Editing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DeltaApexB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HeightB);
            this.Controls.Add(this.WidthB);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Ok);
            this.Name = "Editing";
            this.Text = " Editing";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Editing_FormClosed);
            this.Load += new System.EventHandler(this.Editing_Load);
            this.Shown += new System.EventHandler(this.Editing_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Editing_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Editing_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Editing_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.HScrollBar WidthB;
        private System.Windows.Forms.HScrollBar HeightB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HScrollBar DeltaApexB;
        private System.Windows.Forms.Label label3;
    }
}