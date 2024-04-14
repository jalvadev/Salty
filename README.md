# Salty

>[!CAUTION]
>This is a library made for learning purposes and therefore is not intended for production. If you decide to use it for your product it is at your own risk.

Salty is a library for handling passwords using hash + salt. This library is responsible for the following:

- Generate a random salt.
- Hash a password (or any other text, but this library is intended for passwords).
- Given a password, generate a salt hash for this password.
- Given a hash, a password, a salt, and a hashing method, verify that the given hash corresponds to the expected result of hashing the password with the salt.

Salty is designed to handle all the work with its password hasher with salt. But if you want to use the salt generator or the hasher separately, you are free to do so.

## PasswordManager

Finally, the master class of this library, the PasswordManager. This class is designed for you to forget about everything and be able to manage your application's passwords easily. It has these two functions:

1. Generate hash for salted passwords: You only need to pass the hasher you want to use and the password you want to hash. The function will take care of salting the password before hashing it and return both hash and salt.
```
PasswordResponse passwordResult = PasswordManager.GeneratePasswordHash(new SHA256Hasher(), insertedPassword);
userHash = passwordResult.HashedPassword;
userSalt = passwordResult.Salt;
```
2. Verify if a hash belongs to a salted password. Here, you'll need to pass, on one side, the hasher to be used, the password entered by the user, and the corresponding salt for the presumed user. On the other side, you'll need to pass the hash to compare with the resulting hash.
```
bool result = PasswordManager.ChekPasswordHash(new SHA512Hasher(), insertedPassword, userSalt, userHash);
```

## SaltGenerator

You can use the salt generator by obtaining an instance of it through the GetInstance() method. Once you get the instance of this class you can invoke its single function GenerateSatlString().

```
var generator = SaltGenerator.GetInstance();

string salt = generator.GenerateSaltString();
```

The salt returned by this function will always have a length of 11 characters, as I am basing it on the ideal length explained by Okta in [this post](https://auth0.com/blog/adding-salt-to-hashing-a-better-way-to-store-passwords/).

## HashContext

The HashContext class is the other part of the library, responsible for hashing plain text using SHA256 and SHA512. You can obtain an instance of the HashContext class by using its constructor, which takes a single parameter, an instance of one of the two available Hashers (SHA256Hasher and SHA512Hasher).

```
HashContext hashContextSHA256 = new HashContext(new SHA256Hasher());

HashContext hashContextSHA512 = new HashContext(new SHA512Hasher());
```

You can change the hasher at runtime by using its SetHasher(IHasher hasher) method, to which you must pass the hasher you want to use.

```
hashContextSHA256.SetHasher(new SHA512Hasher());
```

The functions that can be used with the hashContext are:

1. To generate a hash from plain text 
```
hashContextSHA512.GenerateHash(stringToHash);
```
2. Verify that a hashed string using the current method of the hashContext is equal to a hash we pass to it.
```
hashContextSHA512.CheckHash(stringToHash, hash);
```

