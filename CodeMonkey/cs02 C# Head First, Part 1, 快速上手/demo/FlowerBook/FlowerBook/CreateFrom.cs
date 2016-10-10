using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlowerBook.Models;

namespace FlowerBook
{
    public partial class CreateFrom : Form
    {
        ListForm listFrom;
        public CreateFrom()
        {
            InitializeComponent();
        }
        public CreateFrom(ListForm listForm)
        {
            InitializeComponent();
            this.listFrom = listForm;
        }
        private void okBtn_Click(object sender, EventArgs e)
        {
            if (nameTB.Text.Length > 0 && depTB.Text.Length > 0)
            {
                Staff staff = new Staff()
                {
                    Name = nameTB.Text,
                    Department = depTB.Text,
                    Email = emailTB.Text
                };
                staff.Phone = phoneTB.Text;

                if (staff.Create())
                {
                    MessageBox.Show("创建成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listFrom.ReloadStaffs();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("创建失败，原因未知", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("请填写姓名和部门", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
