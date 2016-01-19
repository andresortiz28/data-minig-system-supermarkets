using Apriori.Model;
using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace Apriori.Controller
{
    public delegate void ExecutableDelegate(object sender, string message);

    public class Executable
    {
        public event ExecutableDelegate Message;
        public const int EXAMPLE = 0;
        public const int ALL_STORES_BY_DATE = 1;
        public const int ALL_STORES_BY_MONTH = 2;
        public const int ONE_STORE_BY_DATE = 3;
        public const int ONE_STORE_BY_MONTH = 4;

        private AprioriAlgorithm algorithm;
        private double min_sup;
        private double confidence;
        private DateTime date;
        private ArrayList months;
        private int store;
        private int load;

        public Executable()
        {            
            this.algorithm = new AprioriAlgorithm(this);
        }

        public void executeAlgorithm()
        {
            print("Universidad ICESI");
            print("Proyecto Integrador 2014-1");

            loadInformation();

            int support = (int)(min_sup * algorithm.getTransactions().Count);
            algorithm.setSupport(support);
            algorithm.setConfidence(confidence);

            print("Starting the Apriori Algorithm...\n");
            print("Support \t\t" + (min_sup * 100) + "% : " + support);
            print("Confidence \t" + (confidence * 100) + "%\n");


            Stopwatch time = new Stopwatch();
            time.Start();

            algorithm.execute();

            time.Stop();
            TimeSpan tm = time.Elapsed;
            print("\n--------------------------------------------------------Processing Time: " + tm + "\n\n");

            //printAllLk();
            //printLastLk();
        }
        
        public void setParameters(double min_sup, double confidence, DateTime date, ArrayList months, int store)
        {
            this.min_sup = min_sup;
            this.confidence = confidence;
            this.date = date;
            this.months = months;
            this.store = store;

            if (store == -1)
            {
                if (date.Year == 9998)
                    this.load = ALL_STORES_BY_MONTH;
                else
                    this.load = ALL_STORES_BY_DATE;
            }
            else
            {
                if (date.Year != 9998)
                    this.load = ONE_STORE_BY_DATE;
                else
                    this.load = ONE_STORE_BY_MONTH;
            }
            
            //En este punto pedir todos los datos de la interfaz, y decidir a punta de validaciones de datos que TIPO de carga es.
            //Las constantes que se le dan a esta variable LOAD, esta arriba, y son los casos que queremos que suceda o que cargue.
            //this.load = EXAMPLE;
        }

        public void loadInformation()
        {
            print("\nLoading Information...");
            Stopwatch time = new Stopwatch();
            time.Start();

            switch (this.load)
            {
                case EXAMPLE: print("\nExample\n");
                    algorithm.loadExample();
                    break;

                case ALL_STORES_BY_DATE: print("\nStore: All \nDate: " + date + "\n");
                    algorithm.loadInfo(date);
                    break;

                case ALL_STORES_BY_MONTH: print("\nStore: All \nMonth: " + getMonths(months) + "\n");
                    algorithm.loadInfo(months);
                    break;

                case ONE_STORE_BY_DATE: print("\nStore: " + store + " \nDate: " + date + "\n");
                    algorithm.loadInfo(date, store);
                    break;

                case ONE_STORE_BY_MONTH: print("\nStore: " + store + " \nMonth: " + getMonths(months) + "\n");
                    algorithm.loadInfo(months, store);
                    break;
            }

            time.Stop();
            TimeSpan tm = time.Elapsed;
            print("\nTotal of items:\t\t" + algorithm.getItems().Count);
            print("Total of transactions:\t" + algorithm.getTransactions().Count);
            print("\n--------------------------------------------------------Loading Time: " + tm + "\n\n");
        }


        public void printAllLk()
        {
            print("\n--------------------------------------------------------LK Tables");
            for (int i = 0; i < algorithm.getLklist().Count; i++)
            {
                algorithm.printLk(i);
            }
        }
        
        public string getMonths(ArrayList months)
        {
            string txt = "";

            foreach (int m in months)
            {
                switch (m)
                {
                    case 1: txt += "January - ";
                        break;
                    case 2: txt += "February - ";
                        break;
                    case 3: txt += "March - ";
                        break;
                    case 4: txt += "April - ";
                        break;
                    case 5: txt += "May - ";
                        break;
                    case 6: txt += "June - ";
                        break;
                }
            }
            return txt.Substring(0, txt.Length - 2);
        }

        public void print(string msg)
        {
            this.OnMessage(msg);
        }

        public void OnMessage(string message)
        {
            message += Environment.NewLine;
            // If event is wired, fire it!
            if (Message != null)
            {
                // Get the target and safe cast it.
                Control target = Message.Target as Control;

                // If the target is an control and invoke is required,
                // invoke it; otherwise just fire it normally.
                if (target != null && target.InvokeRequired)
                {
                    object[] args = new object[] { this, message };
                    target.Invoke(Message, args);
                }
                else
                {
                    Message(this, message);
                }
            }
        }

           

    }
}
