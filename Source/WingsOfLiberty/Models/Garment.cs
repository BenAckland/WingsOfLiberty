using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AckBack3.Models
{

    public class Garment
    {
        [ScaffoldColumn(false)]
        public int GarmentID { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Image Folder Location")]
        [StringLength(1024)]
        public string ImgURL { get; set; }

        [Required]
        [Range(0, 500, ErrorMessage="Price must be between 0 and 500")]
        public decimal Price { get; set; }


        public virtual ICollection<Size> Sizes { get; set; }

    }
}