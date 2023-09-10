using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA_Core.Services;
using OA_Service.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : Controller
    {
        public IHistoryService HistoryService { get; }

        public HistoryController(IHistoryService historyService)
        {
            HistoryService = historyService;
        }
        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        // Done
        // Create Exchange History
        public IActionResult Create(ExchangeHistory history)
        {

            if (ModelState.IsValid)
            {
                int data = this.HistoryService.Create(history);
                if (data == 1)
                    return Ok(new Response { Status = "Success", Message = "Currency History created successfully!" });

                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Currency creation failed! Please check currency details and try again." });

            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Currency creation failed! Please check currency details and try again." });
        }
        [Route("GetHighestNCurrencies")]
        [AllowAnonymous]
        // Done 
        // Get Most Rates Of Currency
        public IActionResult GetHighestNCurrencies(int number)
        {
            Array data=this.HistoryService.GetHighestNCurrencies(number).ToArray();
            return Ok(new Response { Status = "Success", Message = " successfully!", Data = data });

        }
        [Route("GetLowestNCurrencies")]
        [AllowAnonymous]
        // Done
        // Get Lowest Rates Of Currency
        public IActionResult GetLowestNCurrencies(int number)
        {
            Array data = this.HistoryService.GetLowestNCurrencies(number).ToArray();
            return Ok(new Response { Status = "Success", Message = " successfully!", Data = data });
        }
        [Route("GetLeastNImprovedCurrenciesByDate")]
        [AllowAnonymous]
        // Done
        // Get Least Improved Currency By Date
        public IActionResult GetLeastNImprovedCurrenciesByDate(DateTime startDate,DateTime endDate)
        {
            Array Data = this.HistoryService.GetLeastNImprovedCurrenciesByDate(startDate, endDate).ToArray();

            return Ok(new Response { Status = "Success", Message = "successfully!", Data = Data });

        }
        [Route("GetMostNImprovedCurrenciesByDate")]
        [AllowAnonymous]
        // Done
        // Get Most Improved Currency By Date
        public IActionResult GetMostNImprovedCurrenciesByDate(DateTime startDate, DateTime endDate)
        {
            Array Data = this.HistoryService.GetMostNImprovedCurrenciesByDate(startDate, endDate).ToArray();

            return Ok(new Response { Status = "Success", Message = "successfully", Data = Data });

        }
    }
}
