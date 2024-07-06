using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_Calc_Up
{
    internal interface ICalculator
    {

        event EventHandler<EventArgs> PushAdd;
        event EventHandler<EventArgs> GotResult;
        void Add(int i);
        void Sub(int i);
        void Div(int value);
        void Mul(int i);
        void CancelLast();
        int InsertFirstValue();
        int InsertValue ();
        void Exit();
        char CheckOperator();
        void Clear();
    }
}

