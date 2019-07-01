using NUnit.Framework;
using System;
using Game;

namespace Tests
{
    internal sealed class ListaTest
    {
        private Lista Lista { get; set; }

        [SetUp]
        public void Start()
        {
            Lista = new Lista();
        }

        [Test]
        public void At_Empty()
        {
            Assert.Throws<Exception>(() => { Lista.NEsimo(0); });
        }

        [Test]
        public void PushLast_Empty()
        {
            Lista.InsertaFin(1);
            Assert.AreEqual(1, Lista.CuentaEltos());
        }

        [Test]
        public void PushLast_NotEmpty()
        {
            Lista.InsertaFin(1);
            Lista.InsertaFin(2);
            Assert.AreEqual(2, Lista.CuentaEltos());
        }

        [Test]
        public void At_NotEmpty()
        {
            const int expected = 2;
            Lista.InsertaFin(expected);
            Assert.AreEqual(expected, Lista.NEsimo(0));
        }

        [Test]
        public void At_MultipleLast()
        {
            Lista.InsertaFin(10);
            Lista.InsertaFin(20);

            Assert.AreEqual(10, Lista.NEsimo(0));
            Assert.AreEqual(20, Lista.NEsimo(1));
        }

        [Test]
        public void RemoveAt_Empty()
        {
            Assert.IsFalse(Lista.BorraElto(0));
        }

        [Test]
        public void RemoveAt_Negative()
        {
            Assert.IsFalse(Lista.BorraElto(-1));
        }

        [Test]
        public void RemoveAt_First()
        {
            Lista.InsertaFin(1);
            Lista.InsertaFin(2);
            Lista.InsertaFin(3);
            Assert.IsTrue(Lista.BorraElto(1));

            // Cover all values are fine
            Assert.AreEqual(2, Lista.CuentaEltos(), "Count should be 2");
            Assert.AreEqual(2, Lista.NEsimo(0), "[ 1, 2, 3 ] -> [ 2, 3 ], at 0, value is 2");
            Assert.AreEqual(3, Lista.NEsimo(1), "[ 1, 2, 3 ] -> [ 2, 3 ], at 1, value is 3");
        }

        [Test]
        public void RemoveAt_Middle()
        {
            Lista.InsertaFin(1);
            Lista.InsertaFin(2);
            Lista.InsertaFin(3);
            Assert.IsTrue(Lista.BorraElto(2));

            // Cover all values are fine
            Assert.AreEqual(2, Lista.CuentaEltos(), "Count should be 2");
            Assert.AreEqual(1, Lista.NEsimo(0), "[ 1, 2, 3 ] -> [ 1, 3 ], at 0, value is 1");
            Assert.AreEqual(3, Lista.NEsimo(1), "[ 1, 2, 3 ] -> [ 1, 3 ], at 1, value is 3");
        }

        [Test]
        public void RemoveAt_Last()
        {
            Lista.InsertaFin(1);
            Lista.InsertaFin(2);
            Lista.InsertaFin(3);
            Assert.IsTrue(Lista.BorraElto(3));

            // Cover all values are fine
            Assert.AreEqual(2, Lista.CuentaEltos(), "Count should be 2");
            Assert.AreEqual(1, Lista.NEsimo(0), "[ 1, 2, 3 ] -> [ 1, 2 ], at 0, value is 1");
            Assert.AreEqual(2, Lista.NEsimo(1), "[ 1, 2, 3 ] -> [ 1, 2 ], at 1, value is 2");
        }

        [Test]
        public void RemoveAt_OutOfBounds()
        {
            Lista.InsertaFin(1);
            Lista.InsertaFin(2);
            Lista.InsertaFin(3);
            Assert.IsFalse(Lista.BorraElto(4));

            // Cover all values are fine
            Assert.AreEqual(3, Lista.CuentaEltos(), "Count should be 2");
            Assert.AreEqual(1, Lista.NEsimo(0), "[ 1, 2, 3 ], at 0, value is 1");
            Assert.AreEqual(2, Lista.NEsimo(1), "[ 1, 2, 3 ], at 1, value is 2");
            Assert.AreEqual(3, Lista.NEsimo(2), "[ 1, 2, 3 ], at 2, value is 3");
        }
    }
}