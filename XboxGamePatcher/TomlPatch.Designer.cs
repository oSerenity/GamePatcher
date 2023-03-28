using System.ComponentModel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace XboxGamePatcher
{
    partial class TomlPatch
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
      this.IsEnabled = new CheckBox();
      this.groupBox1 = new GroupBox();
      this.button1 = new Button();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.IsEnabled.Location = new Point(229, 15);
      this.IsEnabled.Name = "IsEnabled";
      this.IsEnabled.Size = new Size(96, 21);
      this.IsEnabled.TabIndex = 0;
      this.IsEnabled.Text = "Enabled";
      this.IsEnabled.UseVisualStyleBackColor = true;
      this.IsEnabled.CheckedChanged += new EventHandler(this.IsEnabled_CheckedChanged);
      this.groupBox1.Controls.Add((Control) this.button1);
      this.groupBox1.Controls.Add((Control) this.IsEnabled);
      this.groupBox1.Dock = DockStyle.Top;
      this.groupBox1.Location = new Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(450, 47);
      this.groupBox1.TabIndex = 8;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "groupBox1";
      this.button1.Location = new Point(341, 14);
      this.button1.Name = "button1";
      this.button1.Size = new Size(96, 23);
      this.button1.TabIndex = 8;
      this.button1.Text = "Poke";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.PokeButton);
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.groupBox1);
      this.Name = "TomlPatch";
      this.Size = new Size(450, 50);
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
        }

        #endregion
    private CheckBox IsEnabled;
    private Button button1;
    private ContextMenuStrip contextMenuStrip1 { get; set; }

    }
}