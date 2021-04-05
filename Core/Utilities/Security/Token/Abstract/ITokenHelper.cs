using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Security.Token.Concrete;

namespace Core.Utilities.Security.Token.Abstract
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
