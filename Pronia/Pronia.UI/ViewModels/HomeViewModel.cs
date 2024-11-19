using Pronia.Domain.Entities;

namespace Pronia.UI.ViewModels;

public class HomeViewModel
{
    public List<Product>? Products { get; set; }
    public List<Slider>? Sliders { get; set; }
    public List<Testimonial>? Testimonials { get; set; }
}
