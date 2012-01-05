using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AckBack3.Models;
using System.Data;

namespace AckBack3.DAL
{
    public class GarmentRepository: IGarmentRepository, IDisposable
    {

        private TShirtEntities context;

        public GarmentRepository(TShirtEntities context)
        {
            this.context = context;
        }

        public IQueryable<Models.Garment> GetShirts()
        {
            return context.Garments;
        }

        public Models.Garment GetGarmentById(int GarmentId)
        {
            return context.Garments.Find(GarmentId);
        }

        public void InsertGarment(Models.Garment garment)
        {
            context.Garments.Add(garment);
        }

        public void DeleteGarment(int garmentId)
        {
            Garment garment = context.Garments.Find(garmentId);
            context.Garments.Remove(garment);
        }

        public void UpdateGarment(Models.Garment garment)
        {
            context.Entry(garment).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}