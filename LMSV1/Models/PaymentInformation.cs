using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSV1.Models
{
    public class PaymentInformation
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int ID { get; set; }  // Primary key

        [Required(ErrorMessage = "Name is a required field")]
        [Display(Name = "Name On Card")]
        public required string cardName { get; set; }

        [Required(ErrorMessage = "Card number is a required field")]
        [Display(Name = "Card Number")]
        public required Int64 cardNumber { get; set; }

        [Required(ErrorMessage = "Expiration is a required field")]
        [Display(Name = "Expiration")]
        [DataType(DataType.Date)]
        public required DateTime expiration { get; set; }

        [Required(ErrorMessage = "CVV is a required field")]
        [Display(Name = "CVV")]
        public required int cVV { get; set; }

        [Required(ErrorMessage = "Payment amount is a required field")]
        [Display(Name = "Payment Amount")]
        public required float paymentAmount { get; set; }
    }
}
