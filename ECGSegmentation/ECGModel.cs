using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;


namespace ECGSegmentation
{
    public class ECGModel
    {
        private DataAccess _dataaccess;
        private int dataSet = 1;
        public int dataNumber { get; private set; } = 500;
        public int accuracy { get; private set; } = 0;
        public string statistics { get; private set; }
        public bool extras { get; private set; } = false;
        public DataTable dt { get; private set; }

        private List<int> timetable = new List<int>();
        private List<double> basic = new List<double>();
        private List<double> lowpass = new List<double>();
        private List<double> highpass = new List<double>();
        private List<double> derivative = new List<double>();
        private List<double> squaring = new List<double>();
        private List<double> integration = new List<double>();
        private List<string> dbtimetable = new List<string>();

        private List<int> peakCandidateTime = new List<int>();
        private List<double> peakCandidates = new List<double>();

        private List<double> rpeaks = new List<double>();
        private List<double> thresholds = new List<double>();
        private List<double> signalLevel = new List<double>();
        private List<double> noiseLevel = new List<double>();
        private List<int> peaktime = new List<int>();
        
        public List<double> basicget { get { return basic; } }
        public List<double> lowpassget { get { return lowpass; } }
        public List<double> highpassget { get { return highpass; } }
        public List<double> derivativeget { get { return derivative; } }
        public List<double> squaringget { get { return squaring; } }
        public List<double> integrationget { get { return integration; } }
        public List<string> dbtimeget { get { return dbtimetable; } }
        public List<int> timeget { get { return peaktime; } }

        public ECGModel(DataAccess dataAccess){
            _dataaccess = dataAccess;
            dt = new DataTable();
            dt.Columns.Add("Time", typeof(double));
            dt.Columns.Add("mV", typeof(double));
        }

        public void SetDataNum(int num)
        {
            dataNumber = num;
        }

        public void SetDataSetNum(int num)
        {
            dataSet = num;
        }

        public void SetAccuracy(int num)
        {
            accuracy = num;
        }

