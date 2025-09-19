Imports System.Drawing
Imports System.Windows.Forms

Public Class Utilidades
    ' Validar formato de email
    Public Shared Function EsEmailValido(email As String) As Boolean
        If String.IsNullOrWhiteSpace(email) Then Return False
        Try
            Dim addr As New System.Net.Mail.MailAddress(email)
            Return addr.Address = email
        Catch
            Return False
        End Try
    End Function

    ' Formatear salario
    Public Shared Function FormatearSalario(salario As Decimal) As String
        Return salario.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-CO"))
    End Function

    ' Validar solo números
    Public Shared Sub SoloNumeros(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso (e.KeyChar <> "."c) Then
            e.Handled = True
        End If

        ' Solo permitir un punto decimal
        If (e.KeyChar = "."c) AndAlso (DirectCast(sender, TextBox).Text.IndexOf("."c) > -1) Then
            e.Handled = True
        End If
    End Sub

    ' Validar solo letras y espacios
    Public Shared Sub SoloLetras(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Mostrar mensaje de confirmación
    Public Shared Function MostrarConfirmacion(mensaje As String, titulo As String) As Boolean
        Return MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
    End Function

    ' Mostrar mensaje de información
    Public Shared Sub MostrarInformacion(mensaje As String, titulo As String)
        MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Mostrar mensaje de error
    Public Shared Sub MostrarError(mensaje As String, titulo As String)
        MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ' Mostrar mensaje de advertencia
    Public Shared Sub MostrarAdvertencia(mensaje As String, titulo As String)
        MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    ' Configurar DataGridView
    Public Shared Sub ConfigurarDataGridView(dgv As DataGridView)
        With dgv
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219)
            .DefaultCellStyle.SelectionForeColor = Color.White
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.ForeColor = Color.Black
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .EnableHeadersVisualStyles = False
            .RowHeadersVisible = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub
End Class
