namespace Membership.Contract
{
    using System.Runtime.Serialization;

    [DataContract]
    public class EmployeeDto : BaseDto
    {
        [DataMember]
        public UserDto User { get; set; }

        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string PasswordHash { get; set; }

        [DataMember]
        public string PrimaryPhone { get; set; }
        [DataMember]
        public string Department { get; set; }

        [DataMember]
        public string UserEmail
        {
            get
            {
                return User != null ? User.Email : string.Empty;
            }
            protected set { }
        }

        [DataMember]
        public string NewPasswordHash { get; set; }
    }
}