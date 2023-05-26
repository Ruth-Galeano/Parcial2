using Microsoft.AspNetCore.Mvc;
using Parcial2.Models;
using Parcial2.Services;

namespace Parcial2.Controllers
{

    [ApiController]
    [Route("api/[controller]")] 
    public class OperacionController : Controller
    {
        private OperacionServices operacionServices;
        private IConfiguration configuration;
        public OperacionController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.operacionServices = new OperacionServices(configuration.GetConnectionString("postgresDB"));
        }

        [HttpPut("Extracto/{NumeroCuenta}")]
        public ActionResult ImprimirExtracto(string NumeroCuenta)
        {
            var resultado = operacionServices.ImprimirExtractoPorNumCuenta(NumeroCuenta);
            return Ok(resultado);
        }

        [HttpPut("Depositar")]
        public ActionResult Deposito(OperacionesRequestModels model)
        {
            var resultado = operacionServices.Depositar(model);
            return Ok(resultado);
        }

        [HttpPut("Transferir")]
        public ActionResult Transferencia(TransferenciaRequestModels model)
        {
            var resultado = operacionServices.Transferir(model);
            return Ok(resultado);
        }

        [HttpPut("Retirar")]
        public ActionResult Extraccion(OperacionesRequestModels model)
        {
            var resultado = operacionServices.Retirar(model);
            return Ok(resultado);
        }

        [HttpPut("BloquearCuenta/{NumeroCuenta}")]
        public ActionResult BloqueoCuenta(string NumeroCuenta)
        {
            var resultado = operacionServices.BloquearCuenta(NumeroCuenta);
            return Ok(resultado);
        }

    }
}



