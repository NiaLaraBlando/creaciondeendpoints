using System.Collections.Generic;

namespace Creación_de_endpoints
{
 public class InstrumentRepository
 {
 public List<string> Instruments { get; }

 public InstrumentRepository()
 {
 Instruments = new List<string> { "Guitarra", "Batería", "Piano" };
 }
 }
}
