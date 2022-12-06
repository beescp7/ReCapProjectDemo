using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Absract
{
    public interface IRentalsServise
    {
        IResult Add(Rental rentals);
        IResult Delete(Rental rentals);
        IResult Update(Rental rentals);
        IDataResult<List<Rental>> GetAll();
    }
}
