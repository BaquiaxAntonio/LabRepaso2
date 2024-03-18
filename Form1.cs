using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabRepaso2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Vehiculo> vehiculos = new List<Vehiculo>();
        List<Cliente> clientes = new List<Cliente>();
        List<Alquiler> alquileres= new List<Alquiler>();
        List<Reportes> reportes = new List<Reportes>();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void MostrarClientes()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = clientes;
            dataGridView2.Refresh();
        }

        public void Mostrarvehiculos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = vehiculos;
            dataGridView1.Refresh();
        }

        public void MostrarAlquiler()
        {
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = alquileres;
            dataGridView3.Refresh();
        }

        public void MostrarReportes()
        {
            dataGridView4.DataSource = null;
            dataGridView4.DataSource = reportes;
            dataGridView4.Refresh();
        }

        private void MostrarPlacas()
        {
            comboBoxPlaca.DataSource = null;
            comboBoxPlaca.DataSource = vehiculos;
            comboBoxPlaca.DisplayMember = "Placa";
        }
        public void limpiar()
        {
            textBoxPlaca.Text = "";
            textBoxMarca.Text = "";
            textBoxModelo.Text = "";
            textBoxColor.Text = "";
            textBoxPrecioKilometro.Text = "";
        }

        public void limpiar1()
        {
            comboBoxNit.Text = "";
            comboBoxPlaca.Text = "";
            dateTimePickerAlquiler.Text = "";
            dateTimePickerDevolucion.Text = "";
            textBoxKmRecorridos.Text = "";
        }

        private void mostrarMaxKilometraje()
        {
            decimal maxKilometraje = 0;
            string placaMaxKilometraje = "";

            foreach (Alquiler alquiler in alquileres)
            {
                if (alquiler.KilometrosRecorridos > maxKilometraje)
                {
                    maxKilometraje = alquiler.KilometrosRecorridos;
                    placaMaxKilometraje = alquiler.Placa1;
                }
            }

            // Mostrar el máximo kilometraje en la etiqueta
            labelMaxKilometro.Text = "Placa: " + placaMaxKilometraje + " Con: " + maxKilometraje.ToString() + "KM recorridos.";
        }
        public void cargarVehiculo()
        {
            string fileName = "Vehiculo.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            vehiculos.Clear();

            while (reader.Peek() > -1)
            {
                Vehiculo vehiculo = new Vehiculo();
                vehiculo.Placa = reader.ReadLine();
                vehiculo.Marca = reader.ReadLine();
                vehiculo.Modelo = reader.ReadLine();
                vehiculo.Color = reader.ReadLine();
                
                vehiculo.Preciokilometro = Convert.ToInt16(reader.ReadLine());
                vehiculos.Add(vehiculo);
            }
            reader.Close();
            Mostrarvehiculos();
            MostrarPlacas();
        }

        public void cargarCliente()
        {
            string fileName = "Clientes.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Cliente cliente = new Cliente();
                cliente.Nit = reader.ReadLine();
                cliente.Nombre = reader.ReadLine();
                cliente.Dirreccion = reader.ReadLine();
                clientes.Add(cliente);
            }
            reader.Close();
            MostrarClientes();
        }

        public void cargarAlquiler()
        {
            string fileName = "Alquiler.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            alquileres.Clear();

            while (reader.Peek() > -1)
            {
                Alquiler alquiler = new Alquiler ();
                alquiler.Nit = reader.ReadLine();
                alquiler.Placa1 = reader.ReadLine();
                alquiler.FechaAlquiler = Convert.ToDateTime(reader.ReadLine());
                alquiler.FechaDevolucion = Convert.ToDateTime(reader.ReadLine());
                alquiler.KilometrosRecorridos= Convert.ToInt16(reader.ReadLine());
                alquileres.Add(alquiler);
            }
            reader.Close();
            MostrarAlquiler();

        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = new Vehiculo ();
            vehiculo.Placa=textBoxPlaca.Text;
            vehiculo.Marca=textBoxMarca.Text;
            vehiculo.Modelo=textBoxModelo.Text;
            vehiculo.Color=textBoxColor.Text;
            vehiculo.Preciokilometro = Convert.ToInt32(textBoxPrecioKilometro.Text);
            vehiculos.Add(vehiculo);
            string fileName = "Vehiculo.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var auto in vehiculos)
            {
                writer.WriteLine(auto.Placa);
                writer.WriteLine(auto.Marca);
                writer.WriteLine(auto.Modelo);
                writer.WriteLine(auto.Color);
                writer.WriteLine(auto.Preciokilometro);
            }
            writer.Close();

            limpiar();
            MessageBox.Show("auto ingresado");
            cargarVehiculo();

        }

        private void buttonVerDatos_Click(object sender, EventArgs e)
        {
        
        }

        private void textBoxKilometroRecorido_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAlquiler_Click(object sender, EventArgs e)
        {
            Alquiler alquiler = new Alquiler();
            alquiler.Nit=comboBoxNit.Text;
            alquiler.Placa1=comboBoxPlaca.Text;
            alquiler.FechaAlquiler=Convert.ToDateTime(dateTimePickerAlquiler.Text);
            alquiler.FechaAlquiler =Convert.ToDateTime(dateTimePickerDevolucion.Text);
            alquiler.KilometrosRecorridos=Convert.ToInt32(textBoxKmRecorridos.Text);
            alquileres.Add(alquiler);

            string fileName = "Alquiler.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var alquiler1 in alquileres)
            {
                writer.WriteLine(alquiler1.Nit);
                writer.WriteLine(alquiler1.Placa1);
                writer.WriteLine(alquiler1.FechaAlquiler);
                writer.WriteLine(alquiler.FechaDevolucion);
                writer.WriteLine(alquiler1.KilometrosRecorridos);
            }
            writer.Close();

            
            limpiar1();
            MessageBox.Show("Vehiculo alquilado");
            cargarAlquiler();
            
        }

        private void textBoxPlaca1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxNit_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxNit.ValueMember = "nit";
            string nitCliente = Convert.ToString(comboBoxNit.SelectedValue);

            Cliente clienteEncontrado = clientes.Find(c => c.Nit == nitCliente);
            labelCliente.Text = clienteEncontrado.Nombre;

        }

        private void comboBoxPlaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxPlaca.ValueMember = "placa";
            string placaVehiculo = (Convert.ToString(comboBoxPlaca.SelectedValue)).Trim();

            Vehiculo vehiculoEncontrado = vehiculos.Find(c => c.Placa == placaVehiculo);
            if (vehiculoEncontrado != null)
            {
                labelDatosVehiculo.Text = vehiculoEncontrado.Marca + ", " + vehiculoEncontrado.Modelo + ", " + vehiculoEncontrado.Color;
            }

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            cargarCliente();

            comboBoxNit.DataSource = clientes;
            comboBoxNit.DisplayMember = "nit";

            comboBoxPlaca.DataSource = vehiculos;
            comboBoxPlaca.DisplayMember = "placa";

            comboBoxNit.Text = "";
            comboBoxPlaca.Text = "";
            labelCliente.Text = "...";
            labelDatosVehiculo.Text = "...";

        }

        private void adjuntarReporte()
        {
            foreach (Alquiler alquiler in alquileres)
            {
                Cliente cliente = clientes.Find(c => c.Nit == alquiler.Nit);
                Vehiculo vehiculo = vehiculos.Find(v => v.Placa == alquiler.Placa1);

                Reportes reporte = new Reportes();
                reporte.NombreCliente = cliente.Nombre;
                reporte.Placa = vehiculo.Placa;
                reporte.Marca = vehiculo.Marca;
                reporte.Modelo = vehiculo.Modelo;
                reporte.Fechadevolucion = alquiler.FechaDevolucion;
                reporte.Totalpagar = (vehiculo.Preciokilometro) * alquiler.KilometrosRecorridos;
                reportes.Add(reporte);
            }
            MostrarReportes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adjuntarReporte();
            mostrarMaxKilometraje();
            //int mayor = alquileres.Max(a => a.KilometrosRecorridos);
            //labelMax.Text = Convert.ToString(mayor);
        }
    }
}
