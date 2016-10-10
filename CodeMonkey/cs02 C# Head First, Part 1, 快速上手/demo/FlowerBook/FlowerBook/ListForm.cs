using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlowerBook
{
    public partial class ListForm : Form
    {
        public ListForm()
        {
            InitializeComponent();
        }

        private void ListForm_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“flowerBookDbDataSet.Staff”中。您可以根据需要移动或删除它。
            this.staffTableAdapter.Fill(this.flowerBookDbDataSet.Staff);
            
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            new CreateFrom(this).Show();
        }

        public void ReloadStaffs()
        {
            this.staffTableAdapter.Fill(this.flowerBookDbDataSet.Staff);
        }
    }
}
