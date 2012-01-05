using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AckBack3.Models;

namespace AckBack3.DAL
{
    public interface IGarmentRepository : IDisposable
    {
        IQueryable<Garment> GetShirts();
        Garment GetGarmentById(int GarmentId);
        void InsertGarment(Garment garment);
        void DeleteGarment(int garmentId);
        void UpdateGarment(Garment garment);
        void Save();
    }
}