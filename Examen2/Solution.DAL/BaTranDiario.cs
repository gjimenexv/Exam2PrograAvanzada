using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class BaTranDiario : ICRUD<data.BaTranDiario>
    {
        private Repository<data.BaTranDiario> _repository = null;
        public BaTranDiario(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.BaTranDiario>(solutionDBContext);
        }

        public void Delete(data.BaTranDiario t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.BaTranDiario> GetAll()
        {
            return _repository.GetAll();
        }

        public data.BaTranDiario GetOneById(int id)
        {
            return _repository.GetOnebyId(id);
        }
        public data.BaTranDiario GetOneById(string id)
        {
            return _repository.GetOnebyId(id);
        }

        public void Insert(data.BaTranDiario t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.BaTranDiario t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
