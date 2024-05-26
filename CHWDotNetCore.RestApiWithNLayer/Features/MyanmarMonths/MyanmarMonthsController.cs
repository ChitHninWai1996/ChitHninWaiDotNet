using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CHWDotNetCore.RestApiWithNLayer.Features.MyanmarMonths
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarMonthsController : ControllerBase
    {
        private MyanmarMonths _data;

        private async Task<MyanmarMonths> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("MyanmarMonths.json");
            var model = JsonConvert.DeserializeObject<MyanmarMonths>(jsonStr);
            return model;
        }

        [HttpGet]
        public async Task<IActionResult> Tbl_Months()
        {
            var model = await GetDataAsync();
            return Ok(model);

        }

        [HttpGet("monthMm")]
        public async Task<IActionResult> MonthList(string monthMm)
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_Months.FirstOrDefault(x => x.MonthMm == monthMm));

        }
    }


    public class MyanmarMonths
    {
        public Tbl_Months[] Tbl_Months { get; set; }
    }

    public class Tbl_Months
    {
        public int Id { get; set; }
        public string MonthMm { get; set; }
        public string MonthEn { get; set; }
        public string FestivalMm { get; set; }
        public string FestivalEn { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
    }

}
