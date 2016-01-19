using System;
using System.Collections;
using System.Text;

namespace Apriori.Controller
{
    abstract public class Manager
    {
        public abstract void loadInfo();

        public abstract void loadInfo(DateTime date);

        public abstract void loadInfo(ArrayList months);

        public abstract void loadInfo(DateTime date, int store);

        public abstract void loadInfo(ArrayList months, int store);

        public abstract void loadNamesProducts();

    }
}
