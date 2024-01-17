using Day06.DbContext;
using Day06.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Repository
{
    internal class SupplierRepository : RepositoryBase<Supplier>
    {
        public SupplierRepository(AdoDbContext _adoDbContext, DapperDbContext dapperDbContext) : base(_adoDbContext, dapperDbContext)
        {
        }

        public override void Delete(dynamic id)
        {
            // check by id
            if (FindById((int)id) == null)
            {
                Console.WriteLine("Data tidak dapat ditemukan");
                return;
            }

            SqlCommandModel sqlCommandModel = new SqlCommandModel();
            sqlCommandModel.CommandText = "delete from Suppliers where SupplierID=@ID";
            sqlCommandModel.CommandParameters = new SqlCommandParameterModel[]
            {
                new SqlCommandParameterModel()
                {
                    ParameterName = "@ID",
                    DataType=DbType.Int32,
                    Value=(int)id
                }
            };

            //delete
            _dapperDbContext.ExecuteNonQuery(sqlCommandModel);
            //_adoDbContext.ExecuteNonQuery(sqlCommandModel);
        }

        public override IEnumerable<Supplier> FindAll()
        {
            SqlCommandModel sqlCommandModel = new SqlCommandModel() { CommandText = "select * from Suppliers" };
            IEnumerator<Supplier> dataset = _dapperDbContext.ExecuteReader<Supplier>(sqlCommandModel.CommandText);
            _adoDbContext.Dispose();

            // loop and do yield
            while (dataset.MoveNext())
            {
                yield return dataset.Current;
            }
        }

        public override IEnumerable<Supplier> FindById(dynamic id)
        {
            SqlCommandModel sqlCommandModel = new SqlCommandModel();
            sqlCommandModel.CommandText = "select SupplierID, CompanyName, ContactName, ContactTitle from Suppliers where SupplierId=@ID";
            sqlCommandModel.CommandParameters = new SqlCommandParameterModel[]
            {
                new SqlCommandParameterModel(){DataType=DbType.Int32,ParameterName="@ID",Value=(int)id},
            };
            var dataset = _dapperDbContext
                .ExecuteReader<Supplier>(sqlCommandModel);
            _dapperDbContext.Dispose();

            while (dataset.MoveNext())
            {
                yield return (Supplier)dataset.Current;
            }
            yield return (Supplier)dataset.Current;
        }

        public override void Save(Supplier entity)
        {
            // sql command
            SqlCommandModel sqlCommandModel = new SqlCommandModel();
            sqlCommandModel.CommandText = "insert into Suppliers (CompanyName, ContactName, ContactTitle)" +
                "values (@CompanyName, @ContactName, @ContactTitle)";
            sqlCommandModel.CommandParameters = new SqlCommandParameterModel[]
            {
                new SqlCommandParameterModel()
                {
                    ParameterName="@CompanyName",
                    DataType=DbType.String,
                    Value=entity.CompanyName!=null ? entity.CompanyName :""
                },
                new SqlCommandParameterModel()
                {
                    ParameterName="@ContactName",
                    DataType=DbType.String,
                    Value=entity.ContactName!=null ? entity.ContactName : ""
                },
                new SqlCommandParameterModel()
                {
                    ParameterName="@ContactTitle",
                    DataType=DbType.String,
                    Value=entity.ContactTitle!=null ? entity.ContactTitle : ""
                },
            };

            _dapperDbContext.ExecuteNonQuery(sqlCommandModel);
        }

        public override void Update(dynamic id, Supplier entity)
        {// check by id
            if (FindById((int)id) == null)
            {
                Console.WriteLine("Data tidak dapat ditemukan");
                return;
            }


            SqlCommandModel sqlCommandModel = new SqlCommandModel();
            sqlCommandModel.CommandText = "update Suppliers " +
                "set CompanyName=@CompanyName,ContactName=@ContactName,ContactTitle=@ContactTitle " +
                "where SupplierID=@ID";
            sqlCommandModel.CommandParameters = new SqlCommandParameterModel[]
            {
                new SqlCommandParameterModel()
                {
                    ParameterName="@CompanyName",
                    DataType=DbType.String,
                    Value=entity.CompanyName!=null ? entity.CompanyName :""
                },
                new SqlCommandParameterModel()
                {
                    ParameterName="@ContactName",
                    DataType=DbType.String,
                    Value=entity.ContactName!=null ? entity.ContactName : ""
                },
                new SqlCommandParameterModel()
                {
                    ParameterName="@ContactTitle",
                    DataType=DbType.String,
                    Value=entity.ContactTitle!=null ? entity.ContactTitle : ""
                },
                new SqlCommandParameterModel()
                {
                    ParameterName="@ID",
                    DataType=DbType.Int32,
                    Value=(int)id
                }
            };

            // update
            _dapperDbContext.ExecuteNonQuery(sqlCommandModel);
        }
    }
}
