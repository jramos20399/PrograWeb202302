using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class SupplierDALImpl : ISupplierDAL
    {

        private UnidadDeTrabajo<Supplier> unidad;
        private NorthWindContext northwind;

        public bool Add(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Supplier> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Supplier> Find(Expression<Func<Supplier, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Supplier>> GetAll()
        {
           IEnumerable<Supplier> entities = new List<Supplier>();

            using (unidad = new UnidadDeTrabajo<Supplier>(new NorthWindContext()))
            {
                entities = await unidad.genericDAL.GetAll();
            }
            return entities;
        }

        public bool Remove(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Supplier> entities)
        {
            throw new NotImplementedException();
        }

        public Supplier SingleOrDefault(Expression<Func<Supplier, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Supplier entity)
        {
            throw new NotImplementedException();
        }
    }
}
