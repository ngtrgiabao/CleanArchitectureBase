namespace Core.Models.Location
{
    public class AddressModel
    {
        public List<ProvinceModel> Provinces { get; set; }
        public List<DistrictModel> Districts { get; set; }
        public List<WardModel> Wards { get; set; }
    }
}
