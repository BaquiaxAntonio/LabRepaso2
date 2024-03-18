using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRepaso2
{
    internal class Cliente
    {
        string nombre;
        string nit;
        string dirreccion;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Nit { get => nit; set => nit = value; }
        public string Dirreccion { get => dirreccion; set => dirreccion = value; }
    }
}
