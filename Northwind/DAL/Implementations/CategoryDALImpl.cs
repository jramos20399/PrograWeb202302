using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CategoryDALImpl : ICategoryDAL
    {
        private NorthWindContext _northWindContext;
        private UnidadDeTrabajo<Category> unidad;

        public bool Add(Category entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Category>(new NorthWindContext()))
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

        public void AddRange(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Get(int id)
        {
            Category category = null;
            using (unidad = new UnidadDeTrabajo<Category>(new NorthWindContext()))
            {
                category = await unidad.genericDAL.Get(id);


            }

            return category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            IEnumerable<Category> categories = null;
            using (unidad = new UnidadDeTrabajo<Category>(new NorthWindContext()))
            {
                categories = await unidad.genericDAL.GetAll();


            }

            return categories;

        }

        public bool Remove(Category entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Category>(new NorthWindContext()))
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

        public void RemoveRange(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public Category SingleOrDefault(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Category entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Category>(new NorthWindContext()))
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
