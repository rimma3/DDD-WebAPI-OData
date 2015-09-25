using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using PR.CreativeAPI.Interfaces.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PR.CreativeAPI.Interfaces.Services
{
    public interface ICreativesService
    {
        List<Creative> GetAll(Expression<Func<Creative, bool>> expression, Func<IQueryable<Creative>, IOrderedQueryable<Creative>> orderBy, string top, string skip);
        Creative GetCreativeById(int creativeId);
        Creative CreateCreative(CreativeDto creativeRequest);
		void UpdateCreative(CreativeDto creativeRequest);
        void DeleteCreative(int id);    }
}
