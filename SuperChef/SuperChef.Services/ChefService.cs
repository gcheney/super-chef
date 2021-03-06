﻿using SuperChef.Core.Services;
using System;
using System.Collections.Generic;
using SuperChef.Core.Entities;
using System.Linq.Expressions;
using SuperChef.Core.Repositories;
using SuperChef.Core.Infrastructure;

namespace SuperChef.Services
{
    public class ChefService : IChefService
    {
        private readonly IChefRepository _chefRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ChefService(IChefRepository chefRepository,
            IUnitOfWork unitOfWork)
        {
            if (chefRepository == null)
            {
                throw new ArgumentNullException("chefRepository");
            }
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

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

        public Chef GetChefByUserId(string userId)
        {
            var chef = _chefRepository.FindByUserId(userId);
            return chef;
        }

        public Chef GetChefByUserName(string userName)
        {
            var chef = _chefRepository.FindByName(userName);
            return chef;
        }

        public void CreateChef(string userId, string userName)
        {
            Chef chefToCreate = new Chef
            {
                UserName = userName,
                UserId = userId
            };

            CreateChef(chefToCreate);
        }

        private void CreateChef(Chef chef)
        {
            _chefRepository.Add(chef);
            _unitOfWork.Commit();
        }

        public void EditChef(Chef chef)
        {
            _chefRepository.Update(chef);
            _unitOfWork.Commit();
        }

        public void RemoveChef(int id)
        {
            _chefRepository.Delete(id);
        }
    }
}
