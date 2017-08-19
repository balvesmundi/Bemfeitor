using MundiPagg.Benfeitor.Domain.Aggregates.CustomerAgg.Repositories;
using MundiPagg.Benfeitor.Infrastructure.Data.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.Entities;

namespace MundiPagg.Benfeitor.Infrastructure.Data.Repositories {

    public class PersonRepository : Repository<Person>, IPersonRepository {

        public PersonRepository(UnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
