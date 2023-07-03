using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using Water_bucket_challenge.Models;

namespace Water_bucket_challenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WaterBucketController : ControllerBase
    {
        private readonly WaterBucketSolver _waterBucketSolver;
        private readonly ValidateGallons _validateGallons;

        public WaterBucketController()
        {
            _waterBucketSolver = new WaterBucketSolver();
            _validateGallons = new ValidateGallons();
        }

        /*
         * In this controller, the gallons entered by the user (X, Y and Z) are received, in the first 
         * instance it is evaluated that the values meet the requirements and then it is validated if 
         * they have a solution or not, if there is no solution, "XXX" is returned. "But otherwise, 
         * the gallons are sent to the solver to obtain the best solution.
         */
        [HttpPost]
        public ActionResult<Buckets> Create(Gallons gallons)
        {
            if (gallons.X_Gallon <= 0 || gallons.Y_Gallon <= 0 || gallons.Z_Gallon <= 0)
            {
                return BadRequest();
            }

            if (_validateGallons.Validate(gallons))
            {
                var actions = _waterBucketSolver.Solve(gallons);
                return Ok(actions);
            }
            else
            {
                return Content("No solution");
            }
        }
    }
}
