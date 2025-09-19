Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmSplash
    Private Sub frmSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarFormulario()
        MostrarInformacion()
    End Sub

    Private Sub ConfigurarFormulario()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(44, 62, 80)
        Me.Size = New Size(640, 480)

        ' Hacer el formulario semi-transparente
        Me.Opacity = 0.95
    End Sub

    Private Sub MostrarInformacion()
        ' Configurar labels (estos deben existir en el diseño del formulario)
        lblNombreApp.Text = "SISTEMA DE GESTIÓN" & vbCrLf & "DE EMPLEADOS"
        lblNombreApp.Font = New Font("Segoe UI", 24, FontStyle.Bold)
        lblNombreApp.ForeColor = Color.White
        lblNombreApp.TextAlign = ContentAlignment.MiddleCenter

        lblVersion.Text = "Versión 1.0"
        lblVersion.Font = New Font("Segoe UI", 12, FontStyle.Regular)
        lblVersion.ForeColor = Color.FromArgb(189, 195, 199)
        lblVersion.TextAlign = ContentAlignment.MiddleCenter

        lblCargando.Text = "Cargando..."
        lblCargando.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblCargando.ForeColor = Color.FromArgb(52, 152, 219)
        lblCargando.TextAlign = ContentAlignment.MiddleCenter

        ' Configurar barra de progreso (si existe)
        If ProgressBar1 IsNot Nothing Then
            ProgressBar1.Style = ProgressBarStyle.Marquee
            ProgressBar1.MarqueeAnimationSpeed = 75
        End If
    End Sub
End Class