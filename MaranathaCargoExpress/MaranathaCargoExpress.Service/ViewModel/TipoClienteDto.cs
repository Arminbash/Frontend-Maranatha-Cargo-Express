using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaranathaCargoExpress.Service.ViewModel
{
    public class TipoClienteDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Tipo de Cliente
        /// </summary>
        public string Tipo { get; set; }
        /// <summary>
        /// Tipo de Cliente
        /// </summary>
       // public int id { get { return Id;} }

        /// <summary>
        /// Estado
        /// </summary>
        public bool Estado { get; set; }
    }
}
