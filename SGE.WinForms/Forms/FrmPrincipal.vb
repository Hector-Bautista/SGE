Imports SGE.Business
Imports SGE.Common
Imports SGE.Models

Public Class FrmPrincipal

    Private empleadoBLL As EmpleadoBLL
    Private empleados As List(Of Empleado)
    Private departamentos As Dictionary(Of Integer, String)

    ' Constructor del formulario
    Public Sub New()
        InitializeComponent()
        empleadoBLL = New EmpleadoBLL()
        empleados = New List(Of Empleado)()
        departamentos = New Dictionary(Of Integer, String)()
    End Sub

    ' Evento Load del formulario
    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ConfigurarFormulario()
            ConfigurarDataGridView()
            CargarDepartamentos()
            CargarEmpleados()
            ActualizarEstadisticas()
            MostrarMensajeBienvenida()
        Catch ex As Exception
            Utilidades.MostrarError($"Error al inicializar la aplicación: {ex.Message}", "Error de Inicialización")
        End Try
    End Sub

    ' Configurar la apariencia del formulario
    Private Sub ConfigurarFormulario()
        Me.Text = "Sistema de Gestión de Empleados (SGE) v1.0"
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.FromArgb(248, 249, 250)

        ' Configurar la barra de estado
        lblEstado.Text = "Listo"
        lblFechaHora.Text = Date.Now.ToString("dd/MM/yyyy HH:mm")

        ' Configurar timer para actualizar la hora
        Timer1.Interval = 1000
        Timer1.Start()

        ' Configurar búsqueda en tiempo real
        AddHandler txtBuscar.TextChanged, AddressOf txtBuscar_TextChanged
    End Sub

    ' Configurar el DataGridView
    Private Sub ConfigurarDataGridView()
        Utilidades.ConfigurarDataGridView(dgvEmpleados)

        dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Configurar columnas
        dgvEmpleados.Columns.Clear()

        dgvEmpleados.Columns.Add("ID", "ID")
        dgvEmpleados.Columns("ID").DataPropertyName = "ID"
        dgvEmpleados.Columns("ID").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvEmpleados.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        dgvEmpleados.Columns.Add("NombreCompleto", "Nombre Completo")
        dgvEmpleados.Columns("NombreCompleto").DataPropertyName = "NombreCompleto"
        dgvEmpleados.Columns("NombreCompleto").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        dgvEmpleados.Columns.Add("Cargo", "Cargo")
        dgvEmpleados.Columns("Cargo").DataPropertyName = "Cargo"
        dgvEmpleados.Columns("Cargo").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        dgvEmpleados.Columns.Add("Departamento", "Departamento")
        dgvEmpleados.Columns("Departamento").DataPropertyName = "Departamento"
        dgvEmpleados.Columns("Departamento").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        dgvEmpleados.Columns.Add("FechaContratacionCorta", "Fecha Contratación")
        dgvEmpleados.Columns("FechaContratacionCorta").DataPropertyName = "FechaContratacionCorta"
        dgvEmpleados.Columns("FechaContratacionCorta").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvEmpleados.Columns("FechaContratacionCorta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgvEmpleados.Columns.Add("SalarioFormateado", "Salario")
        dgvEmpleados.Columns("SalarioFormateado").DataPropertyName = "SalarioFormateado"
        dgvEmpleados.Columns("SalarioFormateado").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvEmpleados.Columns("SalarioFormateado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvEmpleados.Columns("SalarioFormateado").DefaultCellStyle.ForeColor = Color.Green
        dgvEmpleados.Columns("SalarioFormateado").DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
    End Sub

    ' Cargar departamentos
    Private Sub CargarDepartamentos()
        Try
            departamentos = empleadoBLL.ObtenerDepartamentos()

            ' Actualizar estadísticas de departamentos
            lblTotalDepartamentos.Text = departamentos.Count.ToString()
        Catch ex As Exception
            Utilidades.MostrarError($"Error al cargar departamentos: {ex.Message}", "Error")
        End Try
    End Sub


    ' Cargar empleados
    Private Sub CargarEmpleados()
        Try
            lblEstado.Text = "Cargando empleados..."
            empleados = empleadoBLL.ObtenerTodosLosEmpleados()

            dgvEmpleados.DataSource = Nothing
            dgvEmpleados.DataSource = empleados

            lblEstado.Text = "Empleados cargados correctamente"

        Catch ex As Exception
            Utilidades.MostrarError($"Error al cargar empleados: {ex.Message}", "Error")
            lblEstado.Text = "Error al cargar empleados"
        End Try
    End Sub

    ' Actualizar estadísticas
    Private Sub ActualizarEstadisticas()
        Try
            Dim estadisticas As Dictionary(Of String, Object) = empleadoBLL.ObtenerEstadisticas()

            lblTotalEmpleadosStats.Text = estadisticas("TotalEmpleados").ToString()
            lblSalarioPromedio.Text = Utilidades.FormatearSalario(Convert.ToDecimal(estadisticas("SalarioPromedio")))
            lblNuevosEmpleados.Text = estadisticas("NuevosUltimoMes").ToString()

        Catch ex As Exception
            ' Si hay error, mostrar valores por defecto
            lblTotalEmpleadosStats.Text = "0"
            lblSalarioPromedio.Text = "$0"
            lblNuevosEmpleados.Text = "0"
        End Try
    End Sub


    ' Mostrar mensaje de bienvenida
    Private Sub MostrarMensajeBienvenida()
        lblBienvenida.Text = $"¡Bienvenido al Sistema de Gestión de Empleados! Hoy es {Date.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy")}"
    End Sub

    ' Evento del timer para actualizar la hora
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblFechaHora.Text = Date.Now.ToString("dd/MM/yyyy HH:mm:ss")
    End Sub

    ' Evento de búsqueda en tiempo real
    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs)
        BuscarEmpleados()
    End Sub

    ' Buscar empleados
    Private Sub BuscarEmpleados()
        Try
            Dim termino As String = txtBuscar.Text.Trim()

            If String.IsNullOrEmpty(termino) Then
                dgvEmpleados.DataSource = empleados
            Else
                Dim empleadosFiltrados = empleados.Where(Function(emp) emp.NombreCompleto.ToUpper().Contains(termino.ToUpper()) OrElse
                    emp.ID.ToString().Contains(termino) OrElse
                    emp.Cargo.ToUpper().Contains(termino.ToUpper()) OrElse
                    emp.Departamento.ToUpper().Contains(termino.ToUpper()) OrElse
                    emp.FechaContratacion.ToString("dd/MM/yyyy").Contains(termino)
                ).ToList()

                dgvEmpleados.DataSource = empleadosFiltrados
            End If

        Catch ex As Exception
            Utilidades.MostrarError($"Error al buscar empleados: {ex.Message}", "Error de Búsqueda")
        End Try
    End Sub

    ' Botón Nuevo Empleado
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            Dim frmEmpleado As New frmEmpleado(departamentos)
            If frmEmpleado.ShowDialog() = DialogResult.OK Then
                CargarEmpleados()
                ActualizarEstadisticas()
                Utilidades.MostrarInformacion("Empleado creado exitosamente.", "Éxito")
            End If
        Catch ex As Exception
            Utilidades.MostrarError($"Error al abrir formulario de empleado: {ex.Message}", "Error")
        End Try
    End Sub

    ' Botón Editar Empleado
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            If dgvEmpleados.SelectedRows.Count = 0 Then
                Utilidades.MostrarAdvertencia("Seleccione un empleado para editar.", "Advertencia")
                Return
            End If

            Dim empleadoSeleccionado As Empleado = DirectCast(dgvEmpleados.SelectedRows(0).DataBoundItem, Empleado)
            Dim empleadoCompleto As Empleado = empleadoBLL.ObtenerEmpleadoPorID(empleadoSeleccionado.ID)

            If empleadoCompleto IsNot Nothing Then
                Dim frmEmpleado As New frmEmpleado(departamentos, empleadoCompleto)
                If frmEmpleado.ShowDialog() = DialogResult.OK Then
                    CargarEmpleados()
                    ActualizarEstadisticas()
                    Utilidades.MostrarInformacion("Empleado actualizado exitosamente.", "Éxito")
                End If
            Else
                Utilidades.MostrarError("No se pudo cargar la información del empleado.", "Error")
            End If
        Catch ex As Exception
            Utilidades.MostrarError($"Error al editar empleado: {ex.Message}", "Error")
        End Try
    End Sub

    ' Botón Eliminar Empleado
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvEmpleados.SelectedRows.Count = 0 Then
                Utilidades.MostrarAdvertencia("Seleccione un empleado para eliminar.", "Advertencia")
                Return
            End If

            Dim empleadoSeleccionado As Empleado = DirectCast(dgvEmpleados.SelectedRows(0).DataBoundItem, Empleado)

            If Utilidades.MostrarConfirmacion(
                $"¿Está seguro que desea eliminar al empleado '{empleadoSeleccionado.NombreCompleto}'?" & vbCrLf & vbCrLf &
                "Esta acción no se puede deshacer.", "Confirmar Eliminación") Then

                Dim resultado As String = empleadoBLL.EliminarEmpleado(empleadoSeleccionado.ID)

                If resultado.Contains("exitosamente") Then
                    CargarEmpleados()
                    ActualizarEstadisticas()
                    Utilidades.MostrarInformacion(resultado, "Éxito")
                Else
                    Utilidades.MostrarError(resultado, "Error")
                End If
            End If
        Catch ex As Exception
            Utilidades.MostrarError($"Error al eliminar empleado: {ex.Message}", "Error")
        End Try
    End Sub

    ' Botón Actualizar
    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        CargarEmpleados()
        ActualizarEstadisticas()
    End Sub

    ' Doble clic en el DataGridView para editar
    Private Sub dgvEmpleados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpleados.CellDoubleClick
        If e.RowIndex >= 0 Then
            btnEditar_Click(sender, e)
        End If
    End Sub

End Class

