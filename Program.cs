using Task_1_Calc_Up;

namespace Task_1
{

    /*
     
    Доработайте программу калькулятор реализовав выбор действий
    и вывод результатов на экран в цикле так, чтобы калькулятор мог работать до тех пор
    пока пользователь не нажмет отмена или введёт пустую строку.
            
    */


    internal class Program
    {
        static void Calculator_GotResult(object sendler, EventArgs eventArgs)
        {
            Console.WriteLine($"Результат: {((Calculator)sendler).Result} \n");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Для расчетов используйте операторы: + - / *");
            Console.WriteLine("Для сброса на 0 нажмите  - Delete");
            Console.WriteLine("Для выхода нажмите Space или Enter");
            Console.WriteLine("_______________________________________\n");

            ICalculator calc = new Calculator();
            calc.GotResult += Calculator_GotResult;

            while (true)
            {
                calc.InsertFirstValue();

                while (true)
                {
                    Console.Write("Укажите оператор: ");
                    switch (calc.CheckOperator())
                    {
                        case '+':

                            int AddSecondValue = calc.InsertValue();
                            calc.Add(AddSecondValue);
                            break;

                        case '-':

                            int SubSecondValue = calc.InsertValue();
                            calc.Sub(SubSecondValue);
                            break;

                        case '*':

                            int MulSecondValue = calc.InsertValue();
                            calc.Mul(MulSecondValue);
                            break;

                        case '/':

                            int DivSecondValue = calc.InsertValue();
                            calc.Div(DivSecondValue);
                            break;

                        case 'D':

                            calc.Clear();
                            calc.InsertFirstValue();
                            break;
                    }                 
                }
            }
        }
    }
}

