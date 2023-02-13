using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet_Project2
{
    public partial class Employee : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            if(cn.State==ConnectionState.Closed)
            {
                cn.Open();
            }
           
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

       

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "insert tbEmployee values (@eid,@en,@ea,@es)";
            
            cmd.Parameters.AddWithValue("@eid", TextBox1.Text);
            cmd.Parameters.AddWithValue("@en", TextBox2.Text);
            cmd.Parameters.AddWithValue("@ea", TextBox4.Text);
            cmd.Parameters.AddWithValue("@es", TextBox3.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Clear_Record();
            cn.Close();
           
        }
        private void Clear_Record()
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox1.Focus();
        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            Display_Record();
        }
        private void Display_Record()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select * from tbEmployee";
            SqlDataReader dr = cmd.ExecuteReader();

            ListBox1.DataTextField = "e_name";
            ListBox1.DataValueField = "e_id";



            ListBox1.DataSource = dr;
            ListBox1.DataBind();
            dr.Close();
            cmd.Dispose();
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select * from tbEmployee where e_id= @eid";
            cmd.Parameters.AddWithValue("@eid", ListBox1.SelectedValue);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                TextBox1.Text = dr[0].ToString();
                TextBox2.Text = dr["e_name"].ToString();
                TextBox3.Text = dr["e_add"].ToString();
                TextBox4.Text = dr["e_sal"].ToString();
            }
            dr.Close();
            cmd.Dispose();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Update tbEmployee set e_name=@en,e_add=@ea,e_sal=@es where e_id=@eid";
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@eid", TextBox1.Text);
            cmd.Parameters.AddWithValue("@en", TextBox2.Text);
            cmd.Parameters.AddWithValue("@ea", TextBox3.Text);
            cmd.Parameters.AddWithValue("@es", TextBox4.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Display_Record();
            Clear_Record();


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "delete from tbEmployee where e_id=@eid";
            cmd.Parameters.AddWithValue("@eid", TextBox1.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Display_Record();
            Clear_Record();
        }
    }
} 