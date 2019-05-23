using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Client : Human
    {
        private int tokens;

        public int Tokens { get => tokens; set => tokens = value; }
        public override string ToString()
        {
            return base.ToString() + $"tokens {tokens}";
        }
    }
}
