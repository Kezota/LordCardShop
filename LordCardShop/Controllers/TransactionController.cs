using LordCardShop.Handlers;

namespace LordCardShop.Controllers
{
    public class TransactionController
    {
        public static (bool isTrue, string message) InsertCart(int userId)
        {
            try
            {
                TransactionHandler.CreateTransaction(userId);
                return (true, "Berhasil menambahkan ke keranjang");
            }
            catch (Exception)
            {
                return (false, "Gagal menambahkan ke keranjang");
            }
        }
        
    }
}