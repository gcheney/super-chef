using SuperChef.Core.Services;
using System;
using System.Collections.Generic;
using SuperChef.Core.Entities;
using System.Linq.Expressions;
using SuperChef.Core.Repositories;

namespace SuperChef.Services
{
    public class ChefService : IChefService
    {
        private readonly IChefRepository _chefRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ChefService(IChefRepository chefRepository,
            IUnitOfWork unitOfWork)
        {
            _chefRepository = chefRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Chef> GetAllChefs()
        {
            var chefs = _chefRepository.GetAll();
            return chefs;
        }

        public IEnumerable<Chef> FindChefs(Expression<Func<Chef, bool>> filter)
        {
            var chefs = _chefRepository.GetMany(filter);
            return chefs;
        }

        public Chef GetChef(int id)
        {
            var chef = _chefRepository.GetById(id);
            return chef;
        }

        public void CreateChef(string userId, string userName)
        {
            Chef chefToCreate = new Chef
            {
                Name = userName,
                UserId = userId
            };

            CreateChef(chefToCreate);
        }

        private void CreateChef(Chef chef)
        {
            _chefRepository.Add(chef);
            SaveChef();
        }

        public void RemoveChef(int id)
        {
            _chefRepository.Delete(id);
        }

        public void SaveChef()
        {
            _unitOfWork.Commit();
        }
    }
}