        public void ReadFile()
        {
            ModelReset();
            List<string> datas = new List<string>();
            datas =  _dataaccess.LoadDatas(@"Dataset\ECGs" + dataSet + ".csv", dataNumber);
            foreach(String data in datas)
            {
                string[] splitted = data.Split(',');
                if(splitted[0] != "ECG")
                {
                    splitted[0] = splitted[0].Replace(".", ",");
                    dt.Rows.Add(Int32.Parse(splitted[2]) + 1, splitted[0]);

                    basic.Add(Convert.ToDouble(splitted[0]));
                    timetable.Add(Int32.Parse(splitted[2]));
                }
            }
        }
        public void ReadPeaks()
        {
            List<string> datas = new List<string>();
            datas = _dataaccess.LoadDatas(@"Dataset\Rpeaks" + dataSet + ".csv", dataNumber);
            foreach (string data in datas)
            {
                string[] splitted = data.Split(',');
                if (splitted[0] != "Rpeaks")
                {
                    if (Int32.Parse(splitted[0]) <= dataNumber)
                    {
                        dbtimetable.Add(splitted[0]);
                        dbtimetable.Add("\r\n");
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public void ModelReset()
        {
            dt.Clear();

            basic.Clear();
            lowpass.Clear();
            highpass.Clear();
            derivative.Clear();
            squaring.Clear();
            integration.Clear();
            rpeaks.Clear();
            peakCandidates.Clear();
            peakCandidateTime.Clear();
            peaktime.Clear();
            dbtimetable.Clear();
            thresholds.Clear();
            signalLevel.Clear();
            noiseLevel.Clear();

            timetable.Clear();
            extras = false;
        }

        public void LowPass()
        {
            for(int i = 0;i < basic.Count; i++)
            {
                lowpass.Add(basic[i]);
            }

            for(int i = 0;i < lowpass.Count; i++)
            {
                if(i > 11)
                {
                    lowpass[i] = ((2 * lowpass[i - 1]) - lowpass[i - 2] + basic[i] - (2 * basic[i - 6]) + basic[i - 12]);
                }
            }

            dt = createDT(lowpass);
        }
        
        public void HighPass()
        {
            for (int i = 0; i < lowpass.Count; i++)
            {
                highpass.Add(lowpass[i]);
            }

            for (int i = 0; i < highpass.Count; i++)
            {
                if (i > 31)
                {
                    highpass[i] = (highpass[i - 1] - (lowpass[i]/32) + lowpass[i-16] - lowpass[i - 17] + (lowpass[i - 32]/32));
                }
            }

            dt = createDT(highpass);
        }
        
        public void Derivative()
        {
            for (int i = 0; i < highpass.Count; i++)
            {
                derivative.Add(highpass[i]);
            }

            for (int i = 0; i < derivative.Count; i++)
            {
                if (i > 3)
                {
                    derivative[i] = ((2 * highpass[i]) + highpass[i - 1] - highpass[i - 3] - (2 * highpass[i - 4]))/4;
                }
            }

            dt = createDT(derivative);
        }
        
        public void Squaring()
        {
            for (int i = 0; i < derivative.Count; i++)
            {
                squaring.Add(derivative[i]);
            }

            for (int i = 0; i < squaring.Count; i++)
            {
                squaring[i] = Math.Pow(derivative[i],2);
            }

            dt = createDT(squaring);
        }

        public void Integration()
        {
            for (int i = 0; i < squaring.Count; i++)
            {
                integration.Add(squaring[i]);
            }

            int ws = 24;
            for (int i = 0;i < integration.Count; i++)
            {
                if(i > basic.Count - ws - 2)
                {
                    break;
                }
                if(i > ws)
                {
                    double sum = 0;
                    for(int j = i - ws; j < i + ws + 1;j++)
                    {
                        sum += squaring[j];
                    }
                    integration[i] = sum / (ws + 1);
                }
            }

            dt = createDT(integration);
        }

        public void Preprocessing()
        {
            LowPass();
            HighPass();
            Derivative();
            Squaring();
            Integration();
        }

        private double maxselector()
        {
            double maxi = 0;
            for(int i = 0; i < 300; i++)
            {
                if(integration[i] > maxi)
                {
                    maxi = integration[i];
                }
            }
            return maxi;
        }

        private void peakFinder()
        {
            double currentmaxCandidate = 0;
            int candidateTime = 0;
            int lastpeakcounter = 50;
            for (int i = 23; i < integration.Count; i++)
            {
                if (integration[i] > currentmaxCandidate)
                {
                    currentmaxCandidate = integration[i];
                    candidateTime = i;
                }
                if (integration[i] < currentmaxCandidate / 2 && !peakCandidates.Contains(currentmaxCandidate))
                {
                    peakCandidates.Add(currentmaxCandidate);
                    peakCandidateTime.Add(candidateTime);
                    currentmaxCandidate = 0;
                    lastpeakcounter = 0;
                }
                if (lastpeakcounter == 300)
                {
                    peakCandidates.Add(currentmaxCandidate);
                    peakCandidateTime.Add(candidateTime);
                    lastpeakcounter = 0;
                    currentmaxCandidate = 0;
                }
                lastpeakcounter++;
            }

            int k = 0;
            while (k < peakCandidateTime.Count - 1)
            {
                if (peakCandidateTime[k + 1] - peakCandidateTime[k] <= 80)
                {
                    if (peakCandidates[k] > peakCandidates[k + 1])
                    {
                        peakCandidates.RemoveAt(k + 1);
                        peakCandidateTime.RemoveAt(k + 1);
                    }
                    else
                    {
                        peakCandidates.RemoveAt(k);
                        peakCandidateTime.RemoveAt(k);
                    }
                }
                else
                {
                    k++;
                }
            }
        }

        public void Detection(bool isExtras)
        {
            extras = isExtras;
            double MAX_L = maxselector();
            double noise_level = 0.1 * MAX_L;
            double signal_level = 0.13 * MAX_L;
            double threshold = 0.25 * signal_level + 0.75 * noise_level;
            double threshold2 = 0.5 * threshold;
            double averageRR = 0;
            bool searchback = false;

            peakFinder();

            int lastrcounter = 0;
            for (int i = 0; i < peakCandidates.Count; i++)
            {
                averageRR = 0;
                thresholds.Add(threshold);
                signalLevel.Add(signal_level);
                noiseLevel.Add(noise_level);
                if (peakCandidates[i] > threshold && !searchback)
                {
                    rpeaks.Add(basic[peakCandidateTime[i] - 22]);
                    peaktime.Add(timetable[peakCandidateTime[i] - 22]);
                    signal_level = 0.875 * signal_level + 0.125 * peakCandidates[i];
                    lastrcounter = 0;
                }
                else if(peakCandidates[i] > threshold2 && searchback)
                {
                    rpeaks.Add(basic[peakCandidateTime[i] - 22]);
                    peaktime.Add(timetable[peakCandidateTime[i] - 22]);
                    signal_level = 0.875 * signal_level + 0.125 * peakCandidates[i];
                    lastrcounter = 0;
                    searchback = false;
                }
                else
                {
                    noise_level = 0.875 * noise_level + 0.125 * peakCandidates[i];
                }

                if(rpeaks.Count >= 10)
                {
                    for(int j = rpeaks.Count-10;j < rpeaks.Count-1; j++)
                    {
                        averageRR += peaktime[j] - peaktime[j + 1];
                    }
                    averageRR /= 10;
                }

                if(lastrcounter == 400)
                {
                    signal_level = 0.5 * signal_level;
                    searchback = true;
                    i -= 400;
                }
                lastrcounter++;
                threshold = noise_level + 0.25 * (signal_level - noise_level);
                threshold2 = 0.5 * threshold;
            }

            DataTable newdt = new DataTable();
            newdt.Columns.Add("Time", typeof(double));
            newdt.Columns.Add("mV", typeof(double));

            if (isExtras)
            {
                newdt.Columns.Add("Threshold", typeof(double));
                newdt.Columns.Add("SignalLevel", typeof(double));
                newdt.Columns.Add("NoiseLevel", typeof(double));

                List<double> newthresholds = new List<double>();
                List<double> newnoise = new List<double>();
                List<double> newsignal = new List<double>();

                int tcounter = 0;
                for(int i = 0; i < timetable.Count; i++)
                {
                    newthresholds.Add(thresholds[tcounter]);
                    newsignal.Add(signalLevel[tcounter]);
                    newnoise.Add(noiseLevel[tcounter]);
                    if(tcounter < peakCandidateTime.Count-1 && timetable[i] == peakCandidateTime[tcounter])
                    {
                        tcounter++;
                    }
                }

                for (int i = 0; i < basic.Count; i++)
                {
                    newdt.Rows.Add(timetable[i] + 1, integration[i], newthresholds[i], newsignal[i], newnoise[i]);
                }
            }
            else
            {
                int k = 0;
                newdt.Columns.Add("Peaks", typeof(double));
                for (int i = 0; i < basic.Count; i++)
                {
                    if (k < peaktime.Count && timetable[i] == peaktime[k])
                    {
                        newdt.Rows.Add(timetable[i] + 1, basic[i], rpeaks[k]);
                        k++;
                    }
                    else
                    {
                        newdt.Rows.Add(timetable[i] + 1, basic[i], 0.2);
                    }
                }
                for (int i = 0;i < basic.Count; i++)
                {
                    if(k < peaktime.Count && timetable[i] == peaktime[k])
                    {
                        newdt.Rows.Add(timetable[i]+1, rpeaks[k]);
                        k++;
                    }
                }
            }

            dt = newdt.Copy();
            CalculateStatistics();
        }

        private DataTable createDT(List<double> type)
        {
            DataTable newdt = new DataTable();
            newdt.Columns.Add("Time", typeof(double));
            newdt.Columns.Add("mV", typeof(double));

            for (int i = 0; i < type.Count; i++)
            {
                newdt.Rows.Add(timetable[i]+1, type[i]);
            }

            return newdt;
        }

        private void CalculateStatistics()
        {
            double stats = 0;
            foreach(string original in dbtimetable)
            {   
                if(original != "\r\n")
                {
                    foreach(double peak in peaktime)
                    {
                        if (Math.Abs(Int32.Parse(original) - peak) <= accuracy)
                        {
                            stats++;
                            break;
                        }
                        if (Int32.Parse(original) - peak < -20)
                        {
                            break;
                        }
                    }
                }
            }
            statistics = ((stats / ((double)dbtimetable.Count / 2)) * 100).ToString();
        }
    }
}
/*double threshold1 = 0;
            double threshold2 = 0;
            double npki = 0;
            double spki = 0;
            bool searchback = false;
            double searchback_end = 0;
            int previous = 0;
            double max_rr_width = 2;
            double min_rr_width = 0.2;

            for (int i = 2;i < integration.Count-2; i++)
            {
                if (i - previous > max_rr_width && i -searchback_end > max_rr_width){
                    searchback = true;
                    searchback_end = i;
                    i = previous + 2;
                    continue;
                }
                if (searchback && i == searchback_end){
                searchback = false;
                continue;
                }

                double peaki = integration[i];
                if(peaki < integration[i - 2] || peaki <= integration[i + 2]){
                    i += 1;
                    continue;
                }

                bool is_qrs = false;
                if (searchback)
                {
                    if (peaki > threshold2)
                    {
                        spki = 0.750 * spki + 0.250 * peaki;
                        is_qrs = true;
                    }
                }
                else if(peaki > threshold1){
                    spki = 0.875 * spki + 0.125 * peaki;
                    is_qrs = true;
                }


                if (is_qrs)
                {
                    if(previous == 0 || i -previous >= min_rr_width){
                        peaks.Add(basic[i]);
                        peaktime.Add(timetable[i]);
                    }
                    else if(integration[previous] < peaki)
                    {
                        peaks[peaks.Count()-1] = i;
                        previous = i;
                    }
                }
                else
                {
                    npki = 0.875 * npki + 0.125 * peaki;
                }
                threshold1 = npki + 0.25 * (spki - npki);
                threshold2 = 0.5 * threshold1;
                i += 1;
            }*/