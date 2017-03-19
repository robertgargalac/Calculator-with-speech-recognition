Imports System.Speech
Imports System.Speech.Recognition
Imports System.Threading
Imports System.Speech.Recognition.Grammar
Imports System.Threading.Tasks



Public Class Calc

    Public Sub Calc()
        InitializeComponent()
    End Sub

    Private Sub Calc_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MdiParent = Form1

        Dim build As GrammarBuilder = New GrammarBuilder()
        build.AppendDictation()
        grammar = New Grammar(build)
        recognizer = New SpeechRecognitionEngine
        recognizer.LoadGrammar(grammar)
        recognizer.SetInputToDefaultAudioDevice()
        recognizerState = True
        recThread = New Thread(New ThreadStart(AddressOf RecThreadFunction))
        recThread.Start()

    End Sub

    Dim value As Double = 0
    Dim operation As String = Nothing
    Dim operation_pressed As Boolean = False




    Public WithEvents recognizer As SpeechRecognitionEngine
    Public grammar As Grammar
    Public recThread As Thread
    Public recognizerState As Boolean = True
    Public num As Integer
    Public _e As SpeechRecognizedEventArgs


    Public Function adding(ByVal x As Double, ByVal y As Double) As Double
        Return x + y
    End Function

    Public Function substraction(ByVal x As Double, ByVal y As Double) As Double

        Return x - y
    End Function

    Public Function multiplying(ByVal x As Double, ByVal y As Double) As Double

        Return x * y
    End Function

    Public Function dividing(ByVal x As Double, ByVal y As Double) As Double

        Return x / y
    End Function



    Private Sub txtBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBox.TextChanged

    End Sub


    Private Sub button_Click(sender As System.Object, e As System.EventArgs) Handles onebtn.Click, zerobtn.Click, twobtn.Click, threebtn.Click, sixbtn.Click, sevenbtn.Click, ninebtn.Click, fourbtn.Click, fivebtn.Click, eightbtn.Click, dotbtn.Click

        If txtBox.Text = "0" Or operation_pressed Then
            txtBox.Clear()
            Label1.Text = ""
        End If

        operation_pressed = False
        Dim b As Button = CType(sender, Button)

        txtBox.Text = txtBox.Text + b.Text
        contor.Add(b.Text)

    End Sub

    Private Sub clearbtn_Click(sender As System.Object, e As System.EventArgs) Handles clearbtn.Click
        txtBox.Text = "0"
        Label1.Text = "0"
        value = 0
    End Sub

    Private Sub operrator_Click(sender As System.Object, e As System.EventArgs) Handles plusbtn.Click, subbtn.Click, multbtn.Click, dividebtn.Click

        Dim b As Button = CType(sender, Button)
        contor.Add(b.Text)
        If Not value = 0 Then

            eqbtn.PerformClick()
            operation_pressed = True
            operation = b.Text
            Label1.Text = CType(value, String) + " " + operation
        Else
            operation = b.Text
            value = Double.Parse(txtBox.Text)
            operation_pressed = True
            Label1.Text = CType(value, String) + " " + operation
        End If

    End Sub

    Private Sub eqbtn_Click(sender As System.Object, e As System.EventArgs) Handles eqbtn.Click

        Select Case operation

            Case "+"

                txtBox.Text = (adding(value, Double.Parse(txtBox.Text))).ToString
                contor.Add("=")
                contor.Add(txtBox.Text + "   ")

            Case "-"
                txtBox.Text = (substraction(value, Double.Parse(txtBox.Text))).ToString
                contor.Add("=")
                contor.Add(txtBox.Text)
            Case "*"
                txtBox.Text = (multiplying(value, Double.Parse(txtBox.Text))).ToString
                contor.Add("=")
                contor.Add(txtBox.Text)
            Case "/"
                txtBox.Text = (dividing(value, Double.Parse(txtBox.Text))).ToString
                contor.Add("=")
                contor.Add(txtBox.Text)



        End Select
        value = CType(txtBox.Text, Integer)
        operation = ""

    End Sub

    Public Event SpeechRecognized As EventHandler(Of SpeechRecognizedEventArgs)

    Protected Overridable Sub OnStart(e As SpeechRecognizedEventArgs)
        RaiseEvent SpeechRecognized(Me, e)
    End Sub


    Public Sub recognizer_SpeechRecognized(sender As Object, ByVal e As SpeechRecognizedEventArgs) Handles recognizer.SpeechRecognized

        If Not recognizerState Then
            Return
        End If


        Me.Invoke(DirectCast(Sub() txtBox.Text += (" " + e.Result.Text.ToLower()), MethodInvoker))
    End Sub
    Public Sub RecThreadFunction()
        While True

            Try
                recognizer.Recognize()
            Catch ex As Exception

            End Try
        End While
    End Sub
    Private Sub Calc_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        recThread.Abort()
        recThread = Nothing
        recognizer.UnloadAllGrammars()
        recognizer.Dispose()
        grammar = Nothing

    End Sub

    Private Sub spbtn1_Click(sender As System.Object, e As System.EventArgs) Handles spbtn1.Click
        recognizerState = True
    End Sub

    Private Sub spbtn2_Click(sender As System.Object, e As System.EventArgs) Handles spbtn2.Click
        recognizerState = False
    End Sub

    Private Sub domathbtn_Click(sender As System.Object, e As System.EventArgs) Handles domathbtn.Click
        spbtn2.PerformClick()
        Dim spArray() As String = Split(txtBox.Text)
        txtBox.Clear()
        For i = 0 To spArray.Length - 1
            If spArray(i) = "one" Then
                onebtn.PerformClick()
            ElseIf spArray(i) = "two" Then
                twobtn.PerformClick()
            ElseIf spArray(i) = "three" Then
                twobtn.PerformClick()
            ElseIf spArray(i) = "two" Then
                threebtn.PerformClick()
            ElseIf spArray(i) = "four" Then
                fourbtn.PerformClick()
            ElseIf spArray(i) = "five" Then
                fivebtn.PerformClick()
            ElseIf spArray(i) = "six" Then
                sixbtn.PerformClick()
            ElseIf spArray(i) = "seven" Then
                sevenbtn.PerformClick()
            ElseIf spArray(i) = "two" Then
                twobtn.PerformClick()
            ElseIf spArray(i) = "eight" Then
                eightbtn.PerformClick()
            ElseIf spArray(i) = "nine" Then
                ninebtn.PerformClick()
            ElseIf spArray(i) = "zero" Then
                zerobtn.PerformClick()
            ElseIf spArray(i) = "plus" Then
                plusbtn.PerformClick()
            ElseIf spArray(i) = "minus" Then
                subbtn.PerformClick()
            ElseIf spArray(i) = "divide" Then
                dividebtn.PerformClick()
            ElseIf spArray(i) = "multiply" Then
                multbtn.PerformClick()
            ElseIf spArray(i) = "dot" Then
                dotbtn.PerformClick()
            ElseIf spArray(i) = "point" Then
                dotbtn.PerformClick()
            ElseIf spArray(i) = "equals" Then
                eqbtn.PerformClick()


            End If

        Next



    End Sub
End Class