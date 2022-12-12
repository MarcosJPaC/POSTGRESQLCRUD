using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLSERVERCRUD
{
    public partial class Capitulo : Form
    {
        string consulta;
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPGSQL.ejecutaConsultaSelect("SELECT *FROM Capitulo ORDER BY idCapitulo");
        }

        public Capitulo()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string juego = textBox2.Text;
         

            consulta = "INSERT INTO Capitulo(nombre, juego) values('" + nombre + "', '" + juego +"')";
            ConexionPGSQL.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int identificador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Capitulo SET estatus = False WHERE idCapitulo =  " + identificador.ToString(); ;
            ConexionPGSQL.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string juego = textBox2.Text;

            int identificador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Capitulo SET nombre = '" + nombre + "',juego = '" + juego + "' WHERE idCapitulo = " + identificador.ToString();
            ConexionPGSQL.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cinematica brr = new Cinematica();
            brr.Show();
        }

        private void Capitulo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
}
