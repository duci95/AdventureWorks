using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IL17DusanKrsmanovic2816.BusinessLayer;

namespace IL17DusanKrsmanovic2816
{
    public partial class Form1 : Form
    {
        private Logic logic = new Logic();
        public Form1()
        {
            InitializeComponent();
            this.comboBox1.DataSource = this.logic.getEmployee();
            this.comboBox1.ValueMember = "ID";
            this.comboBox1.DisplayMember = "ImePrezime";
            this.comboBox1.SelectedIndex = -1;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;


            this.comboBox2.DataSource = this.logic.getInfo();
            this.comboBox2.ValueMember = "ID";
            this.comboBox2.DisplayMember = "ImePrezime";
            this.comboBox2.SelectedIndex = -1;
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;


            this.dataGridView1.Columns.Add("Posao", "Posao");
            this.dataGridView1.Columns.Add("DatumZaposlenja", "Datum zaposlenja");
            this.dataGridView1.Columns.Add("Rata", "Rata");
            this.dataGridView1.Columns.Add("UčestalostIsplate", "Isplata");
            this.dataGridView1.Columns.Add("ImeOdeljenja", "Ime odeljenja");
            this.dataGridView1.Columns.Add("ImeGrupe", "Ime grupe");
            this.dataGridView1.Columns.Add("Odmor", "Odmor");
            this.dataGridView1.Columns.Add("Bolovanje", "Bolovanje");


            this.dataGridView2.Columns.Add("Ime", "Ime");
            this.dataGridView2.Columns.Add("Prezime", "Prezime");
            this.dataGridView2.Columns.Add("KreditnaKartica", "Kartica");
            this.dataGridView2.Columns.Add("TipKartice", "Tip kartice");

            this.dataGridView3.Columns.Add("Store", "Prodavnica");
            this.dataGridView3.Columns.Add("Demografija", "Demografija");

            ColumnHeader heder = new ColumnHeader();
            heder = this.listView1.Columns.Add("Telefon",40,HorizontalAlignment.Left);
            heder = this.listView1.Columns.Add("Tip telefona",40,HorizontalAlignment.Right);
            heder = this.listView1.Columns.Add("Email",50,HorizontalAlignment.Center);
            heder = this.listView1.Columns.Add("Smena");
            heder = this.listView1.Columns.Add("Početak");
            heder = this.listView1.Columns.Add("Kraj");

            heder = this.listView2.Columns.Add("Kreditna kartica", 40, HorizontalAlignment.Left);
            heder = this.listView2.Columns.Add("Broj kreditne kartice", 40, HorizontalAlignment.Right);
            
            if(this.comboBox1.SelectedIndex == -1)
            {
                List<CustomerInfoCredit> list = this.logic.getCreditAll();
                this.listView2.Items.Clear();
                this.listView2.BeginUpdate();
                foreach (CustomerInfoCredit x in list)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = x.KreditnaKartica;
                    item.SubItems.Add(x.TipKartice);
                    this.listView2.Items.Add(item);
                }
                this.listView2.EndUpdate();
                
            }




            if (this.comboBox1.SelectedIndex == -1) //ukoliko nijedan nije selektovan ispiujemo sve informacije o zaposlenima u datagridviewu 
            {
                List<EmpInfoPlus> list = this.logic.getEmpInfoPlus();
                this.dataGridView1.Rows.Clear();
                foreach (EmpInfoPlus x in list)
                {
                    int indeks = this.dataGridView1.Rows.Add(x.Posao, x.DatumZaposlenja, x.Rata, x.UčestalostIsplate, x.ImeOdeljenja, x.ImeGrupe, x.Odmor, x.Bolovanje);
                    this.dataGridView1.Rows[indeks].Tag = x.ID;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            object obj = this.comboBox1.SelectedValue;
            if(obj is int && obj != null)
            {
                id = (int)obj;
            }
            List<EmpInfoPlus> list = this.logic.getEmpInfoPlus(id);
            this.dataGridView1.Rows.Clear();
            foreach(EmpInfoPlus x in list)
            {
                int indeks = this.dataGridView1.Rows.Add(x.Posao, x.DatumZaposlenja, x.Rata, x.UčestalostIsplate, x.ImeOdeljenja, x.ImeGrupe, x.Odmor, x.Bolovanje);
                this.dataGridView1.Rows[indeks].Tag = x.ID;
            } 
        }

        private void selectionChanged(object sender, EventArgs e)
        {
            int id = 0;
            object obj = this.dataGridView1.CurrentRow.Tag;
            if (obj is int && obj != null)
            {
                id = (int)obj;
            }
            List<EmpInfoJob> list = this.logic.getEmpInfoJob(id);
            this.listView1.Items.Clear();
            this.listView1.BeginUpdate();
            foreach(EmpInfoJob x in list)
            {
                ListViewItem item = new ListViewItem();
                item.Text = x.Telefon;
                item.Tag = x.ID;
                item.SubItems.Add(x.TipTelefona);
                item.SubItems.Add(x.Email);
                item.SubItems.Add(x.Smena);
                item.SubItems.Add(x.Početak.ToString());
                item.SubItems.Add(x.Kraj.ToString());
                this.listView1.Items.Add(item);
            }
            this.listView1.EndUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<CustomerInfo> list = this.logic.getCustInfo();
            this.dataGridView1.Rows.Clear();
            foreach (CustomerInfo x in list)
            {
                 this.dataGridView2.Rows.Add(x.Ime, x.Prezime, x.KreditnaKartica, x.TipKartice);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            object obj = this.comboBox2.SelectedValue;
            if(obj is int && obj != null)
            {
                id = (int)obj;
            }
            List<CustomerInfoCredit> list = this.logic.getCredit(id);
            this.listView2.Items.Clear();
            this.listView2.BeginUpdate();
            foreach (CustomerInfoCredit x in list)
            {
                ListViewItem item = new ListViewItem();
                item.Text = x.KreditnaKartica;
                item.Tag = x.ID;
                item.SubItems.Add(x.TipKartice);
                this.listView2.Items.Add(item);
            }
            this.listView2.EndUpdate();
             
        }

        private void indexChanged(object sender, EventArgs e)
        {
            int id = 0;
            object obj = this.listView2.SelectedItems[0].Tag;

            if (listView2.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listView2.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                if (obj is int && obj != null)
                {
                    id = (int)obj;
                }
            }

            
            List<CustomerInfoCredit2> list = this.logic.getCrd(id);
            this.dataGridView3.Rows.Clear();
            foreach (CustomerInfoCredit2 item in list)
            {
                int index = this.dataGridView3.Rows.Add(item.Store, item.Demografija);
                this.dataGridView3.Rows[index].Tag = item.ID;
            }
        }
    }
}
