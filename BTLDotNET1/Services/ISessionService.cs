using BTLDotNET1.Models;

namespace BTLDotNET1.Services
{
    public interface ISessionService
    {

        void SaveSession(NhanVien user);
        NhanVien? GetSession();
        void ClearSession();
    }

    public class SessionService : ISessionService
    {
        private NhanVien? _currentUser;


        public void SaveSession(NhanVien user)
        {
            _currentUser = user;
        }

        public NhanVien? GetSession()
        {
            return _currentUser;
        }

        public void ClearSession()
        {
            _currentUser = null;
        }
    }
}
