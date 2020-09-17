using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TariffComparison.Business.Interface;
using TariffComparison.Model;

namespace TariffComparison.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<TBusinessModel, TDataModel, TKey> : Controller where TBusinessModel : class where TDataModel : class
    {
        protected IGenericService<TBusinessModel, TDataModel, TKey> genericService;
        public GenericController(IGenericService<TBusinessModel, TDataModel, TKey> genericService)
        {
            this.genericService = genericService;
        }
        [HttpGet]
        public virtual async Task<ObjectResult> Get()
        {
            try
            {
                var all = await genericService.Get().ConfigureAwait(false);
                return new OkObjectResult(BaseModel.Create(success: true, data: all, total: all.Count, message: "success"));
            }
            catch (Exception ex)
            {
                return new NotFoundObjectResult(BaseModel.Create(success: false, data: null, total: 0, message: ex.Message));
            }
        }

        [HttpPost]
        public virtual async Task<ObjectResult> Post([FromBody]TBusinessModel model)
        {
            try
            {
                var obj = await genericService.Add(model);
                return new OkObjectResult(BaseModel.Create(success: true, data: null, total: 1, message: "success"));
            }
            catch (Exception ex)
            {
                return new NotFoundObjectResult(BaseModel.Create(success: false, data: null, total: 0, message: ex.Message));
            }
        }
    }
}