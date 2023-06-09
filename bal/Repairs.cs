using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bal
{
    public partial class Repairs : Form
    {
        Functions Con;

        public Repairs()
        {
            InitializeComponent();
            Con = new Functions();
            ShowRepairs();
            GetCustomer();
            GetSpare();


        }
        private void GetCost()
        {
            string Query = "select * from SpareTb1 where SpCode={0}";
            Query = string.Format(Query, SpareCb.SelectedValue.ToString());
            foreach (DataRow dr in Con.GetData(Query).Rows)
            {
                SpareCostTb.Text = dr["SpCost"].ToString();

            }
            //MessageBox.Show("Hello");

        }
        private void GetCustomer()
        {
            string Query = " Select * from CustomerTb1";
            CustCb.DisplayMember = Con.GetData(Query).Columns["CustName"].ToString();
            CustCb.ValueMember = Con.GetData(Query).Columns["CustCode"].ToString();
            CustCb.DataSource = Con.GetData(Query);


        }


        private void GetSpare()
        {
            string Query = " Select * from SpareTb1";
           SpareCb.DisplayMember = Con.GetData(Query).Columns["SpName"].ToString();
            SpareCb.ValueMember = Con.GetData(Query).Columns["SpCode"].ToString();
            SpareCb.DataSource = Con.GetData(Query);


        }
        private void ShowRepairs()
        {
            string Query = "select * from RepairTb1";
            RepairsList.DataSource = Con.GetData(Query);
        }
        private void Repairs_Load(object sender, EventArgs e)
        {



        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CustCb.Text == "" || PhoneTb.Text == "" || DNameTb.Text == "" ||ModelTb.Text==""||ProblemTb.Text==""||SpareCb.SelectedIndex == -1||SpareCostTb.Text==""||TotalTb.Text=="")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string RDate = RepDateTb.Value.Date.ToString();
                    int Customer = Convert.ToInt32(CustCb.SelectedValue.ToString());
                    string CPhone = ProblemTb.Text;
                    string DeviceName = DNameTb.Text;
                    string DeviceModel= ModelTb.Text;
                    string Problem= ProblemTb.Text;
                    int Spare = Convert.ToInt32(SpareCb.SelectedValue.ToString());
                    int Total = Convert.ToInt32(TotalTb.Text);
                    //object sparesCostTb = null;
                    int GrdTotal = Convert.ToInt32(SpareCostTb.Text) + Total;
                    string Query = "insert into RepairTb1 values('{0}',{1},'{2}','{3}','{4}','{5}',{6},{7})";
                    Query = string.Format(Query, RDate, Customer, CPhone,DeviceName,DeviceModel,Problem,Spare,GrdTotal);
                    Con.setData(Query);
                    MessageBox.Show("Repair Added!!!");
                    ShowRepairs();
                   



                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }
        int Key = 0;

        private void RepairsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Key = Convert.ToInt32(RepairsList.SelectedRows[0].Cells[0].Value.ToString());

        }

        private void SpareCb_Select(object sender, EventArgs e)
        {

        }

        private void SpareCostTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void SpareCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCost();

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key==0)
            {
                MessageBox.Show("Select a Repair!!!");
            }
            else
            {
                try
                {
                    
                    string Query = "delete from RepairTb1 where RepCode= {0}";
                    Query = string.Format(Query,Key);
                    Con.setData(Query);
                    MessageBox.Show("Repair Deleted!!!");
                    ShowRepairs();




                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            spares Obj = new spares();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
