using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Agenda.UIDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtContatoNovo.Text;
            //txtContatoSalvo.Text = nome;

            string strCon = "Host=localhost;Port=5450;Database=pgsqltests;Username=pguser;Password=pgpassword;";
            string id = Guid.NewGuid().ToString();

            NpgsqlConnection conn = new NpgsqlConnection(strCon);
            conn.Open();

            string sql = String.Format("INSERT INTO public.contato (id, nome) VALUES('{0}', '{1}');", id, nome);

            var cmd = new NpgsqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            sql = String.Format("SELECT nome FROM public.contato WHERE id = '{0}';", id);

            cmd = new NpgsqlCommand(sql, conn);

            txtContatoSalvo.Text = cmd.ExecuteScalar().ToString();

            conn.Close();
        }
    }
}
