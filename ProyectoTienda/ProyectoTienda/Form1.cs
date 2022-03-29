using System.Data;
using System.Data.SqlClient;
namespace ProyectoTienda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        void ClearInformacion()
        {
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtcodigo.Text = "";
            txtdui.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtestado.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Llamaos la clase Conexion para abrir la conexion
            Conexion.Conectar();
            try
            {
                MessageBox.Show("La ha conectado correctamente");
            }
            catch
            {
                MessageBox.Show("Error");
            }

            dGvMostrar.DataSource = MostrarDato();
        }

        public DataTable MostrarDato()
        {
            //Realiamos na consulta a la bd para que nos muestre los registros que deseamos
            
            try
            {
                Conexion.Conectar();
                DataTable dt = new DataTable();
                string consulta = "select codigo, nombreCliente,apellidoCliente,dui,direccion,telefono,estado from  Cliente where estado = 'activo'";
                SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                
                return dt;
            }
            catch
            {
                //Si se encuentra un error nos lo mostrara
                MessageBox.Show("Error");
            }

            return null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dGvMostrar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Aca establecemos la posiciones que a la hora de dar click a datagrid se nos muestre en los campos de texto y
            //se llenen atraves de las posiones y datos que traer
            try
            {
                
                txtcodigo.Text = dGvMostrar.CurrentRow.Cells[0].Value.ToString();
                txtnombre.Text = dGvMostrar.CurrentRow.Cells[1].Value.ToString();
                txtapellido.Text = dGvMostrar.CurrentRow.Cells[2].Value.ToString();
                txtdui.Text = dGvMostrar.CurrentRow.Cells[3].Value.ToString();
                txtdireccion.Text = dGvMostrar.CurrentRow.Cells[4].Value.ToString();
                txttelefono.Text = dGvMostrar.CurrentRow.Cells[5].Value.ToString();
                txtestado.Text = dGvMostrar.CurrentRow.Cells[6].Value.ToString();
                


            }
            catch
            {
                //Si se encuentra un error nos lo mostrara
                MessageBox.Show("Error");
            }
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            //Aca realizamos una consulta para poder actualizar
            //decimos que cuando codigo = async codigo, se establesca la consulta
            try
            {
                Conexion.Conectar();
                string update = "UPDATE Cliente SET nombreCliente=@nombreCliente, apellidoCliente=@apellidoCliente, codigo=@codigo, dui=@dui, direccion=@direccion, telefono=@telefono, estado=@estado  WHERE codigo=@codigo";
                SqlCommand sqlCommand = new SqlCommand(update, Conexion.Conectar());

                sqlCommand.Parameters.AddWithValue("@nombreCliente", txtnombre.Text);
                sqlCommand.Parameters.AddWithValue("@apellidoCliente", txtapellido.Text);
                sqlCommand.Parameters.AddWithValue("@codigo", txtcodigo.Text);
                sqlCommand.Parameters.AddWithValue("@dui", txtdui.Text);
                sqlCommand.Parameters.AddWithValue("@direccion", txtdireccion.Text);
                sqlCommand.Parameters.AddWithValue("@telefono", txttelefono.Text);
                sqlCommand.Parameters.AddWithValue("@estado", txtestado.Text);


                ClearInformacion();
                sqlCommand.ExecuteNonQuery();

                MessageBox.Show("Se ha actualizado correctamente");

                dGvMostrar.DataSource = MostrarDato();

            }
            catch
            {
                // Si se encuentra un error nos lo mostrara
                MessageBox.Show("Error");
            }




        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //realimaos un insert a la bd a traves de parametros donde posisionamos y asiganmos los valores que resiven las cajas de texto
            try
            {
                Conexion.Conectar();
                string insertar = "INSERT INTO Cliente VALUES (@nombreCliente,@apellidoCliente,@codigo,@dui,@direccion,@telefono,@estado)";
                SqlCommand comando = new SqlCommand(insertar, Conexion.Conectar());
                comando.Parameters.AddWithValue("@nombreCliente", txtnombre.Text);
                comando.Parameters.AddWithValue("@apellidoCliente", txtapellido.Text);
                comando.Parameters.AddWithValue("@codigo", txtcodigo.Text);
                comando.Parameters.AddWithValue("@dui", txtdui.Text);
                comando.Parameters.AddWithValue("@direccion", txtdireccion.Text);
                comando.Parameters.AddWithValue("@telefono", txttelefono.Text);
                comando.Parameters.AddWithValue("@estado", txtestado.Text);
                comando.ExecuteNonQuery();
                ClearInformacion();
                MessageBox.Show("Se ha registro correctamente");
                dGvMostrar.DataSource = MostrarDato();
            }
            catch
            {
                // Si se encuentra un error nos lo mostrara
                MessageBox.Show("Error");
            }
            


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}