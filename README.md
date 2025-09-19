La aplicación SGE es un sistema de gestión empresarial desarrollado en Visual Basic .NET utilizando Windows Forms. Su objetivo principal es administrar información relacionada con empleados y departamentos dentro de una organización.
¿Qué hace la aplicación?
La aplicación permite:
•	Registrar, editar y gestionar empleados.
•	Asignar empleados a departamentos.
•	Validar y guardar información relevante como nombre, cargo, salario y fecha de contratación.
¿Cómo está construida?
La aplicación está estructurada en varias capas y componentes:
•	Capa de Presentación (WinForms): Formularios como frmEmpleado y FrmPrincipal para la interacción con el usuario.
•	Capa de Negocio (SGE.Business): Clases como EmpleadoBLL que contienen la lógica de negocio para procesar y validar datos.
•	Capa de Datos (SGE.DataAccess): Clases como EmpleadoDAL para acceder y manipular la base de datos.
•	Modelos (SGE.Models): Clases como Empleado que representan las entidades del sistema.
•	Utilidades (SGE.Common): Funciones auxiliares para validaciones y manejo de errores.
Componentes clave
•	Formularios: frmEmpleado para gestión de empleados, FrmPrincipal como ventana principal.
•	Clases de Negocio: EmpleadoBLL para operaciones de empleados.
•	Clases de Datos: EmpleadoDAL para interacción con la base de datos.
•	Modelos: Empleado para representar la información de cada empleado.
•	Utilidades: Métodos para validaciones y mensajes al usuario.
