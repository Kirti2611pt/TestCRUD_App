using System.Data;
using System.Data.SqlClient;


namespace TestCRUD_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-E9NF7I0\\SQLEXPRESS;Initial Catalog=MyTestDB;Integrated Security=True;Pooling=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("Insert into UserTab Values (@ID,@Name,@Age)",con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age",double.Parse(textBox3.Text));
           
            con.Close();
            MessageBox.Show("Successfully Saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-E9NF7I0\\SQLEXPRESS;Initial Catalog=MyTestDB;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update UserTab set Name=@Name,Age=@Age where ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-E9NF7I0\\SQLEXPRESS;Initial Catalog=MyTestDB;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete UserTab where ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID",int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-E9NF7I0\\SQLEXPRESS;Initial Catalog=MyTestDB;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from UserTab where ID=@ID", con);
            cmd.Parameters.AddWithValue("ID",int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}