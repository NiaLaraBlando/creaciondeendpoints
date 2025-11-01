using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Creación_de_endpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentsController : ControllerBase
    {
        private readonly InstrumentRepository _repo = new InstrumentRepository();

        /// <summary>
        /// Obtiene la lista de instrumentos.
        /// </summary>
        // GET: api/instruments
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            return Ok(_repo.Instruments);
        }

        /// <summary>
        /// Agrega un nuevo instrumento.
        /// </summary>
        /// <param name="instrument">Nombre del instrumento a agregar.</param>
        // POST: api/instruments
        [HttpPost]
        public ActionResult<string> Post([FromBody] string instrument)
        {
            if (string.IsNullOrWhiteSpace(instrument))
            {
                return BadRequest("El nombre del instrumento no puede estar vacío.");
            }

            _repo.Instruments.Add(instrument);
            return Ok($"Instrumento agregado: {instrument}");
        }

        /// <summary>
        /// Actualiza un instrumento por índice.
        /// </summary>
        /// <param name="index">Índice del instrumento a actualizar.</param>
        /// <param name="newInstrument">Nuevo nombre del instrumento.</param>
        // PUT: api/instruments/{index}
        [HttpPut("{index}")]
        public ActionResult<string> Put(int index, [FromBody] string newInstrument)
        {
            if (index < 0 || index >= _repo.Instruments.Count)
            {
                return NotFound($"Índice {index} fuera de rango.");
            }

            if (string.IsNullOrWhiteSpace(newInstrument))
            {
                return BadRequest("El nombre del instrumento no puede estar vacío.");
            }

            _repo.Instruments[index] = newInstrument;
            return Ok($"Instrumento en posición {index} actualizado a: {newInstrument}");
        }

        /// <summary>
        /// Elimina un instrumento por índice.
        /// </summary>
        /// <param name="index">Índice del instrumento a eliminar.</param>
        // DELETE: api/instruments/{index}
        [HttpDelete("{index}")]
        public ActionResult<string> Delete(int index)
        {
            if (index < 0 || index >= _repo.Instruments.Count)
            {
                return NotFound($"Índice {index} fuera de rango.");
            }

            var removed = _repo.Instruments[index];
            _repo.Instruments.RemoveAt(index);
            return Ok($"Instrumento eliminado: {removed}");
        }
    }
}
