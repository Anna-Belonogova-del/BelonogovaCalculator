using BibliotekaBelonogovaIspr;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Belonogova2IspravTest
{
    [TestClass]
    public class biblTests
    {
        [TestMethod]
        public void Sum()
        {
            double a = 5, b = 3, expected = 8;
            double result = bibl.Execute(a, '+', b);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Minys()
        {
            double a = 10, b = 4, expected = 6;
            double result = bibl.Execute(a, '-', b);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ymnog()
        {
            double a = 7, b = 6, expected = 42;
            double result = bibl.Execute(a, '*', b);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void delen()
        {
            double a = 15, b = 3, expected = 5;
            double result = bibl.Execute(a, '/', b);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void delenie_na_0()
        {
            try
            {
                double a = 10, b = 0;
                bibl.Execute(a, '/', b);
                Assert.Fail("Ожидалось исключение");
            }
            catch (DivideByZeroException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Деление на 0, было выброшено: {ex.GetType().Name}");
            }
        }

        [TestMethod]
        public void stepen()
        {
            double a = 2, b = 4, expected = 16;
            double result = bibl.Execute(a, '^', b);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void stepen_mal_chisla()
        {
            double a = 0.5, b = 6, expected = 0.015625;
            double result = bibl.Execute(a, '^', b);
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void priorit()
        {
            Assert.AreEqual(3, bibl.GetPriority('^'));
            Assert.AreEqual(2, bibl.GetPriority('*'));
            Assert.AreEqual(2, bibl.GetPriority('/'));
            Assert.AreEqual(1, bibl.GetPriority('+'));
            Assert.AreEqual(1, bibl.GetPriority('-'));
            Assert.AreEqual(0, bibl.GetPriority('x'));
        }

        [TestMethod]
        public void otritsch()
        {
            double a = -5, b = 3, expected = -2;
            double result = bibl.Execute(a, '+', b);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void drob()
        {
            double a = 2.5, b = 1.5, expected = 4.0;
            double result = bibl.Execute(a, '+', b);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void eshkeree()
        {
            double step1 = bibl.Execute(2, '+', 3);
            double result = bibl.Execute(step1, '*', 4);
            double expected = 20;
            Assert.AreEqual(expected, result);
        }
    }
}