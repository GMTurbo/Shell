﻿namespace NsShell
{
     partial class LayoutSelector
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
               this.button2 = new System.Windows.Forms.Button();
               this.button1 = new System.Windows.Forms.Button();
               this.SuspendLayout();
               // 
               // button2
               // 
               this.button2.Location = new System.Drawing.Point(12, 110);
               this.button2.Name = "button2";
               this.button2.Size = new System.Drawing.Size(123, 67);
               this.button2.TabIndex = 1;
               this.button2.Text = "&SECTIONAL Layout";
               this.button2.UseVisualStyleBackColor = true;
               this.button2.Click += new System.EventHandler(this.button2_Click);
               // 
               // button1
               // 
               this.button1.Location = new System.Drawing.Point(12, 12);
               this.button1.Name = "button1";
               this.button1.Size = new System.Drawing.Size(121, 67);
               this.button1.TabIndex = 2;
               this.button1.Text = "&REGULAR Layout";
               this.button1.UseVisualStyleBackColor = true;
               this.button1.Click += new System.EventHandler(this.button1_Click);
               // 
               // LayoutSelector
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(144, 194);
               this.Controls.Add(this.button1);
               this.Controls.Add(this.button2);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
               this.Name = "LayoutSelector";
               this.Text = "LayoutSelector";
               this.ResumeLayout(false);

          }

          #endregion

          private System.Windows.Forms.Button button2;
          private System.Windows.Forms.Button button1;
     }
}