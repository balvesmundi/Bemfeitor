﻿using Domain.Aggregates.Entities;
using MundiPagg.Benfeitor.Domain.Aggregates.Repositories;
using MundiPagg.Benfeitor.Infrastructure.Data.Seedwork;

namespace MundiPagg.Benfeitor.Infrastructure.Data.Repositories
{

    public class PersonRepository : Repository<Person>, IPersonRepository
    {

        public PersonRepository(UnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
