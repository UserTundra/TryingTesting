using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab_T;

namespace Tests
{
    [TestClass]
    public class MyIntTest
    {
        [TestMethod]
        public void MyIntConstructTest()
        {
            MyInt like_simple_int = new MyInt(1234567890);
            Assert.IsNotNull(like_simple_int);
            MyInt like_simple_string = new MyInt("1234567890");
            Assert.IsNotNull(like_simple_string);
            MyInt like_byte_massive = new MyInt(new byte[] {1,1,1,0,1,0,0,0,0,0,1,1,1,0,1,0,1,0,0,1});
            Assert.IsNotNull(like_byte_massive);

        }

        [TestMethod]
        public void MyIntSignTest()
        {
            int i = 1234567890;
            string s = "1234567890";
            byte[] b1 = { 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 0, 0, 1 };
            byte[] b2 = { 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 0, 0, 1 };

            MyInt like_simple_int = new MyInt(i);
            Assert.AreEqual(like_simple_int.Value, i.ToString());

            MyInt like_simple_int2 = new MyInt(-i);
            Assert.AreEqual(like_simple_int2.Value, (-i).ToString());

            MyInt like_simple_string = new MyInt(s);
            Assert.AreEqual(like_simple_string.Value, s);

            MyInt like_simple_string2 = new MyInt("-"+s);
            Assert.AreEqual(like_simple_string2.Value, "-" + s);

            MyInt like_byte_massive = new MyInt(b1);
            Assert.AreEqual(like_byte_massive.Value, "-1101000001110101001");

            MyInt like_byte_massive2 = new MyInt(b2);
            Assert.AreEqual(like_byte_massive2.Value, "1101000001110101001");


        }
                

        [TestMethod]
        public void MyIntAddTest()
        {
            int a = 5;
            int b = 7;

            MyInt first = new MyInt(a);
            MyInt second = new MyInt(b);
            MyInt result = first.Add(second);
            Assert.AreEqual(result.Value, (12).ToString());

            first = new MyInt(-a);
            second = new MyInt(b);
            result = first.Add(second);
            Assert.AreEqual(result.Value, 2.ToString());

            first = new MyInt(a);
            second = new MyInt(-b);
            result = first.Add(second);
            Assert.AreEqual(result.Value, (-2).ToString());

            first = new MyInt(-a);
            second = new MyInt(-b);
            result = first.Add(second);
            Assert.AreEqual(result.Value, (-12).ToString());
        }

        [TestMethod]
        public void MyIntSubtractTest()
        {
            int c = 5;
            int d = 7;

            MyInt first = new MyInt(c);
            MyInt second = new MyInt(d);
            MyInt result = first.Subtract(second);
            Assert.AreEqual(result.Value, (-2).ToString());

            first = new MyInt(-c);
            second = new MyInt(d);
            result = first.Subtract(second);
            Assert.AreEqual(result.Value, (-12).ToString());

            first = new MyInt(c);
            second = new MyInt(-d);
            result = first.Subtract(second);
            Assert.AreEqual(result.Value, 12.ToString());

            first = new MyInt(-c);
            second = new MyInt(-d);
            result = first.Subtract(second);
            Assert.AreEqual(result.Value, 2.ToString());
        }

        [TestMethod]
        public void MyIntAbsTest()
        {
            MyInt a = new MyInt(5);
            Assert.AreEqual(a.Abs().Value, 5.ToString());

            MyInt b = new MyInt(-14);
            Assert.AreEqual(b.Abs().Value, (14).ToString());

            MyInt c = new MyInt(0);
            Assert.AreEqual(c.Abs().Value, 0.ToString());
        }

        [TestMethod]
        public void MyIntMaxTest()
        {
            int a = 3;
            int b = 9;
            int c = 0;

            MyInt first = new MyInt(a);
            MyInt second = new MyInt(b);
            Assert.AreEqual(second.Max(first).Value, 9.ToString());

            first = new MyInt(-a);
            second = new MyInt(b);
            Assert.AreEqual(second.Max(first).Value, 9.ToString());

            first = new MyInt(a);
            second = new MyInt(-b);
            Assert.AreEqual(second.Max(first).Value, 3.ToString());

            first = new MyInt(-a);
            second = new MyInt(-b);
            Assert.AreEqual(second.Max(first).Value, (-3).ToString());

            first = new MyInt(a);
            second = new MyInt(c);
            Assert.AreEqual(second.Max(first).Value, 3.ToString());

            first = new MyInt(-b);
            second = new MyInt(c);
            Assert.AreEqual(second.Max(first).Value, 0.ToString());
        }

        [TestMethod]
        public void MyIntMinTest()
        {
            int a = 3;
            int b = 9;
            int c = 0;

            MyInt first = new MyInt(a);
            MyInt second = new MyInt(b);
            Assert.AreEqual(second.Min(first).Value, 3.ToString());

            first = new MyInt(-a);
            second = new MyInt(b);
            Assert.AreEqual(second.Min(first).Value, (-3).ToString());

            first = new MyInt(a);
            second = new MyInt(-b);
            Assert.AreEqual(second.Min(first).Value, (-9).ToString());

            first = new MyInt(-a);
            second = new MyInt(-b);
            Assert.AreEqual(second.Min(first).Value, (-9).ToString());

            first = new MyInt(a);
            second = new MyInt(c);
            Assert.AreEqual(second.Min(first).Value, 0.ToString());

            first = new MyInt(-b);
            second = new MyInt(c);
            Assert.AreEqual(second.Min(first).Value, (-9).ToString());
        }


    }
}
