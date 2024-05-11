using FoodieFlow.Pgm.SharedKernel.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieFlow.Pgm.Core.Entities
{
    public class Imagem : BaseEntity
    {
        public string Caminho { get; set; }
        public int IdProduto { get; set; }
    }
}
