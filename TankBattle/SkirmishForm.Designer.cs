namespace TankBattle
{
    partial class SkirmishForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkirmishForm));
            this.displayPanel = new System.Windows.Forms.Panel();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_power = new System.Windows.Forms.Label();
            this.trackBar_power = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_Power = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_windSpeed = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_player = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_power)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Power)).BeginInit();
            this.SuspendLayout();
            // 
            // displayPanel
            // 
            this.displayPanel.Location = new System.Drawing.Point(0, 30);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(800, 554);
            this.displayPanel.TabIndex = 0;
            this.displayPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.displayPanel_Paint);
            // 
            // controlPanel
            // 
            this.controlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlPanel.BackColor = System.Drawing.Color.OrangeRed;
            this.controlPanel.Controls.Add(this.button1);
            this.controlPanel.Controls.Add(this.lb_power);
            this.controlPanel.Controls.Add(this.trackBar_power);
            this.controlPanel.Controls.Add(this.label6);
            this.controlPanel.Controls.Add(this.numericUpDown_Power);
            this.controlPanel.Controls.Add(this.label5);
            this.controlPanel.Controls.Add(this.comboBox1);
            this.controlPanel.Controls.Add(this.label4);
            this.controlPanel.Controls.Add(this.lb_windSpeed);
            this.controlPanel.Controls.Add(this.label2);
            this.controlPanel.Controls.Add(this.lb_player);
            this.controlPanel.Enabled = false;
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(800, 30);
            this.controlPanel.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(698, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Fire!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_power
            // 
            this.lb_power.AutoSize = true;
            this.lb_power.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_power.Location = new System.Drawing.Point(666, 9);
            this.lb_power.Name = "lb_power";
            this.lb_power.Size = new System.Drawing.Size(21, 15);
            this.lb_power.TabIndex = 9;
            this.lb_power.Text = "20";
            // 
            // trackBar_power
            // 
            this.trackBar_power.LargeChange = 10;
            this.trackBar_power.Location = new System.Drawing.Point(511, 0);
            this.trackBar_power.Maximum = 100;
            this.trackBar_power.Minimum = 5;
            this.trackBar_power.Name = "trackBar_power";
            this.trackBar_power.Size = new System.Drawing.Size(130, 45);
            this.trackBar_power.TabIndex = 8;
            this.trackBar_power.Value = 5;
            this.trackBar_power.ValueChanged += new System.EventHandler(this.trackBar_power_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(462, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Power:";
            // 
            // numericUpDown_Power
            // 
            this.numericUpDown_Power.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_Power.Location = new System.Drawing.Point(384, 5);
            this.numericUpDown_Power.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDown_Power.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.numericUpDown_Power.Name = "numericUpDown_Power";
            this.numericUpDown_Power.Size = new System.Drawing.Size(63, 21);
            this.numericUpDown_Power.TabIndex = 6;
            this.numericUpDown_Power.ValueChanged += new System.EventHandler(this.numericUpDown_Power_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(319, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Angle:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(192, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(117, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Weapon:";
            // 
            // lb_windSpeed
            // 
            this.lb_windSpeed.AutoSize = true;
            this.lb_windSpeed.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_windSpeed.Location = new System.Drawing.Point(75, 15);
            this.lb_windSpeed.Name = "lb_windSpeed";
            this.lb_windSpeed.Size = new System.Drawing.Size(29, 15);
            this.lb_windSpeed.TabIndex = 2;
            this.lb_windSpeed.Text = "0 W";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Wind";
            // 
            // lb_player
            // 
            this.lb_player.AutoSize = true;
            this.lb_player.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_player.Location = new System.Drawing.Point(3, 4);
            this.lb_player.Name = "lb_player";
            this.lb_player.Size = new System.Drawing.Size(64, 19);
            this.lb_player.TabIndex = 0;
            this.lb_player.Text = "Player 1";
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SkirmishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 581);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.displayPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "SkirmishForm";
            this.Text = "Form1";
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_power)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Power)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel displayPanel;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_power;
        private System.Windows.Forms.TrackBar trackBar_power;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown_Power;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_windSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_player;
        private System.Windows.Forms.Timer timer1;
    }
}

