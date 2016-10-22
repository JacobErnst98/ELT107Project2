Public Class Form1
    Dim U, RP, R, V, CP As Decimal 'Declair var's

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'reset button
        Label4.ForeColor = System.Drawing.Color.Black 'color black 
        Label4.Text = "Status" ' reset everything
        Label3.Text = "Resistor Testor"
        TextBox1.Text = " "
        TextBox2.Text = " "
        Button2.Visible = True
        RadioButton3.Checked = True
        RadioButton5.Checked = True
        RadioButton8.Checked = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click ' calculate button
        If IsNumeric(TextBox1.Text) And IsNumeric(TextBox2.Text) Then ' is it a number?
            V = Val(TextBox2.Text) 'write values
            If R <= 0 Then ' is it smaller than 0
                MsgBox("Please enter positive numbers") 'Yell at people
                Exit Sub
            End If
            If RadioButton5.Checked = True Then ' Resistance value *
                R = Val(TextBox1.Text)
            ElseIf RadioButton6.Checked = True Then
                R = Val(TextBox1.Text) * 1000
            ElseIf RadioButton7.Checked = True Then
                R = Val(TextBox1.Text) * 1000000
            End If
            If V <= 0 Then ' is V smaller than 0
                MsgBox("Please enter positive numbers") ' yell more
                Exit Sub
            End If
            CP = (V ^ 2) / R 'math
            If RadioButton1.Checked = True Then    'power options
                RP = 0.25
            ElseIf RadioButton2.Checked = True Then
                RP = 0.5
            ElseIf RadioButton3.Checked = True Then
                RP = 1
            ElseIf RadioButton3.Checked = True Then
                RP = 2
            End If
            If CP >= RP Then
                Label4.ForeColor = System.Drawing.Color.Red 'red text
                Label4.Text = "Burnt!" ' he's dead jim
            ElseIf CP < RP Then
                Label4.ForeColor = System.Drawing.Color.Green ' green text
                Label4.Text = "Okay" ' not on fire
            End If
            If RadioButton8.Checked = True Then                    'What units would you like?
                Label3.Text = FormatNumber((CP * 1000), 2) & " mW" 'math and formating 
            ElseIf RadioButton9.Checked = True Then
                Label3.Text = FormatNumber(CP, 2) & " Watts"
            End If
            Button2.Visible = False ' make the button invisible
        End If
        If Not IsNumeric(TextBox1.Text) Or Not IsNumeric(TextBox2.Text) Then 'not numbers?
            MsgBox("Only numbers may be entered For voltage or restance") 'yell alot
            Exit Sub
        End If
    End Sub
End Class
