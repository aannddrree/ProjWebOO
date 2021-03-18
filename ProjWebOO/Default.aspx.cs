using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjWebOO
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GVDog.DataSource = new DogDB().Select();
            GVDog.DataBind();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            var dog = new Dog()
            {
                Name = txtNome.Text
            };

            new DogDB().Insert(dog);

            lblMSG.Text = "Registro Inserido!";
        }
    }
}