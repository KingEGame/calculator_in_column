using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    //класс, реализующий интерфейс InterfaceCalc
    public class Calc : InterfaceCalc
    {
        private double a = 0;
        private double memory = 0;

        public void Put_A(double a)
        {
            this.a = a;
            this.memory = a;
        }

        public void Clear_A()
        {
            a = 0;
        }

        public double Multiplication(double b)
        {
            return a * b;
        }

        public double Division(double b)
        {
            return a / b;
        }

        public double Sum(double b)
        {
            return a + b;
        }

        public double Subtraction(double b) //вычитание
        {
            return a - b;
        }


        //показать содержимое регистра мамяти
        public double MemoryShow()
        {
            return memory;
        }

        //стереть содержимое регистра мамяти
        public void Memory_Clear()
        {
            memory = 0.0;
        }

    }
}
