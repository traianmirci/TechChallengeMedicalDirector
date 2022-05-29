namespace MedicalDirector.API.DTOs.Users
{
    public class AddressDTO
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public GeoDTO geo { get; set; }
    }

    public class CompanyDTO
    {
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
    }

    public class GeoDTO
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class PostDTO
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }

    public class UserDetailedDTO
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? username { get; set; }
        public string? email { get; set; }
        public AddressDTO? address { get; set; }
        public string? phone { get; set; }
        public string? website { get; set; }
        public CompanyDTO? company { get; set; }

        public IEnumerable<PostDTO>? posts { get; set; }
    }
}