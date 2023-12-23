using Core.Models.Location; 
namespace Core.Models
{
    public class OptionsModel
    {
        public OptionsModel()
        {
            Address = new AddressModel();
        }
        public AddressModel Address { get; set; }

    }
}
