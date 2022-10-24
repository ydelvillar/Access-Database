using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;//Agregamos esta libreria.

namespace Access_Database
{
    public partial class Form1 : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Alumno\Downloads\DbPersona.accdb");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }
        void LlenarGrid()
        {
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from TablaPersona order by Id", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);//LLena la tabla con los datos
            dataGridView1.DataSource = dt;//GridView = Cuadro gris de la pestaña
            conn.Close();//Cierra la base de datos
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into TablaPersona(Nombre,Edad)values('" + txtNombre.Text + "'," + txtEdad.Text + ")", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Registro exitosamente guardado");
            //LimpiarTexto();
            LlenarGrid();
        }
    }
}
