<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSplash
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblNombreApp = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblCargando = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'lblNombreApp
        '
        Me.lblNombreApp.AutoSize = True
        Me.lblNombreApp.Location = New System.Drawing.Point(152, 44)
        Me.lblNombreApp.Name = "lblNombreApp"
        Me.lblNombreApp.Size = New System.Drawing.Size(73, 13)
        Me.lblNombreApp.TabIndex = 0
        Me.lblNombreApp.Text = "lblNombreApp"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(271, 147)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(52, 13)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "lblVersion"
        '
        'lblCargando
        '
        Me.lblCargando.AutoSize = True
        Me.lblCargando.Location = New System.Drawing.Point(152, 237)
        Me.lblCargando.Name = "lblCargando"
        Me.lblCargando.Size = New System.Drawing.Size(63, 13)
        Me.lblCargando.TabIndex = 2
        Me.lblCargando.Text = "lblCargando"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(296, 237)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar1.TabIndex = 3
        '
        'frmSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 372)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.lblCargando)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblNombreApp)
        Me.Name = "frmSplash"
        Me.Text = "FrmSplash"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombreApp As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents lblCargando As Label
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
