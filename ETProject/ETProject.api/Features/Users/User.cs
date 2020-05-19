namespace ETProject.api.Features.Users
{
    public class User
    {
        public User()
        {
            
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string UserId { get; private set; }
        public byte[] PassHash { get; private set; }
        public byte[] PassSalt { get; private set; }

        public sealed class builder{
            private User users;
            
            public builder(string name, string userId, byte[] passHash, byte[] passSalt){
                users = new User(){
                    Name = name,
                    UserId = userId,
                    PassHash = passHash,
                    PassSalt = passSalt
                };

            }
            public User build(){
                return users;
            }

        }

        public void SetPassByte(byte[] passHash, byte[] passSalt){
            this.PassHash = passHash;
            this.PassSalt = passSalt;
        }

    }
}