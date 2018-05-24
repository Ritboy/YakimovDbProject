using DB.Entities;
using System;

namespace DB.Dialogs
{
    partial class SupplyDialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.organizationLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.preparationDatePicker = new System.Windows.Forms.DateTimePicker();
            this.expirationDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.responsiblePersonLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.executionDatePicker = new System.Windows.Forms.DateTimePicker();
            this.supplyResolvedPanel = new System.Windows.Forms.Panel();
            this.changeResponsiblePersonButton = new System.Windows.Forms.Button();
            this.executionDateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.productsTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addProductButton = new System.Windows.Forms.Button();
            this.removeProductButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.discountLabel = new System.Windows.Forms.Label();
            this.discountNumeric = new System.Windows.Forms.NumericUpDown();
            this.discountCheckBox = new System.Windows.Forms.CheckBox();
            this.changeOrganizationButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.billNumberLabel = new System.Windows.Forms.Label();
            this.preparationDateLabel = new System.Windows.Forms.Label();
            this.expirationDateLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.supplyResolvedPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productsTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discountNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // organizationLinkLabel
            // 
            this.organizationLinkLabel.AutoSize = true;
            this.organizationLinkLabel.Location = new System.Drawing.Point(310, 17);
            this.organizationLinkLabel.Name = "organizationLinkLabel";
            this.organizationLinkLabel.Size = new System.Drawing.Size(74, 13);
            this.organizationLinkLabel.TabIndex = 3;
            this.organizationLinkLabel.TabStop = true;
            this.organizationLinkLabel.Text = "Организация";
            this.organizationLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.organizationLinkLabel_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Дата составления договора";
            // 
            // preparationDatePicker
            // 
            this.preparationDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.preparationDatePicker.Location = new System.Drawing.Point(313, 41);
            this.preparationDatePicker.Name = "preparationDatePicker";
            this.preparationDatePicker.Size = new System.Drawing.Size(121, 20);
            this.preparationDatePicker.TabIndex = 5;
            // 
            // expirationDatePicker
            // 
            this.expirationDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.expirationDatePicker.Location = new System.Drawing.Point(313, 67);
            this.expirationDatePicker.Name = "expirationDatePicker";
            this.expirationDatePicker.Size = new System.Drawing.Size(121, 20);
            this.expirationDatePicker.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Срок поставки товара до";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(255, 542);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 14;
            this.okButton.Text = "Сохранить";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(336, 542);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Принял (ответсвенное лицо)";
            // 
            // responsiblePersonLinkLabel
            // 
            this.responsiblePersonLinkLabel.AutoSize = true;
            this.responsiblePersonLinkLabel.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.responsiblePersonLinkLabel.Location = new System.Drawing.Point(200, 11);
            this.responsiblePersonLinkLabel.Name = "responsiblePersonLinkLabel";
            this.responsiblePersonLinkLabel.Size = new System.Drawing.Size(127, 13);
            this.responsiblePersonLinkLabel.TabIndex = 11;
            this.responsiblePersonLinkLabel.TabStop = true;
            this.responsiblePersonLinkLabel.Text = "Выберите организацию";
            this.responsiblePersonLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.responsiblePersonLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.responsiblePersonLinkLabel_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Дата исполнения договора";
            // 
            // executionDatePicker
            // 
            this.executionDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.executionDatePicker.Location = new System.Drawing.Point(203, 37);
            this.executionDatePicker.Name = "executionDatePicker";
            this.executionDatePicker.Size = new System.Drawing.Size(121, 20);
            this.executionDatePicker.TabIndex = 13;
            // 
            // supplyResolvedPanel
            // 
            this.supplyResolvedPanel.BackColor = System.Drawing.Color.Transparent;
            this.supplyResolvedPanel.Controls.Add(this.changeResponsiblePersonButton);
            this.supplyResolvedPanel.Controls.Add(this.label5);
            this.supplyResolvedPanel.Controls.Add(this.responsiblePersonLinkLabel);
            this.supplyResolvedPanel.Controls.Add(this.label4);
            this.supplyResolvedPanel.Controls.Add(this.executionDatePicker);
            this.supplyResolvedPanel.Controls.Add(this.executionDateLabel);
            this.supplyResolvedPanel.Enabled = false;
            this.supplyResolvedPanel.Location = new System.Drawing.Point(110, 127);
            this.supplyResolvedPanel.Name = "supplyResolvedPanel";
            this.supplyResolvedPanel.Size = new System.Drawing.Size(444, 74);
            this.supplyResolvedPanel.TabIndex = 16;
            // 
            // changeResponsiblePersonButton
            // 
            this.changeResponsiblePersonButton.Location = new System.Drawing.Point(333, 6);
            this.changeResponsiblePersonButton.Name = "changeResponsiblePersonButton";
            this.changeResponsiblePersonButton.Size = new System.Drawing.Size(75, 23);
            this.changeResponsiblePersonButton.TabIndex = 27;
            this.changeResponsiblePersonButton.Text = "Изменить";
            this.changeResponsiblePersonButton.UseVisualStyleBackColor = true;
            this.changeResponsiblePersonButton.Click += new System.EventHandler(this.changeResponsiblePersonButton_Click);
            // 
            // executionDateLabel
            // 
            this.executionDateLabel.AutoSize = true;
            this.executionDateLabel.Location = new System.Drawing.Point(200, 43);
            this.executionDateLabel.Name = "executionDateLabel";
            this.executionDateLabel.Size = new System.Drawing.Size(111, 13);
            this.executionDateLabel.TabIndex = 33;
            this.executionDateLabel.Text = "Состояние поставки";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Организация (контр-агент)";
            // 
            // productsTable
            // 
            this.productsTable.AllowUserToAddRows = false;
            this.productsTable.AllowUserToDeleteRows = false;
            this.productsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.productsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column7,
            this.Column8,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.productsTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.productsTable.Location = new System.Drawing.Point(6, 51);
            this.productsTable.Name = "productsTable";
            this.productsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productsTable.Size = new System.Drawing.Size(620, 191);
            this.productsTable.TabIndex = 19;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Product_ID";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "TU";
            this.Column7.HeaderText = "ТУ";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Measure";
            this.Column8.HeaderText = "Ед. измерения";
            this.Column8.Name = "Column8";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Name";
            this.Column2.HeaderText = "Наименование";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Quantity";
            this.Column3.HeaderText = "Количество";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Price";
            this.Column4.HeaderText = "Цена";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Nds";
            this.Column5.HeaderText = "Ндс";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Sum";
            this.Column6.HeaderText = "Сумма";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // addProductButton
            // 
            this.addProductButton.Location = new System.Drawing.Point(470, 19);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(75, 23);
            this.addProductButton.TabIndex = 23;
            this.addProductButton.Text = "Добавить";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // removeProductButton
            // 
            this.removeProductButton.Location = new System.Drawing.Point(551, 19);
            this.removeProductButton.Name = "removeProductButton";
            this.removeProductButton.Size = new System.Drawing.Size(75, 23);
            this.removeProductButton.TabIndex = 24;
            this.removeProductButton.Text = "Удалить";
            this.removeProductButton.UseVisualStyleBackColor = true;
            this.removeProductButton.Click += new System.EventHandler(this.removeProductButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.productsTable);
            this.groupBox1.Controls.Add(this.amountLabel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.removeProductButton);
            this.groupBox1.Controls.Add(this.addProductButton);
            this.groupBox1.Controls.Add(this.discountLabel);
            this.groupBox1.Controls.Add(this.discountNumeric);
            this.groupBox1.Controls.Add(this.discountCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 251);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(632, 285);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Продукция";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Location = new System.Drawing.Point(310, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "%";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(53, 248);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(13, 13);
            this.amountLabel.TabIndex = 27;
            this.amountLabel.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(228, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Сумма";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(181, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Сумма";
            // 
            // discountLabel
            // 
            this.discountLabel.AutoSize = true;
            this.discountLabel.Location = new System.Drawing.Point(291, 247);
            this.discountLabel.Name = "discountLabel";
            this.discountLabel.Size = new System.Drawing.Size(13, 13);
            this.discountLabel.TabIndex = 33;
            this.discountLabel.Text = "0";
            this.discountLabel.Visible = false;
            // 
            // discountNumeric
            // 
            this.discountNumeric.Enabled = false;
            this.discountNumeric.Location = new System.Drawing.Point(262, 246);
            this.discountNumeric.Name = "discountNumeric";
            this.discountNumeric.Size = new System.Drawing.Size(42, 20);
            this.discountNumeric.TabIndex = 29;
            this.discountNumeric.ValueChanged += new System.EventHandler(this.discountNumeric_ValueChanged);
            // 
            // discountCheckBox
            // 
            this.discountCheckBox.AutoSize = true;
            this.discountCheckBox.Location = new System.Drawing.Point(135, 246);
            this.discountCheckBox.Name = "discountCheckBox";
            this.discountCheckBox.Size = new System.Drawing.Size(121, 17);
            this.discountCheckBox.TabIndex = 28;
            this.discountCheckBox.Text = "Применить скидку";
            this.discountCheckBox.UseVisualStyleBackColor = true;
            this.discountCheckBox.CheckedChanged += new System.EventHandler(this.discountCheckBox_CheckedChanged);
            // 
            // changeOrganizationButton
            // 
            this.changeOrganizationButton.Location = new System.Drawing.Point(441, 12);
            this.changeOrganizationButton.Name = "changeOrganizationButton";
            this.changeOrganizationButton.Size = new System.Drawing.Size(75, 23);
            this.changeOrganizationButton.TabIndex = 26;
            this.changeOrganizationButton.Text = "Изменить";
            this.changeOrganizationButton.UseVisualStyleBackColor = true;
            this.changeOrganizationButton.Click += new System.EventHandler(this.changeOrganizationButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Состояние поставки";
            // 
            // statusComboBox
            // 
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Items.AddRange(new object[] {
            "Счёт отправлен",
            "Оплата получена",
            "Товар отправлен",
            "Товар получен"});
            this.statusComboBox.Location = new System.Drawing.Point(313, 93);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(121, 21);
            this.statusComboBox.TabIndex = 28;
            this.statusComboBox.Text = "Заявка";
            this.statusComboBox.SelectedIndexChanged += new System.EventHandler(this.statusComboBox_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(315, 228);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 20);
            this.label11.TabIndex = 28;
            this.label11.Text = "Счёт №";
            // 
            // billNumberLabel
            // 
            this.billNumberLabel.AutoSize = true;
            this.billNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.billNumberLabel.Location = new System.Drawing.Point(393, 228);
            this.billNumberLabel.Name = "billNumberLabel";
            this.billNumberLabel.Size = new System.Drawing.Size(18, 20);
            this.billNumberLabel.TabIndex = 29;
            this.billNumberLabel.Text = "0";
            // 
            // preparationDateLabel
            // 
            this.preparationDateLabel.AutoSize = true;
            this.preparationDateLabel.Location = new System.Drawing.Point(310, 47);
            this.preparationDateLabel.Name = "preparationDateLabel";
            this.preparationDateLabel.Size = new System.Drawing.Size(111, 13);
            this.preparationDateLabel.TabIndex = 30;
            this.preparationDateLabel.Text = "Состояние поставки";
            // 
            // expirationDateLabel
            // 
            this.expirationDateLabel.AutoSize = true;
            this.expirationDateLabel.Location = new System.Drawing.Point(310, 73);
            this.expirationDateLabel.Name = "expirationDateLabel";
            this.expirationDateLabel.Size = new System.Drawing.Size(111, 13);
            this.expirationDateLabel.TabIndex = 31;
            this.expirationDateLabel.Text = "Состояние поставки";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(310, 96);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(111, 13);
            this.statusLabel.TabIndex = 32;
            this.statusLabel.Text = "Состояние поставки";
            // 
            // SupplyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(650, 577);
            this.Controls.Add(this.billNumberLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.changeOrganizationButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.expirationDatePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.preparationDatePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.organizationLinkLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.supplyResolvedPanel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.expirationDateLabel);
            this.Controls.Add(this.preparationDateLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplyDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поставка";
            this.Load += new System.EventHandler(this.SupplyDialog_Load);
            this.supplyResolvedPanel.ResumeLayout(false);
            this.supplyResolvedPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productsTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discountNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel organizationLinkLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker preparationDatePicker;
        private System.Windows.Forms.DateTimePicker expirationDatePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel responsiblePersonLinkLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker executionDatePicker;
        private System.Windows.Forms.Panel supplyResolvedPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView productsTable;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.Button removeProductButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button changeResponsiblePersonButton;
        private System.Windows.Forms.Button changeOrganizationButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown discountNumeric;
        private System.Windows.Forms.CheckBox discountCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label billNumberLabel;
        private System.Windows.Forms.Label executionDateLabel;
        private System.Windows.Forms.Label discountLabel;
        private System.Windows.Forms.Label preparationDateLabel;
        private System.Windows.Forms.Label expirationDateLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}