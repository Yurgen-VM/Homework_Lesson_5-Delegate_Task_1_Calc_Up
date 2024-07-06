namespace Task_1_Calc_Up
{
    internal class Calculator : ICalculator
    {
        public event EventHandler<EventArgs> GotResult;
        public event EventHandler<EventArgs> PushAdd;

        private Stack<int> stack = new Stack<int>(); 

        public int Result = 0;
        public char Oper;

        private void RaiseEvent()
        {
            GotResult?.Invoke(this, EventArgs.Empty);
        }           

        public int InsertValue()
        {
            int InsertValue;
            while (true)
            {
                Console.Write("Введите число: ");

                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        Exit();
                        return '\0';

                    case ConsoleKey.Spacebar:
                        Exit();
                        return '\0';

                    case ConsoleKey.Backspace:
                        CancelLast();
                        return '\0';

                    case ConsoleKey.Delete:
                        return 'D';

                }
                char key_2 = key.KeyChar;
                string valueStr = key_2 + Console.ReadLine();

                bool check = int.TryParse(valueStr, out  InsertValue);

                if (check)
                {
                    InsertValue = Convert.ToInt32(InsertValue);
                    return InsertValue;
                }
                else
                {                   
                    Console.WriteLine("Ошибка ввода!");                    
                }                
            }            
        }

        public int InsertFirstValue()
        {
            Result = InsertValue();
            return Result;
        }

        public void Exit()
        {
            int CursorPosition = Console.CursorTop;
            Console.SetCursorPosition(0, CursorPosition);
            Console.WriteLine("Программа завершена");
            Thread.Sleep(1500);
            Environment.Exit(0);
        }

        public char CheckOperator()
        {
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    Exit();
                    return '\0';

                case ConsoleKey.Spacebar:
                    Exit();
                    return '\0';

                case ConsoleKey.Add:
                    Console.WriteLine();
                    return '+';

                case ConsoleKey.Subtract:
                    Console.WriteLine();
                    return '-';

                case ConsoleKey.Divide:
                    Console.WriteLine();
                    return '/';

                case ConsoleKey.Multiply:
                    Console.WriteLine();
                    return '*';

                case ConsoleKey.Backspace:
                    CancelLast();
                    return '\0';

                case ConsoleKey.Delete:
                    return 'D';

            }
            Console.WriteLine("\nНеверный оператор");
            return '\0';

        }


        public void Div(int value)
        {
            stack.Push(Result);
            if (value == 0)
                Console.WriteLine($"Деление на 0 запрещено!");
            else
            {
                Result /= value;
            }                 
            RaiseEvent();
        }

        public void Sub(int value)
        {
            stack.Push(Result);
            Result -= value;
            RaiseEvent();
        }

        public void Add(int value)
        {
            stack.Push(Result);
            Result += value;
            RaiseEvent();
        }

        public void Mul(int value)
        {
            stack.Push(Result);
            Result *= value;
            RaiseEvent();
        }

        public void CancelLast()
        {
            Console.WriteLine("\nОтмена последнего действия");
            if (stack.Count() > 0)
            {
                Result = stack.Pop();
                RaiseEvent();
            }
        }

        public void Clear()
        {
            Console.WriteLine("\nОчистка буфера");
            stack.Clear();
            Result = 0;
            RaiseEvent();
        }
    }
}
