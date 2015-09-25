using CreativeAPI.Models;
using CreativeWebAPI.Infrastructure.RouteNames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PR.CreativeAPI.DomainServices.Facades;
using PR.CreativeAPI.Interfaces.Dtos;
using PR.CreativeAPI.Interfaces.Facades;
using CreativeWebAPI.Controllers;

namespace CreativeAPI.Controllers
{
    /// <summary>
    /// The controller that will handle actions for creatives.
    /// </summary>
    [RoutePrefix("panels")]
    public class PanelsController : ApiBaseController
    {
        private IPanelsFacade _panelsFacade;

        /// <summary>
        /// Creates a new instance of PanelsController.
        /// </summary>
        /// <param name="panelsFacade"></param>
        public PanelsController(IPanelsFacade panelsFacade)
        {
            _panelsFacade = panelsFacade;
        }

        /// <summary>
        /// Gets all panels.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("", Name = PanelRoute.GET_ALL)]
        [ResponseType(typeof(IEnumerable<PanelDto>))]
        public async Task<IHttpActionResult> Get()
        {
            List<PanelDto> panels = _panelsFacade.GetAll();

            return Ok<IEnumerable<PanelDto>>(panels);
        }

        /// <summary>
        /// Gets a specific panel.
        /// </summary>
        /// <param name="panelId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int:min(1)}", Name = PanelRoute.GET_BY_ID)]
        [ResponseType(typeof(PanelDto))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var panel = _panelsFacade.GetPanelById(id);

            if (panel == null)
            {
                return NotFound();
            }
            return Ok(panel);
        }

        /// <summary>
        /// Creates a new panel.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("", Name = PanelRoute.CREATE)]
        public async Task<IHttpActionResult> Post(PanelDto dto)
        {
            PanelDto newPanel = _panelsFacade.CreatePanel(dto);
            return Created<PanelDto>(Url.Content(Url.Route(PanelRoute.CREATE, new { panelId = newPanel.Id })), newPanel);
        }

        /// <summary>
        /// Updates an existing panel.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("", Name = PanelRoute.UPDATE)]
        public async Task<IHttpActionResult> Put(PanelDto dto)
        {
            _panelsFacade.UpdatePanel(dto);
            return NoContent();
        }

        /// <summary>
        /// Deletes an existing panel.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int:min(1)}", Name = PanelRoute.DELETE)]
        public async Task<IHttpActionResult> DELETE(int id)
        {
            _panelsFacade.DeletePanel(id);
            return Ok();
        }
    }
}
