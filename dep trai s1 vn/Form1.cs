using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Security.Policy;

namespace dep_trai_s1_vn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btncalculate_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtname.Text.Trim();
                string typecustomer = cbcustomertype.Text.Trim();
                string member = txtmember.Text.Trim();
                string lastmonth = txtlastmonth.Text.Trim();
                int lastMonth = int.Parse(txtlastmonth.Text.Trim());
                string currentmonth = txtcurrentmonth.Text.Trim();
                int thisMonth = int.Parse(txtcurrentmonth.Text.Trim());
                double money = 0;
                double usedWater = int.Parse(currentmonth) - int.Parse(lastmonth);

                if (typecustomer == "Household")
                {
                    try
                    {
                        string fammem = txtmember.Text.Trim();
                        int temfam = int.Parse(fammem);
                    }
                    catch
                    {
                        MessageBox.Show("Family member must be a number","warning",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (!int.TryParse(lastmonth, out _))
                    {
                        MessageBox.Show("Last month index must be a number ", "Thong bao");
                        return;
                    }
                    else if (!int.TryParse(currentmonth, out _))
                    {
                        MessageBox.Show("This month index must be a number ", "Thong bao");
                        return;
                    }
                    else if (!int.TryParse(member, out _))
                    {
                        MessageBox.Show("Member must be a number", "Thong bao");
                        return;
                    }
                    else if (int.Parse(member) < 1)
                    {
                        MessageBox.Show("Family member must be greater than 1", "Thong bao");
                        return;
                    }
                    else if (int.Parse(currentmonth) - int.Parse(lastmonth) < 0 || int.Parse(lastmonth) < 0 || int.Parse(currentmonth) < 0)
                    {
                        MessageBox.Show("Current must be greater than that last month ");
                        return;
                    }

                    else
                    {
                        double memberUsedWater = usedWater / int.Parse(member);
                        if (memberUsedWater >= 0 && memberUsedWater < 10)
                        {
                            //money = 100%
                            money = usedWater * 5973 * 1.1;
                            txtResult.Text = Convert.ToString(money);
                        }
                        else if (memberUsedWater > 10 && memberUsedWater <= 20)
                        {
                            money = usedWater * 7052 * 1.1;
                            txtResult.Text = Convert.ToString(money);

                        }
                        else if (memberUsedWater > 20 && memberUsedWater <= 30)
                        {
                            money = usedWater * 8699 * 1.1;
                            txtResult.Text = Convert.ToString(money);

                        }
                        else
                        {
                            money = usedWater * 15929 * 1.1;
                            txtResult.Text = Convert.ToString(money);

                        }
                    }
                                   }

                // dich vu cong dng
                else if (typecustomer == "Public Services")
                {
                    if (thisMonth > lastMonth) 
                    {
                        money = usedWater * 9955 * 1.1;
                        txtResult.Text = Convert.ToString(money);
                    }
                    else
                    {
                        MessageBox.Show("Current must be greater than that last month ");
                    }



                }
                //day la don vi sx
                else if (typecustomer == "Production Units")
                {
                    if (thisMonth > lastMonth)
                    {
                        money = usedWater * 11615 * 1.1;
                        txtResult.Text = Convert.ToString(money);
                    }
                    else
                    {
                        MessageBox.Show("Current must be greater than that last month ");
                    }


                }
                //neu la business
                else if (typecustomer == "Business Services")
                    if (thisMonth > lastMonth)
                    {
                        money = usedWater * 22068 * 1.1;
                        txtResult.Text = Convert.ToString(money);
                    }
                    else
                    {
                        MessageBox.Show("Current must be greater than that last month ");
                    }
                btnAdd.Enabled = true;
            }
            catch 
            {
                MessageBox.Show("Enter information to calculate", "Thong bao");
                return;
            }
           
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnclear_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtmember.Clear();
            txtlastmonth.Clear();
            txtcurrentmonth.Clear();
            txtResult.Clear();
        }
        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    string name = txtname.Text.Trim();
                    string typecustomer = cbcustomertype.Text.Trim();
                    string member = txtmember.Text.Trim();
                    string lastmonth = txtlastmonth.Text.Trim();
                    int lastMonth = int.Parse(txtlastmonth.Text.Trim());
                    string currentmonth = txtcurrentmonth.Text.Trim();
                    int thisMonth = int.Parse(txtcurrentmonth.Text.Trim());
                    double money = 0;
                    double usedWater = int.Parse(currentmonth) - int.Parse(lastmonth);

                    if (typecustomer == "Household")
                    {
                        try
                        {
                            string fammem = txtmember.Text.Trim();
                            int temfam = int.Parse(fammem);
                        }
                        catch
                        {
                            MessageBox.Show("Family member must be a number", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (!int.TryParse(lastmonth, out _))
                        {
                            MessageBox.Show("Last month index must be a number ", "Thong bao");
                            return;
                        }
                        else if (!int.TryParse(currentmonth, out _))
                        {
                            MessageBox.Show("This month index must be a number ", "Thong bao");
                            return;
                        }
                        else if (!int.TryParse(member, out _))
                        {
                            MessageBox.Show("Member must be a number", "Thong bao");
                            return;
                        }
                        else if (int.Parse(member) < 1)
                        {
                            MessageBox.Show("Family member must be greater than 1", "Thong bao");
                            return;
                        }
                        else if (int.Parse(currentmonth) - int.Parse(lastmonth) < 0 || int.Parse(lastmonth) < 0 || int.Parse(currentmonth) < 0)
                        {
                            MessageBox.Show("Current must be greater than that last month ");
                            return;
                        }

                        else
                        {
                            double memberUsedWater = usedWater / int.Parse(member);
                            if (memberUsedWater >= 0 && memberUsedWater < 10)
                            {
                                //money = 100%
                                money = usedWater * 5973 * 1.1;
                                txtResult.Text = Convert.ToString(money);
                            }
                            else if (memberUsedWater > 10 && memberUsedWater <= 20)
                            {
                                money = usedWater * 7052 * 1.1;
                                txtResult.Text = Convert.ToString(money);

                            }
                            else if (memberUsedWater > 20 && memberUsedWater <= 30)
                            {
                                money = usedWater * 8699 * 1.1;
                                txtResult.Text = Convert.ToString(money);

                            }
                            else
                            {
                                money = usedWater * 15929 * 1.1;
                                txtResult.Text = Convert.ToString(money);

                            }
                        }
                    }

                    // dich vu cong dng
                    else if (typecustomer == "Public Services")
                    {
                        if (thisMonth > lastMonth)
                        {
                            money = usedWater * 9955 * 1.1;
                            txtResult.Text = Convert.ToString(money);
                        }
                        else
                        {
                            MessageBox.Show("Current must be greater than that last month ");
                        }



                    }
                    //day la don vi sx
                    else if (typecustomer == "Production Units")
                    {
                        if (thisMonth > lastMonth)
                        {
                            money = usedWater * 11615 * 1.1;
                            txtResult.Text = Convert.ToString(money);
                        }
                        else
                        {
                            MessageBox.Show("Current must be greater than that last month ");
                        }


                    }
                    //neu la business
                    else if (typecustomer == "Business Services")
                        if (thisMonth > lastMonth)
                        {
                            money = usedWater * 22068 * 1.1;
                            txtResult.Text = Convert.ToString(money);
                        }
                        else
                        {
                            MessageBox.Show("Current must be greater than that last month ");
                        }
                    btnAdd.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Enter information to calculate", "Thong bao");
                    return;
                }
                btnedit.Enabled = true;
                lstvresult.Items.Remove(lstvresult.SelectedItems[0]);
                ListViewItem item = new ListViewItem();
                item.Text = txtname.Text.Trim();
                item.SubItems.Add(cbcustomertype.Text.Trim());
                item.SubItems.Add(txtmember.Text.Trim());
                item.SubItems.Add(txtlastmonth.Text.Trim());
                item.SubItems.Add(txtcurrentmonth.Text.Trim());
                item.SubItems.Add(txtResult.Text.Trim());
                lstvresult.Items.Add(item);
            }
            catch
            {

            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string customerName = txtname.Text.Trim();
            string customerType = cbcustomertype.Text.Trim();
            string member = txtmember.Text.Trim();
            string currentmonthIndex = txtcurrentmonth.Text.Trim();
            string lastmonthIndex = txtlastmonth.Text.Trim();
            string moneyResult = txtResult.Text.Trim();
            //string strWaterBill = Convert.ToString(WaterBill);
            ListViewItem item = new ListViewItem(customerName);
            item.SubItems.Add(customerType);
            item.SubItems.Add(member);
            item.SubItems.Add(lastmonthIndex);
            item.SubItems.Add(currentmonthIndex);
            //item.SubItems.Add(strWaterBill);
            item.SubItems.Add(moneyResult);
            lstvresult.Items.Add(item);
            btnAdd.Enabled = false;



        }




        private void Form1_Load(object sender, EventArgs e)
        {
            lstvresult.View = View.Details;
            lstvresult.GridLines = true;
            lstvresult.FullRowSelect = true;
            lstvresult.Columns.Add("Full name", 150);
            lstvresult.Columns.Add("Type", 100);
            lstvresult.Columns.Add("Member", 50);
            lstvresult.Columns.Add("Last Water number", 100);
            lstvresult.Columns.Add("Current Water number", 100);
            lstvresult.Columns.Add("Result", 100);
        }

        private void lstvresult_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            if (lstvresult.SelectedItems.Count > 0)
            {
                DialogResult dl = MessageBox.Show("Ban co chac muon xoa ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    lstvresult.Items.Remove(lstvresult.SelectedItems[0]);
                }

            }
            else
            {
                MessageBox.Show("Hay chon 1 phan ma ban muon xoa", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Ban co chac muon thoat ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
           if(d == DialogResult.Yes)
            {
                Application.Exit();
            }
           
   
        }

        private void txtmember_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbcustomertype_SelectedIndexChanged(object sender, EventArgs e)
        {
                        string type = cbcustomertype.Text.Trim();
            if (type.Equals("Household"))
            {
                txtmember.Enabled = true;
            }
            else
            {
                txtmember.Enabled = false;
                txtmember.Text = null;
            }
        }
    }
}
    



