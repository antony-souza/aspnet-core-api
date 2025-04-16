namespace BackendAspNet.utils;

public class HashPasswordUtil
{
    public static string Hash(string password)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt(DotNetEnv.Env.GetInt("BCRYPT_SAL"));
        string hash = BCrypt.Net.BCrypt.HashPassword(password, salt);
        
        return hash;
    }

    public static bool Verify(string password, string hashPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashPassword);
    }
}