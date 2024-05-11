using FoodieFlow.Pgm.SharedKernel.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieFlow.Pgm.Core.Entities
{
    public class Cliente : BaseEntity
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }

}
