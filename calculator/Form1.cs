using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        Calc C;

        public Form1()
        {
            InitializeComponent();

            C = new Calc();

            labelNumber.Text = "0";
        }

        //кнопка Очистка (CE)
        private void buttonClear_Click(object sender, EventArgs e)
        {
            labelNumber.Text = "0";
            lineHorizontal1.Visible = false;
            lineVertical.Visible = false;
            minus_Elemet1.Visible = false;
            Result_Munis1.Visible = false;
            denominator.Location = new System.Drawing.Point(426, 120);
            Result.Location = new System.Drawing.Point(426, 139);
            label1.Text = "0";
            numerator.Text = "0";
            denominator.Text = "0";
            Result.Text = "0";
            Result_Munis1.Text = "0";
            minus_Elemet1.Text = "0";
            znak.Text = "'";

            C.Clear_A();
            FreeButtons();

        }

        //кнопка изменения знака у числа
        private void buttonChangeSign_Click(object sender, EventArgs e)
        {
            if (labelNumber.Text[0] == '-')
                labelNumber.Text = labelNumber.Text.Remove(0, 1);
            else
                labelNumber.Text = "-" + labelNumber.Text;
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            if ((labelNumber.Text.IndexOf(",") == -1) && (labelNumber.Text.IndexOf("∞") == -1))
                labelNumber.Text += ".";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "0";

            CorrectNumber();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "1";

            CorrectNumber();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "2";

            CorrectNumber();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "3";

            CorrectNumber();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "4";

            CorrectNumber();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "5";

            CorrectNumber();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "6";

            CorrectNumber();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "7";

            CorrectNumber();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "8";

            CorrectNumber();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "9";

            CorrectNumber();
        }

        //удаляем лишний ноль впереди числа, если таковой имеется
        private void CorrectNumber()
        {
            //если есть знак "бесконечность" - не даёт писать цифры после него
            if (labelNumber.Text.IndexOf("∞") != -1)
                labelNumber.Text = labelNumber.Text.Substring(0, labelNumber.Text.Length - 1);

            //ситуация: слева ноль, а после него НЕ запятая, тогда ноль можно удалить
            if (labelNumber.Text[0] == '0' && (labelNumber.Text.IndexOf(",") != 1))
                labelNumber.Text = labelNumber.Text.Remove(0, 1);

            //аналогично предыдущему, только для отрицательного числа
            if (labelNumber.Text[0] == '-')
                if (labelNumber.Text[1] == '0' && (labelNumber.Text.IndexOf(",") != 2))
                    labelNumber.Text = labelNumber.Text.Remove(1, 1);
        }



        //кнопка Равно
        private void buttonCalc_Click(object sender, EventArgs e)
        {
            var denominator = labelNumber.Text.Clone();
            if (!buttonMult.Enabled)
            {
                labelNumber.Text = C.Multiplication(Convert.ToDouble(denominator)).ToString();
                BeginWrite(C.MemoryShow(), "*", Convert.ToDouble(denominator), labelNumber.Text);
            }

            if (!buttonDiv.Enabled)
            {

                labelNumber.Text = C.Division(Convert.ToDouble(denominator)).ToString();
                BeginWrite(C.MemoryShow(), "/", Convert.ToDouble(denominator), labelNumber.Text);
            }

            if (!buttonPlus.Enabled)
            {
                labelNumber.Text = C.Sum(Convert.ToDouble(denominator)).ToString();
                BeginWrite(C.MemoryShow(), "+", Convert.ToDouble(denominator), labelNumber.Text);
            }

            if (!buttonMinus.Enabled)
            {
                labelNumber.Text = C.Subtraction(Convert.ToDouble(denominator)).ToString();
                BeginWrite(C.MemoryShow(), "-", Convert.ToDouble(denominator), labelNumber.Text);
            }

            C.Clear_A();
            FreeButtons();

        }

        private void checkThePoint()
        {
            if (labelNumber.Text.Contains(","))
            {
                labelNumber.Text.Replace(",", ".");
            }
        }



        //кнопка Умножение
        private void buttonMult_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                checkThePoint();

                C.Put_A(Convert.ToDouble(labelNumber.Text));

                buttonMult.Enabled = false;

                labelNumber.Text = "0";
            }
        }



        //кнопка Деление
        private void buttonDiv_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                checkThePoint();

                C.Put_A(Convert.ToDouble(labelNumber.Text));

                buttonDiv.Enabled = false;

                labelNumber.Text = "0";
            }
        }

        //кнопка Сложение
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                checkThePoint();
                C.Put_A(Convert.ToDouble(labelNumber.Text));

                buttonPlus.Enabled = false;

                labelNumber.Text = "0";
            }
        }

        //кнопка Вычитание
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                checkThePoint();
                C.Put_A(Convert.ToDouble(labelNumber.Text));

                buttonMinus.Enabled = false;

                labelNumber.Text = "0";
            }
        }


        //проверяет не нажата ли еще какая-либо из кнопок мат.операций
        private bool CanPress()
        {
            if (!buttonMult.Enabled)
                return false;

            if (!buttonDiv.Enabled)
                return false;

            if (!buttonPlus.Enabled)
                return false;

            if (!buttonMinus.Enabled)
                return false;


            return true;
        }

        //снятие нажатия всех кнопок мат.операций
        private void FreeButtons()
        {
            buttonMult.Enabled = true;
            buttonDiv.Enabled = true;
            buttonPlus.Enabled = true;
            buttonMinus.Enabled = true;
        }

        private void BeginWrite(double _numerator, string _znak, double _denominator, string result)
        {

            //for(int i = 0; i< 5; i++)
            //{
            //    if(!_numerator.Equals(.0) && !_denominator.Equals(.0))
            //    {
            //        _numerator *= 10;
            //        _denominator *= 10;
            //    }
            //}

            label1.Text = _numerator + _znak + _denominator + "=" + result;

            numerator.Text = _numerator.ToString();
            denominator.Text = _denominator.ToString();
            znak.Text = _znak;
            Result.Text = result;

            if (_znak.Equals("/"))
            {
                List<Label> minus = new List<Label>();
                minus.Add(minus_Elemet1);
                minus.Add(minus_Elemet2);
                _znak = "-";
                minus_Elemet1.Visible = true;
                Result_Munis1.Visible = true;
                ColumnDelimeter(_numerator, _znak, _denominator, result);
                lineVertical.Visible = true;
                lineHorizontal1.Visible = true;
                denominator.Location = new System.Drawing.Point(475, 94);
                Result.Location = new System.Drawing.Point(475, 120);
            }
        }

        private void ColumnDelimeter(double _numerator, string _znak, double _denominator, string result)
        {
            var arr = result.ToCharArray();

            //for (int i = 0; i < arr.Length; i++)
          //  {
                minus_Elemet1.Text = (Convert.ToDouble(arr[0].ToString()) * _denominator).ToString();
                Result_Munis1.Text = (_numerator - Convert.ToDouble(minus_Elemet1.Text)).ToString();
          //  }

        }

    }
}