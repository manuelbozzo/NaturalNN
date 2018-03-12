namespace NaturalNN_Front
{
    partial class Form1
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
            this.buttonCreateNetwork = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxShape = new System.Windows.Forms.TextBox();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonForward = new System.Windows.Forms.Button();
            this.textBoxTrainTarget = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelNetworkOutput = new System.Windows.Forms.Label();
            this.buttonTrain = new System.Windows.Forms.Button();
            this.numericUpDownIterations = new System.Windows.Forms.NumericUpDown();
            this.textBoxTestInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonTrainGenetic = new System.Windows.Forms.Button();
            this.numericUpDownGenerationsNumber = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDownTrainValue = new System.Windows.Forms.NumericUpDown();
            this.listBoxSymbol = new System.Windows.Forms.ListBox();
            this.labelMinDate = new System.Windows.Forms.Label();
            this.labelMaxDate = new System.Windows.Forms.Label();
            this.labelTicksCount = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownTrainingLapse = new System.Windows.Forms.NumericUpDown();
            this.buttonGenerateTrainInput = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownForwardSeconds = new System.Windows.Forms.NumericUpDown();
            this.buttonGenerateOutput = new System.Windows.Forms.Button();
            this.buttonRunGeneticMongo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGenerationsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTrainValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTrainingLapse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForwardSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreateNetwork
            // 
            this.buttonCreateNetwork.Location = new System.Drawing.Point(167, 45);
            this.buttonCreateNetwork.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCreateNetwork.Name = "buttonCreateNetwork";
            this.buttonCreateNetwork.Size = new System.Drawing.Size(56, 19);
            this.buttonCreateNetwork.TabIndex = 0;
            this.buttonCreateNetwork.Text = "Create";
            this.buttonCreateNetwork.UseVisualStyleBackColor = true;
            this.buttonCreateNetwork.Click += new System.EventHandler(this.buttonCreateNetwork_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shape";
            // 
            // textBoxShape
            // 
            this.textBoxShape.Location = new System.Drawing.Point(88, 45);
            this.textBoxShape.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxShape.Name = "textBoxShape";
            this.textBoxShape.Size = new System.Drawing.Size(76, 20);
            this.textBoxShape.TabIndex = 2;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(88, 67);
            this.textBoxInput.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(76, 20);
            this.textBoxInput.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Train Input";
            // 
            // buttonForward
            // 
            this.buttonForward.Enabled = false;
            this.buttonForward.Location = new System.Drawing.Point(167, 67);
            this.buttonForward.Margin = new System.Windows.Forms.Padding(2);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(56, 19);
            this.buttonForward.TabIndex = 5;
            this.buttonForward.Text = "Forward";
            this.buttonForward.UseVisualStyleBackColor = true;
            this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
            // 
            // textBoxTrainTarget
            // 
            this.textBoxTrainTarget.Location = new System.Drawing.Point(88, 90);
            this.textBoxTrainTarget.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTrainTarget.Name = "textBoxTrainTarget";
            this.textBoxTrainTarget.Size = new System.Drawing.Size(76, 20);
            this.textBoxTrainTarget.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "train Output";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 193);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Network Output";
            // 
            // labelNetworkOutput
            // 
            this.labelNetworkOutput.AutoSize = true;
            this.labelNetworkOutput.Location = new System.Drawing.Point(86, 193);
            this.labelNetworkOutput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNetworkOutput.Name = "labelNetworkOutput";
            this.labelNetworkOutput.Size = new System.Drawing.Size(13, 13);
            this.labelNetworkOutput.TabIndex = 9;
            this.labelNetworkOutput.Text = "0";
            // 
            // buttonTrain
            // 
            this.buttonTrain.Enabled = false;
            this.buttonTrain.Location = new System.Drawing.Point(167, 89);
            this.buttonTrain.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(86, 19);
            this.buttonTrain.TabIndex = 10;
            this.buttonTrain.Text = "Train Natural";
            this.buttonTrain.UseVisualStyleBackColor = true;
            this.buttonTrain.Click += new System.EventHandler(this.buttonTrain_Click);
            // 
            // numericUpDownIterations
            // 
            this.numericUpDownIterations.Location = new System.Drawing.Point(352, 90);
            this.numericUpDownIterations.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownIterations.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownIterations.Name = "numericUpDownIterations";
            this.numericUpDownIterations.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownIterations.TabIndex = 11;
            this.numericUpDownIterations.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // textBoxTestInput
            // 
            this.textBoxTestInput.Location = new System.Drawing.Point(88, 129);
            this.textBoxTestInput.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTestInput.Name = "textBoxTestInput";
            this.textBoxTestInput.Size = new System.Drawing.Size(76, 20);
            this.textBoxTestInput.TabIndex = 13;
            this.textBoxTestInput.Text = "0_0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 133);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Test Input";
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(167, 128);
            this.buttonTest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(56, 19);
            this.buttonTest.TabIndex = 16;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonTrainGenetic
            // 
            this.buttonTrainGenetic.Enabled = false;
            this.buttonTrainGenetic.Location = new System.Drawing.Point(257, 89);
            this.buttonTrainGenetic.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTrainGenetic.Name = "buttonTrainGenetic";
            this.buttonTrainGenetic.Size = new System.Drawing.Size(86, 19);
            this.buttonTrainGenetic.TabIndex = 17;
            this.buttonTrainGenetic.Text = "Train Genetic";
            this.buttonTrainGenetic.UseVisualStyleBackColor = true;
            this.buttonTrainGenetic.Click += new System.EventHandler(this.buttonTrainGenetic_Click);
            // 
            // numericUpDownGenerationsNumber
            // 
            this.numericUpDownGenerationsNumber.Location = new System.Drawing.Point(352, 113);
            this.numericUpDownGenerationsNumber.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownGenerationsNumber.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownGenerationsNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownGenerationsNumber.Name = "numericUpDownGenerationsNumber";
            this.numericUpDownGenerationsNumber.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownGenerationsNumber.TabIndex = 18;
            this.numericUpDownGenerationsNumber.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 93);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Iterations";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(409, 115);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Pop Size";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(23, 255);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 253);
            this.panel1.TabIndex = 21;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // numericUpDownTrainValue
            // 
            this.numericUpDownTrainValue.Location = new System.Drawing.Point(263, 255);
            this.numericUpDownTrainValue.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownTrainValue.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTrainValue.Name = "numericUpDownTrainValue";
            this.numericUpDownTrainValue.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownTrainValue.TabIndex = 22;
            // 
            // listBoxSymbol
            // 
            this.listBoxSymbol.FormattingEnabled = true;
            this.listBoxSymbol.Location = new System.Drawing.Point(412, 257);
            this.listBoxSymbol.Name = "listBoxSymbol";
            this.listBoxSymbol.Size = new System.Drawing.Size(172, 251);
            this.listBoxSymbol.TabIndex = 23;
            // 
            // labelMinDate
            // 
            this.labelMinDate.AutoSize = true;
            this.labelMinDate.Location = new System.Drawing.Point(679, 257);
            this.labelMinDate.Name = "labelMinDate";
            this.labelMinDate.Size = new System.Drawing.Size(50, 13);
            this.labelMinDate.TabIndex = 24;
            this.labelMinDate.Text = "Min Date";
            // 
            // labelMaxDate
            // 
            this.labelMaxDate.AutoSize = true;
            this.labelMaxDate.Location = new System.Drawing.Point(593, 428);
            this.labelMaxDate.Name = "labelMaxDate";
            this.labelMaxDate.Size = new System.Drawing.Size(53, 13);
            this.labelMaxDate.TabIndex = 25;
            this.labelMaxDate.Text = "Max Date";
            // 
            // labelTicksCount
            // 
            this.labelTicksCount.AutoSize = true;
            this.labelTicksCount.Location = new System.Drawing.Point(590, 495);
            this.labelTicksCount.Name = "labelTicksCount";
            this.labelTicksCount.Size = new System.Drawing.Size(63, 13);
            this.labelTicksCount.TabIndex = 26;
            this.labelTicksCount.Text = "Ticks count";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(590, 257);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(52, 13);
            this.labelStartDate.TabIndex = 27;
            this.labelStartDate.Text = "StartDate";
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(593, 274);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(109, 20);
            this.dateTimePickerStartDate.TabIndex = 28;
            this.dateTimePickerStartDate.Value = new System.DateTime(2018, 2, 14, 0, 0, 0, 0);
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(593, 387);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(49, 13);
            this.labelEndDate.TabIndex = 30;
            this.labelEndDate.Text = "EndDate";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(593, 330);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Training Lapse (seconds)";
            // 
            // numericUpDownTrainingLapse
            // 
            this.numericUpDownTrainingLapse.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownTrainingLapse.Location = new System.Drawing.Point(596, 346);
            this.numericUpDownTrainingLapse.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownTrainingLapse.Name = "numericUpDownTrainingLapse";
            this.numericUpDownTrainingLapse.Size = new System.Drawing.Size(66, 20);
            this.numericUpDownTrainingLapse.TabIndex = 32;
            this.numericUpDownTrainingLapse.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownTrainingLapse.ValueChanged += new System.EventHandler(this.numericUpDownTrainingLapse_ValueChanged);
            // 
            // buttonGenerateTrainInput
            // 
            this.buttonGenerateTrainInput.Location = new System.Drawing.Point(412, 514);
            this.buttonGenerateTrainInput.Name = "buttonGenerateTrainInput";
            this.buttonGenerateTrainInput.Size = new System.Drawing.Size(75, 50);
            this.buttonGenerateTrainInput.TabIndex = 33;
            this.buttonGenerateTrainInput.Text = "Generate Train Input";
            this.buttonGenerateTrainInput.UseVisualStyleBackColor = true;
            this.buttonGenerateTrainInput.Click += new System.EventHandler(this.buttonGenerateTrainInput_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(759, 304);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Forward (seconds)";
            // 
            // numericUpDownForwardSeconds
            // 
            this.numericUpDownForwardSeconds.Location = new System.Drawing.Point(762, 322);
            this.numericUpDownForwardSeconds.Name = "numericUpDownForwardSeconds";
            this.numericUpDownForwardSeconds.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownForwardSeconds.TabIndex = 35;
            this.numericUpDownForwardSeconds.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // buttonGenerateOutput
            // 
            this.buttonGenerateOutput.Location = new System.Drawing.Point(498, 517);
            this.buttonGenerateOutput.Name = "buttonGenerateOutput";
            this.buttonGenerateOutput.Size = new System.Drawing.Size(85, 46);
            this.buttonGenerateOutput.TabIndex = 36;
            this.buttonGenerateOutput.Text = "Generate Train Output";
            this.buttonGenerateOutput.UseVisualStyleBackColor = true;
            this.buttonGenerateOutput.Click += new System.EventHandler(this.buttonGenerateOutput_Click);
            // 
            // buttonRunGeneticMongo
            // 
            this.buttonRunGeneticMongo.Location = new System.Drawing.Point(587, 517);
            this.buttonRunGeneticMongo.Name = "buttonRunGeneticMongo";
            this.buttonRunGeneticMongo.Size = new System.Drawing.Size(75, 47);
            this.buttonRunGeneticMongo.TabIndex = 37;
            this.buttonRunGeneticMongo.Text = "Run Genetic";
            this.buttonRunGeneticMongo.UseVisualStyleBackColor = true;
            this.buttonRunGeneticMongo.Click += new System.EventHandler(this.buttonRunGeneticMongo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 576);
            this.Controls.Add(this.buttonRunGeneticMongo);
            this.Controls.Add(this.buttonGenerateOutput);
            this.Controls.Add(this.numericUpDownForwardSeconds);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonGenerateTrainInput);
            this.Controls.Add(this.numericUpDownTrainingLapse);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.labelTicksCount);
            this.Controls.Add(this.labelMaxDate);
            this.Controls.Add(this.labelMinDate);
            this.Controls.Add(this.listBoxSymbol);
            this.Controls.Add(this.numericUpDownTrainValue);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownGenerationsNumber);
            this.Controls.Add(this.buttonTrainGenetic);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.textBoxTestInput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownIterations);
            this.Controls.Add(this.buttonTrain);
            this.Controls.Add(this.labelNetworkOutput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTrainTarget);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonForward);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxShape);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCreateNetwork);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGenerationsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTrainValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTrainingLapse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForwardSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateNetwork;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxShape;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.TextBox textBoxTrainTarget;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelNetworkOutput;
        private System.Windows.Forms.Button buttonTrain;
        private System.Windows.Forms.NumericUpDown numericUpDownIterations;
        private System.Windows.Forms.TextBox textBoxTestInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonTrainGenetic;
        private System.Windows.Forms.NumericUpDown numericUpDownGenerationsNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericUpDownTrainValue;
        private System.Windows.Forms.ListBox listBoxSymbol;
        private System.Windows.Forms.Label labelMinDate;
        private System.Windows.Forms.Label labelMaxDate;
        private System.Windows.Forms.Label labelTicksCount;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownTrainingLapse;
        private System.Windows.Forms.Button buttonGenerateTrainInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownForwardSeconds;
        private System.Windows.Forms.Button buttonGenerateOutput;
        private System.Windows.Forms.Button buttonRunGeneticMongo;
    }
}

