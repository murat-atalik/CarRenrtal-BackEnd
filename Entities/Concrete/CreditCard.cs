using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard:IEntity
    {
        public int CreditCardId { get; set; }
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public DateTime ValidDate { get; set; }
        public decimal CardBalance { get; set; }
        public int Cvv { get; set; }
    }
}
