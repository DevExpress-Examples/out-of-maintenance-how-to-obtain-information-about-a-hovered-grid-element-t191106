using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace dxSample {
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm {
        public XtraForm1() {
            InitializeComponent();
            InitData();
            gridView1.BestFitColumns();
        }
        private void InitData() {
            string filePath = @"..\..\SampleData\Contacts.xml";
            DataSet ds = new DataSet();
            ds.ReadXml(filePath);
            BindingSource bs = new BindingSource();
            bs.DataSource = ds;
            bs.DataMember = "Contacts";
            gridControl1.DataSource = bs;
        }
        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e) {
            Point pt = e.ControlMousePosition;
            GridView view = gridView1;
            GridHitInfo hi = view.CalcHitInfo(pt);
            GridViewInfo viewInfo = view.GetViewInfo() as GridViewInfo;
            if(viewInfo == null)
                return;
            if (hi.InColumnPanel && hi.Column != null) {
                viewInfo.GetColumnLeftCoord(hi.Column);
                int columnLeftCoord = viewInfo.GetColumnLeftCoord(hi.Column);
                DevExpress.XtraGrid.Drawing.GridColumnInfoArgs columnInfo = viewInfo.ColumnsInfo[hi.Column];
                e.Info = new DevExpress.Utils.ToolTipControlInfo(hi.Column, string.Format("'{0}'; left coord:{1}", columnInfo.Caption, columnLeftCoord));
            }
            if (hi.InRowCell) {
                GridCellInfo cellInfo = viewInfo.GetGridCellInfo(hi);
                e.Info = new DevExpress.Utils.ToolTipControlInfo(cellInfo, string.Format("{0}: ({1}, {2})", cellInfo.ViewInfo.DisplayText, cellInfo.RowHandle, cellInfo.Column));
            }
            if (hi.InGroupPanel) {
                Rectangle clientBounds = viewInfo.GroupPanel.ViewInfo.ClientBounds;
                e.Info = new DevExpress.Utils.ToolTipControlInfo(viewInfo.GroupPanel, string.Format("Group Panel: {0}", clientBounds));
            }
        }
    }
}

