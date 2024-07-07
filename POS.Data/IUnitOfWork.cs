using POS.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public interface IUnitOfWork
    {
        IUnitRepository unitRepository { get; }
        IBrandRepository brandRepository { get; }
        IRegister registerRepository { get; }
    }
}
