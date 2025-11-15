using System;

namespace QLKS.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } // Cash, CreditCard, DebitCard, BankTransfer
        public string TransactionId { get; set; }
        public string Status { get; set; } // Pending, Completed, Failed, Refunded
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
