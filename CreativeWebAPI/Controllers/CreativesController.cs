using CreativeAPI.Models;
using CreativeWebAPI.Controllers;
using CreativeWebAPI.Infrastructure.RouteNames;
using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using PR.CreativeAPI.Interfaces.Dtos;
using PR.CreativeAPI.Interfaces.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData.Query;
using CreativeWebAPI.Infrastructure.Extensions;

namespace CreativeAPI.CreativeControllers
{

     /// <summary>
    /// The controller that will handle actions for panels.
    /// </summary>
    [RoutePrefix("creatives")]
    public class CreativesController : ApiBaseController
    {      
        private ICreativesFacade _creativesFacade;

        /// <summary>
        /// Instantiates a new CreativesController class.
        /// </summary>
        /// <param name="creativesFacade"></param>
        public CreativesController(ICreativesFacade creativesFacade)
        {
            _creativesFacade = creativesFacade;
        }

        /// <summary>
        /// Gets all creatives.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("", Name = CreativeRoute.GET_ALL)]
        [ResponseType(typeof(IEnumerable<CreativeModel>))]
        public async Task<IHttpActionResult> GetAllCreatives(ODataQueryOptions<Creative> options)
        {

            //List<Creative> creatives = new List<Creative>();

            Expression<Func<Creative, bool>> myExpression = options.Filter.ToExpression<Creative>();
            Func<IQueryable<Creative>, IOrderedQueryable<Creative>> myOrderBy = options.OrderBy.ToExpression<Creative>();


            Func<IQueryable<Creative>, IOrderedQueryable<Creative>> query2 = query => query.OrderBy(creative => creative.Name);

            List<Creative> creatives = _creativesFacade.GetAll(myExpression, myOrderBy, options.Top.RawValue, options.Skip.RawValue);


            // TODO: refactor to get list of DTOs, that are converted from Domain object in ????
            List<CreativeModel> creativeModels = new List<CreativeModel>();



            foreach (Creative creative in creatives)
            {
                CreativeModel creativeModel = new CreativeModel();
                creativeModel.Id = creative.Id;
                creativeModel.Name = creative.Name;
                creativeModels.Add(creativeModel);
            }

            return Ok<IEnumerable<CreativeModel>>(creativeModels);
        }

        ///// <summary>
        ///// Gets all creatives.
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("creatives", Name = CreativeRoute.GET_ALL)]
        //[ResponseType(typeof(IEnumerable<CreativeModel>))]
        //public async Task<IHttpActionResult> GetAllCreatives(ODataQueryOptions<Creative> options)
        //{

        //    Expression<Func<Creative, bool>> myExpression = options.Filter.ToExpression<Creative>();
        //    Func<IQueryable<Creative>, IOrderedQueryable<Creative>> myOrderBy = options.OrderBy.ToExpression<Creative>();


        //    List<Creative> creatives = _creativesFacade.GetAll(myExpression, myOrderBy, options.Top.RawValue, options.Skip.RawValue);

        //    // TODO: refactor to get list of DTOs, that are converted from Domain object in ????
        //    List<CreativeModel> creativeModels = new List<CreativeModel>();

        

        //    foreach(Creative creative in creatives)
        //    {
        //        CreativeModel creativeModel = new CreativeModel();
        //        creativeModel.Id = creative.Id;
        //        creativeModel.Name = creative.Name;
        //        creativeModels.Add(creativeModel);
        //    }

        //    return Ok<IEnumerable<CreativeModel>>(creativeModels);
        //}

        /// <summary>
        /// Gets a specific creative.
        /// </summary>
        /// <param name="creativeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int:min(1)}", Name = CreativeRoute.GET_BY_ID)]
        [ResponseType(typeof(CreativeModel))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var creative = _creativesFacade.GetCreativeById(id);

            CreativeModel creativeModel = new CreativeModel();
            creativeModel.Id = creative.Id;
            creativeModel.Name = creative.Name;

            if (creative == null)
            {
                return NotFound();
            }
            return Ok(creativeModel);
        }

        /// <summary>
        /// Creates a new creative.
        /// </summary>
        /// <param name="creativeRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("", Name = CreativeRoute.CREATE)]
        [ResponseType(typeof(CreativeDto))]
        public async Task<IHttpActionResult> Post(CreativeDto creativeRequest)
        {
            Creative newCreative = _creativesFacade.CreateCreative(creativeRequest);
            return Created<Creative>(Url.Content(Url.Route(CreativeRoute.CREATE, new { creativeId = newCreative.Id })), newCreative);
        }

        /// <summary>
        /// Updates an existing creative.
        /// </summary>
        /// <param name="creativeRequest"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("", Name = CreativeRoute.UPDATE)]
        [ResponseType(typeof(CreativeDto))]
        public async Task<IHttpActionResult> Put(CreativeDto creativeRequest)
        {
            _creativesFacade.UpdateCreative(creativeRequest);

            return NoContent();
        }

        /// <summary>
        /// Deletes an existing creative.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int:min(1)}", Name = CreativeRoute.DELETE)]
        [ResponseType(typeof(CreativeDto))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            _creativesFacade.DeleteCreative(id);

            return NoContent();
        }
    }
}

