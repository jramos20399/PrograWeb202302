using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    internal class ProductDALImpl : IProductDAL
    {

        private NorthWindContext _northWindContext;
        private UnidadDeTrabajo<Product> unidad;

        public bool Add(Product entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Product>(new NorthWindContext()))
                {
                    unidad.genericDAL.Add(entity);
                    unidad.Complete();  

                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public void AddRange(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Get(int id)
        {
            Product product;
            using (unidad = new UnidadDeTrabajo<Product>(new NorthWindContext()))
            {
                product = await unidad.genericDAL.Get(id);
            }
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            IEnumerable<Product> products;
            using (unidad = new UnidadDeTrabajo<Product>(new NorthWindContext()))
            {
                products = await unidad.genericDAL.GetAll();
            }
            return products;
        }

        public bool Remove(Product entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Product>(new NorthWindContext()))
                {
                    unidad.genericDAL.Remove(entity);
                    unidad.Complete();

                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void RemoveRange(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public Product SingleOrDefault(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Product>(new NorthWindContext()))
                {
                    unidad.genericDAL.Update(entity);
                    unidad.Complete();

                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
