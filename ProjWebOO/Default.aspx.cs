using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proxy;

namespace ProjWebOO
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReloadTable();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            var dog = new Dog()
            {
                Name = txtNome.Text
            };

            if (this.Crud().Insert(dog))
            {
                lblMSG.Text = "Registro Inserido!";
                SaveLog("Registro Inserido!");
                ReloadTable();
            }
            else
            {
                lblMSG.Text = "Erro ao inserir registro!";
                SaveLog("Erro ao inserir registro!");
            }
        }

        private void ReloadTable()
        {
            GVDog.DataSource = this.Crud().Select();
            GVDog.DataBind();
            SaveLog("Consultou Informações");
        }

        private IDogDB Crud()
        {
            return new DogDB();
        }

        private void SaveLog(string msg)
        {
            IMonitore proxy = new Proxy.Proxy(new LogDB());
            proxy.SaveLog(msg);
        }

        private List<Log> GetLogs()
        {
            IMonitore proxy = new Proxy.Proxy(new LogDB());
            return proxy.Select();
        }

        protected void btnLogs_Click(object sender, EventArgs e)
        {
            GVLog.DataSource = GetLogs();
            GVLog.DataBind();
            SaveLog("Consultou Logs");
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            lblMSG.Text = "";
            GVLog.DataSource = null;
            GVLog.DataBind();
            txtNome.Focus();
        }
    }
}