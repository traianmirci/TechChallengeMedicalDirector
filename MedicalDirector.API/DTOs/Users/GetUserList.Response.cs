namespace MedicalDirector.API.DTOs.Users

{
    public class UserListDTO
    {
        IEnumerable<UserInfoDTO>? users;
    }
    public class UserInfoDTO
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? username { get; set; }
        public int? postCount { get; set; }
    }
}
