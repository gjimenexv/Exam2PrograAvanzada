using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;
using Solution.DO.Interfaces;
using Solution.DAL.EF;
using Solution.DAL;

namespace Solution.BS
{
    public class BaTranDiario : ICRUD<data.BaTranDiario>
    {
        private SolutionDBContext _solutionDBContext = null;
        public BaTranDiario(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }
        public void Delete(data.BaTranDiario t)
        {
            new Solution.DAL.BaTranDiario(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.BaTranDiario> GetAll()
        {
            return new Solution.DAL.BaTranDiario(_solutionDBContext).GetAll();
        }

        public data.BaTranDiario GetOneById(int id)
        {
            return new Solution.DAL.BaTranDiario(_solutionDBContext).GetOneById(id);
        }

        public data.BaTranDiario GetOneById(string id)
        {
            return new Solution.DAL.BaTranDiario(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.BaTranDiario t)
        {
            t.CodEmpresa = null;
            new Solution.DAL.BaTranDiario(_solutionDBContext).Insert(t);
        }

        public void Updated(data.BaTranDiario t)
        {
            new Solution.DAL.BaTranDiario(_solutionDBContext).Updated(t);
        }
    }
}
