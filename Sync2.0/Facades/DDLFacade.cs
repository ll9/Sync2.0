using Sync2._0.Controllers;
using Sync2._0.Data;
using Sync2._0.Models;
using Sync2._0.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.Facades
{
    public class DDLFacade
    {
        private readonly ApplicationDbContext _efContext;
        private readonly DbTableRepository _dbTableRepository;
        private readonly ProjectTableChangeSetRepository _projectTableChangeSetRepository;
        private readonly ProjectTableRepository _projectTableRepository;

        public DDLFacade(
            ApplicationDbContext efContext,
            DbTableRepository dbTableRepository,
            ProjectTableChangeSetRepository projectTableChangeSetRepository,
            ProjectTableRepository projectTableRepository)
        {
            _efContext = efContext;
            _dbTableRepository = dbTableRepository;
            _projectTableChangeSetRepository = projectTableChangeSetRepository;
            _projectTableRepository = projectTableRepository;
        }

        internal void AddTable(ProjectTable projectTable)
        {
            _dbTableRepository.AddTable(projectTable.Name, projectTable.JsonDict.Values);
            _efContext.ProjectTables.Add(projectTable);

            _efContext.SaveChanges();
        }

        internal void AddTableWithChangeSet(string name, IEnumerable<Column> columns)
        {
            AddTable(new ProjectTable(name, columns));
            _efContext.ProjectTableChangeSets.Add(new ProjectTableChangeSet(name, columns));

            _efContext.SaveChanges();
        }

        internal void AddColumn(string tableName, string columnName, Type columnDataType)
        {
            _dbTableRepository.AddColumn(tableName, columnName, columnDataType);
            _projectTableChangeSetRepository.AddColumn(tableName, columnName, columnDataType);
            _projectTableRepository.AddColumn(tableName, columnName, columnDataType);
        }

        internal void DropColumn(string tableName, string columnName)
        {
            _dbTableRepository.DropColumn(tableName, columnName);
            _projectTableChangeSetRepository.DropColumn(tableName, columnName);
            _projectTableRepository.DropColumn(tableName, columnName);
        }
    }
}
