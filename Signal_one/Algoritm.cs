using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Signal_one
{
    public static class Algoritm
    {

        public static List<double> getAmplitudeSignalSpectrum(ref List<double> a, ref List<double> b)
        {
            List<double> amplitudeSignalSpectrum = new List<double>(a.Count);
            for (int i = 0; i < a.Count; i++)
            {
                amplitudeSignalSpectrum.Add(Math.Sqrt(a.ElementAt(i) * a.ElementAt(i) + b.ElementAt(i) * b.ElementAt(i)));
            }
            return amplitudeSignalSpectrum;
        }

        public static List<double> getSignalPhaseSpectrum(ref List<double> a, ref List<double> b)
        {
            List<double> signalPhaseSpectrum = new List<double>(a.Count);
            for (int i = 0; i < a.Count; i++)
            {
                signalPhaseSpectrum.Add(Math.Atan2(b.ElementAt(i), a.ElementAt(i)));
            }
            return signalPhaseSpectrum;
        }

        private static int reverse(int I, int T)
        {
            int R;
            int Shift;
            int k;
            R = 0;
            Shift = T - 1;
            int Low, High;
            Low = 1;
            High = 1 << Shift;
            while (Shift >= 0)
            {
                k = ((I & Low) << Shift) | ((I & High) >> Shift);
                R = R | k;
                Shift -= 2;
                Low = Low << 1;
                High = High >> 1;
            }
            return R;
            //int reversedN = I;
            //int count = T - 1;

            //I >>= 1;
            //while (I > 0)
            //{
            //    reversedN = (reversedN << 1) | (I & 1);
            //    count--;
            //    I >>= 1;
            //}

            //return ((reversedN << count) & ((1 << T) - 1));
        }

        public static void BPF(bool isDirectConversion, ref List<double> _signal, ref List<double> _realDPFSignal, ref List<double> _imaginaryDPFSignal)
        {
            int N = isDirectConversion ? _signal.Count : _realDPFSignal.Count;
            int M = Convert.ToInt32(Math.Log(N, 2));
            if (isDirectConversion)
            {
                for (int i = 0; i < N; i++)
                {
                    _realDPFSignal.Add(_signal.ElementAt(i));
                    _imaginaryDPFSignal.Add(0);
                }
            }
            for (int i = 0; i < N; i++) // цикл построения массивов из реверса битов
            {
                int k = reverse(i, M);
                if (i < k)
                {
                    double Sa = _realDPFSignal.ElementAt(i);
                    _realDPFSignal[i] = _realDPFSignal.ElementAt(k);
                    _realDPFSignal[k] = Sa;
                    Sa = _imaginaryDPFSignal.ElementAt(i);
                    _imaginaryDPFSignal[i] = _imaginaryDPFSignal.ElementAt(k);
                    _imaginaryDPFSignal[k] = Sa;
                }
            }

            for (int s = 1; s <= M; s++)
            {
                int m = 1;
                for (int j = 1; j <= s; j++)
                {
                    m = m * 2;
                }
                double WmR = Math.Cos(2 * Math.PI / m);
                double WmI = Math.Sin(2 * Math.PI / m);
                for (int k = 0; k < N; k += m)
                {
                    double WR = 1;
                    double WI = 0;
                    for (int j = 0; j <= m / 2 - 1; j++)
                    {
                        // WR,WI; tr,ti; ur,ui – вещ. и мнимые части соотв. комплексных величин.
                        double tr = _realDPFSignal.ElementAt(k + j + m / 2) * WR - _imaginaryDPFSignal.ElementAt(k + j + m / 2) * WI;
                        double ti = _realDPFSignal.ElementAt(k + j + m / 2) * WI + _imaginaryDPFSignal.ElementAt(k + j + m / 2) * WR;
                        double ur = _realDPFSignal.ElementAt(k + j);
                        double ui = _imaginaryDPFSignal.ElementAt(k + j);
                        _realDPFSignal[k + j] = tr + ur;
                        _imaginaryDPFSignal[k + j] = ti + ui; ;
                        _realDPFSignal[k + j + m / 2] = ur - tr;
                        _imaginaryDPFSignal[k + j + m / 2] = ui - ti;
                        double x = WR * WmR - WI * WmI;
                        double y = WR * WmI + WI * WmR;
                        WR = x;
                        WI = y;
                    }
                }
            }
            if (isDirectConversion)
            {
                for (int k = 0; k < N; k++)
                {
                    _realDPFSignal[k] = _realDPFSignal.ElementAt(k) / N;
                    _imaginaryDPFSignal[k] = _imaginaryDPFSignal.ElementAt(k) / N;
                }
            }
        }


        public static void DPF(bool isDirectConversion, ref List<double> _signal, ref List<double> _realDPFSignal, ref List<double> _imaginaryDPFSignal)
        {
            int N = isDirectConversion ? _signal.Count : _realDPFSignal.Count;
            for (int k = 0; k < N; k++)
            {
                if (isDirectConversion)
                {
                    _realDPFSignal.Add(0);
                    _imaginaryDPFSignal.Add(0);
                }
                else
                {
                    _signal.Insert(k, 0);
                }

                for (int i = 0; i < N; i++)
                {
                    if (isDirectConversion)
                    {
                        _realDPFSignal[k] += _signal.ElementAt(i) * Math.Cos(2.0 * Math.PI * k * i / N);
                        _imaginaryDPFSignal[k] += _signal.ElementAt(i) * Math.Sin(2.0 * Math.PI * k * i / N);
                    }
                    else
                    {
                        _signal[k] += _realDPFSignal.ElementAt(i) * Math.Cos(2.0 * Math.PI * k * i / N) + _imaginaryDPFSignal.ElementAt(i) * Math.Sin(2.0 * Math.PI * k * i / N);
                    }
                }
                if (isDirectConversion)
                {
                    _realDPFSignal[k] = _realDPFSignal.ElementAt(k) / N;
                    _imaginaryDPFSignal[k] = _imaginaryDPFSignal.ElementAt(k) / N;
                }
            }
        }

        private static bool isPowerOfTwo(int val)
        {
            return val != 0 && (val & (val - 1)) == 0;
        }

        public static void BPFn(bool isDirectConversion, ref List<double> _signal, ref List<double> _realDPFSignal, ref List<double> _imaginaryDPFSignal) // заголовок t=0 – прямое преобразование, t=1 обратное
        {
            int P = 2048;
            int N = isDirectConversion ? _signal.Count : _realDPFSignal.Count;
            int L = Convert.ToInt32(Math.Log(N, 2));
            int M = N / L;

            List<double> a = new List<double>();
            List<double> b = new List<double>();

            for (int i = 0; i < M; i++)
            {
                BPFh(isDirectConversion, i, M, L, ref _signal, ref _realDPFSignal, ref _imaginaryDPFSignal); // вызов БПФ для отсчетов шагом M
            }
            for (int s = 0; s < M; s++)
            {
                for (int r = 0; r < L; r++)
                {
                    a.Insert(r + s * L, 0); // a1,b1 всомогательные, такие же, как a,b
                    b.Insert(r + s * L, 0);
                    for (int m = 0; m < M; m++)
                    {
                        a[r + s * L] += a.ElementAt(m + r * M)
                            * Math.Cos(2 * Math.PI * m * (r + s * L) / N)
                            - b.ElementAt(m + r * M) * Math.Sin(2 * Math.PI * m * (r + s * L) / N);
                        b[r + s * L] += a.ElementAt(m + r * M)
                            * Math.Sin(2 * Math.PI * m * (r + s * L) / N)
                            + b.ElementAt(m + r * M) * Math.Cos(2 * Math.PI * m * (r + s * L) / N);
                    }
                }
            }
            for (int i = 0; i < N; i++)
            {
                _realDPFSignal.Insert(i, a.ElementAt(i));
                _imaginaryDPFSignal.Insert(i, b.ElementAt(i));
            }
            if (isDirectConversion)
            {
                for (int k = 0; k < N; k++)
                {
                    _realDPFSignal[k] = _realDPFSignal.ElementAt(k) / N;
                    _imaginaryDPFSignal[k] = _imaginaryDPFSignal.ElementAt(k) / N;
                }
            }
        }

        public static void BPFh(bool isDirectConversion, int Z, int H, int N, ref List<double> _signal, ref List<double> _realDPFSignal, ref List<double> _imaginaryDPFSignal) // БПФ с шагом H от отсчета Z
        {
            int M = Convert.ToInt32(Math.Log(N, 2));
            if (isDirectConversion)
            {
                for (int i = Z; i < N * H; i += H)
                {
                    _realDPFSignal.Insert(i, _signal.ElementAt(i));
                    _imaginaryDPFSignal.Insert(i, 0);
                }
            }
            for (int i = 0; i < N; i++)
            {
                int k = reverse(i, M);
                int p = Z + i * H;
                int q = Z + k * H;
                if (p < q)
                {
                    double Sa = _realDPFSignal.ElementAt(p);
                    _realDPFSignal[p] = _realDPFSignal.ElementAt(q);
                    _realDPFSignal[q] = Sa;
                    Sa = _imaginaryDPFSignal.ElementAt(p);
                    _imaginaryDPFSignal[p] = _imaginaryDPFSignal.ElementAt(q);
                    _imaginaryDPFSignal[q] = Sa;
                }
            }
            for (int s = 1; s <= M; s++)
            {
                int m = 1;
                for (int j = 1; j <= s; j++)
                {
                    m = m * 2;
                }
                double WmR = Math.Cos(2 * Math.PI / m);
                double WmI = Math.Sin(2 * Math.PI / m);
                for (int k = 0; k < N; k += m)
                {
                    double WR = 1;
                    double WI = 0;
                    for (int j = 0; j <= m / 2 - 1; j++)
                    {
                        int p = k + j + m / 2;
                        int q = k + j;
                        p = Z + p * H;
                        q = Z + q * H;
                        double tr = _realDPFSignal.ElementAt(p) * WR - _imaginaryDPFSignal.ElementAt(p) * WI;
                        double ti = _realDPFSignal.ElementAt(p) * WI + _imaginaryDPFSignal.ElementAt(p) * WR;
                        double ur = _realDPFSignal.ElementAt(q);
                        double ui = _imaginaryDPFSignal.ElementAt(q);
                        _realDPFSignal[q] = tr + ur;
                        _imaginaryDPFSignal[q] = ti + ui;
                        _realDPFSignal[p] = ur - tr;
                        _imaginaryDPFSignal[p] = ui - ti;
                        double x = WR * WmR - WI * WmI;
                        double y = WR * WmI + WI * WmR;
                        WR = x;
                        WI = y;
                    }
                }
            }
        }
    }
}
