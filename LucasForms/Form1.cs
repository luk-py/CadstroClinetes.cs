using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


/*
    PROJETO SIMULANDO UM CADASTRO DE CLIENTES 
    QUE PERMITE CADASTRAR :NOME :IDADE :GENERO
    RETORNANDO UM LISTVIEW COM OS CLIENTES CADASTRADOS EM ORDEM CRESCENTE DE IDADE
    E UM FILTER PRA FILTRAR POR GENERO
 */
namespace LucasForms
{
    public partial class Form1 : Form
    {
        DataTable cls = new DataTable();//INICIALIZANDO UMA BASE DE DADOS
        public Form1()
        {
            InitializeComponent();
            AddTable();//METODO QUE CRIA E ADICIONA OS DADOS DOS NA TABELA CLS
            
        }

        private void AddTable()
        {
            /* 
                ESTE METODO CRIA AS COLUNAS NO DATAGRID 
             */
            cls.Columns.Add("idade", typeof(int));
            cls.Columns.Add("nome", typeof(string));
            cls.Columns.Add("sexo", typeof(string));

            /* 
                LAÇO QUE PERCOERRE A LISTA DO OBJETO CLIENTS 
                E PARA CADA OBJETO PREENCHE OS CAMPOS IDADE NOME E SEXO
            */
            var listClients = Clients.GetListaClients();
            foreach (Clients clientes in listClients)
            {
                cls.Rows.Add(clientes.idade, clientes.nome, clientes.sexo);
            }

            
            dataGridView1.DataSource = cls;
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);//RETORNA A LISTA EM ORDEM POR IDADE

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)   //ENQUANTO UM CHECK BOX1 ESTÁ ATIVO, DESATIVA O OUTRO
        {
            if (((CheckBox)sender).Checked)
            {
                checkBox1.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
            } 

        }

        private void button1_Click(object sender, EventArgs e) //EVENTOS DISPARADOS AO CLICAR EM ADICIONAR
        {
            // ESTE LAÇO PERMITE QUE A VARIAVEL CHECK RECEBA O VALOR NO QUAL O CHECKBOX ESTA MARCADO
            string check;
            
            if (checkBox1.Checked)
            {
                check = checkBox1.Text.ToString();
            }
            else if (checkBox2.Checked)
            {
                check = checkBox2.Text.ToString();
            }
            else
            {
                check = "Genero não selecionado";
            };

            //O DATAGRID VAI RECEBER OS DADOS QUE ESTÃO LISTADOS A BAIXO AO CLICAR EM ADICIONAR
            string[] client =
            {

                textBox2.Text,
                textBox1.Text,
                check
            };
            

            cls.Rows.Add(int.Parse(textBox2.Text), textBox1.Text, check);
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);//RETORNA A LISTA EM ORDEM POR IDADE

            //LIMPA TODOS OS CAMPOS 
            textBox1.Text = "";
            textBox2.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private bool IsNumber(string valor)
        {
            return valor.All(char.IsNumber);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) //ENQUANTO UM CHECK BOX 2 ESTÁ ATIVO, DESATIVA O OUTRO
        {
            if (((CheckBox)sender).Checked)
            {
                checkBox2.Enabled = false;
            }
            else
            {
                checkBox2.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FilterGrid();
        }

        private void FilterGrid() //METODO RESPONSAVEL POR FILTRAR OS DADO DE ACORDO COM O GENERO
        {
            cls.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "sexo", textBox3.Text);
            dataGridView1.DataSource = cls;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_MouseHover(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }



    public class Clients //CLASSE CLIENTES QUE RECEBE O OBJETO CLIENTS
    {
        public string nome { get; set; }
        public int idade { get; set; }
        public string sexo { get; set; }

        public Clients(string nome, int idade, string sexo) 
        {
            this.nome = nome;
            this.idade = idade;
            this.sexo = sexo;
        } 
        public static List<Clients> GetListaClients() //METODO LISTA QUE RECEBE DADOS E INSERE NA TABELA
        {
            var listaClients = new List<Clients>();

            
            //INSERI ALGUNS DADOS PREDEFINIDOS PARA NÃO PRECISAR ADICIONAR TODOS MANUALMENTE 

            listaClients.Add(new Clients("Neymar Junior", 30, "Masculino"));
            listaClients.Add(new Clients("Frenkie de Jong", 25, "Masculino"));
            listaClients.Add(new Clients("Taylor Swift", 32, "Feminino"));
            listaClients.Add(new Clients("Megan Fox", 36, "Feminino"));
            listaClients.Add(new Clients("Jenna Ortega", 19, "Feminino"));


            return listaClients ; 
        }



    }

}
