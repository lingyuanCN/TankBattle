namespace TankBattle
{
    partial class SetupGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.playerNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.roundNum = new System.Windows.Forms.NumericUpDown();
            this.btn_setupPlayer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.playerNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundNum)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "How many players? (2-8)";
            // 
            // playerNum
            // 
            this.playerNum.Location = new System.Drawing.Point(237, 27);
            this.playerNum.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.playerNum.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.playerNum.Name = "playerNum";
            this.playerNum.Size = new System.Drawing.Size(120, 21);
            this.playerNum.TabIndex = 1;
            this.playerNum.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "How many game play rounds?";
            // 
            // roundNum
            // 
            this.roundNum.Location = new System.Drawing.Point(237, 61);
            this.roundNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.roundNum.Name = "roundNum";
            this.roundNum.Size = new System.Drawing.Size(120, 21);
            this.roundNum.TabIndex = 3;
            this.roundNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_setupPlayer
            // 
            this.btn_setupPlayer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_setupPlayer.Location = new System.Drawing.Point(108, 109);
            this.btn_setupPlayer.Name = "btn_setupPlayer";
            this.btn_setupPlayer.Size = new System.Drawing.Size(191, 33);
            this.btn_setupPlayer.TabIndex = 4;
            this.btn_setupPlayer.Text = "Setup Players";
            this.btn_setupPlayer.UseVisualStyleBackColor = true;
            this.btn_setupPlayer.Click += new System.EventHandler(this.btn_setupGame_Click);
            // 
            // SetupGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 154);
            this.Controls.Add(this.btn_setupPlayer);
            this.Controls.Add(this.roundNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.playerNum);
            this.Controls.Add(this.label1);
            this.Name = "SetupGame";
            this.Text = "SetupGame";
            ((System.ComponentModel.ISupportInitialize)(this.playerNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown playerNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown roundNum;
        private System.Windows.Forms.Button btn_setupPlayer;
    }
}