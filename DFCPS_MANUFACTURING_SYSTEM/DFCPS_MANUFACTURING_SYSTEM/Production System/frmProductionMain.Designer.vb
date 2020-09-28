<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductionMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductionMain))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.TRANSACTIONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DailyReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CircularLoomSectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DofferToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PDORToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MixingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PDORCUTTINGToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DoffedYarnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinishedProductionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecycleReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrusherReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddLoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VIEWToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RollStockInventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CircularLoomHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.REPORTHISTORYToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JobOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeliveryReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RawMaterialsInventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TOOLSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProducedAndWasteGraphicalReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuttingSewingProductionReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoomsProductionReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PerOperatorPerformanceReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ATTENDANCEEFFICIENCYToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductionDailyPerOperatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RankingReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SETTINGSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ABOUTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbldate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbltime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TRANSACTIONToolStripMenuItem, Me.VIEWToolStripMenuItem, Me.TOOLSToolStripMenuItem, Me.SETTINGSToolStripMenuItem, Me.ABOUTToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(632, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'TRANSACTIONToolStripMenuItem
        '
        Me.TRANSACTIONToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DailyReportToolStripMenuItem, Me.AddLoomToolStripMenuItem})
        Me.TRANSACTIONToolStripMenuItem.Name = "TRANSACTIONToolStripMenuItem"
        Me.TRANSACTIONToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.TRANSACTIONToolStripMenuItem.Text = "Transactions"
        '
        'DailyReportToolStripMenuItem
        '
        Me.DailyReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CircularLoomSectionToolStripMenuItem, Me.DofferToolStripMenuItem, Me.QAToolStripMenuItem, Me.PDORToolStripMenuItem, Me.MixingToolStripMenuItem, Me.PDORCUTTINGToolStripMenuItem, Me.DoffedYarnToolStripMenuItem, Me.FinishedProductionToolStripMenuItem, Me.RecycleReportToolStripMenuItem, Me.CrusherReportToolStripMenuItem, Me.PrintingToolStripMenuItem})
        Me.DailyReportToolStripMenuItem.Name = "DailyReportToolStripMenuItem"
        Me.DailyReportToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.DailyReportToolStripMenuItem.Text = "Add Daily Report"
        '
        'CircularLoomSectionToolStripMenuItem
        '
        Me.CircularLoomSectionToolStripMenuItem.Name = "CircularLoomSectionToolStripMenuItem"
        Me.CircularLoomSectionToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.CircularLoomSectionToolStripMenuItem.Text = "Circular Loom Section"
        '
        'DofferToolStripMenuItem
        '
        Me.DofferToolStripMenuItem.Name = "DofferToolStripMenuItem"
        Me.DofferToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.DofferToolStripMenuItem.Text = "Doffed"
        '
        'QAToolStripMenuItem
        '
        Me.QAToolStripMenuItem.Name = "QAToolStripMenuItem"
        Me.QAToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.QAToolStripMenuItem.Text = "Q.A."
        '
        'PDORToolStripMenuItem
        '
        Me.PDORToolStripMenuItem.Name = "PDORToolStripMenuItem"
        Me.PDORToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.PDORToolStripMenuItem.Text = "Flat Yarn"
        '
        'MixingToolStripMenuItem
        '
        Me.MixingToolStripMenuItem.Name = "MixingToolStripMenuItem"
        Me.MixingToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.MixingToolStripMenuItem.Text = "Mixing"
        '
        'PDORCUTTINGToolStripMenuItem
        '
        Me.PDORCUTTINGToolStripMenuItem.Name = "PDORCUTTINGToolStripMenuItem"
        Me.PDORCUTTINGToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.PDORCUTTINGToolStripMenuItem.Text = "Cutting And Sewing"
        '
        'DoffedYarnToolStripMenuItem
        '
        Me.DoffedYarnToolStripMenuItem.Name = "DoffedYarnToolStripMenuItem"
        Me.DoffedYarnToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.DoffedYarnToolStripMenuItem.Text = "Doffed Yarn"
        '
        'FinishedProductionToolStripMenuItem
        '
        Me.FinishedProductionToolStripMenuItem.Name = "FinishedProductionToolStripMenuItem"
        Me.FinishedProductionToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.FinishedProductionToolStripMenuItem.Text = "Finished Product Q.A. Report"
        '
        'RecycleReportToolStripMenuItem
        '
        Me.RecycleReportToolStripMenuItem.Name = "RecycleReportToolStripMenuItem"
        Me.RecycleReportToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.RecycleReportToolStripMenuItem.Text = "Recycle Report"
        '
        'CrusherReportToolStripMenuItem
        '
        Me.CrusherReportToolStripMenuItem.Name = "CrusherReportToolStripMenuItem"
        Me.CrusherReportToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.CrusherReportToolStripMenuItem.Text = "Crusher Report"
        '
        'PrintingToolStripMenuItem
        '
        Me.PrintingToolStripMenuItem.Name = "PrintingToolStripMenuItem"
        Me.PrintingToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.PrintingToolStripMenuItem.Text = "Printing"
        '
        'AddLoomToolStripMenuItem
        '
        Me.AddLoomToolStripMenuItem.Name = "AddLoomToolStripMenuItem"
        Me.AddLoomToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.AddLoomToolStripMenuItem.Text = "Add / Edit Loom"
        '
        'VIEWToolStripMenuItem
        '
        Me.VIEWToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RollStockInventoryToolStripMenuItem, Me.CircularLoomHistoryToolStripMenuItem, Me.REPORTHISTORYToolStripMenuItem, Me.JobOrderToolStripMenuItem, Me.DeliveryReceiptToolStripMenuItem, Me.RawMaterialsInventoryToolStripMenuItem})
        Me.VIEWToolStripMenuItem.Name = "VIEWToolStripMenuItem"
        Me.VIEWToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.VIEWToolStripMenuItem.Text = "View"
        '
        'RollStockInventoryToolStripMenuItem
        '
        Me.RollStockInventoryToolStripMenuItem.Enabled = False
        Me.RollStockInventoryToolStripMenuItem.Name = "RollStockInventoryToolStripMenuItem"
        Me.RollStockInventoryToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.RollStockInventoryToolStripMenuItem.Text = "Roll Stock Inventory"
        '
        'CircularLoomHistoryToolStripMenuItem
        '
        Me.CircularLoomHistoryToolStripMenuItem.Enabled = False
        Me.CircularLoomHistoryToolStripMenuItem.Name = "CircularLoomHistoryToolStripMenuItem"
        Me.CircularLoomHistoryToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.CircularLoomHistoryToolStripMenuItem.Text = "Circular Loom Section History"
        '
        'REPORTHISTORYToolStripMenuItem
        '
        Me.REPORTHISTORYToolStripMenuItem.Name = "REPORTHISTORYToolStripMenuItem"
        Me.REPORTHISTORYToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.REPORTHISTORYToolStripMenuItem.Text = "Report History"
        '
        'JobOrderToolStripMenuItem
        '
        Me.JobOrderToolStripMenuItem.Name = "JobOrderToolStripMenuItem"
        Me.JobOrderToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.JobOrderToolStripMenuItem.Text = "Job Order"
        '
        'DeliveryReceiptToolStripMenuItem
        '
        Me.DeliveryReceiptToolStripMenuItem.Enabled = False
        Me.DeliveryReceiptToolStripMenuItem.Name = "DeliveryReceiptToolStripMenuItem"
        Me.DeliveryReceiptToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.DeliveryReceiptToolStripMenuItem.Text = "Delivery Receipt"
        '
        'RawMaterialsInventoryToolStripMenuItem
        '
        Me.RawMaterialsInventoryToolStripMenuItem.Enabled = False
        Me.RawMaterialsInventoryToolStripMenuItem.Name = "RawMaterialsInventoryToolStripMenuItem"
        Me.RawMaterialsInventoryToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.RawMaterialsInventoryToolStripMenuItem.Text = "Raw Materials Inventory"
        '
        'TOOLSToolStripMenuItem
        '
        Me.TOOLSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProducedAndWasteGraphicalReportToolStripMenuItem, Me.CuttingSewingProductionReportToolStripMenuItem, Me.LoomsProductionReportToolStripMenuItem, Me.PerOperatorPerformanceReportToolStripMenuItem})
        Me.TOOLSToolStripMenuItem.Name = "TOOLSToolStripMenuItem"
        Me.TOOLSToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.TOOLSToolStripMenuItem.Text = "Report"
        '
        'ProducedAndWasteGraphicalReportToolStripMenuItem
        '
        Me.ProducedAndWasteGraphicalReportToolStripMenuItem.Name = "ProducedAndWasteGraphicalReportToolStripMenuItem"
        Me.ProducedAndWasteGraphicalReportToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
        Me.ProducedAndWasteGraphicalReportToolStripMenuItem.Text = "Yarn Production Report"
        '
        'CuttingSewingProductionReportToolStripMenuItem
        '
        Me.CuttingSewingProductionReportToolStripMenuItem.Name = "CuttingSewingProductionReportToolStripMenuItem"
        Me.CuttingSewingProductionReportToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
        Me.CuttingSewingProductionReportToolStripMenuItem.Text = "Cutting / Sewing Production Report"
        '
        'LoomsProductionReportToolStripMenuItem
        '
        Me.LoomsProductionReportToolStripMenuItem.Name = "LoomsProductionReportToolStripMenuItem"
        Me.LoomsProductionReportToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
        Me.LoomsProductionReportToolStripMenuItem.Text = "Looms Production Report"
        '
        'PerOperatorPerformanceReportToolStripMenuItem
        '
        Me.PerOperatorPerformanceReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ATTENDANCEEFFICIENCYToolStripMenuItem, Me.ProductionToolStripMenuItem, Me.ProductionDailyPerOperatorToolStripMenuItem, Me.RankingReportToolStripMenuItem})
        Me.PerOperatorPerformanceReportToolStripMenuItem.Name = "PerOperatorPerformanceReportToolStripMenuItem"
        Me.PerOperatorPerformanceReportToolStripMenuItem.Size = New System.Drawing.Size(263, 22)
        Me.PerOperatorPerformanceReportToolStripMenuItem.Text = "Per Operator Performance Report"
        '
        'ATTENDANCEEFFICIENCYToolStripMenuItem
        '
        Me.ATTENDANCEEFFICIENCYToolStripMenuItem.Name = "ATTENDANCEEFFICIENCYToolStripMenuItem"
        Me.ATTENDANCEEFFICIENCYToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.ATTENDANCEEFFICIENCYToolStripMenuItem.Text = "Attendance / Efficiency"
        '
        'ProductionToolStripMenuItem
        '
        Me.ProductionToolStripMenuItem.Name = "ProductionToolStripMenuItem"
        Me.ProductionToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.ProductionToolStripMenuItem.Text = "Production"
        '
        'ProductionDailyPerOperatorToolStripMenuItem
        '
        Me.ProductionDailyPerOperatorToolStripMenuItem.Name = "ProductionDailyPerOperatorToolStripMenuItem"
        Me.ProductionDailyPerOperatorToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.ProductionDailyPerOperatorToolStripMenuItem.Text = "Production Daily (Per Operator)"
        '
        'RankingReportToolStripMenuItem
        '
        Me.RankingReportToolStripMenuItem.Name = "RankingReportToolStripMenuItem"
        Me.RankingReportToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.RankingReportToolStripMenuItem.Text = "Ranking Report"
        '
        'SETTINGSToolStripMenuItem
        '
        Me.SETTINGSToolStripMenuItem.Name = "SETTINGSToolStripMenuItem"
        Me.SETTINGSToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SETTINGSToolStripMenuItem.Text = "Settings"
        '
        'ABOUTToolStripMenuItem
        '
        Me.ABOUTToolStripMenuItem.Name = "ABOUTToolStripMenuItem"
        Me.ABOUTToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.ABOUTToolStripMenuItem.Text = "About"
        '
        'StatusStrip
        '
        Me.StatusStrip.Font = New System.Drawing.Font("Segoe UI", 10.18868!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel, Me.lbldate, Me.ToolStripStatusLabel1, Me.lbltime})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 429)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(632, 24)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(48, 19)
        Me.ToolStripStatusLabel.Text = "Date :"
        '
        'lbldate
        '
        Me.lbldate.Name = "lbldate"
        Me.lbldate.Size = New System.Drawing.Size(56, 19)
        Me.lbldate.Text = "lbldate"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(42, 19)
        Me.ToolStripStatusLabel1.Text = "Time"
        '
        'lbltime
        '
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(56, 19)
        Me.lbltime.Text = "lbltime"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(632, 405)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'frmProductionMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmProductionMain"
        Me.Text = "MAIN FORM"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents TRANSACTIONToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VIEWToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TOOLSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SETTINGSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ABOUTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DailyReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CircularLoomSectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CircularLoomHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DofferToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddLoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PDORToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MixingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PDORCUTTINGToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REPORTHISTORYToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DoffedYarnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FinishedProductionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbldate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbltime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents RollStockInventoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ProducedAndWasteGraphicalReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoomsProductionReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CuttingSewingProductionReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PerOperatorPerformanceReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ATTENDANCEEFFICIENCYToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RankingReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RawMaterialsInventoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecycleReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductionDailyPerOperatorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CrusherReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JobOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeliveryReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
