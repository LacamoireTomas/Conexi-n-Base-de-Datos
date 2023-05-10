using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Conexión_Base_de_Datos
{
    public partial class FrmConectBaseDatos : Form
    {
        //Me deja conectarme a la base
        OleDbConnection miConexionBD;
        // Indica lo que quiero a la base de datos
        OleDbCommand miComandoBD;
        //para leer datos de una tabla o sql
        OleDbDataReader miLectorBD;
        public FrmConectBaseDatos()
        {
            InitializeComponent();
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                miConexionBD = new OleDbConnection();
                miConexionBD.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:/VERDULEROS.mdb";
                miConexionBD.Open();
                lblInfo.Text = "Conexión Establecida";
                lblInfo.BackColor = Color.Green;
            }
            catch (Exception ex)
            {
                lblInfo.Text = "Hubo un Error" + ex.Message + ex.Source ;
                lblInfo.BackColor = Color.Green;
                //throw;
            }


        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            try
            {
                miComandoBD = new OleDbCommand();

                miComandoBD.Connection = miConexionBD;
                miComandoBD.CommandType = CommandType.TableDirect;
                miComandoBD.CommandText = "Productos";
                lblInfo.Text = "Tabla Obtenida";
                lblInfo.BackColor = Color.Green;


                miLectorBD = miComandoBD.ExecuteReader();

                while (miLectorBD.Read())
                {
                    dataGridView1.Rows.Add(miLectorBD[0], miLectorBD[1], miLectorBD[2], miLectorBD[3]);
                }

            }
            catch (Exception error)
            {
                lblInfo.Text="hubo un error" + error.Message + error.Source ;
                lblInfo.BackColor = Color.Red;

               // throw;
            }
            
        }

        private void FrmConectBaseDatos_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
