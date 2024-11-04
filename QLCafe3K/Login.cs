using QLCafe3K.DAO;

namespace QLCafe3K
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassWord.Text;

            if(login(username,password))
            {
                DuLieu d = new DuLieu();
                this.Hide();
                d.ShowDialog();
                this.Show();
            }    
            else
            {
                MessageBox.Show("Thông tin đăng nhập sai!");
            }    
        }

        bool login(string username, string password)
        {
            if (username == "ChuQuan" && password == "ChuQuan123")
            {
                return true;
            } 
            else return false;

        }
    }
}
