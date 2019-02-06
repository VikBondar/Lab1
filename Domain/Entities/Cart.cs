﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines { get { return lineCollection; } }

        public void AddItem(Auto auto,int quantity)
        {
            CartLine line = lineCollection
                .Where(b => b.Auto.Id == auto.Id)
                .FirstOrDefault();

            if(line == null)
            {
                lineCollection.Add(new CartLine { Auto = auto, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Auto auto)
        {
            lineCollection.RemoveAll(l => l.Auto.Id == auto.Id);
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Auto.Price * e.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
    }
    public class CartLine
    {
        public Auto Auto { get; set; }
        public int Quantity { get; set; }
    }
}
