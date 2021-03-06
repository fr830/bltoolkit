using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using BLToolkit.Data.DataProvider;
using NUnit.Framework;

using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace HowTo.DataAccess
{
	[TestFixture]
	public class CustomSqlQuery2
	{
		public abstract class TestAccessorBase<T> : /*[a]*/DataAccessor /*[/a]*/
			where T : TestAccessorBase<T>
		{
			private const int Sql = 0;
			private const int Access = 1;
			private const int Oracle = 2;
			private const int Fdp = 3;
			private const int SQLite = 4;

			private readonly string[] _msSqlProviderNames = new[]
			{
				ProviderName.MsSql,
				ProviderName.MsSql2000,
				ProviderName.MsSql2005,
				ProviderName.MsSql2008,
				ProviderName.MsSql2012
			};

			Dictionary<int, string> _sql = new Dictionary<int,string>();

			private string GetSql(string providerName, int provider, int queryId)
			{
				if (_msSqlProviderNames.Contains(providerName))
					providerName = "Sql";

				Stream stream = Assembly.GetCallingAssembly().GetManifestResourceStream(
					"HowTo.DataAccess.Sql." + providerName + ".xml");

				XmlDocument doc = new XmlDocument();

				doc.Load(stream);

				XmlNode node = doc.SelectSingleNode(string.Format("/sql/query[@id={0}]", queryId));

				return node != null? node.InnerText: null;

			}

			protected /*[a]*/override/*[/a]*/ string /*[a]*/PrepareSqlQuery/*[/a]*/(DbManager db, int queryID, int uniqueID, string sqlQuery)
			{
				int    provider     = Sql;
				string providerName = db.DataProvider.Name;

				switch (providerName)
				{
					case "MsSql2000":
					case "MsSql2005":
					case "MsSql2008":
					case "MsSql2012":
					case "Sql"      : provider = Sql; break;
					case "Access"   : provider = Access; break;
					case "Oracle"   : provider = Oracle; break;
					case "Fdp"      : provider = Fdp;    break;
					case "SQLite"   : provider = SQLite; break;
					default:
						throw new ApplicationException(
							string.Format("Unknown data provider '{0}'", providerName));
				}

				string text;
				int    key = provider * 1000000 + uniqueID;

				if (_sql.TryGetValue(key, out text))
					return text;

				_sql[key] = text = GetSql(providerName, provider, queryID) ?? GetSql("Sql", Sql, queryID);

				return text;
			}

			public static T CreateInstance()
			{
				return DataAccessor.CreateInstance<T>();
			}
		}

		public abstract class PersonAccessor : TestAccessorBase<PersonAccessor>
		{
			[SqlQuery(/*[a]*/ID = 1/*[/a]*/)]
			public abstract List<Person> SelectByLastName(string lastName);

			[SqlQuery(/*[a]*/ID = 2/*[/a]*/)]
			public abstract List<Person> SelectBy([Format] string fieldName, string value);

			[SqlQuery(/*[a]*/ID = 3/*[/a]*/)]
			public abstract List<Person> SelectByLastName(string lastName, [Format(0)] int top);

			[SqlQuery(/*[a]*/ID = 4/*[/a]*/)]
			public abstract List<Person> SelectID(int @id);
		}

		[Test]
		public void Test1()
		{
			PersonAccessor da = PersonAccessor.CreateInstance();

			List<Person> list = da.SelectByLastName("Testerson");

			Assert.AreNotEqual(0, list.Count);
		}

		[Test]
		public void Test2()
		{
			PersonAccessor da = PersonAccessor.CreateInstance();

			List<Person> list = da.SelectBy("FirstName", "John");

			Assert.AreNotEqual(0, list.Count);
		}

		[Test]
		public void Test3()
		{
			PersonAccessor da = PersonAccessor.CreateInstance();

			List<Person> list = da.SelectByLastName("Testerson", 1);

			Assert.AreNotEqual(0, list.Count);
		}

		[Test]
		public void Test4()
		{
			PersonAccessor da = PersonAccessor.CreateInstance();

			List<Person> list = da.SelectID(42);

			Assert.AreEqual(42, list[0].ID);
		}
	}
}
