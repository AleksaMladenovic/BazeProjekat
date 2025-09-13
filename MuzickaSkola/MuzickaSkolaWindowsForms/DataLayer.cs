using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MuzickaSkolaWindowsForms.Entiteti;
using NHibernate;
using System.Configuration;

namespace MuzickaSkolaWindowsForms;

public static class DataLayer
{
    private static ISessionFactory? factory;
    private static object lockObj;

    static DataLayer()
    {
        factory = null;
        lockObj = new object();
    }

    public static ISession? GetSession()
    {
        if (factory == null)
        {
            lock (lockObj)
            {
                if (factory == null)
                {
                    factory = CreateSessionFactory();
                }
            }
        }

        return factory?.OpenSession();
    }

    private static ISessionFactory? CreateSessionFactory()
    {
        try
        {
            string cs = ConfigurationManager.ConnectionStrings["OracleCS"].ConnectionString;
            var cfg = OracleManagedDataClientConfiguration.Oracle10
                        .ShowSql()
                        .ConnectionString(c => c.Is(cs));

            return Fluently.Configure()
                    .Database(cfg)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Kurs>())
                    .BuildSessionFactory();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.FormatExceptionMessage());
            return null;
        }
    }

   
}
