using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstTestInterface
{
    public partial class Form1 : Form
    {
        //private readonly System.Windows.Forms.DataGridView dataGridView;
        private DataGridView dataGridView;
        private DatabaseManager dbManager = new DatabaseManager();
        private Button btnGetData;
        private Button btnExportCSV;

        public Form1()
        {
            InitializeComponents();
            //InitializeDataGridView();
        }
        private void InitializeComponents()
        {
            dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;
            btnGetData = new Button();
            btnGetData.Text = "Get Data";
            btnGetData.Click += btnGetData_Click;
            btnExportCSV = new Button();
            btnExportCSV.Text = "Export to CSV";
            btnExportCSV.Click += btnExportCSV_Click;
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Top;
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.Controls.Add(btnGetData);
            tableLayoutPanel.Controls.Add(btnExportCSV);
            Controls.Add(dataGridView);
            Controls.Add(tableLayoutPanel);
        }

        //private void InitializeDataGridView()
        //{
        //    // Create a new DataGridView
        //    dataGridView = new DataGridView();
        //    dataGridView.Dock = DockStyle.Fill;
        //    Controls.Add(dataGridView);
        //}

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataTable employeeData = dbManager.GetEmployeeData();
            dataGridView.DataSource = employeeData;
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            DataTable employeeData = (DataTable)dataGridView.DataSource;
            string fileName = DateTime.Now.ToString("ddMMyyyy") + ".csv";
            string filePath = Path.Combine(@"D:\AbhayServices\FirstService\FirstTestInterface\bin\Debug", fileName);
            dbManager.ExportToCSV(employeeData, filePath);
            MessageBox.Show("CSV file exported successfully!");
        }
    }
}
