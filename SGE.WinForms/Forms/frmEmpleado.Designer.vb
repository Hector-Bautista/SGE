<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpleado
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
        Me.dtpFechaContratacion = New System.Windows.Forms.DateTimePicker()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.txtSalario = New System.Windows.Forms.TextBox()
        Me.txtNombreCompleto = New System.Windows.Forms.TextBox()
        Me.txtCargo = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblSalario = New System.Windows.Forms.Label()
        Me.lblFechaContratacion = New System.Windows.Forms.Label()
        Me.lblNombreCompleto = New System.Windows.Forms.Label()
        Me.lblCargo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'dtpFechaContratacion
        '
        Me.dtpFechaContratacion.Location = New System.Drawing.Point(121, 148)
        Me.dtpFechaContratacion.Name = "dtpFechaContratacion"
        Me.dtpFechaContratacion.Size = New System.Drawing.Size(207, 20)
        Me.dtpFechaContratacion.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Location = New System.Drawing.Point(12, 9)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(43, 13)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "lblTitulo"
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(121, 92)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(121, 21)
        Me.cmbDepartamento.TabIndex = 2
        '
        'txtSalario
        '
        Me.txtSalario.Location = New System.Drawing.Point(121, 119)
        Me.txtSalario.Name = "txtSalario"
        Me.txtSalario.Size = New System.Drawing.Size(207, 20)
        Me.txtSalario.TabIndex = 3
        '
        'txtNombreCompleto
        '
        Me.txtNombreCompleto.Location = New System.Drawing.Point(121, 37)
        Me.txtNombreCompleto.Name = "txtNombreCompleto"
        Me.txtNombreCompleto.Size = New System.Drawing.Size(207, 20)
        Me.txtNombreCompleto.TabIndex = 4
        '
        'txtCargo
        '
        Me.txtCargo.Location = New System.Drawing.Point(121, 63)
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.Size = New System.Drawing.Size(207, 20)
        Me.txtCargo.TabIndex = 5
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(12, 203)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(93, 203)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(12, 95)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(77, 13)
        Me.lblDepartamento.TabIndex = 8
        Me.lblDepartamento.Text = "Departamento:"
        '
        'lblSalario
        '
        Me.lblSalario.AutoSize = True
        Me.lblSalario.Location = New System.Drawing.Point(13, 122)
        Me.lblSalario.Name = "lblSalario"
        Me.lblSalario.Size = New System.Drawing.Size(42, 13)
        Me.lblSalario.TabIndex = 9
        Me.lblSalario.Text = "Salario:"
        '
        'lblFechaContratacion
        '
        Me.lblFechaContratacion.AutoSize = True
        Me.lblFechaContratacion.Location = New System.Drawing.Point(12, 154)
        Me.lblFechaContratacion.Name = "lblFechaContratacion"
        Me.lblFechaContratacion.Size = New System.Drawing.Size(103, 13)
        Me.lblFechaContratacion.TabIndex = 10
        Me.lblFechaContratacion.Text = "Fecha Contratacion:"
        '
        'lblNombreCompleto
        '
        Me.lblNombreCompleto.AutoSize = True
        Me.lblNombreCompleto.Location = New System.Drawing.Point(12, 40)
        Me.lblNombreCompleto.Name = "lblNombreCompleto"
        Me.lblNombreCompleto.Size = New System.Drawing.Size(94, 13)
        Me.lblNombreCompleto.TabIndex = 11
        Me.lblNombreCompleto.Text = "Nombre Completo:"
        '
        'lblCargo
        '
        Me.lblCargo.AutoSize = True
        Me.lblCargo.Location = New System.Drawing.Point(12, 66)
        Me.lblCargo.Name = "lblCargo"
        Me.lblCargo.Size = New System.Drawing.Size(38, 13)
        Me.lblCargo.TabIndex = 12
        Me.lblCargo.Text = "Cargo:"
        '
        'frmEmpleado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 237)
        Me.Controls.Add(Me.lblCargo)
        Me.Controls.Add(Me.lblNombreCompleto)
        Me.Controls.Add(Me.lblFechaContratacion)
        Me.Controls.Add(Me.lblSalario)
        Me.Controls.Add(Me.lblDepartamento)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.txtCargo)
        Me.Controls.Add(Me.txtNombreCompleto)
        Me.Controls.Add(Me.txtSalario)
        Me.Controls.Add(Me.cmbDepartamento)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.dtpFechaContratacion)
        Me.Name = "frmEmpleado"
        Me.Text = "frmEmpleado"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtpFechaContratacion As DateTimePicker
    Friend WithEvents lblTitulo As Label
    Friend WithEvents cmbDepartamento As ComboBox
    Friend WithEvents txtSalario As TextBox
    Friend WithEvents txtNombreCompleto As TextBox
    Friend WithEvents txtCargo As TextBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblDepartamento As Label
    Friend WithEvents lblSalario As Label
    Friend WithEvents lblFechaContratacion As Label
    Friend WithEvents lblNombreCompleto As Label
    Friend WithEvents lblCargo As Label
End Class
