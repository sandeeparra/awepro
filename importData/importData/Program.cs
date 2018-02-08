using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Collections;
using System.Collections.Specialized;

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
                                //if (i == 0 || i == 24 || i == 25 || i == 26)

                                //{
                                //    if (String.IsNullOrWhiteSpace(col))
                                //        dt.Rows[dt.Rows.Count - 1][i] = DBNull.Value;
                                //    else
                                //        //dt.Rows[dt.Rows.Count - 1][i] = DateTime.FromOADate(double.Parse(col)).ToString("MM/dd/yyyy HH:mm:ss", yyyymmddFormat); 
                                //        dt.Rows[dt.Rows.Count - 1][i] = Convert.ToDateTime(DateTime.FromOADate(double.Parse(col)).ToString("MM/dd/yyyy HH:mm:ss", yyyymmddFormat));
                                //}
                                //else
                                dt.Rows[dt.Rows.Count - 1][i] = col;
                                i++;
                            }
                        }
                    }

                    //dt.Columns.RemoveAt(2);
                    //dt.Columns.RemoveAt(8);
                    //dt.Columns.RemoveAt(9);
                    //dt.Columns.RemoveAt(20);

                    var section = System.Configuration.ConfigurationManager.AppSettings;
                    Dictionary<string, string> dictionary = ToDictionaryMethod(section);


                    //foreach (DataColumn dc in dt.Columns )
                    //    {
                    //        if (!dictionary.Keys.Contains(dc.ColumnName))
                    //        {
                    //            dt.Columns.Remove(dc.ColumnName);
                    //        }
                    //    }

                    for (int i = dt.Columns.Count - 1; i >= 0; i--)
                        if (!dictionary.Keys.Contains(dt.Columns[i].ToString()))
                        {
                            dt.Columns.RemoveAt(i);

                        }

                    for (int i = 0; i < dictionary.Keys.Count; i++)
                    {
                        if (!dt.Columns.Contains(dictionary.Keys.ToList()[i].ToString()))
                        {
                            dt.Columns.Add(dictionary.Keys.ToList()[i].ToString()).SetOrdinal(i);
                            dt.Columns[dictionary.Keys.ToList()[i].ToString()].DefaultValue = DBNull.Value;
                        }
                    }


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //for (int j = 0; j <dt.Columns.Count; j++)
                        //{
                            //if (j == 0 || j == 20 || j == 21 || j == 22)

                            //{
                                if (String.IsNullOrWhiteSpace(dt.Rows[i][0].ToString()))
                                    dt.Rows[i][0] = DBNull.Value;
                                else
                                    //dt.Rows[dt.Rows.Count - 1][i] = DateTime.FromOADate(double.Parse(col)).ToString("MM/dd/yyyy HH:mm:ss", yyyymmddFormat); 
                                    dt.Rows[i][0] = Convert.ToDateTime(DateTime.FromOADate(double.Parse(dt.Rows[i][0].ToString())).ToString("MM/dd/yyyy HH:mm:ss", yyyymmddFormat));

                        if (String.IsNullOrWhiteSpace(dt.Rows[i][20].ToString()))
                            dt.Rows[i][20] = DBNull.Value;
                        else
                            //dt.Rows[dt.Rows.Count - 1][i] = DateTime.FromOADate(double.Parse(col)).ToString("MM/dd/yyyy HH:mm:ss", yyyymmddFormat); 
                            dt.Rows[i][20] = Convert.ToDateTime(DateTime.FromOADate(double.Parse(dt.Rows[i][20].ToString())).ToString("MM/dd/yyyy HH:mm:ss", yyyymmddFormat));
                        if (String.IsNullOrWhiteSpace(dt.Rows[i][21].ToString()))
                            dt.Rows[i][21] = DBNull.Value;
                        else
                            //dt.Rows[dt.Rows.Count - 1][i] = DateTime.FromOADate(double.Parse(col)).ToString("MM/dd/yyyy HH:mm:ss", yyyymmddFormat); 
                            dt.Rows[i][21] = Convert.ToDateTime(DateTime.FromOADate(double.Parse(dt.Rows[i][21].ToString())).ToString("MM/dd/yyyy HH:mm:ss", yyyymmddFormat));

                        if (String.IsNullOrWhiteSpace(dt.Rows[i][22].ToString()))
                            dt.Rows[i][22] = DBNull.Value;
                        else
                            //dt.Rows[dt.Rows.Count - 1][i] = DateTime.FromOADate(double.Parse(col)).ToString("MM/dd/yyyy HH:mm:ss", yyyymmddFormat); 
                            dt.Rows[i][22] = Convert.ToDateTime(DateTime.FromOADate(double.Parse(dt.Rows[i][22].ToString())).ToString("MM/dd/yyyy HH:mm:ss", yyyymmddFormat));

                        // }
                        // }
                    }
                    //   Dictionary<string, string> dictionary = (ConfigurationManager.GetSection("DeviceSettings/MajorCommands") as System.Collections.Hashtable)
                    //.Cast<System.Collections.DictionaryEntry>()
                    //.ToDictionary(n => n.Key.ToString(), n => n.Value.ToString());


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
                        Console.WriteLine("Connection opened");
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Console.WriteLine("Import completed");
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
        public static Dictionary<string, string> ToDictionaryMethod(NameValueCollection nvc)
        {
            return nvc.AllKeys.ToDictionary(k => k, k => nvc[k]);
        }
    }

}
