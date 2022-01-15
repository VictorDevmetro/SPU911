using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPU911.Services;

namespace SPU911.Controllers
{
    [Route("api/wishlist")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListService _service;
        private readonly IWishListProducts _wishListProductService;

        public WishListController(IWishListService service,
            IWishListProducts wishListProductService)
        {
            _service = service;
            _wishListProductService = wishListProductService;
        }

        [Route("toggle/{id}")]
        [HttpPost]
        public IActionResult ToggleWishList(int id)
        {
            _service.ToggleWishList(id);
            return CustomResult();
        }

        [Route("count")]
        [HttpPost]
        public IActionResult CustomResult()
        {
            return Ok(_service.Count());
        }

        [Route("")]
        [HttpGet]
        public IActionResult GetWishList()
        {
            return Ok(_wishListProductService.GetWishList());
        }
    }
}
