using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BlazorWebAssembely.Shared
{
    public class Player 
    {
        public int Id { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public char Gender { get; set; }
        public DateOnly Birthday {get;set; }
        [NotMapped]
        public int Age { get { return GetAge(this); } }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int ZipCode { get; set; }
        public float? Rating { get; set; }

        public static int GetAge(Player player)
        {
            var today = DateTime.Now;

            return (today.Year - player.Birthday.Year - 1) + (((today.Month > player.Birthday.Month)
                || ((today.Month == player.Birthday.Month) && (today.Day >= player.Birthday.Day))) ? 1 : 0);
        }
    }
}
