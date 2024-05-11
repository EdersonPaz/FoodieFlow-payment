using FoodieFlow.Pgm.Core.Enum;
using FoodieFlow.Pgm.SharedKernel.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieFlow.Pgm.Core.Entities
{
    public class Produto : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<string> Imagens { get; set; } = new List<string>();
        public List<int> Ingredientes { get; set; } = new List<int>();
        public float Preco { get; set; }
        public EnumCategoria IdCategoria { get; set; }
    }

    public class ProdutoCompleto : Produto
    {
        public List<Imagem> Imagens { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
    }
}
