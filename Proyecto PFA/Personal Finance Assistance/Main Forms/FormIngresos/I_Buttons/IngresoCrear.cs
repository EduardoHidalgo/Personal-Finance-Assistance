﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal_Finance_Assistance
{
    public partial class IngresoCrear : UserControl
    {
        FormIngresos Ingresos;

        public IngresoCrear(FormIngresos ingresos)
        {
            Ingresos = ingresos;
            InitializeComponent();
            LabelError.Visible = false;
            //LabelError.ForeColor = ColorClass.ColorFondo1;
            ButtonCrear.BackColor = ColorClass.ColorBoton;
            TextboxCrear.BackColor = ColorClass.ColorDecorativo;
            ComboboxClasif.BackColor = ColorClass.ColorDecorativo;
            DateTimeCrear.CalendarTitleBackColor = ColorClass.ColorBoton;
            Actualizar_Combobox();
        }

        public void Actualizar_Combobox()
        {
            ComboboxClasif.Items.Clear();
            for (int I = 0; I <= DB_Storer.T2_Tipo_I.Length - 1; I++) // I - 5
            {
                ComboboxClasif.Items.Add(DB_Storer.T2_Tipo_I[I]);
            }
        }
        public void ButtonMethod()
        {
            DateTime Fecha;
            double Monto;
            int ID_TipoI;
            bool P1, P2, P3;
            if (string.IsNullOrEmpty(TextboxCrear.Text))
            {
                P1 = false;
                LabelError.Text = "Inserte un monto";
                LabelError.Visible = true;
            }
            else
            {
                P1 = true;
            }
            if (ComboboxClasif.SelectedItem == null)
            {
                P2 = false;
                LabelError.Text = "Seleccione una clasificación";
                LabelError.Visible = true;
            }
            else
            {
                P2 = true;
            }
            if (string.IsNullOrEmpty(DateTimeCrear.Text))
            {
                P3 = false;
                LabelError.Text = "Inserte una fecha para el ingreso";
                LabelError.Visible = true;
            }
            else
            {
                P3 = true;
            }
            if ((P1 & P2 & P3) == true)
            {
                try
                {
                    Monto = Convert.ToDouble(TextboxCrear.Text);
                    Fecha = Convert.ToDateTime(DateTimeCrear.Text);
                    string temp = ComboboxClasif.Text;
                    int temp2 = Array.IndexOf(DB_Storer.T2_Tipo_I, temp);
                    ID_TipoI = DB_Storer.T2_ID_tipo_I[temp2];
                    DBclass.Insert_Ingreso(Monto, Fecha, ID_TipoI);
                    TextboxCrear.Clear();
                    ComboboxClasif.ResetText();
                    DateTimeCrear.ResetText();
                    LabelError.Text = "Ingreso insertado";
                    LabelError.Visible = true;
                    Ingresos = (FormIngresos)this.ParentForm;
                    Ingresos.Actualizar_Treeview();
                    Actualizar_Combobox();
                    Ingresos.Actualizar_Stats();
                }
                catch
                {
                    LabelError.Text = "Error, Comuníquese con soporte";
                    LabelError.Visible = true;
                }
            }
            else
            {
                LabelError.Text = "Rellene todos los campos correctamente";
                LabelError.Visible = true;
            }
        }

        private void ButtonCrear_MouseClick(object sender, MouseEventArgs e)
        {
            ButtonMethod();
        }
        private void ButtonCrear_MouseEnter(object sender, EventArgs e)
        {
            ButtonCrear.BackColor = ColorClass.ColorBotonCursado;
        }
        private void ButtonCrear_MouseLeave(object sender, EventArgs e)
        {
            ButtonCrear.BackColor = ColorClass.ColorBoton;
        }
        private void LabelButton_MouseClick(object sender, MouseEventArgs e)
        {
            ButtonMethod();
        }
        private void LabelButton_MouseEnter(object sender, EventArgs e)
        {
            ButtonCrear.BackColor = ColorClass.ColorBotonCursado;
        }
        private void LabelButton_MouseLeave(object sender, EventArgs e)
        {
            ButtonCrear.BackColor = ColorClass.ColorBoton;
        }
    }
}
