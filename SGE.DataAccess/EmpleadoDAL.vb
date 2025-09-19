Imports System.Configuration
Imports System.Data.SqlClient
Imports SGE.Models

Public Class EmpleadoDAL

    Private connectionString As String = String.Empty

    ' Constructor que permite personalizar la cadena de conexión
    Public Sub New()
        ' Se puede leer desde app.config si es necesario
        connectionString = ConfigurationManager.ConnectionStrings("SGE_Database").ConnectionString
    End Sub

    Public Sub New(cadenaConexion As String)
        connectionString = cadenaConexion
    End Sub

    ' Obtener todos los empleados activos
    Public Function ObtenerTodosLosEmpleados() As List(Of Empleado)
        Dim empleados As New List(Of Empleado)()

        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("sp_ListarEmpleados", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            empleados.Add(New Empleado(
                                Convert.ToInt32(reader("ID")),
                                reader("NombreCompleto").ToString(),
                                Convert.ToDateTime(reader("FechaContratacion")),
                                reader("Cargo").ToString(),
                                Convert.ToDecimal(reader("Salario")),
                                0, ' No necesitamos el DepartamentoID aquí
                                reader("Departamento").ToString(),
                                Convert.ToBoolean(reader("Estado"))
                            ))
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception($"Error al obtener empleados: {ex.Message}")
            End Try
        End Using

        Return empleados
    End Function

    ' Buscar empleados por término
    Public Function BuscarEmpleados(termino As String) As List(Of Empleado)
        Dim empleados As New List(Of Empleado)()

        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("sp_BuscarEmpleados", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@Termino", termino)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            empleados.Add(New Empleado(
                                Convert.ToInt32(reader("ID")),
                                reader("NombreCompleto").ToString(),
                                Convert.ToDateTime(reader("FechaContratacion")),
                                reader("Cargo").ToString(),
                                Convert.ToDecimal(reader("Salario")),
                                0,
                                reader("Departamento").ToString(),
                                Convert.ToBoolean(reader("Estado"))
                            ))
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception($"Error al buscar empleados: {ex.Message}")
            End Try
        End Using

        Return empleados
    End Function

    ' Obtener empleado por ID
    Public Function ObtenerEmpleadoPorID(id As Integer) As Empleado
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("sp_ObtenerEmpleadoPorID", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", id)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            Return New Empleado(
                                Convert.ToInt32(reader("ID")),
                                reader("NombreCompleto").ToString(),
                                Convert.ToDateTime(reader("FechaContratacion")),
                                reader("Cargo").ToString(),
                                Convert.ToDecimal(reader("Salario")),
                                Convert.ToInt32(reader("DepartamentoID")),
                                reader("Departamento").ToString(),
                                Convert.ToBoolean(reader("Estado"))
                            )
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception($"Error al obtener empleado: {ex.Message}")
            End Try
        End Using

        Return Nothing
    End Function

    ' Insertar nuevo empleado
    Public Function InsertarEmpleado(empleado As Empleado) As Integer
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("sp_InsertarEmpleado", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@NombreCompleto", empleado.NombreCompleto)
                    command.Parameters.AddWithValue("@FechaContratacion", empleado.FechaContratacion)
                    command.Parameters.AddWithValue("@Cargo", empleado.Cargo)
                    command.Parameters.AddWithValue("@Salario", empleado.Salario)
                    command.Parameters.AddWithValue("@DepartamentoID", empleado.DepartamentoID)

                    Dim resultado = command.ExecuteScalar()
                    Return Convert.ToInt32(resultado)
                End Using
            Catch ex As Exception
                Throw New Exception($"Error al insertar empleado: {ex.Message}")
            End Try
        End Using
    End Function

    ' Actualizar empleado
    Public Function ActualizarEmpleado(empleado As Empleado) As Boolean
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("sp_ActualizarEmpleado", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", empleado.ID)
                    command.Parameters.AddWithValue("@NombreCompleto", empleado.NombreCompleto)
                    command.Parameters.AddWithValue("@FechaContratacion", empleado.FechaContratacion)
                    command.Parameters.AddWithValue("@Cargo", empleado.Cargo)
                    command.Parameters.AddWithValue("@Salario", empleado.Salario)
                    command.Parameters.AddWithValue("@DepartamentoID", empleado.DepartamentoID)

                    Dim filasAfectadas As Integer = command.ExecuteNonQuery()
                    Return filasAfectadas > 0
                End Using
            Catch ex As Exception
                Throw New Exception($"Error al actualizar empleado: {ex.Message}")
            End Try
        End Using
    End Function

    ' Eliminar empleado (eliminación lógica)
    Public Function EliminarEmpleado(id As Integer) As Boolean
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("sp_EliminarEmpleado", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", id)

                    Dim filasAfectadas As Integer = command.ExecuteNonQuery()
                    Return filasAfectadas > 0
                End Using
            Catch ex As Exception
                Throw New Exception($"Error al eliminar empleado: {ex.Message}")
            End Try
        End Using
    End Function

    ' Obtener departamentos
    Public Function ObtenerDepartamentos() As Dictionary(Of Integer, String)
        Dim departamentos As New Dictionary(Of Integer, String)()

        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("sp_ListarDepartamentos", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            departamentos.Add(Convert.ToInt32(reader("ID")), reader("Nombre").ToString())
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception($"Error al obtener departamentos: {ex.Message}")
            End Try
        End Using

        Return departamentos
    End Function

    ' Probar conexión a la base de datos
    Public Function ProbarConexion() As Boolean
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Return True
            End Using
        Catch
            Return False
        End Try
    End Function
End Class
