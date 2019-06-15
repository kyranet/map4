using NUnit.Framework;
using Game;
using System;

namespace Tests
{
	class ConnectedListTest
	{
		[Test]
		public void At_Empty()
		{
			var list = new ConnectedList();
			Assert.Throws<Exception>(() => { list.At(0); });
		}

		[Test]
		public void PushFront_Empty()
		{
			var list = new ConnectedList();
			list.PushFront(1);

			Assert.AreEqual(1, list.Count);
		}

		[Test]
		public void PushFront_NotEmpty()
		{
			var list = new ConnectedList();
			list.PushFront(1);
			list.PushFront(2);

			Assert.AreEqual(2, list.Count);
		}

		[Test]
		public void PushLast_Empty()
		{
			var list = new ConnectedList();
			list.PushLast(1);

			Assert.AreEqual(1, list.Count);
		}

		[Test]
		public void PushLast_NotEmpty()
		{
			var list = new ConnectedList();
			list.PushLast(1);
			list.PushLast(2);

			Assert.AreEqual(2, list.Count);
		}

		[Test]
		public void At_NotEmpty()
		{
			var list = new ConnectedList();
			const int expected = 2;
			list.PushFront(expected);

			Assert.AreEqual(expected, list.At(0));
		}

		[Test]
		public void At_MultipleFront()
		{
			var list = new ConnectedList();
			list.PushFront(10);
			list.PushFront(20);

			Assert.AreEqual(20, list.At(0));
			Assert.AreEqual(10, list.At(1));
		}

		[Test]
		public void At_MultipleLast()
		{
			var list = new ConnectedList();
			list.PushLast(10);
			list.PushLast(20);

			Assert.AreEqual(10, list.At(0));
			Assert.AreEqual(20, list.At(1));
		}

		[Test]
		public void RemoveAt_Empty()
		{
			var list = new ConnectedList();
			Assert.IsFalse(list.RemoveAt(0));
		}

		[Test]
		public void RemoveAt_Negative()
		{
			var list = new ConnectedList();
			Assert.IsFalse(list.RemoveAt(-1));
		}

		[Test]
		public void RemoveAt_First()
		{
			var list = new ConnectedList();
			list.PushFront(1);
			list.PushFront(2);
			list.PushFront(3);
			Assert.IsTrue(list.RemoveAt(0));

			// Cover all values are fine
			Assert.AreEqual(2, list.Count, "Count should be 2");
			Assert.AreEqual(2, list.At(0), "[ 3, 2, 1 ] -> [ 2, 1 ], at 0, value is 2");
			Assert.AreEqual(1, list.At(1), "[ 3, 2, 1 ] -> [ 2, 1 ], at 1, value is 1");
		}

		[Test]
		public void RemoveAt_Middle()
		{
			var list = new ConnectedList();
			list.PushFront(1);
			list.PushFront(2);
			list.PushFront(3);
			Assert.IsTrue(list.RemoveAt(1));

			// Cover all values are fine
			Assert.AreEqual(2, list.Count, "Count should be 2");
			Assert.AreEqual(3, list.At(0), "[ 3, 2, 1 ] -> [ 3, 1 ], at 0, value is 3");
			Assert.AreEqual(1, list.At(1), "[ 3, 2, 1 ] -> [ 3, 1 ], at 1, value is 1");
		}

		[Test]
		public void RemoveAt_Last()
		{
			var list = new ConnectedList();
			list.PushFront(1);
			list.PushFront(2);
			list.PushFront(3);
			Assert.IsTrue(list.RemoveAt(2));

			// Cover all values are fine
			Assert.AreEqual(2, list.Count, "Count should be 2");
			Assert.AreEqual(3, list.At(0), "[ 3, 2, 1 ] -> [ 3, 2 ], at 0, value is 3");
			Assert.AreEqual(2, list.At(1), "[ 3, 2, 1 ] -> [ 3, 2 ], at 1, value is 2");
		}

		[Test]
		public void RemoveAt_OutOfBounds()
		{
			var list = new ConnectedList();
			list.PushFront(1);
			list.PushFront(2);
			list.PushFront(3);
			Assert.IsFalse(list.RemoveAt(3));

			// Cover all values are fine
			Assert.AreEqual(3, list.Count, "Count should be 2");
			Assert.AreEqual(3, list.At(0), "[ 3, 2, 1 ], at 0, value is 3");
			Assert.AreEqual(2, list.At(1), "[ 3, 2, 1 ], at 1, value is 2");
			Assert.AreEqual(1, list.At(2), "[ 3, 2, 1 ], at 2, value is 1");
		}

		[Test]
		public void RemoveValue_Empty()
		{
			var list = new ConnectedList();
			Assert.IsFalse(list.RemoveValue(0));
		}

		[Test]
		public void RemoveValue_NotExists()
		{
			var list = new ConnectedList();
			list.PushFront(0);
			Assert.IsFalse(list.RemoveValue(-1));
		}

		[Test]
		public void RemoveValue_First()
		{
			var list = new ConnectedList();
			list.PushFront(1);
			list.PushFront(2);
			list.PushFront(3);
			Assert.IsTrue(list.RemoveValue(3));

			// Cover all values are fine
			Assert.AreEqual(2, list.Count, "Count should be 2");
			Assert.AreEqual(2, list.At(0), "[ 3, 2, 1 ] -> [ 2, 1 ], at 0, value is 2");
			Assert.AreEqual(1, list.At(1), "[ 3, 2, 1 ] -> [ 2, 1 ], at 1, value is 1");
		}

		[Test]
		public void RemoveValue_Middle()
		{
			var list = new ConnectedList();
			list.PushFront(1);
			list.PushFront(2);
			list.PushFront(3);
			Assert.IsTrue(list.RemoveValue(2));

			// Cover all values are fine
			Assert.AreEqual(2, list.Count, "Count should be 2");
			Assert.AreEqual(3, list.At(0), "[ 3, 2, 1 ] -> [ 3, 1 ], at 0, value is 3");
			Assert.AreEqual(1, list.At(1), "[ 3, 2, 1 ] -> [ 3, 1 ], at 1, value is 1");
		}

		[Test]
		public void RemoveValue_Last()
		{
			var list = new ConnectedList();
			list.PushFront(1);
			list.PushFront(2);
			list.PushFront(3);
			Assert.IsTrue(list.RemoveValue(1));

			// Cover all values are fine
			Assert.AreEqual(2, list.Count, "Count should be 2");
			Assert.AreEqual(3, list.At(0), "[ 3, 2, 1 ] -> [ 3, 2 ], at 0, value is 3");
			Assert.AreEqual(2, list.At(1), "[ 3, 2, 1 ] -> [ 3, 2 ], at 1, value is 2");
		}
	}
}