
using datos;
using logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trabajopor3capas
{
    public partial class FormPlanilla : Form
    {
        CtrlPresentacion ctrlPresentacion = new CtrlPresentacion();
        CtrlEmpleados ctrlEmpleados = new CtrlEmpleados();
        List<string> relleno = new List<string>();
        int fondo = 1;
        Button btn = new Button();
       
        public FormPlanilla(int fondo=1,int id=0,string eli=null)
        {
            this.fondo = fondo;

            InitializeComponent();
            ctrlPresentacion.definir(id, eli);
            setColor();
            if (id >= 1) 
            {
               
                this.rellenar(ctrlPresentacion.rellenar(id));
                
            }
           
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (llenos())
                {
                    if (true)
                    {
                        var confirmResult = MessageBox.Show(ctrlEmpleados.buscar(ctrlPresentacion.id).ToString(),
                                "CONFIRMAR",
                                MessageBoxButtons.YesNo);
                        if (confirmResult == DialogResult.Yes)
                        {

                            ctrlPresentacion.accion(txtApellido.Text, txtCuilt.Text, txtDni.Text, txtDomicilio.Text, txtEmail.Text, txtLegajo.Text, txtNombre.Text, txtPuesto.Text, txtTelefono.Text);
                            this.Close();


                        }
                    }
                    else
                    {
                        var confirmResult = MessageBox.Show("Esta Seguro?",
                                "CONFIRMAR",
                                MessageBoxButtons.YesNo);
                        if (confirmResult == DialogResult.Yes)
                        {

                            ctrlPresentacion.accion(txtApellido.Text, txtCuilt.Text, txtDni.Text, txtDomicilio.Text, txtEmail.Text, txtLegajo.Text, txtNombre.Text, txtPuesto.Text, txtTelefono.Text);
                            this.Close();


                        }
                    }
                   
                 
                }
                else
                {
                    MessageBox.Show("Falta rellenar algun campo");
                }



            }
            catch (Exception)
            {

                MessageBox.Show("Ha ingresado un dato de formato incorrecto");
                    
            }
            
        }

        private void FormPlanilla_Load(object sender, EventArgs e)
        {
          
            
            lblId.Visible = ctrlPresentacion.idvisible;
            txtId.Visible= ctrlPresentacion.idvisible;
            txtApellido.ReadOnly = ctrlPresentacion.readOnly;
            txtCuilt.ReadOnly = ctrlPresentacion.readOnly;
            txtDni.ReadOnly = ctrlPresentacion.readOnly;
            txtDomicilio.ReadOnly = ctrlPresentacion.readOnly;
            txtEmail.ReadOnly = ctrlPresentacion.readOnly;
            txtLegajo.ReadOnly = ctrlPresentacion.readOnly;
            txtNombre.ReadOnly = ctrlPresentacion.readOnly;
            txtPuesto.ReadOnly = ctrlPresentacion.readOnly;
            txtTelefono.ReadOnly = ctrlPresentacion.readOnly;

        }
        private void rellenar(List<string> relleno)
        {
            
            txtId.Text = relleno[0];
            txtNombre.Text = relleno[1];
            txtApellido.Text = relleno[2];
            txtEmail.Text = relleno[3];
            txtPuesto.Text = relleno[4];
            txtCuilt.Text = relleno[5];
            txtDni.Text = relleno[6];
            txtDomicilio.Text = relleno[7];
            txtLegajo.Text = relleno[8];
            txtTelefono.Text = relleno[9];
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           
                this.Close();
          
        }
        private bool llenos()
        {
            bool llenos = true;
            foreach (Control item in this.Controls)
            {
                if (item.Tag.ToString()=="campo")
                {
                    if (item.Text=="")
                    {
                        llenos = false;
                    }
                }
            }

            return llenos;

        }

        #region drag 

        private bool mouseDown;
        private Point lastLocation;

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        #endregion

      
        #region Colores y temas

       private void setColor() 
        {
            if (fondo == 1)
            {

                this.BackgroundImage = trabajopor3capas.Properties.Resources.fondo_ag_1;
                btnConfirmar.BackgroundImage= trabajopor3capas.Properties.Resources.btn_1_claro;
                if (ctrlPresentacion.id >= 1)
                {
                    this.BackgroundImage = trabajopor3capas.Properties.Resources.fondo_mod_1;
                    if (ctrlPresentacion.readOnly)
                    {
                        this.BackgroundImage = trabajopor3capas.Properties.Resources.fondo_eli_1;
                    }
                }

            }
            else
            {
                foreach (Control item in this.Controls)
                {
                    if (item.Tag == "campo")
                    {
                        item.ForeColor = Color.White;
                        if (ctrlPresentacion.readOnly)
                        {
                            item.BackColor = Color.SlateGray;
                            
                        }
                        else
                        {
                            item.BackColor = Color.CornflowerBlue;
                        }
                    }
                }
                   
                    txtId.ForeColor = Color.White;
                    txtId.BackColor = Color.SlateGray;
                    
                btnConfirmar.BackgroundImage = trabajopor3capas.Properties.Resources.btn_1_oscuro;
                btnConfirmar.ForeColor = Color.Black;
                this.BackgroundImage = trabajopor3capas.Properties.Resources.fondo_ag_2;
                if (ctrlPresentacion.id >= 1)
                {
                    this.BackgroundImage = trabajopor3capas.Properties.Resources.fondo_mod_2;
                    if (ctrlPresentacion.readOnly)
                    {
                        this.BackgroundImage = trabajopor3capas.Properties.Resources.fondo_eli_2;
                    }
                }
            }

        }

        private void btnAgregar_MouseEnter(object sender, EventArgs e)
        {
            btn = sender as Button;
            if (fondo == 1)
            {
                btn.BackgroundImage = trabajopor3capas.Properties.Resources.btn_2_claro;
            }
            else
            {
                btn.BackgroundImage = trabajopor3capas.Properties.Resources.btn_2_oscuro;
            }


        }

        private void btnAgregar_MouseLeave(object sender, EventArgs e)
        {
            btn = sender as Button;
            if (fondo == 1)
            {
                btn.BackgroundImage = trabajopor3capas.Properties.Resources.btn_1_claro;
            }
            else
            {
                btn.BackgroundImage = trabajopor3capas.Properties.Resources.btn_1_oscuro;
            }

        }

        private void btnSalir_MouseEnter(object sender, EventArgs e)
        {
            btn = sender as Button;
            btn.BackgroundImage = trabajopor3capas.Properties.Resources.btn_cerrar_2;
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            btn = sender as Button;
            btn.BackgroundImage = trabajopor3capas.Properties.Resources.btn_cerrar_1;
        }
        #endregion
    }
}
