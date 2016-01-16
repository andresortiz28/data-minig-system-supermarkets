namespace Apriori.View
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.DateTimePicker();
            this.Stores = new System.Windows.Forms.ComboBox();
            this.MinsupValue = new System.Windows.Forms.NumericUpDown();
            this.ConfidenceValue = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Ejecutar = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Months = new System.Windows.Forms.GroupBox();
            this.checkJunio = new System.Windows.Forms.CheckBox();
            this.checkMayo = new System.Windows.Forms.CheckBox();
            this.checkAbril = new System.Windows.Forms.CheckBox();
            this.checkMarzo = new System.Windows.Forms.CheckBox();
            this.checkFebrero = new System.Windows.Forms.CheckBox();
            this.checkEnero = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MinsupValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfidenceValue)).BeginInit();
            this.Months.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(38, 96);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(51, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Date:";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(38, 119);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Month:";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Store: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Support: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Confidence: ";
            // 
            // Date
            // 
            this.Date.Enabled = false;
            this.Date.Location = new System.Drawing.Point(116, 92);
            this.Date.MaxDate = new System.DateTime(2013, 6, 30, 0, 0, 0, 0);
            this.Date.MinDate = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(199, 20);
            this.Date.TabIndex = 6;
            this.Date.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.Date.ValueChanged += new System.EventHandler(this.Date_ValueChanged);
            // 
            // Stores
            // 
            this.Stores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Stores.FormattingEnabled = true;
            this.Stores.Items.AddRange(new object[] {
            "All",
            "101",
            "102",
            "103",
            "104",
            "105",
            "106",
            "107",
            "108",
            "109",
            "110",
            "111"});
            this.Stores.Location = new System.Drawing.Point(162, 256);
            this.Stores.Name = "Stores";
            this.Stores.Size = new System.Drawing.Size(83, 21);
            this.Stores.TabIndex = 8;
            this.Stores.SelectedIndexChanged += new System.EventHandler(this.Stores_SelectedIndexChanged);
            // 
            // MinsupValue
            // 
            this.MinsupValue.DecimalPlaces = 1;
            this.MinsupValue.Location = new System.Drawing.Point(163, 286);
            this.MinsupValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinsupValue.Name = "MinsupValue";
            this.MinsupValue.Size = new System.Drawing.Size(45, 20);
            this.MinsupValue.TabIndex = 9;
            this.MinsupValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinsupValue.ValueChanged += new System.EventHandler(this.MinsupValue_ValueChanged);
            // 
            // ConfidenceValue
            // 
            this.ConfidenceValue.Location = new System.Drawing.Point(163, 317);
            this.ConfidenceValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ConfidenceValue.Name = "ConfidenceValue";
            this.ConfidenceValue.Size = new System.Drawing.Size(45, 20);
            this.ConfidenceValue.TabIndex = 10;
            this.ConfidenceValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(127, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 26);
            this.label7.TabIndex = 13;
            this.label7.Text = "Proyecto Integrador I\r\nAlgoritmo Apriori";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(124, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "UNIVERSIDAD ICESI";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // Ejecutar
            // 
            this.Ejecutar.Location = new System.Drawing.Point(154, 373);
            this.Ejecutar.Name = "Ejecutar";
            this.Ejecutar.Size = new System.Drawing.Size(75, 23);
            this.Ejecutar.TabIndex = 15;
            this.Ejecutar.Text = "Execute";
            this.Ejecutar.UseVisualStyleBackColor = true;
            this.Ejecutar.Click += new System.EventHandler(this.Ejecutar_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.ForeColor = System.Drawing.Color.Green;
            this.richTextBox1.Location = new System.Drawing.Point(342, 32);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox1.Size = new System.Drawing.Size(555, 581);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            this.richTextBox1.UseWaitCursor = true;
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Months
            // 
            this.Months.Controls.Add(this.checkJunio);
            this.Months.Controls.Add(this.checkMayo);
            this.Months.Controls.Add(this.checkAbril);
            this.Months.Controls.Add(this.checkMarzo);
            this.Months.Controls.Add(this.checkFebrero);
            this.Months.Controls.Add(this.checkEnero);
            this.Months.Enabled = false;
            this.Months.Location = new System.Drawing.Point(116, 119);
            this.Months.Name = "Months";
            this.Months.Size = new System.Drawing.Size(166, 96);
            this.Months.TabIndex = 18;
            this.Months.TabStop = false;
            // 
            // checkJunio
            // 
            this.checkJunio.AutoSize = true;
            this.checkJunio.Location = new System.Drawing.Point(108, 67);
            this.checkJunio.Name = "checkJunio";
            this.checkJunio.Size = new System.Drawing.Size(49, 17);
            this.checkJunio.TabIndex = 24;
            this.checkJunio.Text = "June";
            this.checkJunio.UseVisualStyleBackColor = true;
            // 
            // checkMayo
            // 
            this.checkMayo.AutoSize = true;
            this.checkMayo.Location = new System.Drawing.Point(108, 44);
            this.checkMayo.Name = "checkMayo";
            this.checkMayo.Size = new System.Drawing.Size(46, 17);
            this.checkMayo.TabIndex = 23;
            this.checkMayo.Text = "May";
            this.checkMayo.UseVisualStyleBackColor = true;
            // 
            // checkAbril
            // 
            this.checkAbril.AutoSize = true;
            this.checkAbril.Location = new System.Drawing.Point(108, 21);
            this.checkAbril.Name = "checkAbril";
            this.checkAbril.Size = new System.Drawing.Size(46, 17);
            this.checkAbril.TabIndex = 22;
            this.checkAbril.Text = "April";
            this.checkAbril.UseVisualStyleBackColor = true;
            // 
            // checkMarzo
            // 
            this.checkMarzo.AutoSize = true;
            this.checkMarzo.Location = new System.Drawing.Point(11, 67);
            this.checkMarzo.Name = "checkMarzo";
            this.checkMarzo.Size = new System.Drawing.Size(56, 17);
            this.checkMarzo.TabIndex = 21;
            this.checkMarzo.Text = "March";
            this.checkMarzo.UseVisualStyleBackColor = true;
            // 
            // checkFebrero
            // 
            this.checkFebrero.AutoSize = true;
            this.checkFebrero.Location = new System.Drawing.Point(11, 44);
            this.checkFebrero.Name = "checkFebrero";
            this.checkFebrero.Size = new System.Drawing.Size(67, 17);
            this.checkFebrero.TabIndex = 20;
            this.checkFebrero.Text = "February";
            this.checkFebrero.UseVisualStyleBackColor = true;
            // 
            // checkEnero
            // 
            this.checkEnero.AutoSize = true;
            this.checkEnero.Location = new System.Drawing.Point(11, 21);
            this.checkEnero.Name = "checkEnero";
            this.checkEnero.Size = new System.Drawing.Size(63, 17);
            this.checkEnero.TabIndex = 19;
            this.checkEnero.Text = "January";
            this.checkEnero.UseVisualStyleBackColor = true;
            this.checkEnero.CheckedChanged += new System.EventHandler(this.checkEnero_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(154, 411);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Show Lks";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 648);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Months);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Ejecutar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ConfidenceValue);
            this.Controls.Add(this.MinsupValue);
            this.Controls.Add(this.Stores);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Name = "Form1";
            this.Text = "Apriori";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MinsupValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfidenceValue)).EndInit();
            this.Months.ResumeLayout(false);
            this.Months.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker Date;
        private System.Windows.Forms.ComboBox Stores;
        private System.Windows.Forms.NumericUpDown MinsupValue;
        private System.Windows.Forms.NumericUpDown ConfidenceValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Ejecutar;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox Months;
        private System.Windows.Forms.CheckBox checkJunio;
        private System.Windows.Forms.CheckBox checkMayo;
        private System.Windows.Forms.CheckBox checkAbril;
        private System.Windows.Forms.CheckBox checkMarzo;
        private System.Windows.Forms.CheckBox checkFebrero;
        private System.Windows.Forms.CheckBox checkEnero;
        private System.Windows.Forms.Button button1;
    }
}

