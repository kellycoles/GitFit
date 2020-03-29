

using System.ComponentModel.DataAnnotations;

namespace GitFit.Models
{
    public class Biometric
    {
        [key]
        public int BiometricId{ get; set; }

        public int Height { get; set; }

        public int Weight{ get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }
        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
