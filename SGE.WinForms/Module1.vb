Imports System.Threading

Module Module1
    Public Sub Main()

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)


        Try
            ' Mostrar splash screen
            Dim splash As New frmSplash()
            splash.Show()
            Application.DoEvents()

            ' Simular carga
            Thread.Sleep(2000)

            ' Cerrar splash
            splash.Close()

            ' Verificar conexión a la base de datos
            Dim empleadoBLL As New Business.EmpleadoBLL()
            If Not empleadoBLL.ProbarConexion() Then
                MessageBox.Show("No se pudo conectar a la base de datos. " & vbCrLf &
                               "Verifique que SQL Server esté funcionando y que la base de datos SGE_Database exista.",
                               "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            Application.Run(New FrmPrincipal())

        Catch ex As Exception
            MessageBox.Show($"Error crítico al iniciar la aplicación: {ex.Message}",
                           "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module
