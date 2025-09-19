Public Class Empleado
    Public Property ID As Integer
    Public Property NombreCompleto As String
    Public Property FechaContratacion As Date
    Public Property Cargo As String
    Public Property Salario As Decimal
    Public Property DepartamentoID As Integer
    Public Property Departamento As String
    Public Property Estado As Boolean

    Public Sub New()
        Me.ID = 0
        Me.NombreCompleto = ""
        Me.FechaContratacion = Date.Now
        Me.Cargo = ""
        Me.Salario = 0
        Me.DepartamentoID = 0
        Me.Departamento = ""
        Me.Estado = True
    End Sub

    Public Sub New(id As Integer, nombreCompleto As String, fechaContratacion As Date,
                   cargo As String, salario As Decimal, departamentoID As Integer,
                   departamento As String, estado As Boolean)
        Me.ID = id
        Me.NombreCompleto = nombreCompleto
        Me.FechaContratacion = fechaContratacion
        Me.Cargo = cargo
        Me.Salario = salario
        Me.DepartamentoID = departamentoID
        Me.Departamento = departamento
        Me.Estado = estado
    End Sub

    Public ReadOnly Property SalarioFormateado As String
        Get
            Return Salario.ToString("C", Globalization.CultureInfo.GetCultureInfo("es-CO"))
        End Get
    End Property

    Public ReadOnly Property FechaContratacionCorta As String
        Get
            Return FechaContratacion.ToString("dd/MM/yyyy")
        End Get
    End Property
End Class

