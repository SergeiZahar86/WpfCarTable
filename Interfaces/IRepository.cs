using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Interfaces
{
    /// <summary>
    /// Интерфейс репозитория
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Набор сущностей
        /// </summary>
        IQueryable<T> Items { get; }

        /// <summary>
        /// Получить весь список сущностей
        /// </summary>
        /// <param name="Cancel"></param>
        /// <returns></returns>
        List<T> GetAll(CancellationToken Cancel = default);

        /// <summary>
        /// Получение записи по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(Guid id);

        /// <summary>
        /// Получение записи по id асинхронно
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Cancel"></param>
        /// <returns></returns>
        Task<T> GetAsync(Guid id, CancellationToken Cancel = default);

        /// <summary>
        /// Добавление записи в БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        T Add(T item);

        /// <summary>
        /// Добавление записи в БД асинхронно
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Cancel"></param>
        /// <returns></returns>
        Task<T> AddAsync(T item, CancellationToken Cancel = default);

        /// <summary>
        /// Изменение записи из БД
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);

        /// <summary>
        /// Изменение записи из БД асинхронно
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Cancel"></param>
        /// <returns></returns>
        Task UpdateAsync(T item, CancellationToken Cancel = default);

        /// <summary>
        /// Удаление записи из БД
        /// </summary>
        /// <param name="id"></param>
        void Remove(Guid id);

        /// <summary>
        /// Удаление записи из БД асинхронно
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Cancel"></param>
        /// <returns></returns>
        Task RemoveAsync(Guid id, CancellationToken Cancel = default);
    }
}
