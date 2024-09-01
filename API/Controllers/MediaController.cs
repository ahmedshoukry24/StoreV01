using API.Helper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMediaRepository _context;

        public MediaController(IWebHostEnvironment webHostEnvironment,IMediaRepository context, IHttpContextAccessor contextAccessor)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _contextAccessor = contextAccessor;

        }
        [HttpPost]
        [Route("Upload")]
        public async Task<ActionResult> UploadProductImages()
        {
            string[] extentions = { ".jpg", ".png" };
            int uploaded = 0;
            int notUploaded = 0;
            

            try
            {
                var _uploadedFiles = Request.Form.Files;
                foreach(IFormFile file in _uploadedFiles)
                {

                    string fileExtention = Path.GetExtension(file.FileName);
                    if (!extentions.Contains(fileExtention.ToLower()))
                    {
                        notUploaded++;
                        continue;
                    }

                    string randomFileName = RandomSerial.GenerateFileName(15);
                    string fileName = string.Format("{0}{1}", randomFileName, fileExtention);

                    string filePath = string.Format("{0}\\Uploads\\Products\\{1}",_webHostEnvironment.WebRootPath,fileName);

                    bool condition = true;

                    while (condition)
                    {

                        if(System.IO.File.Exists(filePath))
                        {
                            randomFileName = RandomSerial.GenerateFileName(15);
                            fileName = string.Format("{0}{1}", randomFileName, fileExtention);

                            filePath = string.Format("{0}\\Uploads\\Products\\{1}", _webHostEnvironment.WebRootPath, fileName);
                        }
                        else
                        {
                            condition = false;
                        }
                    }
                    

                    using (FileStream stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                        uploaded++;
                    }
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            if (uploaded > 0 && notUploaded == 0)
                return Ok("Uploaded Successfully!");
            else if (uploaded > 0 && notUploaded > 0)
                return Ok("Some files not uploaded, it must be with extentions .jpg or .png!");
            else return BadRequest("Not uploaded, images must be with extentions .jpg or .png!");

        }

        [HttpPost]
        [Route("UploadStoreImage/{storeId}")]
        public async Task<ActionResult> UploadStoreImage(Guid storeId, IFormFile file)
        {
            string[] allowedExtentions = { ".jpg", ".png" };
            try
            {
                string fileExtention = Path.GetExtension(file.FileName);
                if (!allowedExtentions.Contains(fileExtention.ToLower()))
                    return BadRequest("Image must be .jpg or .png extention!");

                string fileName = $"{RandomSerial.GenerateFileName(15)}{fileExtention}";
                string imageUrl = $"uploads\\stores\\{fileName}";

                string filePath = $"{_webHostEnvironment.WebRootPath}\\{imageUrl}";

                bool condition = true;
                while (condition)
                {
                    if (System.IO.File.Exists(filePath))
                    {
                        fileName = $"{RandomSerial.GenerateFileName(15)}{fileExtention}";
                        filePath = string.Format("{0}\\uploads\\stores\\{1}", _webHostEnvironment.WebRootPath, fileName);
                    }
                    else
                    {
                        condition = false;
                    }
                }

                using (FileStream stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                

                Media media = new Media
                {
                    StoreId = storeId,
                    URL = imageUrl
                };
                var result = await _context.Add(media);
                if (result != null)
                    return Ok("Uploaded Successfully");
                else return BadRequest("Not uploaded!");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }

    }
}
