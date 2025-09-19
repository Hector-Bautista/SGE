Imports SGE.Business
Imports SGE.Common
Imports SGE.Models

Public Class frmEmpleado
    Private empleadoBLL As EmpleadoBLL
    Private empleadoActual As Empleado
    Private departamentos As Dictionary(Of Integer, String)
    Private esNuevo As Boolean

    ' Constructores
    Public Sub New(departamentosDisponibles As Dictionary(Of Integer, String))
        InitializeComponent()
        empleadoBLL = New EmpleadoBLL()
        departamentos = departamentosDisponibles
        empleadoActual = New Empleado()
        esNuevo = True
    End Sub

    Public Sub New(departamentosDisponibles As Dictionary(Of Integer, String), empleado As Empleado)
        InitializeComponent()
        empleadoBLL = New EmpleadoBLL()
        departamentos = departamentosDisponibles
        empleadoActual = empleado
        esNuevo = False
    End Sub

    ' Evento Load del formulario
    Private Sub frmEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarFormulario()
        CargarDepartamentos()
        ConfigurarValidaciones()

        If Not esNuevo Then
            CargarDatosEmpleado()
        Else
            dtpFechaContratacion.MinDate = New DateTime(1900, 1, 1)
            dtpFechaContratacion.MaxDate = New DateTime(2100, 12, 31)
            dtpFechaContratacion.Value = Date.Now
        End If
    End Sub

    ' Configurar el formulario
    Private Sub ConfigurarFormulario()
        If esNuevo Then
            Me.Text = "Nuevo Empleado"
            lblTitulo.Text = "REGISTRAR NUEVO EMPLEADO"
        Else
            Me.Text = $"Editar Empleado - {empleadoActual.NombreCompleto}"
            lblTitulo.Text = "EDITAR INFORMACIÓN DEL EMPLEADO"
        End If

        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
    End Sub

    ' Cargar departamentos en el ComboBox
    Private Sub CargarDepartamentos()
        Try
            cmbDepartamento.DataSource = Nothing
            cmbDepartamento.Items.Clear()

            For Each depto In departamentos
                cmbDepartamento.Items.Add(New ComboBoxItem(depto.Value, depto.Key))
            Next

            cmbDepartamento.DisplayMember = "Text"
            cmbDepartamento.ValueMember = "Value"

        Catch ex As Exception
            Utilidades.MostrarError($"Error al cargar departamentos: {ex.Message}", "Error")
        End Try
    End Sub

    ' Configurar validaciones
    Private Sub ConfigurarValidaciones()
        ' Solo números en salario
        AddHandler txtSalario.KeyPress, AddressOf Utilidades.SoloNumeros

        ' Solo letras en nombre
        AddHandler txtNombreCompleto.KeyPress, AddressOf Utilidades.SoloLetras

        ' Limitar fecha máxima
        dtpFechaContratacion.MaxDate = Date.Now
        dtpFechaContratacion.MinDate = New Date(1950, 1, 1)
    End Sub

    ' Cargar datos del empleado para edición
    Private Sub CargarDatosEmpleado()
        Try
            txtNombreCompleto.Text = empleadoActual.NombreCompleto
            txtCargo.Text = empleadoActual.Cargo
            dtpFechaContratacion.Value = empleadoActual.FechaContratacion
            txtSalario.Text = empleadoActual.Salario.ToString()

            ' Seleccionar departamento
            For i As Integer = 0 To cmbDepartamento.Items.Count - 1
                Dim item As ComboBoxItem = DirectCast(cmbDepartamento.Items(i), ComboBoxItem)
                If item.Value = empleadoActual.DepartamentoID Then
                    cmbDepartamento.SelectedIndex = i
                    Exit For
                End If
            Next

        Catch ex As Exception
            Utilidades.MostrarError($"Error al cargar datos del empleado: {ex.Message}", "Error")
        End Try
    End Sub

    ' Botón Guardar
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If Not ValidarDatos() Then
                Return
            End If

            ' Actualizar datos del empleado
            empleadoActual.NombreCompleto = txtNombreCompleto.Text.Trim()
            empleadoActual.Cargo = txtCargo.Text.Trim()
            empleadoActual.FechaContratacion = dtpFechaContratacion.Value.Date
            empleadoActual.Salario = Convert.ToDecimal(txtSalario.Text)

            If cmbDepartamento.SelectedItem IsNot Nothing Then
                Dim selectedItem As ComboBoxItem = DirectCast(cmbDepartamento.SelectedItem, ComboBoxItem)
                empleadoActual.DepartamentoID = selectedItem.Value
            End If

            ' Guardar empleado
            Dim resultado As String = empleadoBLL.GuardarEmpleado(empleadoActual)

            If resultado.Contains("exitosamente") Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                Utilidades.MostrarError(resultado, "Error al Guardar")
            End If

        Catch ex As Exception
            Utilidades.MostrarError($"Error al guardar empleado: {ex.Message}", "Error")
        End Try
    End Sub

    ' Validar datos del formulario
    Private Function ValidarDatos() As Boolean
        ' Validar nombre completo
        If String.IsNullOrWhiteSpace(txtNombreCompleto.Text) Then
            Utilidades.MostrarAdvertencia("El nombre completo es obligatorio.", "Validación")
            txtNombreCompleto.Focus()
            Return False
        End If

        If txtNombreCompleto.Text.Trim().Length < 3 Then
            Utilidades.MostrarAdvertencia("El nombre completo debe tener al menos 3 caracteres.", "Validación")
            txtNombreCompleto.Focus()
            Return False
        End If

        ' Validar cargo
        If String.IsNullOrWhiteSpace(txtCargo.Text) Then
            Utilidades.MostrarAdvertencia("El cargo es obligatorio.", "Validación")
            txtCargo.Focus()
            Return False
        End If

        ' Validar salario
        Dim salario As Decimal
        If Not Decimal.TryParse(txtSalario.Text, salario) OrElse salario <= 0 Then
            Utilidades.MostrarAdvertencia("Ingrese un salario válido mayor a cero.", "Validación")
            txtSalario.Focus()
            Return False
        End If

        ' Validar departamento
        If cmbDepartamento.SelectedIndex = -1 Then
            Utilidades.MostrarAdvertencia("Seleccione un departamento.", "Validación")
            cmbDepartamento.Focus()
            Return False
        End If

        ' Validar fecha de contratación
        If dtpFechaContratacion.Value > Date.Now Then
            Utilidades.MostrarAdvertencia("La fecha de contratación no puede ser futura.", "Validación")
            dtpFechaContratacion.Focus()
            Return False
        End If

        Return True
    End Function

    ' Botón Cancelar
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' Clase auxiliar para ComboBox
    Private Class ComboBoxItem
        Public Property Text As String
        Public Property Value As Integer

        Public Sub New(texto As String, valor As Integer)
            Text = texto
            Value = valor
        End Sub

        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class

End Class
