using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using ISEN.DotNet.Library.Models;

namespace ISEN.DotNet.Library.Repositories.Interfaces
{
    public interface IOwnerRepository : IBaseRepository<Owner>
    {
        IEnumerable<Owner> GetAll(int id);
    }
}