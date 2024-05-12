namespace S.K.Sabz.Application.Services.Users.Queries.GetAllUsers
{
	public class UserDto
	{
        public long Id { get; set; }
        public string? FirstName { get; set; } = string.Empty;
		public string? LastName { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public bool IsActive { get; set; }
        public DateTime InsertTime { get; set; }
        public string Roles { get; set; }
    }
}
