using System;
using System.Data;
using System.Windows.Forms;

namespace ColoredProgressBar {
    public partial class Form1 : Form {
        DataTable dt = new DataTable();
        public Form1() {
            InitializeComponent();
            dt.Columns.Add("Column");
            for (int i = 0; i <= 100; i += 10)
                dt.Rows.Add(i);
        }
        private void Form1_Load(object sender, EventArgs e) {
            gridControl1.DataSource = dt;
            CustomPaintedProgressBarHelper customPaintedProgressBarHelper = new CustomPaintedProgressBarHelper(col4);
            DRProgressBarHelper drHelper = new DRProgressBarHelper(col5);
            SRProgressBarHelper srHelper = new SRProgressBarHelper(col6);
        }
    }
}
