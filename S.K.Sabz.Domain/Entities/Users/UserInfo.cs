using S.K.Sabz.Domain.Entities.Commons;
using S.K.Sabz.Domain.Entities.Users;
using System.Runtime.InteropServices;


namespace S.K.Sabz.Domain.Entities.Users
{
	public class UserInfo : BaseEntity
	{
        public int CodeMelli { get; set; }
		public string FatherName { get; set; } = string.Empty;
		public int Age { get; set; }
        public DateTime BirthDate { get; set; }
		public DateTime MarriageDate { get; set; }
		public Skintone Skintone  { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public BloodType Bloodtype { get; set; }
		public MaritalStatus MaritalStatus { get; set; }
        public int? NumberOfChildren { get; set; }
        public long? HomePhone { get; set; }
		public string City { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public long? PostalCode { get; set; }
		public GetToKnow GetToKnow { get; set; }
		public string? IntroducerName { get; set; } = string.Empty;
		public string? FieldOfStudy { get; set; } = string.Empty;
		public string Job { get; set; } = string.Empty;
		public string? Email { get; set; } = string.Empty;
		public string? ProfilePictureUrl { get; set; } = string.Empty;
		public Gender Gender { get; set; }

		// Foreign key for the user
		public long UserId { get; set; }
		public User User { get; set; } // Navigation property for the user
	}
}