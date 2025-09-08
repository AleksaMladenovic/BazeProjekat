using System.Threading.Tasks;

namespace MuzickaSkolaWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void cmdPreuzmiKurs_Click(object sender, EventArgs e)
        {
            ISession? session = null;

            try
            {
                session = DataLayer.GetSession();

                if (session != null)
                {
                    Kurs? k = await session.LoadAsync<Kurs>(4);
                    MessageBox.Show($"Kurs sa ID: 4\"{k.Naziv}\" je pronađena.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            finally
            {
                session?.Close();
            }
        }
    }
}
