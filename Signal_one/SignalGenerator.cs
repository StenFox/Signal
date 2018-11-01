using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signal_one
{
    public static class SignalGenerator
    {
        const int maxValue = 255;
        const int minValue = 0;

        public static void GenerationSquareSignal(int _samplingFrequency, int _signalDuration, ref List<double> _signal)
        {
            int countValue = _samplingFrequency * _signalDuration;
            int period = _samplingFrequency * 2;
            _signal = new List<double>(countValue);
            for (int i = 0; i < countValue; i++)
            {
                _signal.Insert(i, i % period < _samplingFrequency ? maxValue : minValue);
            }
        }

        public static void GenerationSawtoothSignal(int _samplingFrequency, int _signalDuration, ref List<double> _signal)
        {
            int countValue = _samplingFrequency * _signalDuration;
            int period = _samplingFrequency * 2;
            double step = (double)_samplingFrequency / maxValue;
            _signal = new List<double>(countValue);
            bool flag = true;
            int j = 0;
            for (int i = 0; i < countValue; i++,j++)
            {
                if( j >= _samplingFrequency )
                {
                    j = 0;
                    flag = flag ? false : true;
                }
                if( flag )
                    _signal.Insert(i, maxValue * j / _samplingFrequency);
                else
                    _signal.Insert(i, maxValue * j / _samplingFrequency - maxValue );
            }
        }

        public static void GenerationTriangularSignal(int _samplingFrequency, int _signalDuration, ref List<double> _signal)
        {
            int countValue = _samplingFrequency * _signalDuration;
            int period = countValue / 2;
            double step = period / maxValue;
            _signal = new List<double>(countValue);
            for (int i = 0; i < period; i++)
                _signal.Insert(i, step * i);
            int j = 0;
            for (int i = period; i < countValue; i++, j++)
                _signal.Insert(i, -maxValue + step * j);
        }
    }

}
