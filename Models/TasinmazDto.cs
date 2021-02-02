using System.Collections.Generic;
using Tasinmaz.Entities;

namespace Tasinmaz.Models
{
    public class TasinmazDto
    {
        public int Id { get; set; }
        public List<Il> Il { get; set; }
        public List<Ilce> Ilce { get; set; }
        public List<Mahalle> Mahalle { get; set; }
    }
}