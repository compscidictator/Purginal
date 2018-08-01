namespace Purginal.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RegistrationCheck
    {
        [Key]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public State State { get; set; }
        public DateTime Timestamp { get; set; }
    }
}