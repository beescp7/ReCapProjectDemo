using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Absract
{
    public interface ICustomersServise
    {
        IResult Add(Customer customers);
        IResult Delete(Customer customers);
        IResult Update(Customer customers);
        IDataResult<List<Customer>> GetAll();
    }
}
