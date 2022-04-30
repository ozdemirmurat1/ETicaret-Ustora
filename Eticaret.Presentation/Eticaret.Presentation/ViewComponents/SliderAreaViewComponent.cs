using Eticaret.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Presentation.ViewComponents
{
    public class SliderAreaViewComponent : ViewComponent
    {
        ISliderService _sliderService;
        public SliderAreaViewComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public IViewComponentResult Invoke()
        {
            //5
            var sliders = _sliderService.List();

            return View(sliders);
        }
    }
}
