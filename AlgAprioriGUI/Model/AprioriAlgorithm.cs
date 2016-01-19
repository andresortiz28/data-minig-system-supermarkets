using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Diagnostics;
using Apriori.Model;
using Apriori.Controller;

namespace Apriori.Model
{
    public class AprioriAlgorithm
    {
        private ArrayList items;
        private Hashtable itemsHash;
        private ArrayList transactions;
        
        private ArrayList lk;
        private ArrayList lkhash;
        private Database database;

        private int support;
        private double confidence;
        private ArrayList lklist;
        private ArrayList lkhashlist;
        private List<Rule> rules;

        private Executable control;


        /**
         * Constructor
         * */
        public AprioriAlgorithm(Executable control)
        {
            this.control = control;
            items = new ArrayList();
            itemsHash = new Hashtable();
            transactions = new ArrayList();
            lk = new ArrayList();
            lkhash = new ArrayList();
            database = new Database(items, itemsHash, transactions, this);
            lklist = new ArrayList();
            lkhashlist = new ArrayList();
            rules = new List<Rule>();            
        }

        public void setSupport(int support)
        {
            this.support = support;
        }

        public void setConfidence(double confidence)
        {
            this.confidence = confidence;
        }

        public ArrayList getItems()
        {
            return this.items;
        }

        public Hashtable getItemsHash()
        {
            return this.itemsHash;
        }

        public ArrayList getTransactions()
        {
            return this.transactions;
        }

        public ArrayList getLklist()
        {
            return this.lklist;
        }

        public ArrayList getLkhashlist()
        {
            return this.lkhashlist;
        }


        public void execute()
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            print("Processing C1 & L1...");
            startl1();

            time.Stop();
            TimeSpan tm = time.Elapsed;
            print("\n\tTime: " + tm);
            print("\tItemsets: " + lk.Count + "\n");
            lklist.Add(lk.Clone());
            lkhashlist.Add(lkhash.Clone());
                          
        
            int k = 2;
            while (lk.Count > 1)
            {     
                time = new Stopwatch();
                time.Start();

                print("Processing C" + k + " & L" + k + "...");
                makeJoins();

                time.Stop();
                tm = time.Elapsed;
                print("\n\tTime: " + tm);
                print("\tItemsets: " + lk.Count + "\n");
                lklist.Add(lk.Clone());
                lkhashlist.Add(lkhash.Clone());

                k++;
            }


            //AQUI ARRANCA LOS METODOS PARA BUSCAR LAS REGLAS DE ASOCIACION.(Descomentarlo para ver lo que sucede)

            print("\nSearching Association Rules...");
            findAssociationRules();
            print("Total of Rules: " + rules.Count + "\n");
            printAssociationRules();
            printAssociationRulesWithNames();
        }

        public void loadExample()
        {
            this.database.loadExample();
        }
        
        public void loadInfo()
        {
            this.database.loadInfo();
        }

        public void loadInfo(DateTime date)
        {
            this.database.loadInfo(date);
        }

        public void loadInfo(ArrayList months)
        {
            this.database.loadInfo(months);
        }

        public void loadInfo(DateTime date, int store)
        {
            this.database.loadInfo(date, store);
        }

        public void loadInfo(ArrayList months, int store)
        {
            this.database.loadInfo(months, store);
        }

        
        public void startl1()
        {
            for (int i = 0; i < items.Count; i++)
            {
                ArrayList itemset = new ArrayList();
                Hashtable itemsetHash = new Hashtable();

                int product = (int)items[i];
                itemset.Add(product);
                itemsetHash.Add(product, "");

                int frec = (int)itemsHash[product];
                if (frec >= this.support)
                {
                    itemset.Add(frec);
                    lk.Add(itemset);
                    lkhash.Add(itemsetHash);
                }
            }
        }


        public int countFrecuencies(ArrayList itemset)
        {
            int total = 0;
            int size = transactions.Count;
            int flag = size - this.support;
            for (int i = 0; i < size; i++)
            {
               //if (i >= flag && (total+(size-i+1)) < this.support)
                   //break;

                Hashtable table = (Hashtable)transactions[i];
                bool exist = true;
                for (int j = 0; j < itemset.Count; j++)
                {
                    int n = (int)itemset[j];
                    if (!table.ContainsKey(n))
                    {
                        exist = false;
                        break;
                    }
                }
                if (exist)
                    total++;
            }
            return total;
        }


        public void makeJoins()
        {
            ArrayList joins = new ArrayList();
            Hashtable joinsHash = new Hashtable();

            for (int i = 0; i < lk.Count; i++)
            {
                ArrayList itemset = (ArrayList)lk[i];
                Hashtable itemsetHash = (Hashtable)lkhash[i];

                for (int j = i + 1; j < lk.Count; j++)
                {
                    ArrayList itemsetNext = (ArrayList)lk[j];
                    for (int n=0; n < itemsetNext.Count -1; n++)
                    {
                        int next =  (int)itemsetNext[n];
                        if (!itemsetHash.ContainsKey( next ))
                        {
                            ArrayList copy = (ArrayList)itemset.Clone();
                            copy.RemoveAt(copy.Count -1 );   //Remueve frecuencia que ya estaba
                            copy.Add(next);
                            if (!existJoin(copy, joins))
                                joins.Add(copy);
                        }
                    }
                }
            }
            updateLk(joins);
        }


