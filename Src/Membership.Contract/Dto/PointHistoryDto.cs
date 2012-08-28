using System.Runtime.Serialization;
namespace Membership.Contract.Dto
{
   [DataContract]
   public class PointHistoryDto :BaseDto
    {
       [DataMember]
        public UserDto User { get; set; }

        //public  PointType { get; set; }
        //public int? PointTypeId { get; set; }

        //public int Point { get; set; }
        //public string Expression { get; set; }

    }
}
