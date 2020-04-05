using WorldBuilder.Data;

namespace WorldBuilder.Services
{
    public class PlayerCharacterService
    {
        private readonly ApplicationDbContext _db;
        private readonly string _userID;
        public PlayerCharacterService(string userID)
        {
            _db = new ApplicationDbContext();
            _userID = userID;
        }


    }
}
