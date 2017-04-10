using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DomainModel.Interfaces
{
    public interface IPersistenceContext
    {
        bool InitializeContext(IConfigurationRoot configuration);
        IStudentsRepository GetStudentsRepository();
        IGroupsRepository GetGroupsRepository();
        IGradesRepository GetGradesRepository();
        bool SaveAll();
        void ReleaseContext();
    }
}
