using Microsoft.AspNetCore.Mvc;
using ProductShop.Application.ApplicationConstants;
using ProductShop.Application.Common;
using ProductShop.Application.DTO.Product;
using ProductShop.Application.Services.Interface;

namespace ProductShop.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{

    private readonly IProductService _productService;
    protected APIResponse _apiResponse;

    public ProductController(IProductService productService)
    {
        _productService = productService;
        _apiResponse = new APIResponse();
    }

    [HttpGet]
    public async Task<ActionResult<APIResponse>> GetAll()
    {
        try
        {
            var res = await _productService.GetAllAsync();
            _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
            _apiResponse.IsSuccess = true;
            _apiResponse.Result = res;
        }
        catch (Exception ex)
        {
            //_apiResponse.AddError(ex.Message.ToString());
            _apiResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            _apiResponse.AddError(CommonMessage.SystemError);
        }
        return Ok(_apiResponse);
    }

    [HttpGet]
    [Route("GetDetail")]
    public async Task<ActionResult<APIResponse>> GetID(int ID)
    {
        try
        {
            var res = await _productService.GetByIdAsync(ID);

            if (res == null)
            {
                _apiResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                _apiResponse.DisplayMessage = CommonMessage.RecordNotFound;
                return Ok(_apiResponse);
            }
            _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
            _apiResponse.IsSuccess = true;
            _apiResponse.Result = res;

        }
        catch (Exception ex)
        {
            _apiResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            _apiResponse.AddError(CommonMessage.SystemError);
        }
        return Ok(_apiResponse);
    }

    [HttpPost]
    public async Task<ActionResult<APIResponse>> CreateId([FromBody] CreateProductDto catcreDTO)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _apiResponse.DisplayMessage = CommonMessage.CreateOperationFailed;
                _apiResponse.AddError(ModelState.ToString());
                return Ok(_apiResponse);
            }
            var entity = await _productService.CreateAsync(catcreDTO);
            _apiResponse.StatusCode = System.Net.HttpStatusCode.Created;
            _apiResponse.IsSuccess = true;
            _apiResponse.DisplayMessage = CommonMessage.CreateOperationSuccess;
            _apiResponse.Result = entity;
        }
        catch (Exception ex)
        {
            _apiResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            _apiResponse.AddError(CommonMessage.SystemError);

        }
        return Ok(_apiResponse);
    }

    [HttpPut]
    public async Task<ActionResult<APIResponse>> UpdateID([FromBody] UpdateProductDto UpdateDto)
    {

        try
        {
            if (!ModelState.IsValid)
            {
                _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _apiResponse.DisplayMessage = CommonMessage.UpdateOperationFailed;
                _apiResponse.AddError(CommonMessage.SystemError);
                return Ok(_apiResponse);
            }
            var res = await _productService.GetByIdAsync(UpdateDto.Id);

            if (res == null)
            {
                _apiResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                _apiResponse.DisplayMessage = CommonMessage.UpdateOperationFailed;
                return Ok(_apiResponse);
            }
            await _productService.UpdateAsync(UpdateDto);
            _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
            _apiResponse.IsSuccess = true;
            _apiResponse.DisplayMessage = CommonMessage.UpdateOperationSuccess;

        }
        catch (Exception ex)
        {
            _apiResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            _apiResponse.AddError(CommonMessage.SystemError);
        }

        return Ok(_apiResponse);
    }

    [HttpDelete]
    public async Task<ActionResult<APIResponse>> DeleteId(int ID)
    {
        try
        {
            if (ID == 0)
            {
                _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _apiResponse.DisplayMessage = CommonMessage.DeleteOperationFailed;
                return Ok(_apiResponse);

            }
            var res = await _productService.GetByIdAsync(ID);
            if (res == null)
            {
                _apiResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                _apiResponse.DisplayMessage = CommonMessage.DeleteOperationFailed;
                return Ok(_apiResponse);
            }
            await _productService.DeleteAsync(ID);
            _apiResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            _apiResponse.IsSuccess = true;
            _apiResponse.DisplayMessage = CommonMessage.DeleteOperationSuccess;
        }
        catch (Exception Ex)
        {
            _apiResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            _apiResponse.AddError(CommonMessage.SystemError);
        }
        return Ok(_apiResponse);
    }

    [HttpGet]
    [Route("Filter")]
    public async Task<ActionResult<APIResponse>> GetFilter(int? categoryID, int? brandID )
    {
        try
        {
            var res = await _productService.GetAllByFilterAsync(categoryID, brandID);   

            if (res == null)
            {
                _apiResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                _apiResponse.DisplayMessage = CommonMessage.RecordNotFound;
                return Ok(_apiResponse);
            }
            _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
            _apiResponse.IsSuccess = true;
            _apiResponse.Result = res;

        }
        catch (Exception ex)
        {
            _apiResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            _apiResponse.AddError(CommonMessage.SystemError);
        }
        return Ok(_apiResponse);
    }
}
