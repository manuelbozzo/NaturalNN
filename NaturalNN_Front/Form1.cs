using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using NaturalNN_Controller;
using MongoConnection;

namespace NaturalNN_Front
{
    public partial class Form1 : Form
    {
        private int[] _shape;
        readonly MainController _mainController = new MainController();
        private Bitmap bmp;

        public delegate void PaintDelegate();

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(panel1.Width, panel1.Height);
            PaintDelegate pd = new PaintDelegate(PanelPaint);

        }

        private void buttonCreateNetwork_Click(object sender, System.EventArgs e)
        {
            try
            {
                _shape = GetShape();
                _mainController.CreateNetwork(_shape);
                buttonForward.Enabled = true;
                buttonTrain.Enabled = true;
                buttonTrainGenetic.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private int[] GetShape()
        {
            string[] shapeBoxSplit = textBoxShape.Text.Split(',');
            if (shapeBoxSplit.Length > 0)
            {
                int[] result = new int[shapeBoxSplit.Length];
                int outParse;
                int index = 0;
                foreach (string s in shapeBoxSplit)
                {
                    if (int.TryParse(s, out outParse))
                    {
                        result[index] = outParse;
                    }
                    else
                    {
                        throw new Exception("Invalid shape format!");
                    }
                    index++;
                }
                return result;
            }
            throw new Exception("Error in parsing");
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            try
            {
                _mainController.SetInput(GetInputArray().First());
                _mainController.RunForward();
                labelNetworkOutput.Text = MainController.GetNetworkOutputString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private List<double[]> GetInputArray()
        {
            List<double[]> resultList = new List<double[]>();
            string[] trainCases = textBoxInput.Text.Split('|');
            foreach (string trainCase in trainCases)
            {
                string[] inputBoxSplit = trainCase.Split('_');
                if (inputBoxSplit.Length > 0)
                {
                    double[] result = new double[inputBoxSplit.Length];
                    double outParse;
                    int index = 0;
                    foreach (string s in inputBoxSplit)
                    {
                        if (double.TryParse(s, out outParse))
                        {
                            result[index] = outParse;
                        }
                        else
                        {
                            throw new Exception("Invalid input format!");
                        }
                        index++;
                    }
                    resultList.Add(result);
                }
            }
            return resultList;
        }

        private void buttonGenerateTrainInput_Click(object sender, EventArgs e)
        {
            _mainController.GenerateTrainInputCompressedSql(dateTimePickerStartDate.Value, dateTimePickerStartDate.Value.AddSeconds(Convert.ToDouble(numericUpDownTrainingLapse.Value)));
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            _mainController.TrainNatural(inputTrainSet: GetInputArray(), outputTarget: GetTrainOut(),
                iterationsNumber: Convert.ToInt32(numericUpDownIterations.Value));
        }

        private List<double[]> GetTrainOut()
        {
            List<double[]> resultList = new List<double[]>();
            string[] trainCases = textBoxTrainTarget.Text.Split('|');
            foreach (string trainCase in trainCases)
            {
                string[] trainBoxSplit = trainCase.Split('_');
                if (trainBoxSplit.Length > 0)
                {
                    double[] result = new double[trainBoxSplit.Length];
                    double outParse;
                    int index = 0;
                    foreach (string s in trainBoxSplit)
                    {
                        if (double.TryParse(s, out outParse))
                        {
                            result[index] = outParse;
                        }
                        else
                        {
                            throw new Exception("Invalid train input format!");
                        }
                        index++;
                    }
                    resultList.Add(result);
                }
            }

            return resultList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //InitMongoData();
            InitSqlData();
            textBoxShape.Text = @"5,1";

        }

        private void InitSqlData()
        {
            List<string> symbols = _mainController.GetSymbolsSql();
            DisplaySymbols(symbols);
        }

        private void InitMongoData()
        {
            List<string> symbols = _mainController.GetSymbols();
            DisplaySymbols(symbols);

        }

        private void DisplaySymbols(List<string> symbols)
        {
            listBoxSymbol.Items.AddRange(symbols.ToArray());
            DateTime minDate = _mainController.GetMinDate();
            dateTimePickerStartDate.MinDate = minDate;
            //dateTimePickerStartDate.Value = minDate;
            DateTime maxDate = _mainController.GetMaxDate();
            labelMinDate.Text = "Min Date = " + minDate.ToShortDateString() + " / " + minDate.ToLongTimeString();
            labelMaxDate.Text = "Max Date = " + maxDate.ToShortDateString() + " / " + maxDate.ToLongTimeString();

            labelTicksCount.Text = "Number os Ticks = " + _mainController.GetTicksCount();

            DateTime EndDate = dateTimePickerStartDate.Value.AddSeconds(Convert.ToDouble(numericUpDownTrainingLapse.Value));
            labelEndDate.Text = "EndDate = " + EndDate.ToShortDateString() + " / " + EndDate.ToLongTimeString();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            try
            {
                _mainController.SetInput(GetTestInputArray());
                _mainController.RunForward();
                PanelPaint();
                PaintInputs();
                labelNetworkOutput.Text = MainController.GetNetworkOutputString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void PanelPaint()
        {
            bmp = new Bitmap(panel1.Width, panel1.Height);

            panel1.BackgroundImage = (Image)bmp;
            panel1.BackgroundImageLayout = ImageLayout.None;

            for (int i = 0; i < panel1.Height; i++)
            {
                for (int j = 0; j < panel1.Width; j++)
                {
                    double[] inputPixel = {TransposeX(j, panel1.Width), TransposeY(i, panel1.Height) };
                    double[] value = _mainController.GetNetworkOutput(inputPixel);

                    bmp.SetPixel(j,i, Color.FromArgb(Map255(value[0]), 0, 0));
                }
            }
        }

        private int Map255(double X)
        {
            double A = 0d;
            double B = 1d;
            double C = 0d;
            double D = 255d;

            double Y = (X - A)/(B - A)*(D - C) + C;
            if (Y < 0)
            {
                Y = 0;
            }
            return (int) Math.Round(Y) > 255 ? 255 : (int)Math.Round(Y);

        }

        private double[] GetTestInputArray()
        {
            string[] inputBoxSplit = textBoxTestInput.Text.Split('_');
            if (inputBoxSplit.Length > 0)
            {
                double[] result = new double[inputBoxSplit.Length];
                double outParse;
                int index = 0;
                foreach (string s in inputBoxSplit)
                {
                    if (double.TryParse(s, out outParse))
                    {
                        result[index] = outParse;
                    }
                    else
                    {
                        throw new Exception("Invalid input format!");
                    }
                    index++;
                }
                return result;
            }
            throw new Exception("Error in parsing");
        }

        private void buttonTrainGenetic_Click(object sender, EventArgs e)
        {
            _mainController.TrainGenetic(GetInputArray(), GetTrainOut(), Convert.ToInt32(numericUpDownIterations.Value), 
                Convert.ToInt32(numericUpDownGenerationsNumber.Value), _shape);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = panel1.PointToClient(Cursor.Position);
            point = AddAsInput(point);

            panel1.BackgroundImage = (Image)bmp;
            panel1.BackgroundImageLayout = ImageLayout.None;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                //g.Clear(Color.White);
                if (numericUpDownTrainValue.Value == 0)
                {
                    g.FillEllipse(Brushes.Green, new Rectangle(point.X-1, point.Y-1, 11, 11));
                    g.FillEllipse(Brushes.Blue, new Rectangle(point.X, point.Y, 9, 9));
                }
                else
                {
                    g.FillEllipse(Brushes.Gray, new Rectangle(point.X - 1, point.Y - 1, 11, 11));
                    g.FillEllipse(Brushes.Red, new Rectangle(point.X, point.Y, 9, 9));
                }
                
            }
            panel1.Invalidate();
        }

        private Point AddAsInput(Point point)
        {
            textBoxInput.Text = textBoxInput.Text + "|" + TransposeX(point.X, panel1.Width) + "_" + TransposeY(point.Y, panel1.Height);
            textBoxTrainTarget.Text = textBoxTrainTarget.Text + "|" + numericUpDownTrainValue.Value;
            if (textBoxInput.Text[0] == '|')
            {
                textBoxInput.Text = textBoxInput.Text.Substring(1);
            }
            if (textBoxTrainTarget.Text[0] == '|')
            {
                textBoxTrainTarget.Text = textBoxTrainTarget.Text.Substring(1);
            }

            return point;
        }

        private void PaintInputs()
        {
            for (int index = 0; index < textBoxInput.Text.Split('|').Length; index++)
            {
                string input = textBoxInput.Text.Split('|')[index];
                string target = textBoxTrainTarget.Text.Split('|')[index];

                var xValue = UnTransposeX(int.Parse(input.Split('_')[0]), panel1.Width);
                var yValue = TransposeY(int.Parse(input.Split('_')[1]), panel1.Width);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    //g.Clear(Color.White);
                    if (target == "0")
                    {
                        g.FillEllipse(Brushes.Green, new Rectangle(xValue - 1, yValue - 1, 11, 11));
                        g.FillEllipse(Brushes.Blue, new Rectangle(xValue, yValue, 9, 9));
                    }
                    else
                    {
                        g.FillEllipse(Brushes.Green, new Rectangle(xValue - 1, yValue - 1, 11, 11));
                        g.FillEllipse(Brushes.Red, new Rectangle(xValue, yValue, 9, 9));
                    }

                }
                
            }
        }

        private int TransposeY(int y, int height)
        {
            return (-y + height) - (height/2);
        }

        private int TransposeX(int x, int width)
        {
            return x - (width/2);
        }

        private int UnTransposeX(int x, int width)
        {
            return x + (width/2);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, new Point(0, 0));
        }

        private void numericUpDownTrainingLapse_ValueChanged(object sender, EventArgs e)
        {
            DateTime EndDate = dateTimePickerStartDate.Value.AddSeconds(Convert.ToDouble(numericUpDownTrainingLapse.Value));
            labelEndDate.Text = "EndDate = " + EndDate.ToShortDateString() + " / " + EndDate.ToLongTimeString();
        }

        private void buttonGenerateOutput_Click(object sender, EventArgs e)
        {
            try
            {
                _mainController.GenerateTrainOutputCompressed(Convert.ToInt32(numericUpDownForwardSeconds.Value), listBoxSymbol.SelectedItem.ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
        }

        private void buttonRunGeneticMongo_Click(object sender, EventArgs e)
        {
            _mainController.TrainGenetic(Convert.ToInt32(numericUpDownIterations.Value), Convert.ToInt32(numericUpDownGenerationsNumber.Value), _shape);
        }
    }
}
