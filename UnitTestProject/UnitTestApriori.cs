using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Apriori.Model;
using Apriori.Controller;
using AlgAprioriGUI;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestApriori
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Executable_Prof()
        {
            // Se espera una excepcion si los archivos no se encuentran en la carpeta correspondiente
            Apriori.Controller.Executable exe = new Apriori.Controller.Executable();
            exe.loadInformation();
        }

        [TestMethod]
        public void Apriori_Prof()
        {
            // No es nulo a pasar de que no se ejecuta nada
            Executable exe = new Executable();
            AprioriAlgorithm apri = new AprioriAlgorithm(exe);
            Assert.IsNotNull(apri, "No es nulo");
        }


        [TestMethod]
        public void Rule_Prof()
        {
            // Frecuencia positiva
            List<int> x = new List<int>();
            x.Add(1);
            x.Add(2);
            x.Add(3);
            x.Add(4);
            x.Add(5);

            List<int> y = new List<int>();
            y.Add(1);
            y.Add(2);
            y.Add(3);
            y.Add(4);
            y.Add(5);

            Rule regla = new Rule(x, y);

            Assert.IsTrue(regla.frecuencia >= 0, "El valor es positivo");
        }


        [TestMethod]
        public void Rule_Prof_1()
        {
            // No clona el ejecto
            List<int> x = new List<int>();
            x.Add(1);
            x.Add(2);
            x.Add(3);
            x.Add(4);
            x.Add(5);

            List<int> y = new List<int>();
            y.Add(1);
            y.Add(2);
            y.Add(3);
            y.Add(4);
            y.Add(5);

            Rule regla = new Rule(x, y);

            Assert.AreNotEqual(regla, regla.clone());
        }


        [TestMethod]
        public void Rule_Prof_2()
        {
            // Cambia la frecuencia
            List<int> x = new List<int>();
            x.Add(1);
            x.Add(2);

            List<int> y = new List<int>();
            y.Add(1);
            y.Add(2);
            double p = 1;
            Rule regla = new Rule(x, y, p);
            double a = 2;
            regla.setFrequency(a);
            Assert.AreEqual(a, regla.getFrequency());
        }

        [TestMethod]
        public void File_Manager_Prof()
        {
            // Obtiene los items del ejemplo basico
            FileManager fm = new FileManager(new ArrayList(), new Hashtable(), new ArrayList(), null);
            fm.Path2 = "example.txt";
            fm.loadExample();
            Assert.IsTrue(fm.Items.Count > 0, "El numero de item s mayor que cero, y es ta correcto");
        }


        [TestMethod]
        public void File_Manager_Prof_1()
        {
            // Obtiene las transacciones del ejemplo basico
            FileManager fm = new FileManager(new ArrayList(), new Hashtable(), new ArrayList(), null);
            fm.Path2 = "example.txt";
            fm.loadExample();
            Assert.IsTrue(fm.Transactions.Count > 0, "El numero de transacciones es mayor que cero, y es ta correcto");
        }

    }
}
