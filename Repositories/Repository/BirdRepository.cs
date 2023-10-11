using BusinessObjects.Models;
using DataAccessObjects;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class BirdRepository : IBirdRepository
    {
        public void AddNew(Bird bird) => BirdDAO.Instance.AddNew(bird);
        

        public void Delete(string id) => BirdDAO.Instance.Delete(id);
        

        public List<Bird> GetAllBirds() => BirdDAO.Instance.GetAllBirds();
        

        public Bird GetBirdByID(string id) => BirdDAO.Instance.GetBirdByID(id);
        

        public List<Bird> GetBirdByName(string name) => BirdDAO.Instance.GetBirdByname(name);
        

        public void Update(Bird bird) => BirdDAO.Instance.Update(bird);
        
    }
}
