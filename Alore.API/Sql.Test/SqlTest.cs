﻿namespace Alore.API.Sql.Test
{
    using System.Threading.Tasks;

    public class SqlTest
    {
        public async Task<TestModel> TestSql()
        {
            TestDao testDao = new TestDao();
            return await testDao.GetModelById(2);
        }
    }

    public class TestDao : AloreDao
    {
        public async Task<TestModel> GetModelById(int id)
        {
            TestModel testModel = null;
            await CreateTransaction(async transaction =>
            {
                await Select(transaction, async reader =>
                {
                    if (await reader.ReadAsync())
                    {
                        testModel = new TestModel();
                        testModel.SetPropertyValues(reader);
                    }
                }, "SELECT * FROM players_test WHERE id = @0", id);
            });

            return testModel;
        }
    }

    public class TestModel : AloreModel
    {
        [AloreColumn("username")]
        public string Username { get; set; }
    }
}
