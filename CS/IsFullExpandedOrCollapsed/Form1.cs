using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace IsFullExpandedOrCollapsed {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            new DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1);
            gridView1.Columns["Discontinued"].Group();
            gridView1.Columns["Category"].Group();
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            gridView1.OptionsView.ShowAutoFilterRow = true;
        }

        bool IsFullExpanded(GridView view) {
            if(view.GroupCount == 0) return true;
            if(view.DataRowCount == 0) return true;
            for(int i = -1; i > int.MinValue; i--) {
                if(!view.IsValidRowHandle(i)) return true;
                if(view.IsGroupRow(i) && !view.GetRowExpanded(i)) return false;
            }
            return true;
        }

        bool IsFullCollapsed(GridView view) {
            if(view.GroupCount == 0) return false;
            if(view.DataRowCount == 0) return false;
            for(int i = -1; i > int.MinValue; i--) {
                if(!view.IsValidRowHandle(i)) return true;
                if(view.IsGroupRow(i) && view.GetRowExpanded(i)) return false;
            }
            return true;
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            MessageBox.Show(string.Format("Fully exapanded: {0}\nFully collapsed: {1}", IsFullExpanded(gridView1), IsFullCollapsed(gridView1)));
        }
    }
}