        public bool existJoin(ArrayList copy, ArrayList joins)
        {
            bool equals = true;
            foreach (ArrayList join in joins)
            {
                equals = true;
                for (int i = 0; i < copy.Count; i++)
                {
                    int n = (int)copy[i];
                    bool exist = false;
                    for (int j = 0; j < join.Count; j++)
                    {
                        if (n == (int)join[j])
                        {
                            exist = true;
                            break;
                        }
                    }
                    if (!exist)
                    {
                        equals = false;
                        break;
                    }
                }
                if (equals)
                    return true;
            }
            return false;
        }


        public void updateLk(ArrayList joins)
        {  
            lk.Clear();
            lkhash.Clear();
            foreach (ArrayList itemset in joins)
            {
                int frec = countFrecuencies(itemset);
                if (frec >= this.support)
                {
                    Hashtable itemsetHash = new Hashtable();
                    foreach (int i in itemset)
                    {
                        itemsetHash.Add(i, "");
                    }
                    itemset.Add(frec);
                    lk.Add(itemset);
                    lkhash.Add(itemsetHash);
                }
            }
        }

        public void printLk(int n)
        {            
            ArrayList lk_temp = (ArrayList)lklist[n];
            print("\nL" + (n + 1));
            print("Total: " + lk_temp.Count + " itemsets!\n");

            foreach (ArrayList itemset in lk_temp)
            {
                String line = "";
                for (int i = 0; i < itemset.Count - 1; i++)
                {
                    line += itemset[i] + "\t";
                }
                int frec = (int)itemset[itemset.Count - 1];
                print(line + "\t:\t"+ frec);
            }
        }






        //ASSOCIATION RULES METHODS------------------------------------------------------------------------------------




        public void findAssociationRules()
        {
            for (int i = 1; i < lklist.Count; i++)
            {
                ArrayList lk = (ArrayList)lklist[i];
                foreach (ArrayList itemset in lk)
                {
                    int k = itemset.Count - 2;

                    while (k > 0)
                    {
                        List<int> itemsetToList = new List<int>();

                        for (int j = 0; j < itemset.Count - 1; j++ ) { itemsetToList.Add((int)itemset[j]); }

                        foreach (List<int> list in Combinations(itemsetToList, k))
                        {
                            List<int> itemsetCopy = new List<int>(); itemsetCopy.AddRange(itemsetToList);
                            itemsetCopy.RemoveAll(item => list.Contains(item));

                            double totalFrecuency = (getRuleFrequency(itemsetToList) / getRuleFrequency(list));

                            if (totalFrecuency >= this.confidence)
                            {
                                rules.Add(new Rule(list, itemsetCopy, totalFrecuency));
                            }
                        }
                        k--;
                    }
                }
            }

        }


        private double getRuleFrequency(List<int> temp)
        {
            double frequency = 0;
            ArrayList lk = (ArrayList)lklist[temp.Count - 1];

            for (int i = 0; i < lk.Count; i++)
            {
                ArrayList itemset = (ArrayList)lk[i];
                Boolean equals = true;

                for (int j = 0; j < itemset.Count - 1; j++)
                {
                    int item = (int)itemset[j];

                    if (!temp.Contains(item))
                    {
                        equals = false;
                        break;
                    }
                }

                if (equals)
                {
                    frequency = Convert.ToDouble(itemset[itemset.Count - 1]);
                    break;
                }

            }
            return frequency;
        }

        private IEnumerable<List<int>> Combinations(List<int> items, int length)
        {
            for (int i = 0; i < items.Count; i++)
            {
                // only want 1 character, just return this one
                if (length == 1)
                    yield return new List<int> { items[i] };

                // want more than one character, return this one plus all combinations one shorter
                // only use characters after the current one for the rest of the combinations
                else

                    foreach (List<int> next in Combinations(items.GetRange(i + 1, items.Count - (i + 1)), length - 1))
                    {
                        List<int> lista = new List<int> { items[i] };
                        lista.AddRange(next);
                        yield return lista;
                    }
            }
        }

        public void printAssociationRules()
        {
            rules.Sort();
            for (int i = 0; i < rules.Count; i++)
            {
                Rule r = rules[i];
                print("[" + (i+1) + "]\t" + r.ToString());
            }
        }
        
        public void printAssociationRulesWithNames()
        {
            this.database.loadNamesProducts();
            rules.Sort();
            for (int i = 0; i < rules.Count; i++)
            {
                Rule r = rules[i];
                print("[" + (i+1) + "]\t" + r.ToStringName());
            }
        }

        public void print(string msg)
        {
            this.control.OnMessage(msg);
        }



    }
 }

