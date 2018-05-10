using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab_T
{
    
    public class MyInt
    {
        public enum SignEnum { Positive=0 , Negative=1 };

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
            if (this.sign == argument.sign)
                return Add(argument);

            

            MyInt maxAbs = this.MaxAbsSource(argument);
            MyInt minAbs = this.Abs().Min(argument.Abs());



            return new MyInt("0");
        }

        public MyInt Add(MyInt argument)
        {
            if (this.sign != argument.sign)
                return Subtract(argument);
            
            string first = "0"+this.Value;
            string second = "0"+argument.Value;

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
                return this.sign == (int)SignEnum.Positive ? this : argument;


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
                        minAbs = this;
                        maxAbs = argument;
                        break;
                    }
                }
            }

            return needMin ? minAbs : maxAbs;
        }

        public MyInt Abs()
        {
            var buf = this.sign;
            this.sign = (int)SignEnum.Positive;
            var result = new MyInt(this.Value);
            this.sign = buf;
            return result;
        }


        
    }
}
