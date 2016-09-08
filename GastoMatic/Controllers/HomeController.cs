using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZXing;
using System.Drawing;
using System.IO;
using System.Web.Services;

namespace GastoMatic.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        string A = "";
        string B = "";

        public ActionResult Index()
        {

            ModelState.AddModelError(A, B);

            //

            //string resultB = "";
            //string Contenido = "";
            //// create a barcode reader instance
            //IBarcodeReader QRreader = new BarcodeReader();
            //// load a bitmap
            //var barcodeBitmap = (Bitmap)Bitmap.FromFile("C:\\QR3.png");

            //// detect and decode the barcode inside the bitmap
            //var result = QRreader.Decode(barcodeBitmap);
            //// do something with the result
            //if (result != null)
            //{
            //    //resultB = result.BarcodeFormat.ToString();
            //    //Contenido = result.Text;

            //ViewBag.resultB = result.BarcodeFormat.ToString();
            //ViewBag.Contenido = result.Text;
            //}


            ViewBag.resultB = A;
            ViewBag.Contenido = B;

            return View();
        }


        public void Capture()
        {
            var stream = Request.InputStream;
            string dump;

            using (var reader = new StreamReader(stream))
                dump = reader.ReadToEnd();

            var path = Server.MapPath("~/test.png");
            System.IO.File.WriteAllBytes(path, String_To_Bytes2(dump));
            Read();
        }

        private byte[] String_To_Bytes2(string strInput)
        {
            int numBytes = (strInput.Length) / 2;
            byte[] bytes = new byte[numBytes];

            for (int x = 0; x < numBytes; ++x)
            {
                bytes[x] = Convert.ToByte(strInput.Substring(x * 2, 2), 16);
            }

            return bytes;
        }

        public void Read()
        {
            string resultB = "";
            string Contenido = "";
            // create a barcode reader instance
            IBarcodeReader QRreader = new BarcodeReader();
            // load a bitmap
            //var barcodeBitmap = (Bitmap)Bitmap.FromFile("C:\QR3.png");
            try
            {
                var barcodeBitmap = (Bitmap)Bitmap.FromFile("~/test.png");
                // detect and decode the barcode inside the bitmap
                var result = QRreader.Decode(barcodeBitmap);
                // do something with the result
                if (result != null)
                {
                    //resultB = result.BarcodeFormat.ToString();
                    //Contenido = result.Text;

                    ViewBag.resultB = result.BarcodeFormat.ToString();
                    ViewBag.Contenido = result.Text;
                }
            }
            catch (Exception x)
            {
                A = "La foto no tiene buena calidad o está de lado";
                B = "Toma la Foto de nuevo";
                Index();
            }


        }


    }
}
