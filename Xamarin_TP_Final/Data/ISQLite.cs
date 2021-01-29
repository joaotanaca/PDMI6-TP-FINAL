using SQLite;

namespace Xamarin_TP_Final.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConexao();
    }
}
