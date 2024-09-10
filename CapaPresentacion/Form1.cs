using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapasEntidad; //
using CapaNegocio; //

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        //N_Contacto objNegocio = new N_Contacto();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListarContacto();// load lo primero que se ejecuta 
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            // Verificar si el campo de ID no está vacío
            if (!string.IsNullOrEmpty(textbox1ID.Text))
            {
                // Obtener el ID del contacto a buscar
                int id;
                if (int.TryParse(textbox1ID.Text, out id))
                {
                    // Llamar al método para buscar el contacto por su ID
                    BuscarContactoPorId(id);
                }
                else
                {
                    MessageBox.Show("El ID especificado no es válido. Por favor, ingrese un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese el ID del contacto que desea buscar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {   // limpiar
            textbox1ID.Clear();
            textBox2Nombre.Clear();
            textBox3Fecha.Clear();
            textBox4Hora.Clear();
            textBox5Detalles.Clear();
            textBox6Ubicacion.Clear();
        }

        private void AgendaDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }// ojb instacia de ... 
        E_Contacto objEntida = new E_Contacto();
        N_Contacto objNegocio = new N_Contacto();

        void ListarContacto()
        {
            DataTable dt =  objNegocio.N_listado();
            AgendaDatos.DataSource = dt;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            E_Contacto contacto = new E_Contacto
            {
                Nombre = textBox2Nombre.Text,
                Fecha = textBox3Fecha.Text,
                Hora = textBox4Hora.Text,
                Detalles = textBox5Detalles.Text,
                Ubicacion = textBox6Ubicacion.Text
            };

            objNegocio.N_guardar(contacto);

            ListarContacto();

            LimpiarCampos();
        }
        private void LimpiarCampos() // metodo que me permite limpiar los campos
        {
            textbox1ID.Clear();
            textBox2Nombre.Clear();
            textBox3Fecha.Clear();
            textBox4Hora.Clear();
            textBox5Detalles.Clear();
            textBox6Ubicacion.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textbox1ID.Text);

            E_Contacto contacto = new E_Contacto
            {
                ID = id,
                Nombre = textBox2Nombre.Text,
                Fecha = textBox3Fecha.Text,
                Hora = textBox4Hora.Text,
                Detalles = textBox5Detalles.Text,
                Ubicacion = textBox6Ubicacion.Text
            };

            objNegocio.N_editar(contacto);

            ListarContacto();

            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textbox1ID.Text);

            objNegocio.N_eliminar(id);

            ListarContacto();

            LimpiarCampos();
        }
        private void BuscarContactoPorId(int id)// lo que me permite buscar por id
        {
            // Llamar al método de la capa de negocio para buscar el contacto por su ID
            DataTable dt = objNegocio.N_buscar(id);

            // Verificar si se encontró algún resultado
            if (dt.Rows.Count > 0)
            {
                // Mostrar los datos del contacto encontrado en los campos correspondientes
                textbox1ID.Text = dt.Rows[0]["ID"].ToString();
                textBox2Nombre.Text = dt.Rows[0]["Nombre"].ToString();
                textBox3Fecha.Text = dt.Rows[0]["Fecha"].ToString();
                textBox4Hora.Text = dt.Rows[0]["Hora"].ToString();
                textBox5Detalles.Text = dt.Rows[0]["Detalles"].ToString();
                textBox6Ubicacion.Text = dt.Rows[0]["Ubicacion"].ToString();
            }
            else
            {
                // Limpiar los campos si no se encontró ningún resultado
                LimpiarCampos();
                MessageBox.Show("No se encontró ningún contacto con el ID especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }   
}
