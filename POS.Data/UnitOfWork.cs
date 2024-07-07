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

        public IBrandRepository brandRepository { get; }

        public IRegister registerRepository { get; }

        public UnitOfWork(IUnitRepository _unitRepository, IBrandRepository _brandRepository, IRegister _registerRepository)
        {
            unitRepository = _unitRepository;
            brandRepository = _brandRepository;
            registerRepository = _registerRepository;
        }

    }
}
