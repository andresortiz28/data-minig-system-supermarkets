using Apriori.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Apriori.Model
{
    public class Rule : IComparable<Rule>
    {
        public List<int> x;
        public List<int> y;
        public double frecuencia;

        public Rule(List<int> x, List<int> y, double frecuency)
        {
            this.x = x;
            this.y = y;
            this.frecuencia = frecuency;
        }


        public Rule(List<int> x, List<int> y)
        {
            this.x = x;
            this.y = y;
        }

        public double getFrequency()
        {
            return frecuencia;
        }

        public void setFrequency(double nuevo)
        {
            this.frecuencia = nuevo;
        }

        override
        public String ToString()
        {
            string xval = "";
            string yval = "";

            foreach (int tempx in x)
            {
                xval += tempx + "\t";
            }

            foreach (int tempy in y)
            {
                yval += tempy + "\t";
            }

            return xval + "->\t" + yval + ":\t" + (int)(this.frecuencia * 100) + " %";
        }

        public String ToStringName()
        {
            string xval = "( ";
            string yval = "( ";

            foreach (int tempx in x)
            {
                xval += FileManager.getName(tempx).Trim( '"' ) + ", ";
            }

            foreach (int tempy in y)
            {
                yval += FileManager.getName(tempy).Trim('"') + ", ";
            }
            xval = xval.Substring(0, xval.Length - 2);
            yval = yval.Substring(0, yval.Length - 2);

            return "{ " + xval + " )" + "   ->   " + yval + " )" + "  :  " + (int)(this.frecuencia * 100) + " % }";
        }

        public Rule clone()
        {
            List<int> xnew = new List<int>();
            xnew.AddRange(this.x);

            List<int> ynew = new List<int>();
            ynew.AddRange(this.y);

            Rule r = new Rule(xnew, ynew);
            r.setFrequency(this.frecuencia);

            return r;
        }

        public int CompareTo(Rule r)
        {
            if (frecuencia < r.frecuencia)
                return -1;
            if (frecuencia > r.frecuencia)
                return 1;
            return 0;
        }
    }
}

