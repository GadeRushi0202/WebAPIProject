using Microsoft.AspNetCore.Mvc;
using WebAPIProject.Services;

using WebAPIProject.Models;
using System.Net.Http.Headers;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService service;
        public ProductController(IProductService Service)
        {
            this.service = Service;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await service.GetProducts();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetProductById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var model = await service.GetProductById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> Post([FromBody][Bind(include: "P_name,Price,Image,c_id")] Product product)
        {
            try
            {
                var result = await service.AddProduct(product);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> Put([FromBody] Product product)
        {
            try
            {
                var result = await service.UpdateProduct(product);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await service.DeleteProduct(id);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        //change
        [HttpPost]
        [Route("uploadImage")]
        public IActionResult UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0];
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                // Adjust the path where you want to save the file
                var filePath = Path.Combine(@"C:\AngularDemos\MiniProject\src\assets\Image\", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                string url = @"\assets\Image\" + fileName;
                ImageDTO dto = new ImageDTO();
                dto.Url = url;
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
    }
}
