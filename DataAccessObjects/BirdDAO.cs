using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class BirdDAO
    {
        private static BirdDAO instance = null!;

        private static readonly object instanceLock = new object();

        private readonly BirdFarmContext _context;

        public BirdDAO()
        {
            _context = new BirdFarmContext();
        }

        public static BirdDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BirdDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Bird> GetAllBirds()
        {
            try
            {
                return _context.Birds.ToList();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Bird GetBirdByID(string id)
        {
            try
            {
                return _context.Birds.Where(b => b.BirdId.Equals(id)).FirstOrDefault()!;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Bird> GetBirdByname(string name)
        {
            try
            {
                return GetAllBirds().Where(b => b.BirdName.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void AddNew(Bird bird)
        {
            try
            {
                if(bird != null)
                {
                    _context.Birds.Add(bird);
                    _context.SaveChanges();
                }

                throw new Exception("Can Not Add");
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Bird bird)
        {
            try
            {
                var _bird = GetBirdByID(bird.BirdId);
                if (_bird != null)
                {
                    _bird.BirdName = bird.BirdName;
                    _bird.UserId = bird.UserId;
                    _bird.Estimation = bird.Estimation;
                    _bird.WeightofBirds = bird.WeightofBirds;
                    _bird.Gender = bird.Gender;
                    _bird.BirdDescription = bird.BirdDescription;
                    _bird.BirdStatus = bird.BirdStatus;
                    _context.Update(bird);
                    _context.SaveChanges();
                }
                throw new Exception("Bird not existed");

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(string id)
        {
            try
            {
                var _bird = GetBirdByID(id);
                if (_bird != null)
                {
                    _context.Remove(_bird);
                    _context.SaveChanges();
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
