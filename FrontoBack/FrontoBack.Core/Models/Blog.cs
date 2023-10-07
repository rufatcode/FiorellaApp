using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontoBack.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
		public string ImgSrc { get; set; }
        [Required, Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		
	}
}

