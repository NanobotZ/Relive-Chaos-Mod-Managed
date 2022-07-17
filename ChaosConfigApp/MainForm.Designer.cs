namespace ChaosConfigApp
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.gbVotingConfig = new System.Windows.Forms.GroupBox();
            this.tbChannelName = new System.Windows.Forms.TextBox();
            this.lblChannelName = new System.Windows.Forms.Label();
            this.lbShowVotingAs = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbShowVotingAs = new System.Windows.Forms.ComboBox();
            this.cbAllowRandomOption = new System.Windows.Forms.CheckBox();
            this.lblAllowRandomOption = new System.Windows.Forms.Label();
            this.lblMaxVoteOptions = new System.Windows.Forms.Label();
            this.nudMaxVoteOptions = new System.Windows.Forms.NumericUpDown();
            this.lblGlobalEffectDurationSeconds = new System.Windows.Forms.Label();
            this.lblVotingEnabled = new System.Windows.Forms.Label();
            this.nudGlobalEffectDuration = new System.Windows.Forms.NumericUpDown();
            this.lblGlobalEffectDuration = new System.Windows.Forms.Label();
            this.cbVotingEnabled = new System.Windows.Forms.CheckBox();
            this.tpEffects = new System.Windows.Forms.TabPage();
            this.dgvEffects = new System.Windows.Forms.DataGridView();
            this.EffectObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EffectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChanceValue = new ChaosConfigApp.NumericUpDownColumn();
            this.DurationModifierValue = new ChaosConfigApp.NumericUpDownColumn();
            this.RestoreDefaults = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numericUpDownColumn1 = new ChaosConfigApp.NumericUpDownColumn();
            this.numericUpDownColumn2 = new ChaosConfigApp.NumericUpDownColumn();
            this.tabControl.SuspendLayout();
            this.tpMain.SuspendLayout();
            this.gbVotingConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxVoteOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGlobalEffectDuration)).BeginInit();
            this.tpEffects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEffects)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tpMain);
            this.tabControl.Controls.Add(this.tpEffects);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(484, 400);
            this.tabControl.TabIndex = 0;
            // 
            // tpMain
            // 
            this.tpMain.Controls.Add(this.gbVotingConfig);
            this.tpMain.Controls.Add(this.lblGlobalEffectDurationSeconds);
            this.tpMain.Controls.Add(this.lblVotingEnabled);
            this.tpMain.Controls.Add(this.nudGlobalEffectDuration);
            this.tpMain.Controls.Add(this.lblGlobalEffectDuration);
            this.tpMain.Controls.Add(this.cbVotingEnabled);
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tpMain.Size = new System.Drawing.Size(476, 374);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "Main";
            this.tpMain.UseVisualStyleBackColor = true;
            // 
            // gbVotingConfig
            // 
            this.gbVotingConfig.Controls.Add(this.tbChannelName);
            this.gbVotingConfig.Controls.Add(this.lblChannelName);
            this.gbVotingConfig.Controls.Add(this.lbShowVotingAs);
            this.gbVotingConfig.Controls.Add(this.label1);
            this.gbVotingConfig.Controls.Add(this.cbShowVotingAs);
            this.gbVotingConfig.Controls.Add(this.cbAllowRandomOption);
            this.gbVotingConfig.Controls.Add(this.lblAllowRandomOption);
            this.gbVotingConfig.Controls.Add(this.lblMaxVoteOptions);
            this.gbVotingConfig.Controls.Add(this.nudMaxVoteOptions);
            this.gbVotingConfig.Location = new System.Drawing.Point(6, 54);
            this.gbVotingConfig.Name = "gbVotingConfig";
            this.gbVotingConfig.Size = new System.Drawing.Size(350, 116);
            this.gbVotingConfig.TabIndex = 5;
            this.gbVotingConfig.TabStop = false;
            this.gbVotingConfig.Text = "Voting options";
            // 
            // tbChannelName
            // 
            this.tbChannelName.Location = new System.Drawing.Point(131, 89);
            this.tbChannelName.Name = "tbChannelName";
            this.tbChannelName.Size = new System.Drawing.Size(86, 20);
            this.tbChannelName.TabIndex = 14;
            // 
            // lblChannelName
            // 
            this.lblChannelName.AutoSize = true;
            this.lblChannelName.Location = new System.Drawing.Point(6, 92);
            this.lblChannelName.Name = "lblChannelName";
            this.lblChannelName.Size = new System.Drawing.Size(112, 13);
            this.lblChannelName.TabIndex = 13;
            this.lblChannelName.Text = "Twitch channel name:";
            // 
            // lbShowVotingAs
            // 
            this.lbShowVotingAs.AutoSize = true;
            this.lbShowVotingAs.Location = new System.Drawing.Point(6, 16);
            this.lbShowVotingAs.Name = "lbShowVotingAs";
            this.lbShowVotingAs.Size = new System.Drawing.Size(83, 13);
            this.lbShowVotingAs.TabIndex = 6;
            this.lbShowVotingAs.Text = "Show voting as:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "(includes random option)";
            // 
            // cbShowVotingAs
            // 
            this.cbShowVotingAs.FormattingEnabled = true;
            this.cbShowVotingAs.Location = new System.Drawing.Point(131, 13);
            this.cbShowVotingAs.Name = "cbShowVotingAs";
            this.cbShowVotingAs.Size = new System.Drawing.Size(86, 21);
            this.cbShowVotingAs.TabIndex = 7;
            // 
            // cbAllowRandomOption
            // 
            this.cbAllowRandomOption.AutoSize = true;
            this.cbAllowRandomOption.Location = new System.Drawing.Point(131, 40);
            this.cbAllowRandomOption.Name = "cbAllowRandomOption";
            this.cbAllowRandomOption.Size = new System.Drawing.Size(15, 14);
            this.cbAllowRandomOption.TabIndex = 9;
            this.cbAllowRandomOption.UseVisualStyleBackColor = true;
            // 
            // lblAllowRandomOption
            // 
            this.lblAllowRandomOption.AutoSize = true;
            this.lblAllowRandomOption.Location = new System.Drawing.Point(6, 40);
            this.lblAllowRandomOption.Name = "lblAllowRandomOption";
            this.lblAllowRandomOption.Size = new System.Drawing.Size(105, 13);
            this.lblAllowRandomOption.TabIndex = 8;
            this.lblAllowRandomOption.Text = "Allow random option:";
            // 
            // lblMaxVoteOptions
            // 
            this.lblMaxVoteOptions.AutoSize = true;
            this.lblMaxVoteOptions.Location = new System.Drawing.Point(6, 65);
            this.lblMaxVoteOptions.Name = "lblMaxVoteOptions";
            this.lblMaxVoteOptions.Size = new System.Drawing.Size(91, 13);
            this.lblMaxVoteOptions.TabIndex = 10;
            this.lblMaxVoteOptions.Text = "Max vote options:";
            // 
            // nudMaxVoteOptions
            // 
            this.nudMaxVoteOptions.Location = new System.Drawing.Point(131, 63);
            this.nudMaxVoteOptions.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudMaxVoteOptions.Name = "nudMaxVoteOptions";
            this.nudMaxVoteOptions.Size = new System.Drawing.Size(86, 20);
            this.nudMaxVoteOptions.TabIndex = 11;
            this.nudMaxVoteOptions.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // lblGlobalEffectDurationSeconds
            // 
            this.lblGlobalEffectDurationSeconds.AutoSize = true;
            this.lblGlobalEffectDurationSeconds.Location = new System.Drawing.Point(223, 8);
            this.lblGlobalEffectDurationSeconds.Name = "lblGlobalEffectDurationSeconds";
            this.lblGlobalEffectDurationSeconds.Size = new System.Drawing.Size(64, 13);
            this.lblGlobalEffectDurationSeconds.TabIndex = 2;
            this.lblGlobalEffectDurationSeconds.Text = "(in seconds)";
            // 
            // lblVotingEnabled
            // 
            this.lblVotingEnabled.AutoSize = true;
            this.lblVotingEnabled.Location = new System.Drawing.Point(6, 33);
            this.lblVotingEnabled.Name = "lblVotingEnabled";
            this.lblVotingEnabled.Size = new System.Drawing.Size(91, 13);
            this.lblVotingEnabled.TabIndex = 3;
            this.lblVotingEnabled.Text = "Is voting enabled:";
            // 
            // nudGlobalEffectDuration
            // 
            this.nudGlobalEffectDuration.Location = new System.Drawing.Point(131, 6);
            this.nudGlobalEffectDuration.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudGlobalEffectDuration.Name = "nudGlobalEffectDuration";
            this.nudGlobalEffectDuration.Size = new System.Drawing.Size(86, 20);
            this.nudGlobalEffectDuration.TabIndex = 1;
            this.nudGlobalEffectDuration.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblGlobalEffectDuration
            // 
            this.lblGlobalEffectDuration.AutoSize = true;
            this.lblGlobalEffectDuration.Location = new System.Drawing.Point(6, 8);
            this.lblGlobalEffectDuration.Name = "lblGlobalEffectDuration";
            this.lblGlobalEffectDuration.Size = new System.Drawing.Size(111, 13);
            this.lblGlobalEffectDuration.TabIndex = 0;
            this.lblGlobalEffectDuration.Text = "Global effect duration:";
            // 
            // cbVotingEnabled
            // 
            this.cbVotingEnabled.AutoSize = true;
            this.cbVotingEnabled.Location = new System.Drawing.Point(131, 32);
            this.cbVotingEnabled.Name = "cbVotingEnabled";
            this.cbVotingEnabled.Size = new System.Drawing.Size(15, 14);
            this.cbVotingEnabled.TabIndex = 4;
            this.cbVotingEnabled.UseVisualStyleBackColor = true;
            this.cbVotingEnabled.CheckedChanged += new System.EventHandler(this.CbVotingEnabled_CheckedChanged);
            // 
            // tpEffects
            // 
            this.tpEffects.Controls.Add(this.dgvEffects);
            this.tpEffects.Location = new System.Drawing.Point(4, 22);
            this.tpEffects.Name = "tpEffects";
            this.tpEffects.Padding = new System.Windows.Forms.Padding(3);
            this.tpEffects.Size = new System.Drawing.Size(476, 374);
            this.tpEffects.TabIndex = 1;
            this.tpEffects.Text = "Effects";
            this.tpEffects.UseVisualStyleBackColor = true;
            // 
            // dgvEffects
            // 
            this.dgvEffects.AllowUserToAddRows = false;
            this.dgvEffects.AllowUserToDeleteRows = false;
            this.dgvEffects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEffects.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvEffects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEffects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EffectObject,
            this.EffectName,
            this.ChanceValue,
            this.DurationModifierValue,
            this.RestoreDefaults});
            this.dgvEffects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEffects.Location = new System.Drawing.Point(3, 3);
            this.dgvEffects.Name = "dgvEffects";
            this.dgvEffects.RowHeadersVisible = false;
            this.dgvEffects.Size = new System.Drawing.Size(470, 368);
            this.dgvEffects.TabIndex = 0;
            this.dgvEffects.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEffects_CellContentClick);
            // 
            // EffectObject
            // 
            this.EffectObject.HeaderText = "Effect Object";
            this.EffectObject.Name = "EffectObject";
            this.EffectObject.ReadOnly = true;
            this.EffectObject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EffectObject.Visible = false;
            // 
            // EffectName
            // 
            this.EffectName.FillWeight = 2F;
            this.EffectName.HeaderText = "Effect Name";
            this.EffectName.Name = "EffectName";
            this.EffectName.ReadOnly = true;
            // 
            // ChanceValue
            // 
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.ChanceValue.DefaultCellStyle = dataGridViewCellStyle1;
            this.ChanceValue.EditingDecimalPlaces = 0;
            this.ChanceValue.FillWeight = 1F;
            this.ChanceValue.HeaderText = "Chance";
            this.ChanceValue.MaximumValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ChanceValue.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ChanceValue.Name = "ChanceValue";
            this.ChanceValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ChanceValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DurationModifierValue
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.DurationModifierValue.DefaultCellStyle = dataGridViewCellStyle2;
            this.DurationModifierValue.EditingDecimalPlaces = 0;
            this.DurationModifierValue.FillWeight = 1F;
            this.DurationModifierValue.HeaderText = "Duration Modifier";
            this.DurationModifierValue.MaximumValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.DurationModifierValue.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DurationModifierValue.Name = "DurationModifierValue";
            this.DurationModifierValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // RestoreDefaults
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "Restore";
            this.RestoreDefaults.DefaultCellStyle = dataGridViewCellStyle3;
            this.RestoreDefaults.FillWeight = 1F;
            this.RestoreDefaults.HeaderText = "Restore Defaults";
            this.RestoreDefaults.Name = "RestoreDefaults";
            this.RestoreDefaults.ReadOnly = true;
            this.RestoreDefaults.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSave.Location = new System.Drawing.Point(0, 397);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(484, 64);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Effect Object";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 2F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Effect Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 187;
            // 
            // numericUpDownColumn1
            // 
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.numericUpDownColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.numericUpDownColumn1.EditingDecimalPlaces = 0;
            this.numericUpDownColumn1.FillWeight = 1F;
            this.numericUpDownColumn1.HeaderText = "Chance";
            this.numericUpDownColumn1.MaximumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownColumn1.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownColumn1.Name = "numericUpDownColumn1";
            this.numericUpDownColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.numericUpDownColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.numericUpDownColumn1.Width = 93;
            // 
            // numericUpDownColumn2
            // 
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.numericUpDownColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.numericUpDownColumn2.EditingDecimalPlaces = 0;
            this.numericUpDownColumn2.FillWeight = 1F;
            this.numericUpDownColumn2.HeaderText = "Duration Modifier";
            this.numericUpDownColumn2.MaximumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownColumn2.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownColumn2.Name = "numericUpDownColumn2";
            this.numericUpDownColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.numericUpDownColumn2.Width = 94;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "MainForm";
            this.Text = "ChaosMod Configuration App";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            this.tpMain.PerformLayout();
            this.gbVotingConfig.ResumeLayout(false);
            this.gbVotingConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxVoteOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGlobalEffectDuration)).EndInit();
            this.tpEffects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEffects)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpMain;
        private System.Windows.Forms.TabPage tpEffects;
        private System.Windows.Forms.DataGridView dgvEffects;
        private System.Windows.Forms.CheckBox cbVotingEnabled;
        private System.Windows.Forms.ComboBox cbShowVotingAs;
        private System.Windows.Forms.Label lbShowVotingAs;
        private System.Windows.Forms.CheckBox cbAllowRandomOption;
        private System.Windows.Forms.NumericUpDown nudMaxVoteOptions;
        private System.Windows.Forms.Label lblMaxVoteOptions;
        private System.Windows.Forms.NumericUpDown nudGlobalEffectDuration;
        private System.Windows.Forms.Label lblGlobalEffectDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGlobalEffectDurationSeconds;
        private System.Windows.Forms.Label lblAllowRandomOption;
        private System.Windows.Forms.Label lblVotingEnabled;
        private System.Windows.Forms.GroupBox gbVotingConfig;
        private System.Windows.Forms.TextBox tbChannelName;
        private System.Windows.Forms.Label lblChannelName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private NumericUpDownColumn numericUpDownColumn1;
        private NumericUpDownColumn numericUpDownColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn EffectObject;
        private System.Windows.Forms.DataGridViewTextBoxColumn EffectName;
        private NumericUpDownColumn ChanceValue;
        private NumericUpDownColumn DurationModifierValue;
        private System.Windows.Forms.DataGridViewButtonColumn RestoreDefaults;
    }
}

