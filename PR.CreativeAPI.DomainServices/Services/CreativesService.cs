using PR.CreativeAPI.Core.Data;
using PR.CreativeAPI.Data;
using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using PR.CreativeAPI.Domain.PersistModels;
using PR.CreativeAPI.Interfaces;
using PR.CreativeAPI.Interfaces.Dtos;
using PR.CreativeAPI.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PR.CreativeAPI.DomainServices.Mappings;
using BandR.Core.Exceptions;

namespace PR.CreativeAPI.DomainServices.Services
{
    public class CreativesService : DomainService<Creative, PersistCreative>, ICreativesService
    {
        public CreativesService(IUnitOfWork<Creative, PersistCreative> unitOfWork) : base(unitOfWork)
        {
        }

        public Creative GetCreativeById(int creativeId)
        {
            Creative creative = _unitOfWork.Repository.SearchById(creativeId);
            return creative;
        }

        public Creative CreateCreative(CreativeDto creativeDto)
        {
            Creative creative = creativeDto.ConvertToDomainModel();

            ValidateForCreation(creative);

            _unitOfWork.Repository.Add(creative);
            _unitOfWork.Save();
            
            return creative;
        }

        public void UpdateCreative(CreativeDto creativeDto)
        {
            Creative creative = _unitOfWork.Repository.SearchById(creativeDto.Id);
            creativeDto.UpdateDomainModel(creative);
            _unitOfWork.Repository.Update(creative);
            _unitOfWork.Save();
        }

        public void DeleteCreative(int id)
        {
            Creative creative = _unitOfWork.Repository.SearchById(id);
            ValidateForDelete(creative);
            _unitOfWork.Repository.Delete(creative);
            _unitOfWork.Save();
        }

        #region private methods

        private void ValidateForCreation(Creative creative)
        {
            if (_unitOfWork.Repository.GetAll().AsQueryable()
                .Count(c => c.AdvertiserId == creative.AdvertiserId && c.Name == creative.Name) > 0)
                throw new DomainException("Creative name is already in use for that Advertiser.");
    }

        private static void ValidateForDelete(Creative creative)
        {
            if (creative == null)
                throw new DomainException("Attempting to delete a non-existent Creative.");
        }
        #endregion private methods

        public List<Creative> GetAll(System.Linq.Expressions.Expression<Func<Creative, bool>> expression, Func<IQueryable<Creative>, IOrderedQueryable<Creative>> orderBy, string top, string skip)
        {
            List<Creative> creatives = new List<Creative>() { new Creative(new CreativeAPI.Domain.PersistModels.PersistCreative() { CreativeId = 1 } ), 
                                          new Creative(new CreativeAPI.Domain.PersistModels.PersistCreative() { CreativeId=2} ) };

            var q = creatives.AsQueryable();

            if (expression != null)
                q = q.Where(expression);

            //if (skip != null)
            //   q=  q.Skip(Convert.ToInt32(skip));

            //if (top != null)
            //   q = q.Take(Convert.ToInt32(top));



            //if (orderBy != null)
            //    q = orderBy(q);   


            return q.ToList<Creative>();
        }
    }
}
