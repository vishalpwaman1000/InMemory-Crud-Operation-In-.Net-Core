using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InMemoryCrudOperation.Model
{
    public class UserDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[JsonIgnore]
        public int UserID { get; set; }

        //[JsonIgnore]
        public DateTime InsertionDate { get; set; }

        [Required]
        public string UserName { get; set; }
        public int Age { get; set; }
    }

    public  class UserDetailsResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

}
