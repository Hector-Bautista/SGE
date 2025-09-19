<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrincipal
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
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.lblFechaHora = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.dgvEmpleados = New System.Windows.Forms.DataGridView()
        Me.lblTotalDepartamentos = New System.Windows.Forms.Label()
        Me.lblTotalEmpleadosStats = New System.Windows.Forms.Label()
        Me.lblSalarioPromedio = New System.Windows.Forms.Label()
        Me.lblNuevosEmpleados = New System.Windows.Forms.Label()
        Me.lblBienvenida = New System.Windows.Forms.Label()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblSalario = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblDepartamentos = New System.Windows.Forms.Label()
        CType(Me.dgvEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(4, 675)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(50, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "lblEstado"
        '
        'lblFechaHora
        '
        Me.lblFechaHora.AutoSize = True
        Me.lblFechaHora.Location = New System.Drawing.Point(1241, 675)
        Me.lblFechaHora.Name = "lblFechaHora"
        Me.lblFechaHora.Size = New System.Drawing.Size(70, 13)
        Me.lblFechaHora.TabIndex = 1
        Me.lblFechaHora.Text = "lblFechaHora"
        '
        'Timer1
        '
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(1218, 6)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(100, 20)
        Me.txtBuscar.TabIndex = 2
        '
        'dgvEmpleados
        '
        Me.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmpleados.Location = New System.Drawing.Point(12, 36)
        Me.dgvEmpleados.Name = "dgvEmpleados"
        Me.dgvEmpleados.Size = New System.Drawing.Size(1020, 597)
        Me.dgvEmpleados.TabIndex = 3
        '
        'lblTotalDepartamentos
        '
        Me.lblTotalDepartamentos.AutoSize = True
        Me.lblTotalDepartamentos.Location = New System.Drawing.Point(1161, 134)
        Me.lblTotalDepartamentos.Name = "lblTotalDepartamentos"
        Me.lblTotalDepartamentos.Size = New System.Drawing.Size(113, 13)
        Me.lblTotalDepartamentos.TabIndex = 4
        Me.lblTotalDepartamentos.Text = "lblTotalDepartamentos"
        '
        'lblTotalEmpleadosStats
        '
        Me.lblTotalEmpleadosStats.AutoSize = True
        Me.lblTotalEmpleadosStats.Location = New System.Drawing.Point(1161, 52)
        Me.lblTotalEmpleadosStats.Name = "lblTotalEmpleadosStats"
        Me.lblTotalEmpleadosStats.Size = New System.Drawing.Size(117, 13)
        Me.lblTotalEmpleadosStats.TabIndex = 6
        Me.lblTotalEmpleadosStats.Text = "lblTotalEmpleadosStats"
        '
        'lblSalarioPromedio
        '
        Me.lblSalarioPromedio.AutoSize = True
        Me.lblSalarioPromedio.Location = New System.Drawing.Point(1161, 78)
        Me.lblSalarioPromedio.Name = "lblSalarioPromedio"
        Me.lblSalarioPromedio.Size = New System.Drawing.Size(93, 13)
        Me.lblSalarioPromedio.TabIndex = 7
        Me.lblSalarioPromedio.Text = "lblSalarioPromedio"
        '
        'lblNuevosEmpleados
        '
        Me.lblNuevosEmpleados.AutoSize = True
        Me.lblNuevosEmpleados.Location = New System.Drawing.Point(1161, 106)
        Me.lblNuevosEmpleados.Name = "lblNuevosEmpleados"
        Me.lblNuevosEmpleados.Size = New System.Drawing.Size(106, 13)
        Me.lblNuevosEmpleados.TabIndex = 8
        Me.lblNuevosEmpleados.Text = "lblNuevosEmpleados"
        '
        'lblBienvenida
        '
        Me.lblBienvenida.AutoSize = True
        Me.lblBienvenida.Location = New System.Drawing.Point(12, 9)
        Me.lblBienvenida.Name = "lblBienvenida"
        Me.lblBienvenida.Size = New System.Drawing.Size(70, 13)
        Me.lblBienvenida.TabIndex = 9
        Me.lblBienvenida.Text = "lblBienvenida"
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(12, 639)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 10
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Location = New System.Drawing.Point(93, 639)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(75, 23)
        Me.btnEditar.TabIndex = 11
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(255, 639)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnActualizar.TabIndex = 12
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(174, 639)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 13
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1169, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Buscar:"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(1066, 52)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(89, 13)
        Me.lblTotal.TabIndex = 15
        Me.lblTotal.Text = "Total Empleados:"
        '
        'lblSalario
        '
        Me.lblSalario.AutoSize = True
        Me.lblSalario.Location = New System.Drawing.Point(1066, 78)
        Me.lblSalario.Name = "lblSalario"
        Me.lblSalario.Size = New System.Drawing.Size(89, 13)
        Me.lblSalario.TabIndex = 16
        Me.lblSalario.Text = "Salario Promedio:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1053, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Empleados Nuevos:"
        '
        'lblDepartamentos
        '
        Me.lblDepartamentos.AutoSize = True
        Me.lblDepartamentos.Location = New System.Drawing.Point(1046, 134)
        Me.lblDepartamentos.Name = "lblDepartamentos"
        Me.lblDepartamentos.Size = New System.Drawing.Size(109, 13)
        Me.lblDepartamentos.TabIndex = 18
        Me.lblDepartamentos.Text = "Total Departamentos:"
        '
        'FrmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 729)
        Me.Controls.Add(Me.lblDepartamentos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblSalario)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.lblBienvenida)
        Me.Controls.Add(Me.lblNuevosEmpleados)
        Me.Controls.Add(Me.lblSalarioPromedio)
        Me.Controls.Add(Me.lblTotalEmpleadosStats)
        Me.Controls.Add(Me.lblTotalDepartamentos)
        Me.Controls.Add(Me.dgvEmpleados)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.lblFechaHora)
        Me.Controls.Add(Me.lblEstado)
        Me.Name = "FrmPrincipal"
        Me.Text = "SGE"
        CType(Me.dgvEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblEstado As Label
    Friend WithEvents lblFechaHora As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents dgvEmpleados As DataGridView
    Friend WithEvents lblTotalDepartamentos As Label
    Friend WithEvents lblTotalEmpleadosStats As Label
    Friend WithEvents lblSalarioPromedio As Label
    Friend WithEvents lblNuevosEmpleados As Label
    Friend WithEvents lblBienvenida As Label
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnActualizar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblSalario As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblDepartamentos As Label
End Class
