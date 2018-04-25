using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class Cart
    {
        [Key]
        public Guid CartId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public int AlbumId { get; set; }

        [ForeignKey("AlbumId")]
        public virtual Album Album { get; set; }
    }
}