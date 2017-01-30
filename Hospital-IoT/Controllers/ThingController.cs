using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Hospital_IoT.Controllers
{
    public class ThingController : Controller
    {
        IoTModel.IoTModel db = new IoTModel.IoTModel();

        // GET: Thing
        public ActionResult Index()
        {
            var things = db.Sensor_Data;
            return View(things);
        }

        public ActionResult Thing(int thingID)
        {
            ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["test"];
            if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
                throw new Exception("Fatal error: missing connecting string in web.config file");
            var conString = mySetting.ConnectionString;

            SqlConnection con = new SqlConnection(conString);
            SqlCommand sqlCommand = new SqlCommand("RetrieveLastThingSensor", con);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@intThingId", thingID);
            con.Open();

            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            ListView listView = new ListView();
            if (dataReader.HasRows)
            {
                if (dataReader.Read())
                {
                    ListViewItem obj = new ListViewItem(Convert.ToString(dataReader[0]), Convert.ToString(dataReader[1]);
                    listView.Items.Add(obj); // add object to the listbox
                }
            }
            con.Close();
            return View();
        }
        // GET: Thing/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Thing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Thing/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Thing/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Thing/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Thing/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Thing/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
