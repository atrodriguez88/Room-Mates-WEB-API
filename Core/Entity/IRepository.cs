using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RoomM.API.Core.Entity
{
    public interface IRepository<T>
    {
        #region IRepository<T> Members

        /// <summary>
        /// Retorna un objeto del tipo AsQueryable y acepta como parámetro las relaciones a incluir
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAll();

        IAsyncEnumerable<T> Include(Expression<Func<T, object>> where);

        /// <summary>
        /// Retorna un objeto del tipo AsQueryable bajo una condición que especifiques como parámetro
        /// </summary>
        /// <param name="where"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> where);

        /// <summary>
        /// Retorna una entidad bajo una condición especificada
        /// </summary>
        /// <param name="where"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<T> Single(Expression<Func<T, bool>> where);

        /// <summary>
        /// Retorna una entidad bajo una condición especificada o null sino encontrara registros
        /// </summary>
        /// <param name="where"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<T> SingleOrDefault(Expression<Func<T, bool>> where);

        /// <summary>
        /// Retorna la primera entidad encontrada bajo una condición especificada
        /// </summary>
        /// <param name="where"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<T> First(Expression<Func<T, bool>> where);

        /// <summary>
        /// Retorna la primera entidad encontrada bajo una condición especificada o null sino encontrara registros
        /// </summary>
        /// <param name="where"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<T> FirstOrDefault(Expression<Func<T, bool>> where);

        /// <summary>
        /// Elimina una entidad
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Registra una entidad
        /// </summary>
        /// <param name="entity"></param>
        Task Insert(T entity);

        /// <summary>
        /// Actualiza una entidad
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Registra varias entidades
        /// </summary>
        /// <param name="entity"></param>
        void Insert(IEnumerable<T> entities);

        /// <summary>
        /// Actualiza varias entidades
        /// </summary>
        /// <param name="entity"></param>
        void Update(IEnumerable<T> entities);
        #endregion

        #region SQL Queries
        /// <summary>
        /// Ejecuta un query personalizado
        /// </summary>
        /// <param name="entity"></param>
        IQueryable<T> SelectQuery(string query, params object[] parameters);

        /// <summary>
        /// Ejecuta un query personalizado y returns an integer specifying the number of rows affected
        /// by the SQL statement passed to it. Valid operations are INSERT, UPDATE and DELETE.
        /// The method is not used for returning entities.
        /// </summary>
        /// <param name="entity"></param>
        Task<int> ExecuteSqlCommand(string query, params object[] parameters);
        #endregion
    }
}
