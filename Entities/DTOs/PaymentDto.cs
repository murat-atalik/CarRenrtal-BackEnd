using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PaymentDto:IDto
    {
        public int CreditCardId { get; set; }
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public DateTime ValidDate { get; set; }
        public decimal CardBalance { get; set; }
        public int Cvv { get; set; }



        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
