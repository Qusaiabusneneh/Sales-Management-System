using Data_Access_Layer;
using System.Data;
namespace Busniess_Layer
{
    public class clsUsers
    {
        private enum enMode { enAdd, enUpdate }
        private enMode _Mode;
        public int? UserID { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public string UserRoll { set; get; }
        public string UserState { set; get; }
        public clsUsers()
        {
            UserID = null;
            Password = string.Empty;
            UserRoll = string.Empty;
            UserState = string.Empty;
            _Mode = enMode.enAdd;
        }
        public clsUsers(int? userID, string username, string password, string userRoll, string userState)
        {
            UserID = userID;
            Username = username;
            Password = password;
            UserRoll = userRoll;
            UserState = userState;
            _Mode = enMode.enUpdate;
        }
        public static DataTable GetAllUsers()
        {
            return clsUsersDataAccess.GetAllUsers();
        }
        private bool _AddNewUser()
        {
            this.UserID = clsUsersDataAccess.AddNewUser(this.Username, this.Password, this.UserRoll, this.UserState);
            return this.UserID != null;
        }
        private bool _UpdateUser()
        {
            return clsUsersDataAccess.UpdateUser(this.UserID, this.Username, this.Password, this.UserRoll, this.UserState);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAdd:
                    {
                        if (_AddNewUser())
                        {
                            _Mode = enMode.enUpdate;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.enUpdate:
                    return _UpdateUser();
            }
            return false;
        }
        public static clsUsers Find(int? UserID)
        {
            string Username = string.Empty, Password = string.Empty, UserRoll = string.Empty, UserState = string.Empty;
            bool isFound = clsUsersDataAccess.GetUserInfoByID(UserID, ref Username, ref Password, ref UserRoll, ref UserState);
            if (isFound)
                return new clsUsers(UserID, Username, Password, UserRoll, UserState);
            else
                return null;
        }
        public static clsUsers Find(string Username, string Password)
        {
            int? UserID = null;
            string UserRoll = string.Empty, UserState = string.Empty;
            bool isFound = clsUsersDataAccess.GetUserInfoByUsernameAndPassword(Username, Password, ref UserID, ref UserRoll, ref UserState);
            if (isFound)
                return new clsUsers(UserID, Username, Password, UserRoll, UserState);
            else
                return null;
        }
        public static clsUsers Find(string UserState)
        {
            int? UserID = null;
            string Username = string.Empty, Password = string.Empty, UserRoll = string.Empty;
            bool isFound = clsUsersDataAccess.GetUserInfoIfUserStateTrue(UserState, ref UserID, ref Username, ref Password, ref UserRoll);
            if (isFound)
                return new clsUsers(UserID, Username, Password, UserRoll, UserState);
            else
                return null;
        }
        public static bool DeleteUser(int? UserID)
        {
            return clsUsersDataAccess.DeleteUser(UserID);
        }
        public static int Count()
        {
            return clsUsersDataAccess.Count();
        }
    }
}
