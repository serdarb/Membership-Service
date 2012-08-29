namespace Membership.Contract
{
    using System.Runtime.Serialization;
    using System.Collections.Generic;

    [DataContract]
    public class PointTableDto
    {
        [DataMember]
        public List<UserDto> TopList { get; set; }

        public int AskingUsersOrder { get; set; }
        public UserDto AskingUser { get; set; }
        public bool  IsUserInTop { get; set; }
    }
}