using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using XL.upload.Dapper.WindowsFormsApp1.Models;

namespace XL.upload.Dapper.WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            var products = new List<Product>()
            {
                new Product(){ProductName="aa"},
                new Product(){ProductName="bb"}
            };
            BulkAdd(products);
        }

        public void BulkAdd(List<Product> products)
        {
            var CN_Str = Properties.Settings.Default.CNStr;
            var SQL = @"INSERT INTO [dbo].[Products]
           ([ProductName]
           ,[SupplierID]
           ,[CategoryID]
           ,[QuantityPerUnit]
           ,[UnitPrice]
           ,[UnitsInStock]
           ,[UnitsOnOrder]
           ,[ReorderLevel]
           ,[Discontinued])
     VALUES
           (@ProductName,
           @SupplierID, 
           @CategoryID, 
           @QuantityPerUnit, 
           @UnitPrice, 
           @UnitsInStock,
           @UnitsOnOrder,
           @ReorderLevel,
           @Discontinued)";
            using (var CN = new SqlConnection(CN_Str))
            {
                CN.Execute(SQL, products);
            }

        }

    }
}
