using System.ComponentModel.DataAnnotations;

namespace Water_bucket_challenge.Models
{
    /*
     * Object to store the values received by the user (Gallons X, Y and Z)
     */
    public class Gallons
    {
        [Required]
        public int X_Gallon { get; set; }
        [Required]
        public int Y_Gallon { get; set; }
        [Required]
        public int Z_Gallon { get; set; }
    }
}
