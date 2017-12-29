
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ISW_Dashboard.Controllers
{
    public class ImportExcelController : Controller
    {
        // GET: ImportData
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Import()
        {

            string filePath = string.Empty;
            try
            {
                if (Request.Files["uploadFile"].ContentLength > 0)
                {

                }
                
                
                filePath = Request.Files["uploadFile"].FileName;
                string extension = Path.GetExtension(Request.Files["uploadFile"].FileName);
                string filePath2 = Server.MapPath("~/uploads/") + Path.GetFileNameWithoutExtension( Request.Files["uploadFile"].FileName) +"_" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + extension;
                DataTable dt = new DataTable();

                Request.Files["uploadFile"].SaveAs(filePath2);

                //FileUpload1.SaveAs(filePath);
                //System.Data.OleDb.OleDbConnection oconn;
                string connString = string.Empty;
                try
                {
                    using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath2, false))
                    {
                        //Read the first Sheet from Excel file.
                        Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

                        //Get the Worksheet instance.
                        Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;

                        //Fetch all the rows present in the Worksheet.
                        IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();

                        //Create a new DataTable.
                        

                        //Loop through the Worksheet rows.
                        foreach (Row row in rows)
                        {
                            //Use the first row to add columns to DataTable.
                            if (row.RowIndex.Value == 1)
                            {
                                foreach (Cell cell in row.Descendants<Cell>())
                                {
                                    dt.Columns.Add(GetValue(doc, cell));
                                }
                            }
                            else
                            {
                                //Add rows to DataTable.
                                dt.Rows.Add();
                                int i = 0;
                                foreach (Cell cell in row.Descendants<Cell>())
                                {
                                    dt.Rows[dt.Rows.Count - 1][i] = GetValue(doc, cell);
                                    i++;
                                }
                            }
                        }
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

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            ViewBag.ErrorMessage = "Upload completed";
                            //return Content("<script language='javascript' type='text/javascript'>alert('Upload completed');window.history.replaceState(null,'Title','/ImportData/Index');</script>");
                        }
                        catch (Exception ex)
                        {
                            ViewBag.ErrorMessage = "Please select correct file";
                            ViewBag.ErrorMessage = ex.Message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message ;
                    ViewBag.ErrorMessage = "Please select correct file";
                    ViewBag.ErrorMessage = ex.Message;
                    //  return Content("<script language='javascript' type='text/javascript'>alert('Please select correct file');window.history.pushState('state','Title','/ImportData/Index');</script>");

                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message ;
                ViewBag.ErrorMessage = "Please select correct file";
                ViewBag.ErrorMessage = ex.Message;
                //  return Content("<script language='javascript' type='text/javascript'>alert('Please select correct file');window.history.pushState('state','Title','/ImportData/Index');</script>");

            }

            //alert(sID + ":" + dID);

            //if (postedFile != null)
            //{
            //    string path = Server.MapPath("~/Uploads/");
            //    if (!Directory.Exists(path))
            //    {
            //        Directory.CreateDirectory(path);
            //    }

            //    //filePath = path + Path.GetFileName(postedFile.FileName);
            //    //string extension = Path.GetExtension(postedFile.FileName);
            //    //postedFile.SaveAs(filePath);

            //    string conString = string.Empty;
            //    switch (extension)
            //    {
            //        case ".xls": //Excel 97-03.
            //            conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
            //            break;
            //        case ".xlsx": //Excel 07 and above.
            //            conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
            //            break;
            //    }

            //    DataTable dt = new DataTable();
            //    conString = string.Format(conString, filePath);

            //    using (OleDbConnection connExcel = new OleDbConnection(conString))
            //    {
            //        using (OleDbCommand cmdExcel = new OleDbCommand())
            //        {
            //            using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
            //            {
            //                cmdExcel.Connection = connExcel;

            //                //Get the name of First Sheet.
            //                connExcel.Open();
            //                DataTable dtExcelSchema;
            //                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            //                string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            //                connExcel.Close();

            //                //Read Data from First Sheet.
            //                connExcel.Open();
            //                cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
            //                odaExcel.SelectCommand = cmdExcel;
            //                odaExcel.Fill(dt);
            //                connExcel.Close();
            //            }
            //        }
            //    }

            //    conString = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
            //    using (SqlConnection con = new SqlConnection(conString))
            //    {
            //        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
            //        {
            //            //Set the database table name.
            //            sqlBulkCopy.DestinationTableName = "dbo.Customers";

            //            //[OPTIONAL]: Map the Excel columns with that of the database table
            //            sqlBulkCopy.ColumnMappings.Add("Id", "CustomerId");
            //            sqlBulkCopy.ColumnMappings.Add("Name", "Name");
            //            sqlBulkCopy.ColumnMappings.Add("Country", "Country");

            //            con.Open();
            //            sqlBulkCopy.WriteToServer(dt);
            //            con.Close();
            //        }
            //    }
            //}

            return View("Index");
        }
        private string GetValue(SpreadsheetDocument doc, Cell cell)
        {
            string value = cell.CellValue.InnerText;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
            }
            return value;
        }
    }
}