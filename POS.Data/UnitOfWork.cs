using POS.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUnitRepository unitRepository { get; }
        public UnitOfWork(IUnitRepository _unitRepository)
        {
            unitRepository = _unitRepository;
        }

    }
}
