using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCBlog.Models
{
    public class Comment
    {
        public Comment()
        {
            this.Date = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Искам коментар")]
        public string Text { get; set; }

        public int Post { get; set; }

        public DateTime Date { get; set; }

        public ApplicationUser Author { get; set; }
    }
}