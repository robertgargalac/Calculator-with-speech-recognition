<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class History
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
        Me.histBox = New System.Windows.Forms.TextBox()
        Me.showhistbtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'histBox
        '
        Me.histBox.Font = New System.Drawing.Font("Bernard MT Condensed", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.histBox.Location = New System.Drawing.Point(66, 12)
        Me.histBox.Multiline = True
        Me.histBox.Name = "histBox"
        Me.histBox.ReadOnly = True
        Me.histBox.Size = New System.Drawing.Size(400, 270)
        Me.histBox.TabIndex = 0
        Me.histBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'showhistbtn
        '
        Me.showhistbtn.Font = New System.Drawing.Font("OCR A Extended", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.showhistbtn.Location = New System.Drawing.Point(149, 307)
        Me.showhistbtn.Name = "showhistbtn"
        Me.showhistbtn.Size = New System.Drawing.Size(213, 51)
        Me.showhistbtn.TabIndex = 1
        Me.showhistbtn.Text = "Show History"
        Me.showhistbtn.UseVisualStyleBackColor = True
        '
        'History
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 401)
        Me.Controls.Add(Me.showhistbtn)
        Me.Controls.Add(Me.histBox)
        Me.Name = "History"
        Me.Text = "History"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents showhistbtn As System.Windows.Forms.Button
    Public WithEvents histBox As System.Windows.Forms.TextBox
End Class
