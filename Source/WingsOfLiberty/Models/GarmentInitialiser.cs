using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AckBack3.Models
{
    public class GarmentInitialiser : DropCreateDatabaseIfModelChanges<TShirtEntities>
    {
        protected override void Seed(TShirtEntities context)
        {
            var garments = new List<Garment>{
            
                new Garment{ Description = "Shirt1", ImgURL="../../content/themes/images/ShirtThumb.jpg", Name="Shirt1", Price = 10.00M, Sizes = new List<Size>()},
                new Garment{ Description = "Shirt2", ImgURL="../../content/themes/images/ShirtThumb.jpg", Name="Shirt2", Price = 20.00M, Sizes = new List<Size>()},
                new Garment{ Description = "Shirt3", ImgURL="../../content/themes/images/ShirtThumb.jpg", Name="Shirt3", Price = 30.00M, Sizes = new List<Size>()},
                new Garment{ Description = "Shirt4", ImgURL="../../content/themes/images/ShirtThumb.jpg", Name="Shirt4", Price = 40.00M, Sizes = new List<Size>()}
            };
            garments.ForEach(s => context.Garments.Add(s));
            context.SaveChanges();

            var sizes = new List<Size>{
            
                new Size{ Dimensions = "1x1x1", Name = "Small"},
                new Size{ Dimensions = "2x2x2", Name = "Medium"},
                new Size{ Dimensions = "3x3x3", Name = "Large"},
            };
            sizes.ForEach(s => context.Sizes.Add(s));
            context.SaveChanges();

            garments[0].Sizes.Add(sizes[0]);
            garments[0].Sizes.Add(sizes[1]);
            garments[0].Sizes.Add(sizes[2]);
            garments[1].Sizes.Add(sizes[1]);
            garments[1].Sizes.Add(sizes[2]);
            garments[2].Sizes.Add(sizes[2]);
            garments[3].Sizes.Add(sizes[0]);
            garments[3].Sizes.Add(sizes[2]);

            context.SaveChanges();
        }
    }
}