using BusBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusBookingSystem.Controllers
{
    public class DriverController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Driver
       
        public ActionResult Index()
        {
            var drivers = getDrivers();
            return View(drivers);
        }
               
        public IEnumerable<Driver> getDrivers()
        {
            //this var drivers is dbset in db , that get all drivers in db.
            var drivers = db.Drivers.ToList();
            return drivers;
        }

        public ActionResult Details(int id)
        {

            //SingleOrDefault() : this is for single specific customer.
            var driver = getDrivers().SingleOrDefault(c => c.Id == id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        /*The logic to Add new Driver by admin : 
         * mplementing the /Driver/Add URL is a two step process. When a Admin first visits the /Driver/Add URL we want to show them an HTML form that they can fill out to enter a new driver. 
         * Then, when the admin submits the form and posts the data back to the server, we want to retrieve the posted contents and save it into our database.
         */
        /*HTTPPost method hides information from URL and does not bind data to URL. 
        It is more secure than HttpGet method but it is slower than HttpGet. 
        It is only useful when you are passing sensitive information to the server.
        sensitive information
        */
        [HttpGet] //hit by the action link("Add") in Add view.
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost] //hit when click the button "Create" in the view.
        public ActionResult Add(Driver createNewDriver) //mvc smart enough to bind this model to form(request) data because form data has pefix Driver
        {
            /* when the request data to the application,
            * mvc framework will use this proprty to inititalize as parameters in action.
            */
            if(!ModelState.IsValid)
            {// validtion (Data annotaion != form data).
                return View("Add", createNewDriver);
            }
         
                db.Drivers.Add(createNewDriver); //it's only added in memory.
                db.SaveChanges(); //it's added persitent in database.
                return RedirectToAction("Index"); //after saveing data back to Index(list of drivers). 
        }

        //An Edit link sends HttpGet request to the Edit action method of DriverController with corresponding PersonId in the query string.
        [HttpGet]
        public ActionResult Edit(int id) //mvc smart enough to bind this model to form(request) data because form data has pefix Driver
        {
            //http://localhost/driver/edit/{Id
            //get the driver from db who has id = id the which come from form requst(data).
            var driverFromDB = db.Drivers.SingleOrDefault(d => d.Id == id);
           
            if(driverFromDB == null)
            {
                return HttpNotFound();
            }
            /*HttpGet Edit action method will fetch student data from the database,
             * based on the supplied Id parameter and render the Edit view with that particular Driver data.
             */
            return View(driverFromDB);
           
        }

        /*The user can edit the data and click on the Save button in the Edit view.
         * The Save button will send a HttpPOST request http://localhost/Student/Edit with the Form data collection.
         */
        [HttpPost]
        public ActionResult Edit(Driver driver) 
        {
            /*The HttpPOST Edit action method in DriverController will finally update the data into the database 
              and render an Index page with the refreshed data using the RedirectToAction method
            */
            if (!ModelState.IsValid)
            {//no validtion (Data annotaion != form data request).
                return View("Edit", "driver");
            }
            //get the driver from db who has id = id the which come from form requst(data).
            //انا هنا جيلي داتا من الفورم معمولها ايديت قبل مااعملها سيف هشوف موجود فالداتا بيز ولا ؟ موجوده هاخد الداتا بعد ماتعدلت وحطها فالداتا بيز
            var driverFromDB = db.Drivers.SingleOrDefault(d => d.Id == driver.Id);

            driverFromDB.PhoneNumber = driver.PhoneNumber;
            driverFromDB.Salary = driver.Salary;
            driverFromDB.UserName = driver.UserName;
            driverFromDB.Gender = driver.Gender;
            driverFromDB.Address = driver.Address;
            driverFromDB.Age = driver.Age;
            driverFromDB.EMail = driver.EMail;
            
            db.SaveChanges(); //it's added persitent in database.
            return RedirectToAction("Index", "driver");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var driver = db.Drivers.SingleOrDefault(d => d.Id == id);
            db.Drivers.Remove(driver);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}