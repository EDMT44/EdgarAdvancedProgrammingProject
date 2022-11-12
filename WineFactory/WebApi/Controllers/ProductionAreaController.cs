using Microsoft.AspNetCore.Mvc;
using WineFactory;
using Repository;
using System.Net;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionAreaController : ControllerBase
    {
        private readonly ILogger<ProductionAreaController> _logger;

        private readonly IWineRepository _wineRepository;

        public ProductionAreaController(ILogger<ProductionAreaController> logger, IWineRepository wineRepository)
        {
            _logger = logger;
            _wineRepository = wineRepository;
        }

        [HttpPost("PostWine/{fermenter},{flavor},{id},{batchId},{state},{dataTime}", Name = "PostWine")]
        public ActionResult<Wine> PostWine(Fermenter fermenter, int flavor, int id, string batchId, int state, DateTime date)
        {
            _wineRepository.BeginTransaction();
            var wine = _wineRepository.CreateWine(fermenter, Enum.GetValues<Flavors>()[flavor], id, batchId, Enum.GetValues<WineStates>()[state], date);
            _wineRepository.CommitTransaction();
            if (wine == null)
            {
                _logger.LogError($"{nameof(ProductionAreaController.PostWine)} -> cannot create wine");
                return NotFound();
            }
            return wine;
        }

        [HttpGet("GetWines", Name = "GetWines")]
        public ActionResult<IEnumerable<Wine>> GetWorkers()
        {
            _wineRepository.BeginTransaction();
            var wine = _wineRepository.GetWines();
            _wineRepository.CommitTransaction();
            if (wine == null)
            {
                _logger.LogError($"{nameof(ProductionAreaController.GetWine)} -> wine not found");
                return NotFound();
            }
            return wine;
        }

        [HttpGet("GetWine/{id}", Name = "GetWine")]
        public ActionResult<Wine> GetWine(int id)
        {
            _wineRepository.BeginTransaction();
            var wine = _wineRepository.GetWine(id);
            _wineRepository.CommitTransaction();
            if (wine == null)
            {
                _logger.LogError($"{nameof(ProductionAreaController.GetWine)} -> wine not found");
                return NotFound();
            }
            return wine;
        }
    }
}