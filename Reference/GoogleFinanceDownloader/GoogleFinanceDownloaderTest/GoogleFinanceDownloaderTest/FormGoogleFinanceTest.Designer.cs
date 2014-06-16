namespace GoogleFinanceDownloaderTest {
    partial class FormGoogleFinanceTest {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkBoxRawData = new System.Windows.Forms.CheckBox();
            this.richTextBoxData = new System.Windows.Forms.RichTextBox();
            this.groupBoxURL = new System.Windows.Forms.GroupBox();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.panelURLData = new System.Windows.Forms.Panel();
            this.groupBoxDatesRange = new System.Windows.Forms.GroupBox();
            this.dateTimePickerSinceDate = new System.Windows.Forms.DateTimePicker();
            this.radioButtonSince = new System.Windows.Forms.RadioButton();
            this.radioButtonLastQuoute = new System.Windows.Forms.RadioButton();
            this.radioButtonAllData = new System.Windows.Forms.RadioButton();
            this.groupBoxTicker = new System.Windows.Forms.GroupBox();
            this.labelCode = new System.Windows.Forms.Label();
            this.labelExchange = new System.Windows.Forms.Label();
            this.textBoxExchange = new System.Windows.Forms.TextBox();
            this.textBoxTicker = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel.SuspendLayout();
            this.groupBoxData.SuspendLayout();
            this.groupBoxURL.SuspendLayout();
            this.panelURLData.SuspendLayout();
            this.groupBoxDatesRange.SuspendLayout();
            this.groupBoxTicker.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.groupBoxData, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.groupBoxURL, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.panelURLData, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(589, 662);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.buttonSave);
            this.groupBoxData.Controls.Add(this.checkBoxRawData);
            this.groupBoxData.Controls.Add(this.richTextBoxData);
            this.groupBoxData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxData.Location = new System.Drawing.Point(4, 246);
            this.groupBoxData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxData.Size = new System.Drawing.Size(581, 412);
            this.groupBoxData.TabIndex = 2;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Data";
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(120, 25);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 28);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkBoxRawData
            // 
            this.checkBoxRawData.AutoSize = true;
            this.checkBoxRawData.Location = new System.Drawing.Point(13, 28);
            this.checkBoxRawData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxRawData.Name = "checkBoxRawData";
            this.checkBoxRawData.Size = new System.Drawing.Size(86, 21);
            this.checkBoxRawData.TabIndex = 0;
            this.checkBoxRawData.Text = "Raw data";
            this.checkBoxRawData.UseVisualStyleBackColor = true;
            this.checkBoxRawData.CheckedChanged += new System.EventHandler(this.checkBoxRawData_CheckedChanged);
            // 
            // richTextBoxData
            // 
            this.richTextBoxData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxData.BackColor = System.Drawing.Color.White;
            this.richTextBoxData.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxData.Location = new System.Drawing.Point(7, 63);
            this.richTextBoxData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxData.Name = "richTextBoxData";
            this.richTextBoxData.ReadOnly = true;
            this.richTextBoxData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxData.Size = new System.Drawing.Size(567, 338);
            this.richTextBoxData.TabIndex = 2;
            this.richTextBoxData.Text = "";
            this.richTextBoxData.TextChanged += new System.EventHandler(this.textBoxData_TextChanged);
            // 
            // groupBoxURL
            // 
            this.groupBoxURL.Controls.Add(this.textBoxURL);
            this.groupBoxURL.Controls.Add(this.buttonDownload);
            this.groupBoxURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxURL.Location = new System.Drawing.Point(4, 150);
            this.groupBoxURL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxURL.Name = "groupBoxURL";
            this.groupBoxURL.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxURL.Size = new System.Drawing.Size(581, 88);
            this.groupBoxURL.TabIndex = 1;
            this.groupBoxURL.TabStop = false;
            this.groupBoxURL.Text = "URL";
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(12, 22);
            this.textBoxURL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxURL.Multiline = true;
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.ReadOnly = true;
            this.textBoxURL.Size = new System.Drawing.Size(451, 48);
            this.textBoxURL.TabIndex = 0;
            this.textBoxURL.TextChanged += new System.EventHandler(this.textBoxURL_TextChanged);
            // 
            // buttonDownload
            // 
            this.buttonDownload.Enabled = false;
            this.buttonDownload.Location = new System.Drawing.Point(472, 21);
            this.buttonDownload.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(100, 28);
            this.buttonDownload.TabIndex = 1;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // panelURLData
            // 
            this.panelURLData.Controls.Add(this.groupBoxDatesRange);
            this.panelURLData.Controls.Add(this.groupBoxTicker);
            this.panelURLData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelURLData.Location = new System.Drawing.Point(4, 4);
            this.panelURLData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelURLData.Name = "panelURLData";
            this.panelURLData.Size = new System.Drawing.Size(581, 138);
            this.panelURLData.TabIndex = 0;
            // 
            // groupBoxDatesRange
            // 
            this.groupBoxDatesRange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDatesRange.Controls.Add(this.dateTimePickerSinceDate);
            this.groupBoxDatesRange.Controls.Add(this.radioButtonSince);
            this.groupBoxDatesRange.Controls.Add(this.radioButtonLastQuoute);
            this.groupBoxDatesRange.Controls.Add(this.radioButtonAllData);
            this.groupBoxDatesRange.Location = new System.Drawing.Point(293, 5);
            this.groupBoxDatesRange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxDatesRange.Name = "groupBoxDatesRange";
            this.groupBoxDatesRange.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxDatesRange.Size = new System.Drawing.Size(287, 128);
            this.groupBoxDatesRange.TabIndex = 1;
            this.groupBoxDatesRange.TabStop = false;
            this.groupBoxDatesRange.Text = "Range";
            // 
            // dateTimePickerSinceDate
            // 
            this.dateTimePickerSinceDate.Enabled = false;
            this.dateTimePickerSinceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerSinceDate.Location = new System.Drawing.Point(148, 80);
            this.dateTimePickerSinceDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerSinceDate.Name = "dateTimePickerSinceDate";
            this.dateTimePickerSinceDate.Size = new System.Drawing.Size(112, 22);
            this.dateTimePickerSinceDate.TabIndex = 3;
            this.dateTimePickerSinceDate.ValueChanged += new System.EventHandler(this.uriParameterControl_ValueChanged);
            // 
            // radioButtonSince
            // 
            this.radioButtonSince.AutoSize = true;
            this.radioButtonSince.Location = new System.Drawing.Point(25, 81);
            this.radioButtonSince.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonSince.Name = "radioButtonSince";
            this.radioButtonSince.Size = new System.Drawing.Size(114, 21);
            this.radioButtonSince.TabIndex = 2;
            this.radioButtonSince.TabStop = true;
            this.radioButtonSince.Text = "At least since:";
            this.radioButtonSince.UseVisualStyleBackColor = true;
            this.radioButtonSince.CheckedChanged += new System.EventHandler(this.uriParameterControl_ValueChanged);
            // 
            // radioButtonLastQuoute
            // 
            this.radioButtonLastQuoute.AutoSize = true;
            this.radioButtonLastQuoute.Location = new System.Drawing.Point(25, 53);
            this.radioButtonLastQuoute.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonLastQuoute.Name = "radioButtonLastQuoute";
            this.radioButtonLastQuoute.Size = new System.Drawing.Size(93, 21);
            this.radioButtonLastQuoute.TabIndex = 1;
            this.radioButtonLastQuoute.TabStop = true;
            this.radioButtonLastQuoute.Text = "Last quote";
            this.radioButtonLastQuoute.UseVisualStyleBackColor = true;
            // 
            // radioButtonAllData
            // 
            this.radioButtonAllData.AutoSize = true;
            this.radioButtonAllData.Checked = true;
            this.radioButtonAllData.Location = new System.Drawing.Point(25, 25);
            this.radioButtonAllData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonAllData.Name = "radioButtonAllData";
            this.radioButtonAllData.Size = new System.Drawing.Size(73, 21);
            this.radioButtonAllData.TabIndex = 0;
            this.radioButtonAllData.TabStop = true;
            this.radioButtonAllData.Text = "All data";
            this.radioButtonAllData.UseVisualStyleBackColor = true;
            this.radioButtonAllData.CheckedChanged += new System.EventHandler(this.uriParameterControl_ValueChanged);
            // 
            // groupBoxTicker
            // 
            this.groupBoxTicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxTicker.Controls.Add(this.labelCode);
            this.groupBoxTicker.Controls.Add(this.labelExchange);
            this.groupBoxTicker.Controls.Add(this.textBoxExchange);
            this.groupBoxTicker.Controls.Add(this.textBoxTicker);
            this.groupBoxTicker.Location = new System.Drawing.Point(3, 5);
            this.groupBoxTicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxTicker.Name = "groupBoxTicker";
            this.groupBoxTicker.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxTicker.Size = new System.Drawing.Size(287, 128);
            this.groupBoxTicker.TabIndex = 0;
            this.groupBoxTicker.TabStop = false;
            this.groupBoxTicker.Text = "Ticker";
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(33, 81);
            this.labelCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(45, 17);
            this.labelCode.TabIndex = 2;
            this.labelCode.Text = "Code:";
            // 
            // labelExchange
            // 
            this.labelExchange.AutoSize = true;
            this.labelExchange.Location = new System.Drawing.Point(33, 33);
            this.labelExchange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelExchange.Name = "labelExchange";
            this.labelExchange.Size = new System.Drawing.Size(74, 17);
            this.labelExchange.TabIndex = 0;
            this.labelExchange.Text = "Exchange:";
            // 
            // textBoxExchange
            // 
            this.textBoxExchange.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxExchange.Location = new System.Drawing.Point(119, 28);
            this.textBoxExchange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxExchange.Name = "textBoxExchange";
            this.textBoxExchange.Size = new System.Drawing.Size(132, 22);
            this.textBoxExchange.TabIndex = 1;
            this.textBoxExchange.Text = "CURRENCY";
            this.textBoxExchange.TextChanged += new System.EventHandler(this.uriParameterControl_ValueChanged);
            // 
            // textBoxTicker
            // 
            this.textBoxTicker.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxTicker.Location = new System.Drawing.Point(119, 76);
            this.textBoxTicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxTicker.Name = "textBoxTicker";
            this.textBoxTicker.Size = new System.Drawing.Size(132, 22);
            this.textBoxTicker.TabIndex = 3;
            this.textBoxTicker.Text = "EURUSD";
            this.textBoxTicker.TextChanged += new System.EventHandler(this.uriParameterControl_ValueChanged);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "GogleFinanceTest.txt";
            this.saveFileDialog.Filter = "All files (*.*)|*.*";
            // 
            // FormGoogleFinanceTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 662);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(6, 527);
            this.Name = "FormGoogleFinanceTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Google Finance Download";
            this.tableLayoutPanel.ResumeLayout(false);
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.groupBoxURL.ResumeLayout(false);
            this.groupBoxURL.PerformLayout();
            this.panelURLData.ResumeLayout(false);
            this.groupBoxDatesRange.ResumeLayout(false);
            this.groupBoxDatesRange.PerformLayout();
            this.groupBoxTicker.ResumeLayout(false);
            this.groupBoxTicker.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.GroupBox groupBoxTicker;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.Label labelExchange;
        private System.Windows.Forms.TextBox textBoxExchange;
        private System.Windows.Forms.TextBox textBoxTicker;
        private System.Windows.Forms.GroupBox groupBoxDatesRange;
        private System.Windows.Forms.RadioButton radioButtonSince;
        private System.Windows.Forms.RadioButton radioButtonLastQuoute;
        private System.Windows.Forms.RadioButton radioButtonAllData;
        private System.Windows.Forms.DateTimePicker dateTimePickerSinceDate;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxRawData;
        private System.Windows.Forms.RichTextBox richTextBoxData;
        private System.Windows.Forms.GroupBox groupBoxURL;
        private System.Windows.Forms.Panel panelURLData;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

