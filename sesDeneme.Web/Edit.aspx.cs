using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sesDeneme.Web
{
    public abstract partial class Edit : System.Web.UI.Page
    {
        SesProjeDbEntities listContext = new SesProjeDbEntities();
         
        protected void Page_Load(object sender, EventArgs e)
        {
            lblResponse.Width = 80;
            lblAction.Width = 80;
            lblCommand.Width = 80;
            List<Command> commandList = listContext.Commands.ToList();
            if (Request.QueryString["id"] != null)
            {
                if (txtCommand.Text == "")
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    btnEdit.Text = "Güncelle";
                    Getir(id);
                    btnSil.Visible = true;
                }
            }
            else
            {
                btnEdit.Text = "Kayıt";
            }
        }

        private  void Guncelle(int no)
        {

            if (txtResponse.Text != null || txtAction.Text != null || txtCommand.Text != null)
            {
                Command gelen = listContext.Commands.Where(s => s.commandId == no).Single();
                gelen.command1 = txtCommand.Text;
                gelen.response = txtResponse.Text;
                gelen.action = txtAction.Text.ToString();
                bool deneme = Convert.ToBoolean(RadioButtonList1.SelectedItem.Value);
                gelen.speak = deneme;
                listContext.Entry(gelen).State = EntityState.Modified;
                listContext.SaveChanges();
                Response.Redirect("List.aspx");
            }
            else
            {
                lblControl.Text = "ALANLAR BOŞ BIRAKILAMAZ !";
            }

        }

        private void Getir(int no)
        {
            Command gelen = listContext.Commands.Where(s => s.commandId == no).Single();
            txtCommand.Text = gelen.command1.ToString();
            if (gelen.response != null)
            {
                txtResponse.Text = gelen.response.ToString();
            }
            else
            {
                txtResponse.Text = "NULL";
            }

            if (gelen.action != null)
            {
                txtAction.Text = gelen.action.ToString();
            }
            else
            {
                txtAction.Text = "NULL";
            }
           
            if (gelen.speak == true)
            {
                RadioButtonList1.SelectedIndex = 0;
            }
            else
            {
                RadioButtonList1.SelectedIndex = 1;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text.ToString() == "Güncelle")
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Guncelle(id);
            }
            else if (btnEdit.Text.ToString() == "Kayıt")
            {
                Kaydet();
            }
        }

        private void Kaydet()
        {
            Command yeni = new Command();
            yeni.command1 = txtCommand.Text.ToString();
            yeni.response = txtResponse.Text.ToString();
            yeni.action = txtAction.Text.ToString();
            bool deneme = Convert.ToBoolean(RadioButtonList1.SelectedItem.Value);
            yeni.speak = deneme;
            listContext.Entry(yeni).State = EntityState.Added;
            listContext.SaveChanges();
            Response.Redirect("List.aspx");
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            var gelen = listContext.Commands.Find(id);
            listContext.Entry(gelen).State = EntityState.Deleted;
            Response.Redirect("List.aspx");
        }
    }
}