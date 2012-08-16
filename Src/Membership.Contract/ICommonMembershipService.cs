using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Membership.Contract
{
    [ServiceContract]
    public interface ICommonMembershipService
    {
        [OperationContract]
        List<CountryDto> GetCountries();

        [OperationContract]
        bool AddCountry(CountryDto country);

        [OperationContract]
        bool UpdateCountry(CountryDto country);

        [OperationContract]
        bool DeleteCountry(CountryDto country);
    }
}
