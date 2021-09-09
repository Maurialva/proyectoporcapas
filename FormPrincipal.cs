
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
    public partial class FormPrincipal : Form
    {
        CtrlPresentacion ctrlPresentacion = new CtrlPresentacion();
        int fondo = 1;
        Button btn = new Button();
        public FormPrincipal()
        {
            InitializeComponent();
            dataGrid.ColumnCount = 10;
            dataGrid.Columns[0].Name = "Id";
            dataGrid.Columns[1].Name = "Nombre";
            dataGrid.Columns[2].Name = "Apellido";
            dataGrid.Columns[3].Name = "Puesto";
            dataGrid.Columns[4].Name = "Email";
            dataGrid.Columns[5].Name = "Cuil";
            dataGrid.Columns[6].Name = "Dni";
            dataGrid.Columns[7].Name = "Domicilio";
            dataGrid.Columns[8].Name = "Legajo";
            dataGrid.Columns[9].Name = "Telefono";
            ctrlPresentacion.actualizarMain(this.dataGrid);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormPlanilla op = new FormPlanilla(fondo);
            op.ShowDialog(); 
            this.ctrlPresentacion.actualizarMain(this.dataGrid);
        }
        
        private void btnModificar_Click(object sender, EventArgs e)
        {
            FormPlanilla op = new FormPlanilla(fondo,Convert.ToInt32(dataGrid.SelectedCells[0].Value));
            op.ShowDialog();
            ctrlPresentacion.actualizarMain(dataGrid);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FormPlanilla op = new FormPlanilla(fondo,Convert.ToInt32(dataGrid.SelectedCells[0].Value),"eliminar");
            op.ShowDialog(); 
            ctrlPresentacion.actualizarMain(dataGrid);
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("CERRAR PROGRAMA",
                                    "Salir?",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this.Close();
            }

        }

        #region Colores y temas

        private void btnModo_Click(object sender, EventArgs e)
        {
            if (fondo == 1)
            {
                this.BackgroundImage = trabajopor3capas.Properties.Resources.fondo_1_oscuro;
                btnAgregar.BackgroundImage = trabajopor3capas.Properties.Resources.btn_1_oscuro;
                btnEliminar.BackgroundImage = trabajopor3capas.Properties.Resources.btn_1_oscuro;
                btnModificar.BackgroundImage = trabajopor3capas.Properties.Resources.btn_1_oscuro;
                btnModo.BackgroundImage = trabajopor3capas.Properties.Resources.btn_1_oscuro;

                btnAgregar.ForeColor = Color.Black;
                btnEliminar.ForeColor = Color.Black;
                btnModificar.ForeColor = Color.Black;
                btnModo.ForeColor = Color.Black;
                dataGrid.BackgroundColor = Color.SlateGray;
                fondo = 2;
                btnModo.Text = "Modo Claro";
                dataGrid.DefaultCellStyle.BackColor = Color.SlateGray;
                dataGrid.DefaultCellStyle.ForeColor = Color.White;
                dataGrid.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
                dataGrid.DefaultCellStyle.SelectionForeColor = Color.White;

            }
            else
            {
                this.BackgroundImage = trabajopor3capas.Properties.Resources.fondo_1_claro;
                btnAgregar.BackgroundImage = trabajopor3capas.Properties.Resources.btn_1_claro;
                btnEliminar.BackgroundImage = trabajopor3capas.Properties.Resources.btn_1_claro;
                btnModificar.BackgroundImage = trabajopor3capas.Properties.Resources.btn_1_claro;
                btnModo.BackgroundImage = trabajopor3capas.Properties.Resources.btn_1_claro;
                fondo = 1;
                btnAgregar.ForeColor = Color.White;
                btnEliminar.ForeColor = Color.White;
                btnModificar.ForeColor = Color.White;
                btnModo.ForeColor = Color.White;
                btnModo.Text = "Modo Oscuro";
                dataGrid.BackgroundColor = Color.LightSteelBlue;
                dataGrid.DefaultCellStyle.BackColor= Color.CornflowerBlue;
                dataGrid.DefaultCellStyle.ForeColor = Color.White;
                dataGrid.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                dataGrid.DefaultCellStyle.SelectionForeColor = Color.White;
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


    }
}
