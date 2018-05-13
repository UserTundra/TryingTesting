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
            Assert.AreEqual(i.ToString(), like_simple_int.Value);

            MyInt like_simple_int2 = new MyInt(-i);
            Assert.AreEqual((-i).ToString(), like_simple_int2.Value);

            MyInt like_simple_string = new MyInt(s);
            Assert.AreEqual(s, like_simple_string.Value);

            MyInt like_simple_string2 = new MyInt("-"+s);
            Assert.AreEqual("-" + s, like_simple_string2.Value);

            MyInt like_byte_massive = new MyInt(b1);
            Assert.AreEqual("-1101000001110101001", like_byte_massive.Value);

            MyInt like_byte_massive2 = new MyInt(b2);
            Assert.AreEqual("1101000001110101001", like_byte_massive2.Value);


        }
                

        [TestMethod]
        public void MyIntAddTest()
        {
            int a = 5;
            int b = 7;

            MyInt first = new MyInt(a);
            MyInt second = new MyInt(b);
            MyInt result = first.Add(second);
            Assert.AreEqual((12).ToString(), result.Value);

            first = new MyInt(-a);
            second = new MyInt(b);
            result = first.Add(second);
            Assert.AreEqual(2.ToString(), result.Value);

            first = new MyInt(a);
            second = new MyInt(-b);
            result = first.Add(second);
            Assert.AreEqual((-2).ToString(), result.Value);

            first = new MyInt(-a);
            second = new MyInt(-b);
            result = first.Add(second);
            Assert.AreEqual((-12).ToString(), result.Value);
        }

        [TestMethod]
        public void MyIntSubtractTest()
        {
            int c = 5;
            int d = 7;

            

            MyInt first = new MyInt(c);
            MyInt second = new MyInt(d);
            MyInt result = first.Subtract(second);
            Assert.AreEqual((-2).ToString(), result.Value);

            first = new MyInt(10);
            second = new MyInt(3);
            Assert.AreEqual(7.ToString(), first.Subtract(second).Value);


            first = new MyInt(-c);
            second = new MyInt(d);
            result = first.Subtract(second);
            Assert.AreEqual((-12).ToString(), result.Value);

            first = new MyInt(c);
            second = new MyInt(-d);
            result = first.Subtract(second);
            Assert.AreEqual(12.ToString(), result.Value);

            first = new MyInt(-c);
            second = new MyInt(-d);
            result = first.Subtract(second);
            Assert.AreEqual(2.ToString(), result.Value);
        }

        [TestMethod]
        public void MyIntAbsTest()
        {
            MyInt a = new MyInt(5);
            Assert.AreEqual(5.ToString(), a.Abs().Value);

            MyInt b = new MyInt(-14);
            Assert.AreEqual((14).ToString(), b.Abs().Value);

            MyInt c = new MyInt(0);
            Assert.AreEqual(0.ToString(), c.Abs().Value);
        }

        [TestMethod]
        public void MyIntMaxTest()
        {
            int a = 3;
            int b = 9;
            int c = 0;

            MyInt first = new MyInt(a);
            MyInt second = new MyInt(b);
            Assert.AreEqual(9.ToString(), second.Max(first).Value);

            first = new MyInt(-a);
            second = new MyInt(b);
            Assert.AreEqual(9.ToString(), second.Max(first).Value);

            first = new MyInt(a);
            second = new MyInt(-b);
            Assert.AreEqual(3.ToString(), second.Max(first).Value);

            first = new MyInt(-a);
            second = new MyInt(-b);
            Assert.AreEqual((-3).ToString(), second.Max(first).Value);

            first = new MyInt(a);
            second = new MyInt(c);
            Assert.AreEqual(3.ToString(), second.Max(first).Value);

            first = new MyInt(-b);
            second = new MyInt(c);
            Assert.AreEqual(0.ToString(), second.Max(first).Value);
        }

        [TestMethod]
        public void MyIntMinTest()
        {
            int a = 3;
            int b = 9;
            int c = 0;

            MyInt first = new MyInt(a);
            MyInt second = new MyInt(b);
            Assert.AreEqual(3.ToString(), second.Min(first).Value);

            first = new MyInt(-a);
            second = new MyInt(b);
            Assert.AreEqual((-3).ToString(), second.Min(first).Value);

            first = new MyInt(a);
            second = new MyInt(-b);
            Assert.AreEqual((-9).ToString(), second.Min(first).Value);

            first = new MyInt(-a);
            second = new MyInt(-b);
            Assert.AreEqual((-9).ToString(), second.Min(first).Value);

            first = new MyInt(a);
            second = new MyInt(c);
            Assert.AreEqual(0.ToString(), second.Min(first).Value);

            first = new MyInt(-b);
            second = new MyInt(c);
            Assert.AreEqual((-9).ToString(), second.Min(first).Value);
        }

        [TestMethod]
        public void MyIntMultiplyTest()
        {
            int a = 3;
            int b = 9;
            int c = 0;


            MyInt first = new MyInt(a);
            MyInt second = new MyInt(b);
            Assert.AreEqual(27.ToString(), second.Multiply(first).Value);

            first = new MyInt(-a);
            second = new MyInt(b);
            Assert.AreEqual((-27).ToString(), second.Multiply(first).Value);

            first = new MyInt(a);
            second = new MyInt(-b);
            Assert.AreEqual((-27).ToString(), second.Multiply(first).Value);

            first = new MyInt(-a);
            second = new MyInt(-b);
            Assert.AreEqual(27.ToString(), second.Multiply(first).Value);
            
            first = new MyInt(a);
            second = new MyInt(c);
            Assert.AreEqual(0.ToString(), second.Multiply(first).Value);

            first = new MyInt(-b);
            second = new MyInt(c);
            Assert.AreEqual(0.ToString(), second.Multiply(first).Value);
        }

        [TestMethod]
        public void MyIntDivideTest()
        {
            int a = 3;
            int b = 10;
            int c = 0;

            MyInt first = new MyInt(a);
            MyInt second = new MyInt(b);
            Assert.AreEqual(3.ToString(), second.Divide(first).Value);
            Assert.AreEqual(0.ToString(), first.Divide(second).Value);

            first = new MyInt(-a);
            second = new MyInt(b);
            Assert.AreEqual((-3).ToString(), second.Divide(first).Value);
            Assert.AreEqual(0.ToString(), first.Divide(second).Value);

            first = new MyInt(a);
            second = new MyInt(-b);
            Assert.AreEqual((-3).ToString(), second.Divide(first).Value);
            Assert.AreEqual(0.ToString(), first.Divide(second).Value);

            first = new MyInt(-a);
            second = new MyInt(-b);
            Assert.AreEqual(3.ToString(), second.Divide(first).Value);
            Assert.AreEqual(0.ToString(), first.Divide(second).Value);

            first = new MyInt(a);
            second = new MyInt(c);
            Assert.AreEqual(0.ToString(), second.Divide(first).Value);
            Assert.IsNull(first.Divide(second));

            first = new MyInt(-b);
            second = new MyInt(c);
            Assert.AreEqual(0.ToString(), second.Divide(first).Value);
            Assert.IsNull(first.Divide(second));
        }

        [TestMethod]
        public void MyIntGcdTest()
        {
            int a = 7;
            int b = 1;
            int c = 28;
            int d = 4;
            int e = 0;
            int f = 14;

            MyInt first = new MyInt(a);
            MyInt second = new MyInt(b);
            Assert.AreEqual(1.ToString(), first.Gcd(second).Value);

            first = new MyInt(-a);
            second = new MyInt(b);
            Assert.AreEqual(1.ToString(), first.Gcd(second).Value);

            first = new MyInt(a);
            second = new MyInt(c);
            Assert.AreEqual(7.ToString(), first.Gcd(second).Value);

            first = new MyInt(c);
            second = new MyInt(d);
            Assert.AreEqual(4.ToString(), first.Gcd(second).Value);

            first = new MyInt(a);
            second = new MyInt(d);
            Assert.AreEqual(1.ToString(), first.Gcd(second).Value);

            first = new MyInt(d);
            second = new MyInt(e);
            Assert.AreEqual(4.ToString(), first.Gcd(second).Value);
           

            first = new MyInt(21);
            second = new MyInt(14);
            Assert.AreEqual(7.ToString(), first.Gcd(second).Value);
        }

        [TestMethod]
        public void MyIntCompareTest()
        {
            int a = 11;
            int b = 11;
            int c = 15;

            MyInt first = new MyInt(a);
            MyInt second = new MyInt(b);
            Assert.AreEqual(0, first.CompareTo(second));

            first = new MyInt(a);
            second = new MyInt(-b);
            Assert.AreEqual(1, first.CompareTo(second));

            first = new MyInt(b);
            second = new MyInt(c);
            Assert.AreEqual( -1, first.CompareTo(second));
        }

        [TestMethod]
        public void MyIntLongValueTest()
        {
            string shortValue = "123123213";
            string longVaule = Int64.MaxValue.ToString() + "999999999999999999999999999999999999999";

            MyInt value = new MyInt(shortValue);
            Assert.AreEqual(Convert.ToInt64(shortValue), value.LongValue());

            value = new MyInt(longVaule);
            Assert.AreEqual(Int64.MaxValue, value.LongValue());



        }


    }
}
