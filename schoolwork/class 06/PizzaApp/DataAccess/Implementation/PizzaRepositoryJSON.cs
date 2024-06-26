﻿using DataAccess.Interface;
using DataAccess.Implementation;
using DomainModels;

namespace DataAccess.Implementation
{
    public class PizzaRepositoryJSON : RepositoryJSON<Pizza>, IPizzaRepository
    {
        public List<Pizza> SearchByName(string name)
        {
            var pizzas = ReadContent();
            return pizzas.Where(x => x.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }
    }
}
