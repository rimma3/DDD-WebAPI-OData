using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using PR.CreativeAPI.Interfaces;
using PR.CreativeAPI.Interfaces.Dtos;
using PR.CreativeAPI.Interfaces.Facades;
using PR.CreativeAPI.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
 
namespace PR.CreativeAPI.DomainServices.Facades
{
    public class CreativesFacade :ICreativesFacade
    {
        private ICreativesService _creativesService;

        public CreativesFacade(ICreativesService CreativesService)
        {
            _creativesService = CreativesService;
        }
        public List<Creative> GetAll(Expression<Func<Creative, bool>> expression, Func<IQueryable<Creative>, IOrderedQueryable<Creative>> orderBy, string top, string skip)

        {
            return _creativesService.GetAll(expression, orderBy, top, skip);
        }
        public Creative GetCreativeById(int creativeId)
        {
            return _creativesService.GetCreativeById(creativeId);
        }

        public Creative CreateCreative(CreativeDto creativeRequest)
        {
            return _creativesService.CreateCreative(creativeRequest);
        }

        public void UpdateCreative(CreativeDto creativeRequest)
        {
            _creativesService.UpdateCreative(creativeRequest);
        }

        public void DeleteCreative(int id)
        {
            _creativesService.DeleteCreative(id);
        }
    }
}
