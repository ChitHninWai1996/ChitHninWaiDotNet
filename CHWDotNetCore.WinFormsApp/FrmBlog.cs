namespace CHWDotNetCore.WinFormsApp
{
    public partial class FrmBlog : Form
    {
        public FrmBlog()
        {
            InitializeComponent();
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hello world.");
        }
    }
}
