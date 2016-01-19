using Apriori.Controller;
using Apriori.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Apriori.Controller
{
    public class Database
    {
        private AprioriAlgorithm algorithm;
        private FileManager manager;

        public Database(ArrayList items, Hashtable itemsHash, ArrayList transactions, AprioriAlgorithm algorithm)
        {
            this.algorithm = algorithm;
            this.manager = new FileManager(items, itemsHash, transactions, this);
        }

        public void loadExample()
        {
            this.manager.loadExample();
        }

        public void loadInfo()
        {
            this.manager.loadInfo();
        }

        public void loadInfo(DateTime date)
        {
            this.manager.loadInfo(date);
        }

        public void loadInfo(ArrayList months)
        {
            this.manager.loadInfo(months);
        }

        public void loadInfo(DateTime date, int store)
        {
            this.manager.loadInfo(date, store);
        }

        public void loadInfo(ArrayList months, int store)
        {
            this.manager.loadInfo(months, store);
        }

        public void loadNamesProducts()
        {
            this.manager.loadNamesProducts();
        }

        public void print(string msg)
        {
            this.algorithm.print(msg);
        }


    }
}
