using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    // generic constraint -- kısıtlama

    // class -- referans tip olabilir demek. class olabilir demek değil

    // new() -- new'lenebilir olmalı IEntity kullanmamak için , sadece türevlerini kullanmak için
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter= null); // null ise filtre vermeyebilir demek
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
       
    }
}
