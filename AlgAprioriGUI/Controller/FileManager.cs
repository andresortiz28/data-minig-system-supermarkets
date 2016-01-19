using Apriori.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Apriori.Controller
{
    public class FileManager : Manager
    {
        private string path;
        private string path2;

        public string Path2
        {
            get { return path2; }
            set { path2 = value; }
        }
        private string path3;
        private int min;
        private int max;
        private StreamReader reader;
        private ArrayList items;

        public ArrayList Items
        {
            get { return items; }
            set { items = value; }
        }
        private Hashtable itemsHash;
        private ArrayList transactions;

        public ArrayList Transactions
        {
            get { return transactions; }
            set { transactions = value; }
        }
        private static Hashtable itemsNames = new Hashtable();
        private Database db;


        public FileManager(ArrayList items, Hashtable itemsHash, ArrayList transactions, Database db)
        {
            this.path = "htrcVtaI2013_";
            this.path2 = "example.txt";
            this.path3 = "productos.txt";
            this.min = 1;
            this.max = 11;
            this.reader = null;

            this.items = items;
            this.itemsHash = itemsHash;
            this.transactions = transactions;
            this.db = db;
        }


        public void loadExample()
        {
            this.reader = new StreamReader(path2);
            string line = "";

            String[] codes = null;
            while ((line = reader.ReadLine()) != null)
            {
                codes = line.Split(',');
                Hashtable t = new Hashtable();
                for (int i = 0; i < codes.Length; i++)
                {
                    int product = Int32.Parse(codes[i]);
                    if (!itemsHash.ContainsKey(product))
                    {
                        items.Add(product);
                        itemsHash.Add(product, 0);
                    }
                    t.Add(product, "");
                    addFrecuency(product);
                }
                transactions.Add(t);
            }
            reader.Close();
        }


        public override void loadInfo()
        {
            this.reader = new StreamReader(path);

            string line = "";
            string[] data = null;
            Hashtable t = new Hashtable();
            string date = "";
            String code = "";

            Boolean added = false;
            while ((line = reader.ReadLine()) != null)
            {
                added = false;
                data = line.Split('|');
                int product = Int32.Parse(data[3]);
                if (!itemsHash.ContainsKey(product))
                {
                    itemsHash.Add(product, 0);
                    items.Add(product);
                }

                if (data[0] == date)
                {
                    if (data[2] == code)
                    {
                        if (!t.ContainsKey(data[3]))
                        {
                            t.Add(product, "");
                            addFrecuency(product);
                        }
                    }
                    else
                    {
                        transactions.Add(t.Clone());
                        t.Clear();
                        added = true;
                        code = data[2];
                        t.Add(product, "");
                        addFrecuency(product);
                    }
                }
                else
                {
                    if (t.Keys.Count > 0)
                        transactions.Add(t.Clone());
                    t.Clear();
                    added = true;
                    date = data[0];
                    code = data[2];
                    t.Add(product, "");
                    addFrecuency(product);
                }
            }
            if (!added & t.Count > 0)
                transactions.Add(t.Clone());
            reader.Close();
        }



        public override void loadInfo(DateTime date)
        {
            //Load the data from the 11 offices.
            for (int i = min; i <= max; i++)
            {
                string ext = "10" + i;
                if (i > 9)
                    ext = "1" + i;

                this.reader = new StreamReader(path + ext);
                print("Loading trasactions of Store " + ext + "...");

                string line = "";
                string[] data = null;
                Hashtable t = new Hashtable();
                String code = "";
                Boolean added = false;

                while ((line = reader.ReadLine()) != null)
                {
                    added = false;
                    data = line.Split('|');

                    string[] datax = data[0].Split('-');
                    int y = Int32.Parse(datax[0]);
                    int m = Int32.Parse(datax[1]);
                    int d = Int32.Parse(datax[2]);

                    if (y == date.Year && m == date.Month && d == date.Day)
                    {
                        int product = Int32.Parse(data[3]);
                        if (!itemsHash.ContainsKey(product))
                        {
                            itemsHash.Add(product, 0);
                            items.Add(product);
                        }

                        if (data[2] == code)
                        {
                            if (!t.ContainsKey(data[3]))
                            {
                                t.Add(product, "");
                                addFrecuency(product);
                            }

                        }
                        if (data[2] != code)
                        {
                            if (t.Keys.Count > 0)
                                transactions.Add(t.Clone());
                            t.Clear();
                            added = true;
                            code = data[2];
                            t.Add(product, "");
                            addFrecuency(product);
                        }
                    }

                }
                if (!added & t.Count > 0)
                    transactions.Add(t.Clone());

            }
            reader.Close();
        }



        public override void loadInfo(ArrayList months)
        {
            //Load the data from the 12 offices.
            for (int i = min; i <= max; i++)
            {
                string ext = "10" + i;
                if (i > 9)
                    ext = "1" + i;

                this.reader = new StreamReader(path + ext);
                print("Loading trasactions of Store: " + ext);

                string line = "";
                string[] data = null;
                Hashtable t = new Hashtable();
                String code = "";
                Boolean added = false;

                while ((line = reader.ReadLine()) != null)
                {
                    added = false;
                    data = line.Split('|');
                    string[] datax = data[0].Split('-');
                    int m = Int32.Parse(datax[1]);

                    Boolean correct = false;
                    foreach (int month in months)
                    {
                        if (m == month)
                        {
                            correct = true;
                            break;
                        }
                    }

                    if (correct)
                    {
                        int product = Int32.Parse(data[3]);
                        if (!itemsHash.ContainsKey(product))
                        {
                            itemsHash.Add(product, 0);
                            items.Add(product);
                        }
                        if (data[2] == code)
                        {
                            if (!t.ContainsKey(data[3]))
                            {
                                t.Add(product, "");
                                addFrecuency(product);
                            }

                        }
                        if (data[2] != code)
                        {
                            if (t.Keys.Count > 0)
                                transactions.Add(t.Clone());
                            t.Clear();
                            added = true;
                            code = data[2];
                            t.Add(product, "");
                            addFrecuency(product);
                        }
                    }

                }
                if (!added & t.Count > 0)
                    transactions.Add(t.Clone());

            }
            reader.Close();
        }


        public override void loadInfo(DateTime date, int store)
        {
            this.reader = new StreamReader(path + "" + store);

            string line = "";
            string[] data = null;
            Hashtable t = new Hashtable();
            String code = "";
            Boolean added = false;

            while ((line = reader.ReadLine()) != null)
            {
                added = false;
                data = line.Split('|');

                string[] datax = data[0].Split('-');
                int y = Int32.Parse(datax[0]);
                int m = Int32.Parse(datax[1]);
                int d = Int32.Parse(datax[2]);

                if (y == date.Year && m == date.Month && d == date.Day)
                {
                    int product = Int32.Parse(data[3]);
                    if (!itemsHash.ContainsKey(product))
                    {
                        itemsHash.Add(product, 0);
                        items.Add(product);
                    }

                    if (data[2] == code)
                    {
                        if (!t.ContainsKey(data[3]))
                        {
                            t.Add(product, "");
                            addFrecuency(product);
                        }

                    }
                    if (data[2] != code)
                    {
                        if (t.Keys.Count > 0)
                            transactions.Add(t.Clone());
                        t.Clear();
                        added = true;
                        code = data[2];
                        t.Add(product, "");
                        addFrecuency(product);
                    }
                }

            }
            if (!added & t.Count > 0)
                transactions.Add(t.Clone());
            reader.Close();
        }

        public override void loadInfo(ArrayList months, int store)
        {
            this.reader = new StreamReader(path + "" + store);

            string line = "";
            string[] data = null;
            Hashtable t = new Hashtable();
            String code = "";
            Boolean added = false;

            while ((line = reader.ReadLine()) != null)
            {
                added = false;
                data = line.Split('|');

                string[] datax = data[0].Split('-');
                int m = Int32.Parse(datax[1]);

                Boolean correct = false;
                foreach (int month in months)
                {
                    if (m == month)
                    {
                        correct = true;
                        break;
                    }
                }

                if (correct)
                {
                    int product = Int32.Parse(data[3]);
                    if (!itemsHash.ContainsKey(product))
                    {
                        itemsHash.Add(product, 0);
                        items.Add(product);
                    }

                    if (data[2] == code)
                    {
                        if (!t.ContainsKey(data[3]))
                        {
                            t.Add(product, "");
                            addFrecuency(product);
                        }

                    }
                    if (data[2] != code)
                    {
                        if (t.Keys.Count > 0)
                            transactions.Add(t.Clone());
                        t.Clear();
                        added = true;
                        code = data[2];
                        t.Add(product, "");
                        addFrecuency(product);
                    }
                }

            }
            if (!added & t.Count > 0)
                transactions.Add(t.Clone());
            reader.Close();
        }


        public void addFrecuency(int product)
        {
            int value = (int)itemsHash[product];
            itemsHash[product] = value + 1;
        }


        public override void loadNamesProducts()
        {
            print("\nLoading Product's Names...\n");
            this.reader = new StreamReader(path3);
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                int code = Int32.Parse(data[0]);
                string name = data[1];

                if (itemsHash.ContainsKey(code) && !itemsNames.ContainsKey(code))
                    itemsNames.Add(code, name.ToLower());
            }
            reader.Close();
        }

        public static string getName(int codeProduct)
        {
            return (string)itemsNames[codeProduct];
        }

        public void print(string msg)
        {
            this.db.print(msg);
        }

    }
}
