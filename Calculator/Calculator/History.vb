Imports Calculator.Calc
Public Class History
    Public obiect As New Calc
    Dim text2 As String = ""
    Private Sub History_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MdiParent = Form1

    End Sub

    Private Sub showhistbtn_Click(sender As System.Object, e As System.EventArgs) Handles showhistbtn.Click
        For Each item As String In contor
            text2 += item
        Next
        histBox.Text = text2

    End Sub
End Class