﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRepaso2
{
    internal class Alquiler
    {
        string nit;
        string placa1;
        DateTime fechaAlquiler;
        DateTime fechaDevolucion;
        int kilometrosRecorridos;

        public string Nit { get => nit; set => nit = value; }
        public string Placa1 { get => placa1; set => placa1 = value; }
        public DateTime FechaAlquiler { get => fechaAlquiler; set => fechaAlquiler = value; }
        public DateTime FechaDevolucion { get => fechaDevolucion; set => fechaDevolucion = value; }
        public int KilometrosRecorridos { get => kilometrosRecorridos; set => kilometrosRecorridos = value; }
    }
}
