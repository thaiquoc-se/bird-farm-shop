using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IBirdRepository
    {
        List<Bird> GetAllBirds();

        List<Bird> GetBirdByName(string name);

        Bird GetBirdByID(string id);

        void AddNew(Bird bird); 

        void Update(Bird bird);

        void Delete(string id);
    }
}
