using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA_Core.Services;
using OA_Repository.Validations.Currency;
using OA_Service;
using OA_Service.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : Controller
{
        public ICurrencyService<Currency> CurrencyService { get; }

        public CurrencyController(ICurrencyService<Currency> currencyService)
        {
            CurrencyService = currencyService;
        }

        [HttpPost]
        [Route("Create")]
        [AllowAnonymous]
        // Create New Currency
        public IActionResult Create(CurrencyValidation Currency)
        {
                if (ModelState.IsValid)
                {
                   Currency currencyMap = new Currency ();
                   currencyMap.Name = Currency.Name;
                   currencyMap.Sgin = Currency.Sgin;
                   currencyMap.IsActive = Currency.IsActive;
                
                int data = this.CurrencyService.Create(currencyMap);
                    if (data == 1)
                        return Ok(new Response { Status = "Success", Message = "Currency created successfully!" });

                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Currency creation failed! Please check user details and try again." });
                }
                 return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Currency creation failed! Please check user details and try again." });
                
        }
        [HttpPost]
        [Route("Update")]
        [AllowAnonymous]
        // Edit Currency
        public IActionResult Update(Currency Currency)
        {
            if (ModelState.IsValid)
            {
               this.CurrencyService.Update(Currency);
               return Ok(new Response { Status = "Success", Message = "Currency Edited successfully!" });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Currency creation failed! Please check user details and try again." });

        }
        [HttpPost]
        [Route("Delete")]
        [AllowAnonymous]
        // Delete Currency
        public IActionResult Delete(int id)
        {
            this.CurrencyService.Delete(id);
            return Ok(new Response { Status = "Success", Message = "Currency Deleted successfully!" });

        }

        [Route("GetAllCurrencies")]
        [AllowAnonymous]
        // Get All Currencies
        public IActionResult GetAllCurrencies(int id)
        {
            Array Data= this.CurrencyService.GetAll().ToArray();

            return Ok(new Response { Status = "Success", Message = "Successfully!" ,Data=Data});

        }

        [Route("GetCurrencyByName")]
        [AllowAnonymous]
        // Get Currency By Name
        public IActionResult GetCurrencyByName(string Name)
        {
            Currency Data = this.CurrencyService.FindByName(Name);
            return Ok(new Response { Status = "Success", Message = "successfully!", Data = Data });
        }

    }
}
