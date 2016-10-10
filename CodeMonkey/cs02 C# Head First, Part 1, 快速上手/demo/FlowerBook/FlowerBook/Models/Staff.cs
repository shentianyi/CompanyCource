using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace FlowerBook.Models
{
    /// <summary>
    /// 员工类
    /// </summary>
    public class Staff
    {
        private readonly string connString = ConfigurationManager
            .ConnectionStrings["FlowerBook.Properties.Settings.FlowerBookDbConnectionString"].ToString();

        /// <summary>
        /// 属性
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Resigned { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Staff()
        {
            this.Resigned = false;
        }


        /// <summary>
        /// 创建，将数据写入数据库
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            bool success = false;
            if (!CheckEmailExist())
            {
                /// using会调用disopse方法，自动关闭数据库连接
                using (SqlConnection con = new SqlConnection(connString))
                {
                    string sql = "insert into staff(name,department,email,phone) values(@name,@department,@email,@phone);";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add(new SqlParameter("name", this.Name));
                    cmd.Parameters.Add(new SqlParameter("department", this.Department));
                    cmd.Parameters.Add(new SqlParameter("email", this.Email));
                    cmd.Parameters.Add(new SqlParameter("phone", this.Phone));

                    con.Open();

                    success = cmd.ExecuteNonQuery() == 1;
                }
            }
            else
            {
                success = false;
            }
            return success;
        }

        /// <summary>
        /// 根据检查email是否存在
        /// </summary>
        /// <returns></returns>
        public bool CheckEmailExist()
        {
            bool exist = false;
            if (string.IsNullOrEmpty(this.Email))
            {
                exist = false;
            }
            else
            {
                // 数据库连接
                SqlConnection con = new SqlConnection(connString);
                // 查询语句
                string sql = "select * from staff where email=@email";
                // 数据库命令
                SqlCommand cmd = new SqlCommand(sql, con);
                // 添加参数
                cmd.Parameters.Add(new SqlParameter("email", this.Email));
                // 打开数据库连接
                con.Open();
                // 执行命令
                exist = cmd.ExecuteScalar() != null;
                // 关闭连接
                con.Close();
            }
            return exist;
        }
    }
}
