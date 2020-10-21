using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CubeIntersection.ApplicationServices.Cubes;

namespace CubeIntersection.Api.Controllers
{
    /// <summary>
    /// The cube intersection controller class.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class CubeIntersectionController : ControllerBase
    {
        /// <summary>
        /// The cube service
        /// </summary>
        private readonly ICubeService _cubeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CubeIntersectionController" /> class.
        /// </summary>
        /// <param name="cubeService">The cube service.</param>
        public CubeIntersectionController(ICubeService cubeService)
        {
            _cubeService = cubeService;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("Get/{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var cube = this._cubeService.Get(id);
                if (cube == null) return NotFound();
                return Ok(cube);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(this._cubeService.GetAll());
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        /// <summary>
        /// Inserts the specified cube dto.
        /// </summary>
        /// <param name="cubeDto">The cube dto.</param>
        /// <returns></returns>
        [HttpPost("Insert")]
        public IActionResult Insert(CubeDto cubeDto)
        {
            try
            {
                this._cubeService.Insert(cubeDto);
                return Ok(cubeDto);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("Remove/{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                this._cubeService.Remove(id);
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        /// <summary>
        /// Removes all.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("RemoveAll")]
        public IActionResult RemoveAll()
        {
            try
            {
                this._cubeService.RemoveAll();
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
        /// <summary>
        /// Gets the with collisions.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("GetWithCollisions/{id}")]
        public IActionResult GetWithCollisions(string id)
        {
            try
            {
                return Ok(this._cubeService.GetWithCollisions(id));
            }
            catch (Exception e)
            {
                return Conflict(e);
            }
        }

        /// <summary>
        /// Gets the collisions with others.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="othersIds">The others ids.</param>
        /// <returns></returns>
        [HttpPost("GetCollisionsWithOthers")]
        public IActionResult GetCollisionsWithOthers(string id, IEnumerable<string> othersIds)
        {
            try
            {
                return Ok(this._cubeService.GetCollisionsWithOthers(id, othersIds));
            }
            catch (Exception e)
            {
                return Conflict(e);
            }
        }

        /// <summary>
        /// Gets all with collisions.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllWithCollisions")]
        public IActionResult GetAllWithCollisions()
        {
            try
            {
                return Ok(this._cubeService.GetAllWithCollisions());
            }
            catch (Exception e)
            {
                return Conflict(e);
            }
        }

        /// <summary>
        /// Gets the intersections with other.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("GetIntersectionsWithOther/{id}")]
        public IActionResult GetIntersectionsWithOther(string id)
        {
            try
            {
                return Ok(this._cubeService.GetIntersectionsWithOther(id));
            }
            catch (Exception e)
            {
                return Conflict(e);
            }
        }

        /// <summary>
        /// Gets the intersections with others.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        [HttpPost("GetIntersectionsWithOthers")]
        public IActionResult GetIntersectionsWithOthers(string id, IEnumerable<string> ids)
        {
            try
            {
                return Ok(this._cubeService.GetIntersectionsWithOthers(id, ids));
            }
            catch (Exception e)
            {
                return Conflict(e);
            }
        }

        /// <summary>
        /// Gets all intersections.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllIntersections")]
        public IActionResult GetAllIntersections()
        {
            try
            {
                return Ok(this._cubeService.GetAllIntersections());
            }
            catch (Exception e)
            {
                return Conflict(e);
            }
        }
    }
}
