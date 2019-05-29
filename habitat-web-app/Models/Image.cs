using System;
using System.ComponentModel.DataAnnotations;

namespace HabitatWebApp.Models
{
    public class Image
    {

        [Key]
        public int ImageId { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public string Name { get; set; }

        public byte[] TheImage { get; set; }

        public int IssueId { get; set; }

        public virtual Issue Issue { get; set; }
    }
}