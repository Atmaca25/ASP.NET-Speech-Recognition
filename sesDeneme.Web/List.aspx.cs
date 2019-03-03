using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sesDeneme.Web
{
    public partial class List : System.Web.UI.Page
    {
        SesProjeDbEntities listContext = new SesProjeDbEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()
        {

            List<Command> commandList = listContext.Commands.ToList();
            int sütunSayisi = 6, satirSayisi = commandList.Count;
            for (int i = 0; i < satirSayisi; i++)
            {
                TableRow satir = new TableRow();

                for (int j = 0; j < sütunSayisi; j++)
                {
                    TableCell sutun = new TableCell();
                    if (j == 0)
                    {
                        sutun.Text = commandList[i].commandId.ToString();
                    }
                    else if (j == 1)
                    {
                        sutun.Text = commandList[i].command1.ToString();
                    }
                    else if (j == 2)
                    {
                        if (commandList[i].response != null)
                        {
                            sutun.Text = commandList[i].response.ToString();
                        }
                        else
                        {
                            sutun.Text = "NULL";
                        }

                    }
                    else if (j == 3)
                    {
                        if (commandList[i].action != null)
                        {
                            sutun.Text = commandList[i].action.ToString();
                        }
                        else
                        {
                            sutun.Text = "NULL";
                        }

                    }
                    else if (j == 4)
                    {
                        sutun.Text = commandList[i].speak.ToString();
                    }
                    else if (j == 5)
                    {
                         sutun.Text = "<a href=" + '"'+ "Edit.aspx?id="+commandList[i].commandId.ToString() +'"'+">Edit</a>";
                        //sutun.Text = "<p>Deneme</p>";
                    }
                    //sutun.Text = "Sütuuuun " + i + "-" + j;
                    //sutun.BorderStyle = BorderStyle.Solid;
                    sutun.BorderStyle = BorderStyle.Solid;
                    sutun.Width= Unit.Pixel(160);
                    sutun.BorderColor = System.Drawing.Color.White;
                    sutun.BorderWidth = Unit.Pixel(1);
                    satir.Cells.Add(sutun);
                }
                Table1.Rows.Add(satir);

            }
        }

        protected void btnYeni_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx");
        }

        protected void btnGeri_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}