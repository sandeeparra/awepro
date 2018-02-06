using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Configuration;
using System.Data;


namespace importData
{
    class Program
    {
        static private string GetValue(SpreadsheetDocument doc, Cell cell)
        {
            string value = cell.InnerText;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
            }
            return value;
        }
        static void Main(string[] args)
        {
            try
            {
                string filePath = args[0].ToString();
                if (String.IsNullOrWhiteSpace(filePath))
                    return;
                DataTable dt = new DataTable();
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath, false))
                {
                    //Read the first Sheet from Excel file.
                    Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

                    //Get the Worksheet instance.
                    Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;

                    //Fetch all the rows present in the Worksheet.
                    IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();

                    //Create a new DataTable.
                    IFormatProvider yyyymmddFormat = new System.Globalization.CultureInfo("en-GB", false);
                    //Loop through the Worksheet rows.
                    foreach (Row row in rows)
                    {
                        //Use the first row to add columns to DataTable.
                        if (row.RowIndex.Value == 6)
                        {
                            foreach (Cell cell in row.Descendants<Cell>())
                            {
                                String col = GetValue(doc, cell).Replace(" ", "");
                                dt.Columns.Add(col);
                            }
                        }
                        else if (row.RowIndex.Value > 6)
                        {
                            //Add rows to DataTable.
                            dt.Rows.Add();
                            int i = 0;
                            foreach (Cell cell in row.Descendants<Cell>())
                            {
                                String col = GetValue(doc, cell);
                                if (i == 0 || i == 23 || i == 24 || i == 26)
                                {
                                    if (String.IsNullOrWhiteSpace(col))
                                        dt.Rows[dt.Rows.Count - 1][i] = DBNull.Value;
                                    else
                                        dt.Rows[dt.Rows.Count - 1][i] = DateTime.FromOADate(double.Parse(col)).ToString("MM/dd/yyyy HH:mm:ss", yyyymmddFormat); 
                                }
                                else
                                    dt.Rows[dt.Rows.Count - 1][i] = col;
                                i++;
                            }
                        }
                    }

                    dt.Columns.RemoveAt(2);
                    dt.Columns.RemoveAt(8);
                    dt.Columns.RemoveAt(9);
                    dt.Columns.RemoveAt(20);
                    try
                    {
                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                        SqlCommand cmd = new SqlCommand("alterTable", con);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.LastIndexOf("\\") + 1);
                        SqlParameter parameter = new SqlParameter();
                        //The parameter for the SP must be of SqlDbType.Structured 
                        parameter.ParameterName = "@local";
                        parameter.SqlDbType = System.Data.SqlDbType.Structured;
                        parameter.Value = dt;
                        cmd.Parameters.Add(parameter);
                        Console.WriteLine(con.ConnectionTimeout);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
