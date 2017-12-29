using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;

namespace ISW_Dashboard.Controllers
{
    public class ImportDataController : Controller
    {
        // GET: ImportData
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Import()
        {

            try
            {
                if (Request.Files["uploadFile"].ContentLength > 0)
                {

                }
                string filePath = string.Empty;
                filePath = Request.Files["uploadFile"].FileName;
                string extension = Path.GetExtension(Request.Files["uploadFile"].FileName);

                //System.Data.OleDb.OleDbConnection oconn;
                string connString = string.Empty;
                try
                {
                    if (filePath != string.Empty)
                    {

                        if (extension == ".xls")
                        {
                            connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath.ToString() + ";Extended Properties=\"Excel 8.0;HDR=Yes;\"";
                        }
                        else if (extension == ".xlsx")
                        {
                            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath.ToString() + ";Extended Properties=\"Excel 12.0;HDR=Yes;\"";
                        }
                        OleDbConnection oconn = new OleDbConnection(connString);

                        oconn.Open();
                        try
                        {
                            if (oconn.State == System.Data.ConnectionState.Closed)
                                oconn.Open();
                        }
                        catch (Exception ex)
                        {
                            // MessageBox.Show(ex.Message);
                        }

                        try
                        {
                            //  DataTable myTableName = oconn.GetSchema();               
                            OleDbCommand ocmd = new OleDbCommand("select * from [Table1$]", oconn);
                            OleDbDataAdapter dadapter = new OleDbDataAdapter(ocmd);
                            DataSet dset = new DataSet();
                            dadapter.Fill(dset);
                            oconn.Close();
                            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                            SqlCommand cmd = new SqlCommand("alterTable", con);

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.LastIndexOf("\\") + 1);
                            SqlParameter parameter = new SqlParameter();
                            //The parameter for the SP must be of SqlDbType.Structured 
                            parameter.ParameterName = "@local";
                            parameter.SqlDbType = System.Data.SqlDbType.Structured;
                            parameter.Value = dset.Tables[0];
                            cmd.Parameters.Add(parameter);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            ViewBag.ErrorMessage = "Upload completed";
                            //return Content("<script language='javascript' type='text/javascript'>alert('Upload completed');window.history.replaceState(null,'Title','/ImportData/Index');</script>");
                        }
                        catch(Exception ex)
                        {
                            ViewBag.ErrorMessage = "Please select correct file";
                        }
                    }
                }
                catch (Exception ex)
                {

                    ViewBag.ErrorMessage = "Please select correct file";
                    //  return Content("<script language='javascript' type='text/javascript'>alert('Please select correct file');window.history.pushState('state','Title','/ImportData/Index');</script>");

                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Please select correct file";
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

            return View("index");
        }
    }
}