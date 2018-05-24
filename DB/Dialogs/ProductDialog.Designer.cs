namespace DB.Dialogs
{
    partial class ProductDialog
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tuTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.measureTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.availableNumeric = new System.Windows.Forms.NumericUpDown();
            this.priceNumeric = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.descriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.availableLable = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.availableNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextBox.Location = new System.Drawing.Point(190, 23);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(281, 27);
            this.nameTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Наименование";
            // 
            // tuTextBox
            // 
            this.tuTextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tuTextBox.Location = new System.Drawing.Point(190, 56);
            this.tuTextBox.Name = "tuTextBox";
            this.tuTextBox.Size = new System.Drawing.Size(281, 27);
            this.tuTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "ТУ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "В наличии";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Цена (прайс-лист)";
            // 
            // measureTextBox
            // 
            this.measureTextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.measureTextBox.Location = new System.Drawing.Point(190, 89);
            this.measureTextBox.Name = "measureTextBox";
            this.measureTextBox.Size = new System.Drawing.Size(281, 27);
            this.measureTextBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ед. измерения";
            // 
            // availableNumeric
            // 
            this.availableNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.availableNumeric.Location = new System.Drawing.Point(190, 122);
            this.availableNumeric.Maximum = new decimal(new int[] {
            200000000,
            0,
            0,
            0});
            this.availableNumeric.Name = "availableNumeric";
            this.availableNumeric.Size = new System.Drawing.Size(120, 26);
            this.availableNumeric.TabIndex = 12;
            // 
            // priceNumeric
            // 
            this.priceNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceNumeric.Location = new System.Drawing.Point(190, 154);
            this.priceNumeric.Maximum = new decimal(new int[] {
            200000000,
            0,
            0,
            0});
            this.priceNumeric.Name = "priceNumeric";
            this.priceNumeric.Size = new System.Drawing.Size(120, 26);
            this.priceNumeric.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 19);
            this.label6.TabIndex = 14;
            this.label6.Text = "Описание";
            // 
            // descriptionRichTextBox
            // 
            this.descriptionRichTextBox.Location = new System.Drawing.Point(12, 223);
            this.descriptionRichTextBox.Name = "descriptionRichTextBox";
            this.descriptionRichTextBox.Size = new System.Drawing.Size(459, 180);
            this.descriptionRichTextBox.TabIndex = 15;
            this.descriptionRichTextBox.Text = "";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelButton.Location = new System.Drawing.Point(255, 424);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 24);
            this.cancelButton.TabIndex = 27;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.okButton.Location = new System.Drawing.Point(157, 424);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(92, 24);
            this.okButton.TabIndex = 26;
            this.okButton.Text = "Сохранить";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // availableLable
            // 
            this.availableLable.AutoSize = true;
            this.availableLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.availableLable.Location = new System.Drawing.Point(186, 124);
            this.availableLable.Name = "availableLable";
            this.availableLable.Size = new System.Drawing.Size(18, 20);
            this.availableLable.TabIndex = 29;
            this.availableLable.Text = "0";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceLabel.Location = new System.Drawing.Point(186, 156);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(18, 20);
            this.priceLabel.TabIndex = 30;
            this.priceLabel.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(316, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 19);
            this.label7.TabIndex = 31;
            this.label7.Text = "Руб";
            // 
            // ProductDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(483, 460);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.descriptionRichTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.measureTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tuTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.availableNumeric);
            this.Controls.Add(this.availableLable);
            this.Controls.Add(this.priceNumeric);
            this.Controls.Add(this.priceLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductDialog";
            this.Text = "Продукция";
            ((System.ComponentModel.ISupportInitialize)(this.availableNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tuTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox measureTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown availableNumeric;
        private System.Windows.Forms.NumericUpDown priceNumeric;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox descriptionRichTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label availableLable;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label label7;
    }
}