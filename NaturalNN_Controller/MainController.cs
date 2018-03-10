using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NaturalNN_Controller.Heuristics;
using NaturalNN_Engine.Structures;


namespace NaturalNN_Controller
{
    public class MainController
    {
        private static NeuronNet _network;
        private static readonly Random Rnd = new Random();
        private NaturalDescent _naturalDescent;
        private GeneticAlgorithm _geneticAlgorithm;
        private List<double[]> _inputTrainSet;
        private List<double[]> _outputTrainSet;
        private List<long> _inputTrainSetEpochs;
        bool MC = MongoConnection.MongoConnection.Connect();
        public void CreateNetwork(int[] shape)
        {
            _network = new NeuronNet(shape, Rnd);
            _naturalDescent = new NaturalDescent(_network);
        }


        public void RunForward()
        {
            _network.ForwardPropagate();
        }

        public void SetInput(double[] inputArray)
        {
            if (_network.InputLayer == null)
            {
                _network.SetInputLayer(inputArray);
            }
            else
            {
                _network.SetInputLayer(inputArray);
            }
        }

        public static string GetNetworkOutputString()
        {
            string result = string.Empty;
            double[] outputArray = _network.GetOutputValues();
            foreach (double d in outputArray)
            {
                result += d + " - ";
            }
            result += "*";
            result = result.Replace(" - *", "");

            return result;
        }

        public void TrainNatural(List<double[]> inputTrainSet, List<double[]> outputTarget, int iterationsNumber)
        {
            _naturalDescent.TrainNatural(inputTrainSet,outputTarget,iterationsNumber);
        }

        

        public void TrainGenetic(List<double[]> inputTrainSet, List<double[]> outputTarget, int iterationsNumber, int populationSize, int[] shape)
        {
            _geneticAlgorithm = new GeneticAlgorithm(shape, populationSize, Rnd, -1, 1, inputTrainSet[0]);
            _geneticAlgorithm.RunGenerations(iterationsNumber, inputTrainSet, outputTarget, 4);
            _network = _geneticAlgorithm.PopulationList.First();
        }

        public void TrainGenetic(int iterationsNumber, int populationSize, int[] shape)
        {
            _geneticAlgorithm = new GeneticAlgorithm(shape, populationSize, Rnd, -1, 1, _inputTrainSet.First());
            _geneticAlgorithm.RunGenerations(iterationsNumber, _inputTrainSet, _outputTrainSet, 4);
            _network = _geneticAlgorithm.PopulationList.First();
        }

        public double[] GetNetworkOutput(double[] inputPixel)
        {
            SetInput(inputPixel);
            RunForward();

            return _network.GetOutputValues();
        }

        public List<string> GetSymbols()
        {
            if (!MC) { throw new Exception("Not Connected"); }
            return MongoConnection.MongoConnection.SymbolList();
        }

        public List<string> GetSymbolsSql()
        {
            return SqlConnection.SqlConnection.SymbolList();
        }

        public DateTime GetMinDate()
        {
            if (!MC) { throw new Exception("Not Connected"); }
            return MongoConnection.MongoConnection.GetMinDate();
        }

        public DateTime GetMaxDate()
        {
            if (!MC) { throw new Exception("Not Connected"); }
            return MongoConnection.MongoConnection.GetMaxDate();
        }

        public int GetTicksCount()
        {
            if (!MC) { throw new Exception("Not Connected"); }
            return MongoConnection.MongoConnection.GetTicksCount();
        }

        public void GenerateTrainInputCompressed(DateTime startTime, DateTime endTime)
        {
            _inputTrainSet = MongoConnection.MongoConnection.GetAllTicksRangeCompressed(startTime, endTime);
            _inputTrainSetEpochs = MongoConnection.MongoConnection.GetAllTicksEpochsRangeCompressed(startTime, endTime);
        }
        
        public void GenerateTrainInputCompressedVariation(DateTime startTime, DateTime endTime, int backTimeSeconds)
        {

            //WIP
            //_inputTrainSet = MongoConnection.MongoConnection.GetAllTicksRangeCompressedVariation(startTime, endTime, backTimeSeconds);
            _inputTrainSetEpochs = MongoConnection.MongoConnection.GetAllTicksEpochsRangeCompressed(startTime, endTime);
        }

        public void GenerateTrainOutputCompressed(int fowardSeconds, string symbol)
        {
            if(_inputTrainSet == null) { throw new Exception("Must generate input first!"); }

            _outputTrainSet = MongoConnection.MongoConnection.GetPredictions(_inputTrainSetEpochs, fowardSeconds, symbol);
        }
    }
}
