using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab_T
{
    
    public class MyInt : IComparable<MyInt>
    {
        public enum SignEnum { Positive=0 , Negative=1 };

        public enum Comparing { Bigger=1, Equals=0, Less=-1}

        private StringBuilder _value = new StringBuilder();

        private int sign;

        public String Value
        {
            get { return this.ToString(); }

            private set { _value = new StringBuilder(value); }
        }

        private void ConstructFromString(string value)
        {
            if (value.First().Equals('-'))
                sign = (int) SignEnum.Negative;
            else
                sign = (int) SignEnum.Positive;

            _value.Append(value.Where(x => char.IsDigit(x))
                               .SkipWhile(x=>x=='0')
                               .ToArray());

            if (_value.Length == 0)
                _value.Append('0');
        }

        public MyInt(int value)
        {
            ConstructFromString(value.ToString());
        }

        public MyInt(string value)
        {
            ConstructFromString(value);
        }

        public MyInt(byte[] value)
        {
            var joinString = String.Join("", value.Skip(1));
            ConstructFromString(joinString);

            if ((int) value.First() != 0)
                sign = (int)SignEnum.Negative;
            else
                sign = (int)SignEnum.Positive;
            
        }

        public override String ToString()
        {
            string signString = "";
            if (sign == (int)SignEnum.Negative)
                signString = "-";
            return signString + _value.ToString();
        }

        public MyInt Subtract(MyInt argument)
        {
            if (this.sign != argument.sign)
            {
                var signReplaced = argument.Copy()
                                           .ChangeSign();
                return Add(signReplaced);
            }

            MyInt maxAbs = this.MaxAbsSource(argument);
            MyInt minAbs = this.Abs().Min(argument.Abs());

            int resultSign = MaxAbsSource(argument.Copy().ChangeSign()).sign;

            string source =  maxAbs.AbsString();
            string to =  minAbs.AbsString().PadLeft(source.Length,'0');

            int idx = source.Length;

            StringBuilder result = new StringBuilder();
            int sourcePointer = (int)Char.GetNumericValue(source.Last());
            while (idx > 0 )
            {
                --idx;
                int summ = sourcePointer - (int)Char.GetNumericValue(to[idx]);
                if(idx > 0)
                    sourcePointer = (int)Char.GetNumericValue(source[idx - 1]);
                if (summ < 0)
                {
                    sourcePointer--;
                    summ = 10 + summ;
                }
                result.Append(summ);
                
            }

            var ans = new MyInt(new String(result.ToString().Reverse().ToArray()));


            if (ans.Abs().Value == "0")
                ans.sign = (int)SignEnum.Positive;
            else
                ans.sign = resultSign;

            return ans;
        }

        public MyInt Add(MyInt argument)
        {
            if (this.sign != argument.sign)
            {
                if(this.sign == (int)SignEnum.Negative)
                {
                    MyInt signReplaced = this.Copy()
                                             .ChangeSign();
                    return argument.Subtract(signReplaced);
                }
                else
                {
                    MyInt signReplaced = argument.Copy()
                                             .ChangeSign();
                    return this.Subtract(signReplaced);
                }
                
            }


            string first = "0" + this.AbsString(); 
            string second = "0" + argument.AbsString();

            int firstIdx = first.Length;
            int secondIdx = second.Length;

            Stack<byte> result = new Stack<byte>();
            int buf = 0;

            while (firstIdx > 0 || secondIdx > 0)
            {
                int summ = buf;
                if (firstIdx > 0)
                    summ += (int)Char.GetNumericValue(first[--firstIdx]);
                if (secondIdx > 0)
                    summ += (int)Char.GetNumericValue(second[--secondIdx]);

                result.Push((byte)(summ % 10));
                buf = summ / 10;
            }

            result.Push((byte)this.sign);
            return new MyInt(result.ToArray());
        }
        

        public MyInt Multiply(MyInt argument)
        {
            MyInt zero = new MyInt(0);
            MyInt answer = new MyInt(0);
            MyInt decrement = argument.sign == (int)SignEnum.Positive ? new MyInt(1) : new MyInt(-1);
            MyInt addition = this;
            if (decrement.sign == (int)SignEnum.Negative)
                addition = this.Copy().ChangeSign();
            while (argument.CompareTo(zero) != 0)
            {
                answer = answer.Add(addition);
                argument = argument.Subtract(decrement);
            }
            return answer;
        }

        public MyInt Divide(MyInt argument)
        {
            var dividedNumber = this.Abs();
            var divider = argument.Abs();

            if (dividedNumber.CompareTo(divider) == 0)
                return new MyInt(1);
            else if (dividedNumber.CompareTo(divider) < 0)
                return new MyInt(0);
            if (divider.Value == "0")
                return null;

            int resultSign = this.sign == argument.sign ? (int)SignEnum.Positive : (int)SignEnum.Negative;

            MyInt ans = new MyInt(0);
            MyInt increment = new MyInt(1);
            
            while(dividedNumber.CompareTo(divider) != (int)Comparing.Less)
            {
                dividedNumber = dividedNumber.Subtract(divider);
                ans = ans.Add(increment);
            }

            ans.sign = resultSign;
            return ans;
        }

        public long LongValue()
        {
            long ans = 0;
            var len = Int64.MaxValue.ToString().Length;
            var result = Convert.ToInt64(this.Value.Substring(0, Math.Min(len,this.Value.Length) ));
            return result;
        }

        private MyInt MOD(MyInt argument)
        {
            var div = this.Divide(argument);
            var result = this.Subtract(div.Multiply(argument));
            return result;
        }

        public MyInt Gcd(MyInt argument)
        {
            if (argument.CompareTo(new MyInt(0)) == (int)Comparing.Equals)
                return this;
            return argument.Gcd(this.MOD(argument));
        }


        public MyInt Min(MyInt argument)
        {
            return GetExtremum(argument, needMin: true);
        }

        public MyInt Max(MyInt argument)
        {
            return GetExtremum(argument, needMin: false);
        }

        private MyInt MaxAbsSource(MyInt argument, bool isNeedMin = false)
        {

            MyInt maxAbs = this.Abs().Max(argument.Abs());
            MyInt minAbs = this.Abs().Min(argument.Abs());

            if (this.Abs().Value == maxAbs.Value)
                return isNeedMin ? argument : this;
            else
                return isNeedMin ? this : argument;
        }

        private MyInt GetExtremum(MyInt argument, bool needMin)
        {
            if (this.sign != argument.sign)
            {
                if(needMin)
                    return this.sign == (int)SignEnum.Positive ? argument : this;
                else
                    return this.sign == (int)SignEnum.Positive ? this : argument;
            }
                


            MyInt minAbs = null;
            MyInt maxAbs = null;

            if (this.Value.Length > argument.Value.Length)
            {
                minAbs = argument;
                maxAbs = this;
            }
            else if(this.Value.Length < argument.Value.Length)
            {
                minAbs = this;
                maxAbs = argument;
            }
            else
            {
                for (int i = 0; i < this.Value.Length; i++)
                {
                    if(this.Value[i] - argument.Value[i] < 0)
                    {
                        minAbs = this;
                        maxAbs = argument;
                        break;
                    }
                    else if(argument.Value[i] - this.Value[i] < 0)
                    {
                        minAbs = argument;
                        maxAbs = this;
                        break;
                    }
                }
            }

            if (minAbs == null)
                return this;

            if (this.sign == (int)SignEnum.Positive)
                return needMin ? minAbs : maxAbs;
            else
                return needMin ? maxAbs : minAbs;
        }

        public MyInt Abs()
        {
            return new MyInt(_value.ToString());
        }

        public String AbsString()
        {
            return _value.ToString();
        }

        public MyInt Copy()
        {
            return new MyInt(Value);
        }

        public MyInt ChangeSign()
        {
            sign = sign == (int)SignEnum.Positive ? (int)SignEnum.Negative : (int)SignEnum.Positive;
            return this;
        }

        public int CompareTo(MyInt argument)
        {
            if (argument.sign != this.sign)
                return this.sign == (int)SignEnum.Positive ? 1 : -1;

            MyInt min = Min(argument);
            MyInt max = Max(argument);

            if (min.Value == max.Value)
                return (int)Comparing.Equals;

            if (this.Value == max.Value)
                return (int)Comparing.Bigger;
            else
                return (int)Comparing.Less;

        }
    }
}
