using System;

namespace Nemovitosti.DataAccessLayer
{
    public static class DalInitializer
    {
        /// <summary>
        /// Provede inicializaci Data Access Layer.
        /// 1) Nastaví mapování Dapperu tak, že typu .Net DateTime bude odpovídat typ Sql Serveru DateTime2 (nikoliv zastaralý DateTime)
        /// 2) Nastaví Slapper.AutoMapper tak, že za jendoznačný identifikátor instance budou považovány i atributy, které se jmenují Id+JmenoTridy
        /// </summary>
        //XXX prejmenovat ID atributy trid tak, aby byly jednotne a vsechny "Id", nikoliv Id<JmenoTridy>, coz nezni moc objektove (ale lip se to mapovalo z DB)
        public static void Init()
        {
            Dapper.SqlMapper.AddTypeMap(typeof(DateTime), System.Data.DbType.DateTime2);
            //Slapper.AutoMapper.Configuration.IdentifierConventions.Add(type => "Id" + type.Name);
        }
    }
}
