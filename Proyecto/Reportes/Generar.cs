using Entidades;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportes
{
    public class Generar
    {
        /// <summary>
        /// Genera el informe de los beneficiarios
        /// </summary>
        /// <param name="beneficiarios"></param>
        /// <param name="ides"></param>
        /// <returns></returns>
        public static string Beneficiarios(List<Beneficiario> beneficiarios, List<int> ides)
        {
            ExcelPackage ExcelPkg = new ExcelPackage();
            ExcelWorksheet wsSheet1 = ExcelPkg.Workbook.Worksheets.Add("Hoja1");

            // wsSheet1.Cells.Style.Font.Name = "Montserrat";
            wsSheet1.Cells.Style.Font.Name = "Roboto";

            using (ExcelRange Rng = wsSheet1.Cells["B2:I2"])
            {
                Rng.Value = "Informe de Beneficiarios";

                Rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                Rng.Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(1, 46, 103));

                Rng.Merge = true;

                Rng.Style.Font.Size = 16;

                Rng.Style.Font.Bold = true;
            }

            using (ExcelRange Rng = wsSheet1.Cells["B4:I" + (ides.Count + 4)])
            {
                // Acceso indirecto a la clase ExcelTableCollection
                ExcelTable table = wsSheet1.Tables.Add(Rng, "tblBeneficiario");
                //table.Name = "tblBeneficiario";

                // Establecer posicion y nombre de columnas
                table.Columns[0].Name = "ID";
                table.Columns[1].Name = "Apellido";
                table.Columns[2].Name = "Nombre";
                table.Columns[3].Name = "DNI";
                table.Columns[4].Name = "Cuil";
                table.Columns[5].Name = "Email";
                table.Columns[6].Name = "Nivel de Escolaridad";
                table.Columns[7].Name = "Candidato";

                //table.ShowHeader = false;
                table.ShowFilter = true;
                //table.ShowTotal = true;
            }

            // Insertar datos en las celdas de la tabla de Excel
            var i = 5;
            var indiceBen = 0;

            foreach (var id in ides)
            {
                // [ID] Columna
                using (ExcelRange Rng = wsSheet1.Cells["B" + i++]) { Rng.Value = id; }

                i--;

                // [APELLIDO] Columna                
                using (ExcelRange Rng = wsSheet1.Cells["C" + i]) { Rng.Value = beneficiarios[indiceBen].Apellido; }

                // [NOMBRE] Columna
                using (ExcelRange Rng = wsSheet1.Cells["D" + i]) { Rng.Value = beneficiarios[indiceBen].Nombre; }

                // [DNI] Columna
                using (ExcelRange Rng = wsSheet1.Cells["E" + i]) { Rng.Value = beneficiarios[indiceBen].DNI; }

                // [CUIL] Columna
                using (ExcelRange Rng = wsSheet1.Cells["F" + i]) { Rng.Value = beneficiarios[indiceBen].Cuil; }

                // [EMAIL] Columna
                using (ExcelRange Rng = wsSheet1.Cells["G" + i]) { Rng.Value = beneficiarios[indiceBen].Email; }

                // [NIVEL DE ESCOLARIDAD] Columna
                using (ExcelRange Rng = wsSheet1.Cells["H" + i]) { Rng.Value = beneficiarios[indiceBen].NivelDeEscolaridad; }

                // [CANDIDATO] Columna
                if (beneficiarios[indiceBen].Candidato)
                {
                    using (ExcelRange Rng = wsSheet1.Cells["I" + i]) { Rng.Value = "SI"; }
                }
                else
                {
                    using (ExcelRange Rng = wsSheet1.Cells["I" + i]) { Rng.Value = "NO"; }
                }

                i++;
                indiceBen++;
            }

            wsSheet1.Cells[wsSheet1.Dimension.Address].AutoFitColumns();
            ExcelPkg.SaveAs(new FileInfo(@"InformeBeneficiarios.xlsx"));

            return "Informe Creado";
        }


        /// <summary>
        /// Genera el informe de los empleados
        /// </summary>
        /// <param name="instructores"></param>
        /// <param name="idesInstructores"></param>
        /// <param name="tutores"></param>
        /// <param name="idesTutores"></param>
        /// <returns></returns>
        public static string Empleados(List<Instructor> instructores, List<int> idesInstructores, List<Tutor> tutores, List<int> idesTutores)
        {
            ExcelPackage ExcelPkg = new ExcelPackage();
            ExcelWorksheet wsSheet1 = ExcelPkg.Workbook.Worksheets.Add("Hoja1");

            // wsSheet1.Cells.Style.Font.Name = "Montserrat";
            // FontFamily de la hoja
            wsSheet1.Cells.Style.Font.Name = "Roboto";

            using (ExcelRange Rng = wsSheet1.Cells["B2:F2"])
            {
                Rng.Value = "Informe de Instructores";

                Rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                Rng.Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(1, 46, 103));

                Rng.Merge = true;

                Rng.Style.Font.Size = 16;

                Rng.Style.Font.Bold = true;
            }

            using (ExcelRange Rng = wsSheet1.Cells["B4:F" + (idesInstructores.Count + 4)])
            {
                // Acceso indirecto a la clase ExcelTableCollection
                ExcelTable table = wsSheet1.Tables.Add(Rng, "tblInstructor");
                //table.Name = "tblSalesman";

                // Establecer posicion y nombre de columnas
                table.Columns[0].Name = "ID";
                table.Columns[1].Name = "Apellido";
                table.Columns[2].Name = "Nombre";
                table.Columns[3].Name = "DNI";
                table.Columns[4].Name = "Reparticion";

                //table.ShowHeader = false;
                table.ShowFilter = true;
                //table.ShowTotal = true;
            }

            // Insertar datos de instructores en las celdas de la tabla de Excel
            var i = 5;
            var indiceEmp = 0;

            foreach (var id in idesInstructores)
            {
                // [ID] Columna
                using (ExcelRange Rng = wsSheet1.Cells["B" + i++]) { Rng.Value = id; }

                i--;

                // [APELLIDO] Columna                
                using (ExcelRange Rng = wsSheet1.Cells["C" + i]) { Rng.Value = instructores[indiceEmp].Apellido; }

                // [NOMBRE] Columna
                using (ExcelRange Rng = wsSheet1.Cells["D" + i]) { Rng.Value = instructores[indiceEmp].Nombre; }

                // [DNI] Columna
                using (ExcelRange Rng = wsSheet1.Cells["E" + i]) { Rng.Value = instructores[indiceEmp].DNI; }

                // [REPARTICION] Columna
                using (ExcelRange Rng = wsSheet1.Cells["F" + i]) { Rng.Value = instructores[indiceEmp].Reparticion; }

                i++;
                indiceEmp++;
            }

            ExcelWorksheet wsSheet2 = ExcelPkg.Workbook.Worksheets.Add("Hoja2");

            // wsSheet2.Cells.Style.Font.Name = "Montserrat";
            // FontFamily de la hoja
            wsSheet2.Cells.Style.Font.Name = "Roboto";

            using (ExcelRange Rng = wsSheet2.Cells["B2:F2"])
            {
                Rng.Value = "Informe de Tutores";

                Rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                Rng.Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(1, 46, 103));

                Rng.Merge = true;

                Rng.Style.Font.Size = 16;

                Rng.Style.Font.Bold = true;
            }

            using (ExcelRange Rng = wsSheet2.Cells["B4:F" + (idesTutores.Count + 4)])
            {
                // Acceso indirecto a la clase ExcelTableCollection
                ExcelTable table = wsSheet2.Tables.Add(Rng, "tblTutor");
                //table.Name = "tblTutor";

                // Establecer posicion y nombre de columnas
                table.Columns[0].Name = "ID";
                table.Columns[1].Name = "Apellido";
                table.Columns[2].Name = "Nombre";
                table.Columns[3].Name = "DNI";
                table.Columns[4].Name = "Reparticion";

                //table.ShowHeader = false;
                table.ShowFilter = true;
                //table.ShowTotal = true;
            }

            // Insertar datos de tutores en las celdas de la tabla de Excel
            i = 5;
            indiceEmp = 0;

            foreach (var id in idesTutores)
            {
                // [ID] Columna
                using (ExcelRange Rng = wsSheet2.Cells["B" + i++]) { Rng.Value = id; }

                i--;

                // [APELLIDO] Columna                
                using (ExcelRange Rng = wsSheet2.Cells["C" + i]) { Rng.Value = tutores[indiceEmp].Apellido; }

                // [NOMBRE] Columna
                using (ExcelRange Rng = wsSheet2.Cells["D" + i]) { Rng.Value = tutores[indiceEmp].Nombre; }

                // [DNI] Columna
                using (ExcelRange Rng = wsSheet2.Cells["E" + i]) { Rng.Value = tutores[indiceEmp].DNI; }

                // [REPARTICION] Columna
                using (ExcelRange Rng = wsSheet2.Cells["F" + i]) { Rng.Value = tutores[indiceEmp].Reparticion; }

                i++;
                indiceEmp++;
            }

            wsSheet1.Cells[wsSheet1.Dimension.Address].AutoFitColumns();
            wsSheet2.Cells[wsSheet2.Dimension.Address].AutoFitColumns();
            ExcelPkg.SaveAs(new FileInfo(@"InformeEmpleados.xlsx"));

            return "Informe Creado";
        }


        /// <summary>
        /// Genera el reporte de los cursos
        /// </summary>
        /// <param name="cursos"></param>
        /// <param name="idesCursos"></param>
        /// <returns></returns>
        public static string Cursos(List<Curso> cursos, List<int> idesCursos)
        {
            ExcelPackage ExcelPkg = new ExcelPackage();
            //Crea la hoja1
            ExcelWorksheet wsSheet1 = ExcelPkg.Workbook.Worksheets.Add("Hoja1");

            // wsSheet1.Cells.Style.Font.Name = "Montserrat";
            // FontFamily del archivo
            wsSheet1.Cells.Style.Font.Name = "Roboto";

            // Titulo
            using (ExcelRange Rng = wsSheet1.Cells["B2:F2"])
            {
                Rng.Value = "Informe de Cursos";

                Rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                Rng.Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(1, 46, 103));

                Rng.Merge = true;

                Rng.Style.Font.Size = 16;

                Rng.Style.Font.Bold = true;
            }

            // Creo la tabla
            using (ExcelRange Rng = wsSheet1.Cells["B4:F" + (idesCursos.Count + 4)])
            {
                // Acceso indirecto a la clase ExcelTableCollection
                ExcelTable table = wsSheet1.Tables.Add(Rng, "tblCursos");
                //table.Name = "tblSalesman";

                // Establecer posicion y nombre de columnas
                table.Columns[0].Name = "ID";
                table.Columns[1].Name = "Tema";
                table.Columns[2].Name = "Instructor";
                table.Columns[3].Name = "Tutor";
                table.Columns[4].Name = "Cantidad de Alumnos";

                //table.ShowHeader = false;
                table.ShowFilter = true;
                //table.ShowTotal = true;
            }

            // Insertar datos en las celdas de la tabla de Excel
            var i = 5;
            var indiceBen = 0;

            foreach (var id in idesCursos)
            {
                // [ID] Columna
                using (ExcelRange Rng = wsSheet1.Cells["B" + i++]) { Rng.Value = id; }

                // [TEMA] Columna
                i--;
                using (ExcelRange Rng = wsSheet1.Cells["C" + i]) { Rng.Value = cursos[indiceBen].Tema; }

                // [INSTRUCTOR] Columna
                using (ExcelRange Rng = wsSheet1.Cells["D" + i]) { Rng.Value = cursos[indiceBen].Instructor.Apellido + ", " + cursos[indiceBen].Instructor.Nombre; }

                // [TUTOR] Columna
                using (ExcelRange Rng = wsSheet1.Cells["E" + i]) { Rng.Value = cursos[indiceBen].Tutor.Apellido + ", " + cursos[indiceBen].Tutor.Nombre; }

                // [CANTIDAD DE ALUMNOS] Columna
                using (ExcelRange Rng = wsSheet1.Cells["F" + i]) { Rng.Value = cursos[indiceBen].CantidadDeAlumnos(); }

                i++;
                indiceBen++;
            }

            wsSheet1.Cells[wsSheet1.Dimension.Address].AutoFitColumns();
            ExcelPkg.SaveAs(new FileInfo(@"InformeCursos.xlsx"));

            return "Informe Creado";
        }



        public static string Contrataciones(string nombreEmpresa, List<Beneficiario> beneficiarios, List<Contratacion> contrataciones)
        {
            ExcelPackage ExcelPkg = new ExcelPackage();
            //Crea la hoja1
            ExcelWorksheet wsSheet1 = ExcelPkg.Workbook.Worksheets.Add("Hoja1");

            // wsSheet1.Cells.Style.Font.Name = "Montserrat";
            // FontFamily del archivo
            wsSheet1.Cells.Style.Font.Name = "Roboto";

            // Titulo
            using (ExcelRange Rng = wsSheet1.Cells["B2:I2"])
            {
                Rng.Value = "Contratos de: " + nombreEmpresa;

                Rng.Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(1, 46, 103));

                Rng.Merge = true;

                Rng.Style.Font.Size = 16;

                Rng.Style.Font.Bold = true;
            }

            // Creo la tabla
            using (ExcelRange Rng = wsSheet1.Cells["B4:D" + (beneficiarios.Count + 4)])
            {
                // Acceso indirecto a la clase ExcelTableCollection
                ExcelTable table = wsSheet1.Tables.Add(Rng, "tblContratos");
                //table.Name = "tblSalesman";

                // Establecer posicion y nombre de columnas
                table.Columns[0].Name = "Beneficiario";
                table.Columns[1].Name = "Cargo";
                table.Columns[2].Name = "Sueldo";

                //table.ShowHeader = false;
                table.ShowFilter = true;
                //table.ShowTotal = true;
            }

            // Insertar datos en las celdas de la tabla de Excel
            var i = 5;
            var indiceCon = 0;

            foreach (var beneficiario in beneficiarios)
            {                
                // [BENEFICIARIO] Columna
                using (ExcelRange Rng = wsSheet1.Cells["B" + i]) { Rng.Value = beneficiario.Apellido + ", " + beneficiario.Nombre; }

                // [CARGO] Columna
                using (ExcelRange Rng = wsSheet1.Cells["C" + i]) { Rng.Value = contrataciones[indiceCon].Cargo; }

                // [SUELDO] Columna
                using (ExcelRange Rng = wsSheet1.Cells["D" + i]) { Rng.Value = "$" + contrataciones[indiceCon].Sueldo.ToString(); }

                i++;
                indiceCon++;
            }

            wsSheet1.Cells[wsSheet1.Dimension.Address].AutoFitColumns();
            ExcelPkg.SaveAs(new FileInfo(@"InformeContratos-" + nombreEmpresa + ".xlsx"));

            return "Informe Creado";
        }

    }
}
