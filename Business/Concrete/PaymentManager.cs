using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        public IResult Payment()
        {
            var result = new Random().Next(5);
            if (result == 0)
            {
                return new ErrorResult(Messages.FailureMessage);
            }

            return new SuccessResult(Messages.PaymentSuccess);

        }
    }
}
