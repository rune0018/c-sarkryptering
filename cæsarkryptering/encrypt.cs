using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace cæsarkryptering
{
    public class encrypt
    {

        public static double[] freq_norm = [0.64297, 0.11746, 0.21902, 0.33483, 1.00000, 0.17541,
            0.15864, 0.47977, 0.54842, 0.01205, 0.06078, 0.31688, 0.18942,
            0.53133, 0.59101, 0.15187, 0.00748, 0.47134, 0.49811, 0.71296,
            0.21713, 0.07700, 0.18580, 0.01181, 0.15541, 0.00583];
        public static string alltext = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string simplekrypt(string input, int moveby = 2)
        {
            if(moveby < -alltext.Length)
            {
                moveby = moveby * -2;
                moveby = moveby / 2;
                moveby = moveby % alltext.Length;
                moveby = moveby - moveby - moveby;
            }
            string output = "";
            foreach (char a in input)
            {
                for (int i = 0; i < alltext.Length; i++)
                {
                    if (a.ToString().ToUpper().ToCharArray()[0] == alltext[i])
                    {
                        int ind = (i + moveby) % alltext.Length;
                        if (ind < 0)
                            ind += alltext.Length;
                        output += alltext[ind];
                    }
                    else if (a == ' ') {  output += a; }
                }
            }
            return output;
        }
        public static string advancedencrypt(string input,string key)
        {
            key = key.ToUpper();
            input = input.ToUpper();
            string encrypted = "";
            int keyindex = 0;
            List<int> keys = keydecode(key);
            foreach (char a in input)
            {
                for (int i = 0; i < alltext.Length; i++)
                {
                    if (a.Equals(alltext[i]))
                    {
                        int ind = (i+keys[keyindex]) % alltext.Length;
                        encrypted += alltext[ind];
                    }
                    else if(a == ' ') encrypted += a;
                }
                keyindex = (keyindex + 1) % key.Length;
            }
            return encrypted;
        }
        public static string advanceddecrypt(string input,string key)
        {
            List<int> keys = keydecode(key);
            key = "";
            for(int i = 0; i < keys.Count; i++)
            {
                
                key += alltext[(alltext.Length - keys[i])%alltext.Length];
            }
            return advancedencrypt(input, key);
        }
        private static List<int> keydecode(string key)
        {
            List<int> keys = new List<int>(); int temp = 0;
            foreach (char c in key)
            {
                for (int b = 0; b < alltext.Length; b++)
                {
                    if (temp < key.Length)
                        if (alltext[b] == key.ToCharArray()[temp])
                        {
                            keys.Add(b);
                            temp++;
                        }
                }
            }
            return keys;
        }
        public static double[] frequency(string input)
        {
            double[] result=new double[alltext.Length];
            double todiv = 0;
            foreach (char a in input)
            {
                for(int i = 0;i < alltext.Length; i++)
                {
                    if (a == alltext[i])
                    {
                        
                        result[i]++;
                    }

                }
            }
            foreach(double temp in result)
            {
                if (temp > todiv)
                {
                    todiv = temp;
                }
            }
            double[] output = new double[alltext.Length];
            for(int i = 0;i<26 ; i++)
            {
                output[i] = result[i]/ todiv;
            }
            return output;
        }

        public static string autodecrypt(string input)
        {
            Dictionary<int, double[]> frequencys = new Dictionary<int, double[]>();
            for (int i = 0;i<alltext.Length;i++) {
                string temp = simplekrypt(input, i);
                frequencys.Add(i, frequency(temp));
            }
            double[] errindex = new double[alltext.Length];
            int currenterrindex = 0;
            foreach (double[] keyValuePair in frequencys.Values) {
                double err = 0;
                for (int i = 0; i < keyValuePair.Length; i++)
                {
                    err += Math.Abs(freq_norm[i] - keyValuePair[i]);
                }
                errindex[currenterrindex] = err;
                currenterrindex++;
            }
            int currentlowestindexErr = 0;
            double lowestErr = 100;
            for(int i = 0; i < alltext.Length; i++)
            {
                if (errindex[i] < lowestErr)
                {
                    lowestErr = errindex[i];
                    currentlowestindexErr = i;
                }
            }

            return simplekrypt(input,currentlowestindexErr);
        }
    }
}
