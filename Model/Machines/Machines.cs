using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Machines
    {
        private int id;
        private string name;
        private int coins;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Coins { get => coins; set => coins = value; }

        public void addCoins (int a )
        {
            this.coins += a;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
