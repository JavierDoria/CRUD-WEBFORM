using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CRUD.EntityLayer;
using CRUD.BusinessLayer;
using System.Globalization;
using Microsoft.Ajax.Utilities;

namespace crud.webform
{
    public partial class Contact : Page
    {
        private static int idEmpleado = 0;
        DepartamentoBL departamentoBL = new DepartamentoBL();
        EmpleadoBL empleadoBL = new EmpleadoBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["idEmpleado"] != null)
                {
                    idEmpleado = Convert.ToInt32(Request.QueryString["idEmpleado"].ToString());

                    if (idEmpleado != 0)
                    {
                        lblTitulo.Text = "Editar Empleado";
                        btnSubmit.Text = "Actualizar";

                        Empleado empleado = empleadoBL.obtener(idEmpleado);
                        txtNombreCompleto.Text = empleado.NombreCompleto;
                        CargarDepartamento(empleado.Departamento.IdDepartamento.ToString());
                        txtSueldo.Text = empleado.sueldo.ToString();
                        txtFechaContrato.Text = Convert.ToDateTime(empleado.FechaContrato, new CultureInfo("es-PE")).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        lblTitulo.Text = "Nuevo Empleado";
                        btnSubmit.Text = "Guardar";
                        CargarDepartamento();
                    }
                }
                else Response.Redirect("~/Default.aspx");
            }
        }
        private void CargarDepartamento(string idDepartamento = "")
        {
            List<Departamento> lista = departamentoBL.Lista();
            ddlDepartamento.DataTextField = "Nombre";
            ddlDepartamento.DataValueField = "idDepartamento";

            ddlDepartamento.DataSource = lista;
            ddlDepartamento.DataBind();
            if (idDepartamento != "")
                ddlDepartamento.SelectedValue = idDepartamento;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Empleado entidad = new Empleado()
            {
                IdEmpleado = idEmpleado,
                NombreCompleto = txtNombreCompleto.Text,
                Departamento = new Departamento() { IdDepartamento = Convert.ToInt32(ddlDepartamento.SelectedValue) },
                sueldo = Convert.ToDecimal(txtSueldo.Text, new CultureInfo("es-PE")),
                FechaContrato = txtFechaContrato.Text
            };
            bool respuesta;
            if (idEmpleado != 0)
                respuesta = empleadoBL.editar(entidad);
            else respuesta = empleadoBL.crear(entidad);
            if (respuesta) Response.Redirect("~/Default.aspx");
            else ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se puede realizar la operacion'", true);
        }
    }
}