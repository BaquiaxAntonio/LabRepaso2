using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRepaso2
{
    internal class Reportes
    {
        string nombreCliente;
        string placa;
        string marca;
        string modelo;
        DateTime fechadevolucion;
        int totalpagar;

        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public DateTime Fechadevolucion { get => fechadevolucion; set => fechadevolucion = value; }
        public int Totalpagar { get => totalpagar; set => totalpagar = value; }
    }
}
