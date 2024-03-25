using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WheelyRev.Models;

namespace WheelyRev.Controllers
{
    public class MyShopController : BaseController
    {
        // GET: MyShop
        public ActionResult MyShop()
        {
            return View();
        }
        [Authorize(Roles = "Store owner")]
        [HttpPost]
        public ActionResult MyShop(HttpPostedFileBase file, Products product)
        {
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    // Check file type (example: allow only image files)
                    string[] allowedFileTypes = { "image/jpeg", "image/png", "image/gif", "image/jpg" };
                    if (!allowedFileTypes.Contains(file.ContentType))
                    {
                        TempData["msg"] = "Invalid file type. Please upload a valid image file.";
                        return View();
                    }

                    // Get the path to the "Images" folder
                    string imagesFolderPath = Server.MapPath("~/Images");

                    // Create the folder if it doesn't exist
                    if (!Directory.Exists(imagesFolderPath))
                    {
                        Directory.CreateDirectory(imagesFolderPath);
                    }

                    // Combine the folder path and the filename
                    string fileName = Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(imagesFolderPath, fileName);

                    // Handle file name conflicts
                    if (System.IO.File.Exists(filePath))
                    {
                        fileName = Guid.NewGuid().ToString() + "_" + fileName;
                        filePath = Path.Combine(imagesFolderPath, fileName);
                    }

                    // Save the file to the specified path
                    file.SaveAs(filePath);

                    var imageModel = new Products
                    {
                        ImagePath = fileName,
                        productName = product.productName,
                        productDescription = product.productDescription,
                        productPrice = product.productPrice,
                        productQty = product.productQty
                    };

                    _db.Products.Add(imageModel);
                    _db.SaveChanges();

                    TempData["msg"] = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    TempData["msg"] = "ERROR: " + ex.Message.ToString();
                }
            }
            else
            {
                TempData["msg"] = "You have not specified a file.";
            }
            return RedirectToAction("MyShop");
        }
    }
}