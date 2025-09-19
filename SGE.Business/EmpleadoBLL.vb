Imports SGE.DataAccess
Imports SGE.Models

Public Class EmpleadoBLL
    Private empleadoDAL As EmpleadoDAL

    Public Sub New()
        empleadoDAL = New EmpleadoDAL()
    End Sub

    Public Sub New(cadenaConexion As String)
        empleadoDAL = New EmpleadoDAL(cadenaConexion)
    End Sub

    ' Validar datos del empleado
    Public Function ValidarEmpleado(empleado As Empleado) As String
        If String.IsNullOrWhiteSpace(empleado.NombreCompleto) Then
            Return "El nombre completo es obligatorio."
        End If

        If empleado.NombreCompleto.Length < 3 Then
            Return "El nombre completo debe tener al menos 3 caracteres."
        End If

        If String.IsNullOrWhiteSpace(empleado.Cargo) Then
            Return "El cargo es obligatorio."
        End If

        If empleado.Salario <= 0 Then
            Return "El salario debe ser mayor a cero."
        End If

        If empleado.DepartamentoID <= 0 Then
            Return "Debe seleccionar un departamento válido."
        End If

        If empleado.FechaContratacion > Date.Now Then
            Return "La fecha de contratación no puede ser futura."
        End If

        Return String.Empty ' Sin errores
    End Function

    ' Obtener todos los empleados
    Public Function ObtenerTodosLosEmpleados() As List(Of Empleado)
        Try
            Return empleadoDAL.ObtenerTodosLosEmpleados()
        Catch ex As Exception
            Throw New Exception($"Error en la lógica de negocio: {ex.Message}")
        End Try
    End Function

    ' Buscar empleados
    Public Function BuscarEmpleados(termino As String) As List(Of Empleado)
        If String.IsNullOrWhiteSpace(termino) Then
            Return ObtenerTodosLosEmpleados()
        End If

        Try
            Return empleadoDAL.BuscarEmpleados(termino.Trim())
        Catch ex As Exception
            Throw New Exception($"Error al buscar empleados: {ex.Message}")
        End Try
    End Function

    ' Obtener empleado por ID
    Public Function ObtenerEmpleadoPorID(id As Integer) As Empleado
        If id <= 0 Then
            Throw New ArgumentException("ID de empleado inválido.")
        End If

        Try
            Return empleadoDAL.ObtenerEmpleadoPorID(id)
        Catch ex As Exception
            Throw New Exception($"Error al obtener empleado: {ex.Message}")
        End Try
    End Function

    ' Guardar empleado (insertar o actualizar)
    Public Function GuardarEmpleado(empleado As Empleado) As String
        ' Validar datos
        Dim mensajeValidacion As String = ValidarEmpleado(empleado)
        If Not String.IsNullOrEmpty(mensajeValidacion) Then
            Return mensajeValidacion
        End If

        Try
            If empleado.ID = 0 Then
                ' Insertar nuevo empleado
                Dim nuevoID As Integer = empleadoDAL.InsertarEmpleado(empleado)
                If nuevoID > 0 Then
                    empleado.ID = nuevoID
                    Return "Empleado creado exitosamente."
                Else
                    Return "Error al crear el empleado."
                End If
            Else
                ' Actualizar empleado existente
                If empleadoDAL.ActualizarEmpleado(empleado) Then
                    Return "Empleado actualizado exitosamente."
                Else
                    Return "Error al actualizar el empleado."
                End If
            End If
        Catch ex As Exception
            Return $"Error al guardar empleado: {ex.Message}"
        End Try
    End Function

    ' Eliminar empleado
    Public Function EliminarEmpleado(id As Integer) As String
        If id <= 0 Then
            Return "ID de empleado inválido."
        End If

        Try
            If empleadoDAL.EliminarEmpleado(id) Then
                Return "Empleado eliminado exitosamente."
            Else
                Return "Error al eliminar el empleado."
            End If
        Catch ex As Exception
            Return $"Error al eliminar empleado: {ex.Message}"
        End Try
    End Function

    ' Obtener departamentos
    Public Function ObtenerDepartamentos() As Dictionary(Of Integer, String)
        Try
            Return empleadoDAL.ObtenerDepartamentos()
        Catch ex As Exception
            Throw New Exception($"Error al obtener departamentos: {ex.Message}")
        End Try
    End Function

    ' Obtener estadísticas
    Public Function ObtenerEstadisticas() As Dictionary(Of String, Object)
        Try
            Dim empleados As List(Of Empleado) = ObtenerTodosLosEmpleados()
            Dim estadisticas As New Dictionary(Of String, Object)()

            estadisticas("TotalEmpleados") = empleados.Count

            If empleados.Count > 0 Then
                estadisticas("SalarioPromedio") = empleados.Average(Function(e) e.Salario)
                estadisticas("SalarioMaximo") = empleados.Max(Function(e) e.Salario)
                estadisticas("SalarioMinimo") = empleados.Min(Function(e) e.Salario)

                ' Empleados contratados en los últimos 30 días
                Dim fechaLimite As Date = Date.Now.AddDays(-30)
                estadisticas("NuevosUltimoMes") = empleados.Where(Function(e) e.FechaContratacion >= fechaLimite).Count()

                ' Agrupar por departamento
                Dim porDepartamento = empleados.GroupBy(Function(e) e.Departamento).
                                               Select(Function(g) New With {
                                                   .Departamento = g.Key,
                                                   .Cantidad = g.Count()
                                               }).ToList()
                estadisticas("PorDepartamento") = porDepartamento
            Else
                estadisticas("SalarioPromedio") = 0
                estadisticas("SalarioMaximo") = 0
                estadisticas("SalarioMinimo") = 0
                estadisticas("NuevosUltimoMes") = 0
                estadisticas("PorDepartamento") = New List(Of Object)()
            End If

            Return estadisticas
        Catch ex As Exception
            Throw New Exception($"Error al obtener estadísticas: {ex.Message}")
        End Try
    End Function

    ' Probar conexión
    Public Function ProbarConexion() As Boolean
        Try
            Return empleadoDAL.ProbarConexion()
        Catch
            Return False
        End Try
    End Function
End Class

