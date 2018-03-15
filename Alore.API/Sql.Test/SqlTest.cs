namespace Alore.API.Sql.Test
{
    using System.Threading.Tasks;

    public class SqlTest
    {
        public async void TestSql()
        {
            TestSource testSource = new TestSource();
            TestModel testModel = await testSource.TestPlayerById(4);
        }
    }

    internal class TestSource : DataSource<TestModel>
    {
        public async Task<TestModel> TestPlayerById(int id) =>
            await GetEntityByValue(id, "id");
    }

    [AloreTable("players_test")]
    internal class TestModel
    {
        [AloreColumn("id")]
        public int Id { get; set; }

        [AloreColumn("username")]
        public string Username { get; set; }
    }
}
