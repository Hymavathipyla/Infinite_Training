using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductsAssignment
{
    public partial class ProductsForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.Items.Add(new ListItem("Select Product", "0"));
                DropDownList1.Items.Add(new ListItem("Bag", "Bag"));
                DropDownList1.Items.Add(new ListItem("Toys", "Toys"));
                DropDownList1.Items.Add(new ListItem("Phone", "Phone"));
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Bag")
            {
                Image1.ImageUrl = "https://i5.walmartimages.com/seo/Michael-Kors-Women-s-Jet-Set-Large-East-West-Crossbody-Handbag_2c4a4a49-6818-4173-9122-d9f4fbff8e29.dbf24514e80af5295323560fb746b4b8.jpeg";
            }
            else if (DropDownList1.SelectedValue == "Toys")
            {
                Image1.ImageUrl = "https://static.vecteezy.com/system/resources/thumbnails/033/959/322/small_2x/wooden-children-s-toys-on-the-table-wooden-play-set-generated-by-artificial-intelligence-photo.jpg";
            }
            else if (DropDownList1.SelectedValue == "Phone")
            {
                Image1.ImageUrl = "https://cdn.pixabay.com/photo/2016/10/09/16/33/mobile-1726138_1280.jpg";
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Bag")
            {
                Label1.Text = "Price: ₹15,000";
            }
            else if (DropDownList1.SelectedValue == "Toys")
            {
                Label1.Text = "Price: ₹500";
            }
            else if (DropDownList1.SelectedValue == "Phone")
            {
                Label1.Text = "Price: ₹10,000";
            }
            else
            {
                Label1.Text = "Please select a product";
            }
        }
    }
}
        


    
