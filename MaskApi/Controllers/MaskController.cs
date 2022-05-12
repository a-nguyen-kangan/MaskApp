using System.Collections.Generic;
using MaskApi.models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Configuration;

namespace MaskApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaskController : ControllerBase {
        public static List<Mask> MasksInStock = new List<Mask>();
        
        public MaskController() {
            MasksInStock.Add(new Mask("m-9999", 1, "White", true, false, "Flowers", true, 10.00));
            MasksInStock.Add(new Mask("m-8888", 3, "Black", false, true, "RaceCars", true, 3.50));
            MasksInStock.Add(new Mask("m-7777", 1, "Pink", true, false, "Peppa Pig", true, 15.00));
            MasksInStock.Add(new Mask("m-6666", 3, "Yellow", false, true, "Sponge Bob", true, 5.50));
            MasksInStock.Add(new Mask("m-2222", 1, "Red", false, true, "MAGA", true, 2.50));
        }

        [HttpGet("GetAll")]
        public List<Mask> GetAll() {
            return MasksInStock;
        }

        [HttpGet("{maskId}")]
        public Mask GetMask(string maskId) {
            Mask found = null;
            foreach(Mask mask in MasksInStock) {
                if(maskId == mask.MaskId) {
                    found = mask;
                    break;
                }
            }
            
            return found;
        }
        
        [HttpGet("TESTVAR")]
        public string TestVar() {
            var str = "";
            str = Environment.GetEnvironmentVariable("TESTVAR");
            return str;
        }
        
        [HttpGet("ConnString")]
        public string GetConnString() {
            var str = "";
            str = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_TestString");
            return str;
        }
    }
}
