namespace BackendAspNet.utils;

public static class HashPasswordUtil
{
    public static string Hash(string password)
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt(DotNetEnv.Env.GetInt("BCRYPT_SAL"));
        var hash = BCrypt.Net.BCrypt.HashPassword(password, salt);
        
        return hash;
    }

    public static bool Verify(string password, string hashPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashPassword);
    }
}