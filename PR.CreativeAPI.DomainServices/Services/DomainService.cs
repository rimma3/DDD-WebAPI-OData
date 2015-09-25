using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandR.Core.Data;
using BandR.Core.Domain;
using PR.CreativeAPI.Core.Data;
using PR.CreativeAPI.Core.Domain;

namespace PR.CreativeAPI.DomainServices.Services
{
    public abstract class DomainService<TDomainEntity, TPersistEntity>
        where TDomainEntity : CreativeDomainEntity<TPersistEntity>, IAggregateRoot
        where TPersistEntity : class, IPersistEntity
    {
        protected IUnitOfWork<TDomainEntity, TPersistEntity> _unitOfWork;

        public DomainService(IUnitOfWork<TDomainEntity, TPersistEntity> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<TDomainEntity> GetAll()
        {
            return _unitOfWork.Repository.GetAll().ToList();
        }
    }
}
