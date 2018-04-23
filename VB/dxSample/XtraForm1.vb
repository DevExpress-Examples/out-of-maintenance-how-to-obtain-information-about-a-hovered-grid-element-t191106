Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Namespace dxSample
    Partial Public Class XtraForm1
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()
            InitData()
            gridView1.BestFitColumns()
        End Sub
        Private Sub InitData()
            Dim filePath As String = "..\..\SampleData\Contacts.xml"
            Dim ds As New DataSet()
            ds.ReadXml(filePath)
            Dim bs As New BindingSource()
            bs.DataSource = ds
            bs.DataMember = "Contacts"
            gridControl1.DataSource = bs
        End Sub
        Private Sub toolTipController1_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles toolTipController1.GetActiveObjectInfo
            Dim pt As Point = e.ControlMousePosition
            Dim view As GridView = gridView1
            Dim hi As GridHitInfo = view.CalcHitInfo(pt)
            Dim viewInfo As GridViewInfo = TryCast(view.GetViewInfo(), GridViewInfo)
            If viewInfo Is Nothing Then
                Return
            End If
            If hi.InColumnPanel AndAlso hi.Column IsNot Nothing Then
                viewInfo.GetColumnLeftCoord(hi.Column)
                Dim columnLeftCoord As Integer = viewInfo.GetColumnLeftCoord(hi.Column)
                Dim columnInfo As DevExpress.XtraGrid.Drawing.GridColumnInfoArgs = viewInfo.ColumnsInfo(hi.Column)
                e.Info = New DevExpress.Utils.ToolTipControlInfo(hi.Column, String.Format("'{0}'; left coord:{1}", columnInfo.Caption, columnLeftCoord))
            End If
            If hi.InRowCell Then
                Dim cellInfo As GridCellInfo = viewInfo.GetGridCellInfo(hi)
                e.Info = New DevExpress.Utils.ToolTipControlInfo(cellInfo, String.Format("{0}: ({1}, {2})", cellInfo.ViewInfo.DisplayText, cellInfo.RowHandle, cellInfo.Column))
            End If
            If hi.InGroupPanel Then
                Dim clientBounds As Rectangle = viewInfo.GroupPanel.ViewInfo.ClientBounds
                e.Info = New DevExpress.Utils.ToolTipControlInfo(viewInfo.GroupPanel, String.Format("Group Panel: {0}", clientBounds))
            End If
        End Sub
    End Class
End Namespace

