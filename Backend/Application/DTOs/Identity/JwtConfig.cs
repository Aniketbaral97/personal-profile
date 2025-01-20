namespace Application.DTOs.Identity;

public class JwtConfig{
        public string Key{get;init;}
        public string Issuer{get;init;}
        public int ExpiresInHour {get;init;}

        public JwtConfig(string key, string issuer, int expiresInHour){
            Key =key;
            Issuer =issuer;
            ExpiresInHour =expiresInHour;
        }
    }
