using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using AventStack.ExtentReports;
using System.IO;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Threading;
using System.Configuration;
using AutoWebSpa.Core.Query;

namespace AutoWebSpa.Core
{
    [TestFixture]
    public class SeleniumExtentReport : Base
    {

        private static readonly  ExtentReports _extent = new ExtentReports();       
        private static readonly ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(AppDomain.CurrentDomain.BaseDirectory + "\\Test_Execution_Reports\\Automation_Report.html");
        private static readonly string iteracion = ResultadosMariaDB.GetUltimaIteracion();
        protected ExtentTest detalleReporte;
        ResultadosMariaDB insert = new ResultadosMariaDB();
        bool UsarBD = true; 

        public SeleniumExtentReport()
        {
            _extent.AttachReporter(htmlReporter);

        }


        ///Getting the name of current running test to extent report
        /// Author: Sanoj
        /// Since: 23-Sep-2018
        [SetUp]
        public void BeforeTest()
        {
            try
            {
                detalleReporte = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
                inicializar(BrowerType.Chrome,false);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }


        /// Finish the execution and logging the detials into HTML report
        /// Author: Sanoj
        /// Since: 23-Sep-2018
        [TearDown]
        public void AfterTest()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = "" +TestContext.CurrentContext.Result.StackTrace + "";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        string screenShotPath = Capture(Driver, TestContext.CurrentContext.Test.Name);
                        detalleReporte.Log(logstatus, "Test ended with " +logstatus + " – " +errorMessage);
                        detalleReporte.Log(logstatus, "Snapshot below: " +detalleReporte.AddScreenCaptureFromPath(screenShotPath));
                        if (UsarBD) {
                            insert.RegistarAsync(iteracion, TestContext.CurrentContext.Test.Name, "FAIL");
                        }
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        detalleReporte.Log(logstatus, "Test ended with " +logstatus);
                        break;
                    default:
                        logstatus = Status.Pass;
                        detalleReporte.Log(logstatus, "Test ended with " +logstatus);
                        if (UsarBD)
                        {
                            insert.RegistarAsync(iteracion,TestContext.CurrentContext.Test.Name, "PASS");
                        }
                        break;
                }
                Driver.Quit();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        ///To flush extent report
        ///To quit driver instance
        /// /// Author: Sanoj
        /// Since: 23-Sep-2018
        [OneTimeTearDown]
        public void AfterClass()
        {
            try
            {
                _extent.Flush();
            }
            catch (Exception e)
            {
                throw (e);
            }
            
        }

        /// To capture the screenshot for extent report and return actual file path
        /// Author: Sanoj
        /// Since: 23-Sep-2018
        private string Capture(IWebDriver driver, string screenShotName)
        {
            string localpath = "";
            try
            {
                Thread.Sleep(4000);
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();
                string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                var dir = AppDomain.CurrentDomain.BaseDirectory;
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Defect_Screenshots\\");
                string finalpth = AppDomain.CurrentDomain.BaseDirectory + "\\Defect_Screenshots\\" +screenShotName + ".png";
                //string finalpth = dir + "Defect_Screenshots\\" + screenShotName + ".png";
                localpath = new Uri(finalpth).LocalPath;
                screenshot.SaveAsFile(localpath);
            }
            catch (Exception e)
            {
                throw (e);
            }
            return localpath;
        }
    }
}